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

        private Socket _local;
        private UDPPipe _pipe;

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
                EndPoint remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
                byte[] buf = new byte[4096];
                object[] state = new object[] {
                    _local,
                    buf
                };
                _local.BeginReceiveFrom(buf, 0, buf.Length, SocketFlags.None, ref remoteEP, new AsyncCallback(receiveFrom), state);
            }
            catch (SocketException)
            {
                _local.Close();
                throw;
            }
        }

        public void Stop()
        {
            if (_local != null)
            {
                _local.Close();
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

        private void receiveFrom(IAsyncResult ar)
        {
            object[] state = (object[])ar.AsyncState;
            Socket socket = (Socket)state[0];
            byte[] buf = (byte[])state[1];
            EndPoint remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
            try
            {
                int bytesRead = socket.EndReceiveFrom(ar, ref remoteEP);
                if (_pipe.CreatePipe(buf, bytesRead, socket, remoteEP))
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
                    remoteEP = (EndPoint)(new IPEndPoint(IPAddress.Any, 0));
                    socket.BeginReceiveFrom(buf, 0, buf.Length, SocketFlags.None, ref remoteEP, new AsyncCallback(receiveFrom), state);
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
