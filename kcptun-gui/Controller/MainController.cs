using System;

using kcptun_gui.Model;

namespace kcptun_gui.Controller
{
    public class MainController
    {
        public const string Version = "1.1";

        public ConfigurationController ConfigController { get; private set; }
        public KCPTunnelController KCPTunnelController { get; private set; }

        public bool IsKcptunRunning
        {
            get { return KCPTunnelController.IsRunning; }
        }

        public MainController()
        {
            ConfigController = new Controller.ConfigurationController();
            ConfigController.ConfigChanged += OnConfigChanged;

            KCPTunnelController = new KCPTunnelController();

        }

        public void Start()
        {
            Reload();
        }

        public void Stop()
        {
            try
            {
                KCPTunnelController.Stop();
            }
            catch(Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        public void Reload()
        {
            try
            {
                if (KCPTunnelController.IsRunning)
                    KCPTunnelController.Stop();
                Configuration config = ConfigController.GetCurrentConfiguration();
                if (config.enabled)
                {
                    KCPTunnelController.Server = config.GetCurrentServer();
                    KCPTunnelController.Start();
                }
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        private void OnConfigChanged(object sender, EventArgs e)
        {
            Reload();
        }

    }
}
