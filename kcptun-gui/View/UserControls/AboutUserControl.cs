using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using kcptun_gui.Controller;

namespace kcptun_gui.View
{
    public partial class AboutUserControl : UserControl
    {
        public AboutUserControl()
        {
            InitializeComponent();
            KcptunVersion.Text = KCPTunnelController.GetKcptunVersion();
        }

        private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }
    }
}
