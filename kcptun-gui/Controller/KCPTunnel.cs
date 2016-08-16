using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;

using kcptun_gui.Model;
using kcptun_gui.Properties;
using kcptun_gui.Util;

namespace kcptun_gui.Controller
{
    public class KCPTunnel
    {
        const string FILENAME = "kcptun-client.exe";

        private Process _process;
        private Server _server;

        static KCPTunnel()
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

        public KCPTunnel() { }

        public KCPTunnel(Server server)
        {
            _server = server;
        }

        public void Start()
        {
            if (IsRunning)
                throw new Exception("Kcptun running");

            StringBuilder arguments = new StringBuilder();
            arguments.Append($" -l \"{_server.localaddr}\"");
            arguments.Append($" -r \"{_server.remoteaddr}\"");
            arguments.Append($" --crypt {_server.crypt}");
            if (_server.crypt != kcptun_crypt.none)
                arguments.Append($" --key \"{_server.key}\"");
            arguments.Append($" --mode \"{_server.mode}\"");
            arguments.Append($" --conn {_server.conn}");
            arguments.Append($" --mtu {_server.mtu}");
            arguments.Append($" --sndwnd {_server.sndwnd}");
            arguments.Append($" --rcvwnd {_server.rcvwnd}");
            if (_server.nocomp)
                arguments.Append($" --nocomp");
            arguments.Append($" --datashard {_server.datashard}");
            arguments.Append($" --parityshard {_server.parityshard}");
            arguments.Append($" --dscp {_server.dscp}");
            if (_server.mode == kcptun_mode.manual)
            {
                arguments.Append($" --nodelay {_server.nodelay}");
                arguments.Append($" --resend {_server.resend}");
                arguments.Append($" --nc {_server.nc}");
                arguments.Append($" --interval {_server.interval}");
            }
            if (!string.IsNullOrEmpty(_server.other_arguments))
                arguments.Append($" {_server.other_arguments}");

            _process = new Process();
            // Configure the process using the StartInfo properties.
            _process.StartInfo.FileName = Utils.GetTempPath(FILENAME);
            _process.StartInfo.Arguments = arguments.ToString();
            _process.StartInfo.WorkingDirectory = Utils.GetTempPath();
            _process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            _process.StartInfo.UseShellExecute = false;
            _process.StartInfo.CreateNoWindow = true;
            _process.StartInfo.RedirectStandardError = true;
            _process.StartInfo.RedirectStandardOutput = true;
            _process.ErrorDataReceived += _process_ErrorDataReceived;
            _process.OutputDataReceived += _process_OutputDataReceived;
            _process.Exited += _process_Exited;
            _process.EnableRaisingEvents = true;
            _process.Start();
            _process.BeginOutputReadLine();
            _process.BeginErrorReadLine();

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

                    if (Stoped != null)
                        Stoped.Invoke(this, new EventArgs());
                }
            }
        }

        public void Reload()
        {
            if (!IsRunning)
                throw new Exception("Kcptun stoped");
            Stop();
            Start();
        }

        private void _process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logging.Info(e.Data);
        }

        private void _process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            Logging.Info(e.Data);
        }

        private void _process_Exited(object sender, EventArgs e)
        {
            if (_process != null)
            {
                _process.Dispose();
                _process = null;

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
    }
}
