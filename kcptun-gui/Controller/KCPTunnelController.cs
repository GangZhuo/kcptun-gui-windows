using System;
using System.Diagnostics;
using System.IO;
using System.Text;

using kcptun_gui.Model;
using kcptun_gui.Properties;
using kcptun_gui.Util;

namespace kcptun_gui.Controller
{
    public class KCPTunnelController
    {
        const string FILENAME = "kcptun-client.exe";

        private Process _process;
        private Server _server;

        static KCPTunnelController()
        {
            try
            {
                if (Environment.Is64BitOperatingSystem)
                    FileManager.UncompressFile(Utils.GetTempPath(FILENAME), Resources.client_windows_amd64_exe);
                else
                    FileManager.UncompressFile(Utils.GetTempPath(FILENAME), Resources.client_windows_386_exe);
            }
            catch (IOException e)
            {
                Logging.LogUsefulException(e);
            }
        }

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

        public event EventHandler Started;
        public event EventHandler Stoped;

        public KCPTunnelController() { }

        public KCPTunnelController(Server server)
        {
            _server = server;
        }

        public void Start()
        {
            if (IsRunning)
                throw new Exception("Kcptun running");
            if (_server == null)
                throw new Exception("No Server");

            _process = new Process();
            _process.StartInfo.FileName = Utils.GetTempPath(FILENAME);
            _process.StartInfo.Arguments = BuildArguments(_server);
            _process.StartInfo.WorkingDirectory = Utils.GetTempPath();
            _process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.CreateNoWindow = true;
            _process.StartInfo.RedirectStandardError = true;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.ErrorDataReceived += OnProcessErrorDataReceived;
            _process.OutputDataReceived += OnProcessOutputDataReceived;
            _process.Exited += OnProcessExited;
            _process.EnableRaisingEvents = true;
            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();

            Console.WriteLine("kcptun started " + _server.FriendlyName());

            if (Started != null)
                Started.Invoke(this, new EventArgs());
        }

        public void Stop()
        {
            if (_process != null)
            {
                KillProcess(_process);
                if (_process != null)
                {
                    _process.Dispose();
                    _process = null;

                    Console.WriteLine("kcptun stoped " + _server.FriendlyName());

                    if (Stoped != null)
                        Stoped.Invoke(this, new EventArgs());
                }
            }
        }

        private void OnProcessOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logging.Info(e.Data);
        }

        private void OnProcessErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logging.Info(e.Data);
        }

        private void OnProcessExited(object sender, EventArgs e)
        {
            if (_process != null)
            {
                _process.Dispose();
                _process = null;

                Console.WriteLine("kcptun stoped " + _server.FriendlyName());

                if (Stoped != null)
                    Stoped.Invoke(this, new EventArgs());
            }
        }

        private static void KillProcess(Process p)
        {
            try
            {
                p.CloseMainWindow();
                p.WaitForExit(100);
                if (!p.HasExited)
                {
                    p.Kill();
                    p.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
            }
        }

        public static void KillAll()
        {
            Process[] processes = Process.GetProcessesByName("kcptun-client");
            foreach (Process p in processes)
            {
                KillProcess(p);
            }
        }

        public static string GetKcptunVersion()
        {
            string version = "";
            try
            {
                Process p = new Process();
                // Configure the process using the StartInfo properties.
                p.StartInfo.FileName = Utils.GetTempPath(FILENAME);
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
                    Console.WriteLine("Can't get kcptun version.");
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
            StringBuilder arguments = new StringBuilder();
            arguments.Append($" -l \"{server.localaddr}\"");
            arguments.Append($" -r \"{server.remoteaddr}\"");
            arguments.Append($" --crypt {server.crypt}");
            if (server.crypt != kcptun_crypt.none)
                arguments.Append($" --key \"{server.key}\"");
            arguments.Append($" --mode \"{server.mode}\"");
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
            if (!string.IsNullOrEmpty(server.other_arguments))
                arguments.Append($" {server.other_arguments}");

            return arguments.ToString();
        }
    }
}
