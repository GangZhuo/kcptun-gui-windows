using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using kcptun_gui.Controller;
using kcptun_gui.View;

namespace kcptun_gui
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!Logging.OpenLogFile())
            {
                MessageBox.Show($"Can't access the file '{Logging.LogFilePath}', it is maybe used by another process.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            KcptunController controller = new KcptunController();
            MenuViewController viewController = new MenuViewController(controller);
            Application.Run();
        }
    }
}
