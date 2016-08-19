using System;

using kcptun_gui.Model;

namespace kcptun_gui.Controller
{
    public class ConfigurationController
    {
        private MainController controller;

        private Configuration _config;

        public event EventHandler ConfigChanged;
        public event EventHandler EnableChanged;
        public event EventHandler VerboseChanged;
        public event EventHandler ServerIndexChanged;
        public event EventHandler KCPTunPathChanged;

        public ConfigurationController(MainController controller)
        {
            this.controller = controller;
            _config = Configuration.Load();
            if (_config.servers.Count == 0)
            {
                _config.servers.Add(Configuration.GetDefaultServer());
                _config.index = 0;
            }
        }

        public Server GetCurrentServer()
        {
            return _config.GetCurrentServer();
        }

        // always return copy
        public Configuration GetConfigurationCopy()
        {
            return Configuration.Load();
        }

        // always return current instance
        public Configuration GetCurrentConfiguration()
        {
            return _config;
        }

        public void ToggleEnable(bool enabled)
        {
            _config.enabled = enabled;
            SaveConfig(_config);
            if (EnableChanged != null)
                EnableChanged.Invoke(this, new EventArgs());
        }

        public void ToggleVerboseLogging(bool enabled)
        {
            _config.verbose = enabled;
            SaveConfig(_config);
            if (VerboseChanged != null)
                VerboseChanged.Invoke(this, new EventArgs());
        }

        public void SelectServerIndex(int index)
        {
            _config.index = index;
            SaveConfig(_config);
            if (ServerIndexChanged != null)
                ServerIndexChanged.Invoke(this, new EventArgs());
        }

        public void ChangeKCPTunPath(string kcptunPath)
        {
            _config.kcptun_path = kcptunPath;
            SaveConfig(_config);
            if (KCPTunPathChanged != null)
                KCPTunPathChanged.Invoke(this, new EventArgs());
        }

        public void SaveConfig(Configuration config)
        {
            Configuration.Save(config);
            this._config = config;
            if (config.isDefault)
                config.isDefault = false;
            if (ConfigChanged != null)
                ConfigChanged.Invoke(this, new EventArgs());
        }

    }
}
