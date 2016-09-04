using System;
using System.Diagnostics;
using System.IO;
using System.Text;

using kcptun_gui.Model;
using kcptun_gui.Common;

namespace kcptun_gui.Controller
{
    public class KCPTunnelController
    {
        const string FILENAME = "kcptun-client.exe";

        private MainController controller;

        private MyProcess _process;
        private Server _server;

        public Server Server
        {
            get
            {
                return _server;
            }
            set
            {
                _server = value;
            }
        }

        public bool IsRunning
        {
            get
            {
                return _process != null;
            }
        }

        public string localaddr { get; set; }
        public string remoteaddr { get; set; }

        public event EventHandler Started;
        public event EventHandler Stoped;

        public KCPTunnelController(MainController controller)
        {
            this.controller = controller;
        }

        public string GetKCPTunPath()
        {
            Configuration config = controller.ConfigController.GetCurrentConfiguration();
            if (string.IsNullOrEmpty(config.kcptun_path))
            {
                string path = null;
                if (Environment.Is64BitOperatingSystem && File.Exists("client_windows_amd64.exe"))
                    path = "client_windows_amd64.exe";
                else if (File.Exists("client_windows_386.exe"))
                    path = "client_windows_386.exe";
                if (path == null)
                    throw new Exception("client_windows_amd64.exe or client_windows_386.exe not exists, please download from https://github.com/xtaci/kcptun or specify absolute path through context menu (Right click task bar icon, then select 'More/Custom KCPTun').");
                return path;
            }
            else
                return config.kcptun_path;
        }

        public void Start()
        {
            if (IsRunning)
                throw new Exception("Kcptun running");
            if (_server == null)
                throw new Exception("No Server");

            try
            {
                string filename = GetKCPTunPath();
                Console.WriteLine($"kcptun client: {filename}");
                MyProcess p = new MyProcess(_server);
                p.StartInfo.FileName = filename;
                p.StartInfo.Arguments = BuildArguments(_server, localaddr, remoteaddr);
                p.StartInfo.WorkingDirectory = Utils.GetTempPath();
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.ErrorDataReceived += OnProcessErrorDataReceived;
                p.OutputDataReceived += OnProcessOutputDataReceived;
                p.Exited += OnProcessExited;
                p.EnableRaisingEvents = true;
                p.Start();
                _process = p;
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();

                Console.WriteLine("kcptun client started - " + p.server.FriendlyName());

                if (Started != null)
                    Started.Invoke(this, new EventArgs());
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        public void Stop()
        {
            try
            {
                MyProcess p = _process;
                if (p != null)
                {
                    _process = null;
                    KillProcess(p);
                    p.Dispose();

                    Console.WriteLine("kcptun client stoped - " + p.server.FriendlyName());

                    if (Stoped != null)
                        Stoped.Invoke(this, new EventArgs());
                }
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        private void WriteToLogFile(MyProcess process, string s, bool error)
        {
            if (s != null)
            {
                using (StringReader sr = new StringReader(s))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        error = line.IndexOf("[ERR]") >= 0;
                        if (controller.ConfigController.GetCurrentConfiguration().verbose || error)
                        {
                            string formatedMessage = process.server.FriendlyName() + " - " + line;
                            if (error)
                                Logging.Error(formatedMessage);
                            else
                                Logging.Info(formatedMessage);
                        }
                    }
                }
            }
        }

        private void OnProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (controller.ConfigController.GetCurrentConfiguration().verbose)
                WriteToLogFile(sender as MyProcess, e.Data, false);
        }

        private void OnProcessErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            WriteToLogFile(sender as MyProcess, e.Data, true);
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            if (sender == _process)
                Stop();
        }

        private void KillProcess(Process p)
        {
            try
            {
                if (!p.HasExited)
                {
                    p.CloseMainWindow();
                    p.WaitForExit(100);
                    if (!p.HasExited)
                    {
                        p.Kill();
                        p.WaitForExit();
                    }
                }
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        public void KillAll()
        {
            string filename = Path.GetFileNameWithoutExtension(GetKCPTunPath());
            Process[] processes = Process.GetProcessesByName(filename);
            foreach (Process p in processes)
            {
                KillProcess(p);
            }
        }

        public string GetKcptunVersion()
        {
            string version = "";
            try
            {
                string filename = GetKCPTunPath();
                Console.WriteLine($"kcptun client: {filename}");
                Process p = new Process();
                // Configure the process using the StartInfo properties.
                p.StartInfo.FileName = filename;
                p.StartInfo.Arguments = "-v";
                p.StartInfo.WorkingDirectory = Utils.GetTempPath();
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.CreateNoWindow = true;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.Start();
                int count = 300;
                while (!p.HasExited && count > 0)
                {
                    p.WaitForExit(100);
                    count--;
                }
                if (count == 0)
                {
                    Console.WriteLine("Can't get kcptun client version.");
                    return "";
                }
                version = p.StandardOutput.ReadToEnd();
            }
            catch(Exception e)
            {
                Logging.LogUsefulException(e);
            }
            return version;
        }

        public static string BuildArguments(Server server)
        {
            return BuildArguments(server, null, null);
        }

        private static string BuildArguments(Server server, string localaddr, string remoteaddr)
        {
            if (string.IsNullOrEmpty(localaddr))
                localaddr = server.localaddr;
            if (string.IsNullOrEmpty(remoteaddr))
                remoteaddr = server.remoteaddr;
            StringBuilder arguments = new StringBuilder();
            if (server.mode == kcptun_mode.manual_all)
            {
                arguments.Append($" -l \"{localaddr}\"");
                arguments.Append($" -r \"{remoteaddr}\"");
                arguments.Append($" {server.extend_arguments}");
            }
            else
            {
                MyEnumConverter cryptConverter = new MyEnumConverter(typeof(kcptun_crypt));
                MyEnumConverter modeConverter = new MyEnumConverter(typeof(kcptun_mode));
                arguments.Append($" -l \"{localaddr}\"");
                arguments.Append($" -r \"{remoteaddr}\"");
                arguments.Append($" --crypt {cryptConverter.ConvertToString(server.crypt)}");
                if (server.crypt != kcptun_crypt.none)
                    arguments.Append($" --key \"{server.key}\"");
                arguments.Append($" --mode {modeConverter.ConvertToString(server.mode)}");
                arguments.Append($" --conn {server.conn}");
                arguments.Append($" --mtu {server.mtu}");
                arguments.Append($" --sndwnd {server.sndwnd}");
                arguments.Append($" --rcvwnd {server.rcvwnd}");
                if (server.nocomp)
                    arguments.Append($" --nocomp");
                arguments.Append($" --datashard {server.datashard}");
                arguments.Append($" --parityshard {server.parityshard}");
                arguments.Append($" --dscp {server.dscp}");
                if (server.mode == kcptun_mode.manual)
                {
                    arguments.Append($" --nodelay {server.nodelay}");
                    arguments.Append($" --resend {server.resend}");
                    arguments.Append($" --nc {server.nc}");
                    arguments.Append($" --interval {server.interval}");
                }
                else
                {
                    /*do nothing*/
                }
                if (!string.IsNullOrEmpty(server.extend_arguments))
                    arguments.Append($" {server.extend_arguments}");
            }

            return arguments.ToString().Trim();
        }

        class MyProcess: Process
        {
            public Server server { get; private set; }

            public MyProcess(Server server)
            {
                this.server = server;
            }
        }
    }
}
