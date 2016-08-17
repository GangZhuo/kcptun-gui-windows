using System;
using System.Windows.Forms;
using Microsoft.Win32;
using kcptun_gui.Util;

namespace kcptun_gui.Controller
{
    class AutoStartup
    {
        static string Key = "kcptun_" + Application.StartupPath.GetHashCode();

        public static bool Set(bool enabled)
        {
            RegistryKey runKey = null;
            try
            {
                string path = Application.ExecutablePath;
                runKey = Utils.OpenUserRegKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if ( runKey == null ) {
                    Logging.Error( @"Cannot find HKCU\Software\Microsoft\Windows\CurrentVersion\Run" );
                    return false;
                }
                if (enabled)
                {
                    runKey.SetValue(Key, path);
                }
                else
                {
                    runKey.DeleteValue(Key);
                }
                return true;
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
                return false;
            }
            finally
            {
                if (runKey != null)
                {
                    try { runKey.Close(); }
                    catch (Exception e)
                    { Logging.LogUsefulException(e); }
                }
            }
        }

        public static bool Check()
        {
            RegistryKey runKey = null;
            try
            {
                string path = Application.ExecutablePath;
                runKey = Utils.OpenUserRegKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if (runKey == null) {
                    Logging.Error(@"Cannot find HKCU\Software\Microsoft\Windows\CurrentVersion\Run");
                    return false;
                }
                string[] runList = runKey.GetValueNames();
                foreach (string item in runList)
                {
                    if (item.Equals(Key, StringComparison.OrdinalIgnoreCase))
                        return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Logging.LogUsefulException(e);
                return false;
            }
            finally
            {
                if (runKey != null)
                {
                    try { runKey.Close(); }
                    catch (Exception e)
                    { Logging.LogUsefulException(e); }
                }
            }
        }
    }
}
