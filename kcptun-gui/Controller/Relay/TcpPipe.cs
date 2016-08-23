using System;
using System.Net;
using System.Net.Sockets;

namespace kcptun_gui.Controller.Relay
{
    public class TCPPipe
    {
        private IRelay _relay;
        private EndPoint _localEP;
        private EndPoint _remoteEP;

        public TCPPipe(IRelay relay, EndPoint localEP, EndPoint remoteEP)
        {
            _relay = relay;
            _localEP = localEP;
            _remoteEP = remoteEP;
        }

        public bool CreatePipe(Socket socket)
        {
            new Handler(_relay, _localEP, _remoteEP).Start(socket);
            return true;
        }

        class Handler
        {
            private IRelay _relay;
            private EndPoint _localEP;
            private EndPoint _remoteEP;

            private Socket _local;
            private Socket _remote;
            private bool _closed = false;
            private bool _localShutdown = false;
            private bool _remoteShutdown = false;
            public const int RecvSize = 16384;
            // remote receive buffer
            private byte[] remoteRecvBuffer = new byte[RecvSize];
            // connection receive buffer
            private byte[] connetionRecvBuffer = new byte[RecvSize];

            public Handler(IRelay relay, EndPoint localEP, EndPoint remoteEP)
            {
                _relay = relay;
                _localEP = localEP;
                _remoteEP = remoteEP;
            }

            public void Start(Socket socket)
            {
                this._local = socket;
                try
                {
                    _remote = new Socket(_remoteEP.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                    _remote.SetSocketOption(SocketOptionLevel.Tcp, SocketOptionName.NoDelay, true);

                    // Connect to the remote endpoint.
                    _remote.BeginConnect(_remoteEP, new AsyncCallback(ConnectCallback), null);
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void ConnectCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _remote.EndConnect(ar);
                    StartPipe();
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void StartPipe()
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _remote.BeginReceive(remoteRecvBuffer, 0, RecvSize, 0, new AsyncCallback(PipeRemoteReceiveCallback), null);
                    _local.BeginReceive(connetionRecvBuffer, 0, RecvSize, 0, new AsyncCallback(PipeConnectionReceiveCallback), null);
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void PipeRemoteReceiveCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    int bytesRead = _remote.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        _relay.onInbound(bytesRead);
                        _local.BeginSend(remoteRecvBuffer, 0, bytesRead, 0, new AsyncCallback(PipeConnectionSendCallback), null);
                    }
                    else
                    {
                        //Console.WriteLine("bytesRead: " + bytesRead.ToString());
                        _remote.Shutdown(SocketShutdown.Send);
                        _remoteShutdown = true;
                        CheckClose();
                    }
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void PipeConnectionReceiveCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    int bytesRead = _local.EndReceive(ar);

                    if (bytesRead > 0)
                    {
                        _relay.onOutbound(bytesRead);
                        _remote.BeginSend(connetionRecvBuffer, 0, bytesRead, 0, new AsyncCallback(PipeRemoteSendCallback), null);
                    }
                    else
                    {
                        _local.Shutdown(SocketShutdown.Send);
                        _localShutdown = true;
                        CheckClose();
                    }
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void PipeRemoteSendCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _remote.EndSend(ar);
                    _local.BeginReceive(this.connetionRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(PipeConnectionReceiveCallback), null);
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void PipeConnectionSendCallback(IAsyncResult ar)
            {
                if (_closed)
                {
                    return;
                }
                try
                {
                    _local.EndSend(ar);
                    _remote.BeginReceive(this.remoteRecvBuffer, 0, RecvSize, 0,
                        new AsyncCallback(PipeRemoteReceiveCallback), null);
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                    this.Close();
                }
            }

            private void CheckClose()
            {
                if (_localShutdown && _remoteShutdown)
                {
                    this.Close();
                }
            }

            public void Close()
            {
                lock (this)
                {
                    if (_closed)
                    {
                        return;
                    }
                    _closed = true;
                }
                if (_local != null)
                {
                    try
                    {
                        _local.Shutdown(SocketShutdown.Both);
                        _local.Close();
                        _local = null;
                        connetionRecvBuffer = null;
                    }
                    catch (Exception e)
                    {
                        Logging.LogUsefulException(e);
                    }
                }
                if (_remote != null)
                {
                    try
                    {
                        _remote.Shutdown(SocketShutdown.Both);
                        _remote.Close();
                        _remote = null;
                        remoteRecvBuffer = null;
                    }
                    catch (SocketException e)
                    {
                        Logging.LogUsefulException(e);
                    }
                }
            }
        }
    }
}
