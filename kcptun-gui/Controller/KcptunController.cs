using System;

using kcptun_gui.Model;

namespace kcptun_gui.Controller
{
    public class KcptunController
    {
        public const string Version = "1.0.0.0";

        public KCPTunnel kcptun;
        public Configuration config;

        public event EventHandler ConfigChanged;
        public event EventHandler KcptunStarted;
        public event EventHandler KcptunStoped;

        public KcptunController()
        {
            kcptun = new KCPTunnel();
            kcptun.Started += _kcptun_Started;
            kcptun.Stoped += _kcptun_Stoped;

            config = Configuration.Load();
            if (config.configs.Count == 0)
            {
                config.configs.Add(Configuration.GetDefaultServer());
                config.index = 0;
            }
            Server server = config.GetCurrentServer();
            kcptun.Server = server;
        }

        public Server GetCurrentServer()
        {
            return config.GetCurrentServer();
        }

        public void SaveConfig(Configuration config)
        {
            Configuration.Save(config);
            this.config = config;

            kcptun.Server = config.GetCurrentServer();
            if (kcptun.IsRunning)
                kcptun.Reload();

            if (ConfigChanged != null)
                ConfigChanged.Invoke(this, new EventArgs());
        }

        public bool IsKcptunRunning()
        {
            return kcptun.IsRunning;
        }

        public void Start()
        {
            kcptun.Start();
        }

        public void Stop()
        {
            kcptun.Stop();
        }

        public void Reload()
        {
            kcptun.Reload();
        }

        private void _kcptun_Stoped(object sender, EventArgs e)
        {
            Console.WriteLine("kcptun stoped");
            if (KcptunStarted != null)
                KcptunStarted.Invoke(this, new EventArgs());
        }

        private void _kcptun_Started(object sender, EventArgs e)
        {
            Console.WriteLine("kcptun started");
            if (KcptunStoped != null)
                KcptunStoped.Invoke(this, new EventArgs());
        }

    }
}
