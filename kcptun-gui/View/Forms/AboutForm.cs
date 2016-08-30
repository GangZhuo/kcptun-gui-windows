using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using kcptun_gui.Controller;

namespace kcptun_gui.View
{
    public partial class AboutForm : Form
    {
        private MainController controller;

        public AboutForm(MainController controller)
        {
            this.controller = controller;
            InitializeComponent();
            UpdateText();
            this.aboutUserControl1.KCPTunVersion = controller.KCPTunnelController.GetKcptunVersion();
            controller.ConfigController.KCPTunPathChanged += ConfigController_KCPTunPathChanged;
        }

        private void UpdateText()
        {
            Text = I18N.GetString("About");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            controller.ConfigController.KCPTunPathChanged -= ConfigController_KCPTunPathChanged;
            base.OnClosing(e);
        }

        private void ConfigController_KCPTunPathChanged(object sender, EventArgs e)
        {
            this.aboutUserControl1.KCPTunVersion = controller.KCPTunnelController.GetKcptunVersion();
        }
    }
}
