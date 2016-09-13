using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace kcptun_gui.Controller.Relay
{
    public class UDPPipe
    {
        private const int EXPIRE_MILLISECONDS = 30000;

        private IRelay _relay;
        private EndPoint _localEP;
        private EndPoint _remoteEP;

        private Hashtable _handlers = Hashtable.Synchronized(new Hashtable());

        private System.Timers.Timer _timer = new System.Timers.Timer(10000);

        public UDPPipe(IRelay relay, EndPoint localEP, EndPoint remoteEP)
        {
            _relay = relay;
            _localEP = localEP;
            _remoteEP = remoteEP;
            _timer.AutoReset = true;
            _timer.Enabled = true;
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        ~UDPPipe()
        {
            _timer.Stop();
            _timer = null;
            foreach(Handler h in _handlers.Values)
                h.Close(false);
            _handlers.Clear();
            _handlers = null;
        }

        public bool CreatePipe(byte[] firstPacket, int length, Socket fromSocket, EndPoint fromEP)
        {
            Handler handler = getHandler(fromEP, fromSocket);
            handler.Handle(firstPacket, length);
            return true;
        }

        private Handler getHandler(EndPoint fromEP, Socket fromSocket)
        {
            string key = fromEP.ToString();
            Hashtable handlers = _handlers;
            lock (handlers)
            {
                if (handlers.ContainsKey(key))
                {
                    Logging.Debug($"reuse udp handler for {key}");
                    return (Handler)handlers[key];
                }
                Handler handler = new Handler(_relay);
                handlers.Add(key, handler);
                handler._local = fromSocket;
                handler._localEP = fromEP;
                handler._remoteEP = _remoteEP;
                handler.OnClose += handler_OnClose;
                handler.Start();
                Logging.Debug($"create udp handler for {key}");
                return handler;
            }
        }

        private void handler_OnClose(object sender, EventArgs e)
        {
            Handler handler = (Handler)sender;
            string key = handler._localEP.ToString();
            Hashtable handlers = _handlers;
            lock (handlers)
            {
                if (handlers.ContainsKey(key))
                {
                    Logging.Debug($"remove udp handler {key}");
                    handlers.Remove(key);
                }
            }
        }

        private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                _timer.Stop();
                Hashtable handlers = _handlers;
                List<Handler> keys = new List<Handler>(handlers.Count);
                lock (handlers)
                {
                    foreach (string key in handlers.Keys)
                    {
                        Handler handler = (Handler)handlers[key];
                        if (handler.IsExpire())
                        {
                            keys.Add(handler);
                        }
                    }
                    foreach (Handler handler in keys)
                    {
                        Logging.Debug($"remove expired udp handler {handler._remote.LocalEndPoint.ToString()}");
                        string key = handler._localEP.ToString();
                        handler.Close(false);
                        handlers.Remove(key);
                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
            finally
            {
                _timer.Start();
            }
        }

        private class Handler
        {
            public event EventHandler OnClose;

            private DateTime _expires;

            public Socket _local;
            private IRelay _relay;
            public EndPoint _localEP;
            public EndPoint _remoteEP;
            public Socket _remote;

            private bool _closed = false;
            public const int RecvSize = 16384;
            // remote receive buffer
            private byte[] remoteRecvBuffer = new byte[RecvSize];

            private LinkedList<byte[]> _packages = new LinkedList<byte[]>();
            private bool _connected = false;
            private bool _sending = false;

            public Handler(IRelay relay)
            {
                _relay = relay;
            }

            public bool IsExpire()
            {
                lock(this)
                {
                    return _expires <= DateTime.Now;
                }
            }

            public void Start()
            {
                try
                {
                    _remote = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                    _remote.SetSocketOption(SocketOptionLevel.Udp, SocketOptionName.NoDelay, true);
                    _remote.BeginConnect(_remoteEP, new AsyncCallback(remoteConnectCallback), null);
                    resetExpireTime();
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            public void Handle(byte[] buffer, int length)
            {
                if (_closed) return;
                try
                {
                    if (length > 0)
                    {
                        lock (_packages)
                        {
                            byte[] bytes = new byte[length];
                            Buffer.BlockCopy(buffer, 0, bytes, 0, length);
                            _packages.AddLast(bytes);
                        }
                        StartSend();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void remoteConnectCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    _remote.EndConnect(ar);
                    lock (_packages)
                        _connected = true;
                    StartPipe();
                    StartSend();
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void StartPipe()
            {
                if (_closed) return;
                try
                {
                    _remote.BeginReceive(remoteRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(remoteReceiveCallback), null);
                    resetExpireTime();
                    StartSend();
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void StartSend()
            {
                if (_closed) return;
                try
                {
                    lock (_packages)
                    {
                        if (_sending || !_connected)
                            return;
                        if (_packages.Count > 0)
                        {
                            _sending = true;
                            byte[] bytes = _packages.First.Value;
                            _packages.RemoveFirst();
                            _relay.onOutbound(bytes.Length);
                            Logging.Debug($"send {bytes.Length} bytes to {_remoteEP}");
                            _remote.BeginSend(bytes, 0, bytes.Length, 0, new AsyncCallback(remoteSendCallback), null);
                        }
                    }
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void remoteSendCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    _remote.EndSend(ar);
                    lock (_packages)
                        _sending = false;
                    StartSend();
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void remoteReceiveCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    int bytesRead = _remote.EndReceive(ar);
                    resetExpireTime();
                    Logging.Debug($"recv {bytesRead} bytes from {_remoteEP}");
                    if (bytesRead > 0)
                    {
                        _relay.onInbound(bytesRead);
                        Logging.Debug($"send {bytesRead} bytes to {_localEP}");
                        _local.BeginSendTo(remoteRecvBuffer, 0, bytesRead, 0, _localEP, new AsyncCallback(localSendCallback), null);
                    }
                    else
                    {
                        this.Close();
                    }
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void localSendCallback(IAsyncResult ar)
            {
                if (_closed) return;
                try
                {
                    _local.EndSendTo(ar);
                    _remote.BeginReceive(remoteRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(remoteReceiveCallback), null);
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void resetExpireTime()
            {
                lock (this)
                {
                    _expires = DateTime.Now.AddMilliseconds(EXPIRE_MILLISECONDS);
                }
            }

            public void Close(bool reportClose = true)
            {
                if (_closed) return;
                _closed = true;
                if (_remote != null)
                {
                    try
                    {
                        Logging.Debug($"close remote udp socket");
                        _remote.Shutdown(SocketShutdown.Both);
                        _remote.Close();
                        _remote = null;
                        remoteRecvBuffer = null;
                        _packages.Clear();
                        _packages = null;
                    }
                    catch (SocketException e)
                    {
                        Logging.LogUsefulException(e);
                    }
                }
                if (reportClose && OnClose != null)
                {
                    OnClose(this, new EventArgs());
                    OnClose = null;
                }
            }
        }
    }
}
