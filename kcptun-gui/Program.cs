using System;
using System.IO;
using System.Windows.Forms;

using kcptun_gui.Controller;
using kcptun_gui.View;

namespace kcptun_gui
{
    static class Program
    {
        static MainController controller;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Directory.SetCurrentDirectory(Application.StartupPath);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Logging.OpenLogFile())
            {
                MessageBox.Show($"Can't access the file '{Logging.LogFilePath}', it is maybe used by another process.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            controller = new MainController();
            MenuViewController viewController = new MenuViewController(controller);
            controller.Start();
            Application.ApplicationExit += Application_ApplicationExit;
            Application.Run();
        }

        private static void Application_ApplicationExit(object sender, EventArgs e)
        {
            if (controller != null)
            {
                controller.Stop();
                controller = null;
            }
        }
    }
}
