using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using kcptun_gui.Common;
using kcptun_gui.Controller;

namespace kcptun_gui.Model
{
    public class TrafficStatistics : Dictionary<string, TrafficLog>
    {
        private static string TRAFFIC_STATISTICS_FILE = "kcptun-traffic-statistics.json";

        public TrafficLog GetTrafficLog(Server server)
        {
            if (this.ContainsKey(server.remoteaddr))
            {
                return this[server.remoteaddr];
            }
            else
            {
                TrafficLog log = new TrafficLog();
                this.Add(server.remoteaddr, log);
                return log;
            }
        }

        public static TrafficStatistics Load()
        {
            try
            {
                string filename = Utils.GetTempPath(TRAFFIC_STATISTICS_FILE);
                string content = File.ReadAllText(filename);
                TrafficStatistics instance = JsonConvert.DeserializeObject<TrafficStatistics>(content);
                if (instance == null)
                    return new TrafficStatistics();
                return instance;
            }
            catch (Exception e)
            {
                if (!(e is FileNotFoundException))
                    Logging.LogUsefulException(e);
                return new TrafficStatistics();
            }
        }

        public static void Save(TrafficStatistics instance)
        {
            try
            {
                string filename = Utils.GetTempPath(TRAFFIC_STATISTICS_FILE);
                using (StreamWriter sw = new StreamWriter(File.Open(filename, FileMode.Create)))
                {
                    string jsonString = JsonConvert.SerializeObject(instance, Formatting.Indented);
                    sw.Write(jsonString);
                    sw.Flush();
                }
            }
            catch (IOException e)
            {
                Console.Error.WriteLine(e);
            }
        }

    }
}
