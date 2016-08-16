using System;
using System.IO;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;

using kcptun_gui.Util;

namespace kcptun_gui.Controller
{
    public class Logging
    {
        public static string LogFilePath;

        private static FileStream fs;
        private static StreamWriterWithTimestamp sw;

        public static bool OpenLogFile()
        {
            try
            {
                LogFilePath = Utils.GetTempPath("kcptun.log");

                fs = new FileStream(LogFilePath, FileMode.Append);
                sw = new StreamWriterWithTimestamp(fs);
                sw.AutoFlush = true;
                Console.SetOut(sw);
                Console.SetError(sw);

                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        private static void WriteToLogFile(object o)
        {
            try
            {
                Console.WriteLine(o);
            }
            catch (ObjectDisposedException)
            {
            }
        }

        public static void Error(object o)
        {
            WriteToLogFile("[E] " + o);
        }

        public static void Info(object o)
        {
            WriteToLogFile(o);
        }

        public static void clear() {
            sw.Close();
            sw.Dispose();
            fs.Close();
            fs.Dispose();
            File.Delete(LogFilePath);
            OpenLogFile();
        }

        [Conditional("DEBUG")]
        public static void Debug(object o)
        {
            WriteToLogFile("[D] " + o);
        }

        public static void LogUsefulException(Exception e)
        {
            Info(e);
        }
    }

    // Simply extended System.IO.StreamWriter for adding timestamp workaround
    public class StreamWriterWithTimestamp : StreamWriter
    {
        public StreamWriterWithTimestamp(Stream stream) : base(stream)
        {
        }

        private string GetTimestamp()
        {
            return "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] ";
        }

        public override void WriteLine(string value)
        {
            base.WriteLine(GetTimestamp() + value);
        }

        public override void Write(string value)
        {
            base.Write(GetTimestamp() + value);
        }
    }

}
