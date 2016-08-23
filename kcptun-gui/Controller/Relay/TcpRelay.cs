using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

using kcptun_gui.Controller.Relay;

namespace kcptun_gui.Controller
{
    public class TCPRelay : IRelay
    {
        private Socket _socket;
        private TCPPipe _pipe;

        private MainController _controller;
        private EndPoint _localEP;
        private EndPoint _remoteEP;

        public event EventHandler<RelayEventArgs> Inbound;
        public event EventHandler<RelayEventArgs> Outbound;

        public TCPRelay(MainController controller, EndPoint localEP, EndPoint remoteEP)
        {
            _controller = controller;
            _localEP = localEP;
            _remoteEP = remoteEP;
            this._pipe = new TCPPipe(this, localEP, remoteEP);
        }

        public void Start()
        {
            try
            {
                // Create a TCP/IP socket.
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                _socket.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
                // Bind the socket to the local endpoint and listen for incoming connections.
                _socket.Bind(_localEP);
                _socket.Listen(1024);
                // Start an asynchronous socket to listen for connections.
                Console.WriteLine("TCPRelay listen on " + _localEP.ToString());
                _socket.BeginAccept(new AsyncCallback(AcceptCallback), _socket);
            }
            catch (SocketException)
            {
                _socket.Close();
                throw;
            }
        }

        public void Stop()
        {
            if (_socket != null)
            {
                _socket.Close();
                _socket = null;
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

        private void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = (Socket)ar.AsyncState;
            try
            {
                Socket conn = listener.EndAccept(ar);
                if (_pipe.CreatePipe(conn))
                    return;
                // do nothing
            }
            catch (ObjectDisposedException)
            {
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
            finally
            {
                try
                {
                    listener.BeginAccept( new AsyncCallback(AcceptCallback), listener);
                }
                catch (ObjectDisposedException)
                {
                    // do nothing
                }
                catch (Exception e)
                {
                    Logging.LogUsefulException(e);
                }
            }
        }
    }
}
