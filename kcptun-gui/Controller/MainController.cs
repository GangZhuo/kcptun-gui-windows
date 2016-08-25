using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

using kcptun_gui.Model;
using kcptun_gui.Common;

namespace kcptun_gui.Controller
{
    public class MainController
    {
        public const string Version = "1.3";
        public const int TrafficLogSize = 60; // 1 minutes

        private IRelay _tcpRelay;
        private IRelay _udpRelay;

        public Traffic rawTrafficStatistics = new Traffic();
        public Traffic kcpTrafficStatistics = new Traffic();
        public LinkedList<TrafficLog> trafficLogList = new LinkedList<TrafficLog>();
        private System.Timers.Timer timer;

        public ConfigurationController ConfigController { get; private set; }
        public KCPTunnelController KCPTunnelController { get; private set; }

        public event EventHandler TrafficChanged;

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
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
                timer = null;
            }
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
                if (timer != null)
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
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
                    {
                        RegistStatistics();
                        StartTrafficLogger();
                    }
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

        private void StartTrafficLogger()
        {
            if (trafficLogList == null)
                trafficLogList = new LinkedList<TrafficLog>();
            else
                trafficLogList.Clear();
            for (int i = 0; i < TrafficLogSize; i++)
            {
                TrafficLog item = new TrafficLog();
                item.raw = new Traffic();
                item.kcp = new Traffic();
                trafficLogList.AddLast(item);
            }
            if (timer == null)
            {
                timer = new System.Timers.Timer(1000);
                timer.Elapsed += Timer_Elapsed;
                timer.AutoReset = true;
                timer.Enabled = true;
            }
            timer.Start();
       }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            UpdateTrafficList();
            TrafficChanged?.Invoke(this, new EventArgs());
        }

        private void UpdateTrafficList()
        {
            TrafficLog current = new TrafficLog();
            current.raw = new Traffic
            {
                inboundCounter = rawTrafficStatistics.inboundCounter,
                outboundCounter = rawTrafficStatistics.outboundCounter
            };
            current.kcp = new Traffic
            {
                inboundCounter = kcpTrafficStatistics.inboundCounter,
                outboundCounter = kcpTrafficStatistics.outboundCounter
            };
            trafficLogList.AddLast(current);

            if (trafficLogList.Count > TrafficLogSize)
                trafficLogList.RemoveFirst();
        }

        public class Traffic
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

        public class TrafficLog
        {
            public Traffic raw;
            public Traffic kcp;
        }

    }
}
