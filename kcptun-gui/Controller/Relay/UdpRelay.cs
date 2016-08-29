using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

using kcptun_gui.Controller.Relay;
using System.Threading;

namespace kcptun_gui.Controller
{
    public class UDPRelay : IRelay
    {
        public class State
        {
            public byte[] buffer;
            public EndPoint remoteEP;

            public State()
            {
                buffer = new byte[4096];
                remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
            }
        }

        private Socket _local;
        private UDPPipe _pipe;
        private State state = new State();

        private MainController _controller;
        private EndPoint _localEP;
        private EndPoint _remoteEP;

        public event EventHandler<RelayEventArgs> Inbound;
        public event EventHandler<RelayEventArgs> Outbound;

        public UDPRelay(MainController controller, EndPoint localEP, EndPoint remoteEP)
        {
            _controller = controller;
            _localEP = localEP;
            _remoteEP = remoteEP;
            this._pipe = new UDPPipe(this, localEP, remoteEP);
        }

        public void Start()
        {
            try
            {
                // Create a TCP/IP socket.
                _local = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _local.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                // Bind the socket to the local endpoint and listen for incoming connections.
                _local.Bind(_localEP);

                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("UDPRelay listen on " + _localEP.ToString());
                localStartReceive();
            }
            catch (SocketException e)
            {
                Logging.LogUsefulException(e);
                Stop();
            }
        }

        public void Stop()
        {
            if (_local != null)
            {
                try
                {
                    _local.Shutdown(SocketShutdown.Both);
                    _local.Close();
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                }
                _local = null;
            }
        }

        public void onInbound(long n)
        {
            Inbound?.Invoke(this, new Controller.RelayEventArgs(n));
        }

        public void onOutbound(long n)
        {
            Outbound?.Invoke(this, new Controller.RelayEventArgs(n));
        }

        private void Restart()
        {
            Console.WriteLine("Restart UDP server");
            if (_local != null)
            {
                try
                {
                    _local.Shutdown(SocketShutdown.Both);
                    _local.Close();
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                }
                _local = null;
            }

            try
            {
                // Create a TCP/IP socket.
                _local = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _local.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                // Bind the socket to the local endpoint and listen for incoming connections.
                _local.Bind(_localEP);

                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("Restart UDPRelay on " + _localEP.ToString());
                localStartReceive();
            }
            catch (SocketException e)
            {
                Logging.LogUsefulException(e);
                Stop();
            }
        }

        private void localStartReceive()
        {
            try
            {
                _local.BeginReceiveFrom(state.buffer, 0, state.buffer.Length, SocketFlags.None,
                    ref state.remoteEP, new AsyncCallback(localReceiveCallback), state);
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
                Restart();
            }
        }

        private void localReceiveCallback(IAsyncResult ar)
        {
            State state = (State)ar.AsyncState;
            try
            {
                EndPoint remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
                int bytesRead = _local.EndReceiveFrom(ar, ref remoteEP);
                _pipe.CreatePipe(state.buffer, bytesRead, _local, remoteEP);
                localStartReceive();
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
                Restart();
            }
        }

    }
}
