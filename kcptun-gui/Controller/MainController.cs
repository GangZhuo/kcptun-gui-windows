using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

using kcptun_gui.Model;
using kcptun_gui.Common;

namespace kcptun_gui.Controller
{
    public class MainController
    {
        public const string Version = "1.2";

        private IRelay _tcpRelay;
        private IRelay _udpRelay;

        public TrafficStatistics rawTrafficStatistics = new TrafficStatistics();
        public TrafficStatistics kcpTrafficStatistics = new TrafficStatistics();

        public ConfigurationController ConfigController { get; private set; }
        public KCPTunnelController KCPTunnelController { get; private set; }

        public bool IsKcptunRunning
        {
            get { return KCPTunnelController.IsRunning; }
        }

        public MainController()
        {
            ConfigController = new ConfigurationController(this);
            ConfigController.ConfigChanged += OnConfigChanged;

            KCPTunnelController = new KCPTunnelController(this);

        }

        public void Start()
        {
            Reload();
        }

        public void Stop()
        {
            if (_tcpRelay != null)
            {
                _tcpRelay.Stop();
                _tcpRelay = null;
            }
            if (_udpRelay != null)
            {
                _udpRelay.Stop();
                _udpRelay = null;
            }
            if (KCPTunnelController.IsRunning)
                KCPTunnelController.Stop();
        }

        public void Reload()
        {
            try
            {
                if (_tcpRelay != null)
                {
                    _tcpRelay.Stop();
                    _tcpRelay = null;
                }
                if (_udpRelay != null)
                {
                    _udpRelay.Stop();
                    _udpRelay = null;
                }
                if (KCPTunnelController.IsRunning)
                {
                    KCPTunnelController.Stop();
                }
                Configuration config = ConfigController.GetCurrentConfiguration();
                if (config.enabled)
                {
                    KCPTunnelController.Server = config.GetCurrentServer();
                    KCPTunnelController.localaddr = null;
                    KCPTunnelController.remoteaddr = null;
                    if (config.statistics_enabled)
                        RegistStatistics();
                    KCPTunnelController.Start();
                }
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        private void RegistLeftStatistics()
        {
            Server server = KCPTunnelController.Server;
            string[] localaddr_compns = server.localaddr.Split(':');
            IPEndPoint localEP = new IPEndPoint(
                string.IsNullOrEmpty(localaddr_compns[0]) ? IPAddress.Any : IPAddress.Parse(localaddr_compns[0]),
                Convert.ToInt32(localaddr_compns[1]));
            IPEndPoint remoteEP = new IPEndPoint(
                IPAddress.Loopback,
                Utils.GetFreePort(ProtocolType.Tcp, localEP.Port + 1));

            KCPTunnelController.localaddr = remoteEP.ToString();
            Logging.Debug($"Left: localEP={localEP.ToString()}, remoteEP={remoteEP.ToString()}");
            _tcpRelay = new TCPRelay(this, localEP, remoteEP);
            _tcpRelay.Inbound += _tcpRelay_Inbound;
            _tcpRelay.Outbound += _tcpRelay_Outbound;
            _tcpRelay.Start();
        }

        private void RegistRightStatistics()
        {
            Server server = KCPTunnelController.Server;
            string[] localaddr_compns = server.localaddr.Split(':');
            string[] remoteaddr_compns = server.remoteaddr.Split(':');
            IPEndPoint localEP = new IPEndPoint(
                IPAddress.Loopback,
                Utils.GetFreePort(ProtocolType.Udp, Convert.ToInt32(localaddr_compns[1])));
            IPEndPoint remoteEP = new IPEndPoint(
                IPAddress.Parse(remoteaddr_compns[0]),
                Convert.ToInt32(remoteaddr_compns[1]));

            KCPTunnelController.remoteaddr = localEP.ToString();
            Logging.Debug($"right: localEP={localEP.ToString()}, remoteEP={remoteEP.ToString()}");
            _udpRelay = new UDPRelay(this, localEP, remoteEP);
            _udpRelay.Inbound += _udpRelay_Inbound;
            _udpRelay.Outbound += _udpRelay_Outbound;
            _udpRelay.Start();
        }

        private void _tcpRelay_Inbound(object sender, RelayEventArgs e)
        {
            rawTrafficStatistics.onInbound(e.Value);
        }

        private void _tcpRelay_Outbound(object sender, RelayEventArgs e)
        {
            rawTrafficStatistics.onOutbound(e.Value);
        }

        private void _udpRelay_Inbound(object sender, RelayEventArgs e)
        {
            kcpTrafficStatistics.onInbound(e.Value);
        }

        private void _udpRelay_Outbound(object sender, RelayEventArgs e)
        {
            kcpTrafficStatistics.onOutbound(e.Value);
        }

        private void RegistStatistics()
        {
            RegistLeftStatistics();
            RegistRightStatistics();
        }

        private void OnConfigChanged(object sender, EventArgs e)
        {
            Reload();
        }

        public class TrafficStatistics
        {
            public long inboundCounter = 0;
            public long outboundCounter = 0;

            public void onInbound(long n)
            {
                Interlocked.Add(ref inboundCounter, n);
            }

            public void onOutbound(long n)
            {
                Interlocked.Add(ref outboundCounter, n);
            }

            public void reset()
            {
                Interlocked.Exchange(ref inboundCounter, 0);
                Interlocked.Exchange(ref outboundCounter, 0);
            }
        }
    }
}
