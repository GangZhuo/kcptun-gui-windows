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
        public string KCPTunVersion
        {
            get { return KcptunVersion.Text; }
            set { KcptunVersion.Text = value; }
        }

        public AboutUserControl()
        {
            InitializeComponent();
            UpdateText();
            GUIVersion.Text = I18N.GetString("GUI version ") + UpdateChecker.GUI_VERSION;
        }

        private void UpdateText()
        {
            AboutLabel.Text = I18N.GetString("GUI for kcptun.");
            HomePageLabel.Text = I18N.GetString("Report GUI issues to");
            KcptunHomePageLabel.Text = I18N.GetString("Report kcptun issues to");
        }

        private void OnLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }
    }
}
