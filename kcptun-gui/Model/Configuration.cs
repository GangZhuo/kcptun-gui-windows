using System;
using System.Collections.Generic;
using System.IO;

using Newtonsoft.Json;
using kcptun_gui.Controller;

namespace kcptun_gui.Model
{
    [Serializable]
    public class Configuration
    {
        public List<Server> servers;

        public int index;

        public bool enabled;

        public bool verbose;

        public string kcptun_path;

        public bool statistics_enabled;

        public bool check_gui_update;

        public bool check_kcptun_update;

        public bool auto_upgrade_kcptun;

        public string language;

        [JsonIgnore]
        public bool isDefault;

        private static string CONFIG_FILE = "kcptun-gui-config.json";

        public Server GetCurrentServer()
        {
            if (index >= 0 && index < servers.Count)
                return servers[index];
            else
                return GetDefaultServer();
        }

        public static Configuration Load()
        {
            try
            {
                string configContent = File.ReadAllText(CONFIG_FILE);
                Configuration config = JsonConvert.DeserializeObject<Configuration>(configContent);
                if (config.servers == null) config.servers = new List<Server>();
                return config;
            }
            catch (Exception e)
            {
                if (!(e is FileNotFoundException))
                    Logging.LogUsefulException(e);
                return new Configuration
                {
                    index = 0,
                    enabled = false,
                    isDefault = true,
                    kcptun_path = "",
                    statistics_enabled = false,
                    check_gui_update = true,
                    check_kcptun_update = true,
                    auto_upgrade_kcptun = false,
                    servers = new List<Server>()
                    {
                        GetDefaultServer()
                    }
                };
            }
        }

        public static void Save(Configuration config)
        {
            if (config.index >= config.servers.Count)
                config.index = config.servers.Count - 1;
            if (config.index <= -1)
                config.index = 0;
            try
            {
                using (StreamWriter sw = new StreamWriter(File.Open(CONFIG_FILE, FileMode.Create)))
                {
                    string jsonString = JsonConvert.SerializeObject(config, Formatting.Indented);
                    sw.Write(jsonString);
                    sw.Flush();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine(e);
            }
        }

        public static Server GetDefaultServer()
        {
            return new Server();
        }
    }
}
