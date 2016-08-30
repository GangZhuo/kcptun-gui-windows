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
using kcptun_gui.Model;

namespace kcptun_gui.View.Forms
{
    public partial class CustomKCPTunForm : Form
    {
        private MainController controller;
        private Configuration config;

        public CustomKCPTunForm(MainController controller)
        {
            this.controller = controller;
            config = controller.ConfigController.GetConfigurationCopy();
            InitializeComponent();
            UpdateText();
            controller.ConfigController.ConfigChanged += OnConfigChanged;
        }

        private void UpdateText()
        {
            Text = I18N.GetString("Set your kcptun path...");
            KcptunClientPathLabel.Text = I18N.GetString("Kcptun Client:");
            BrowserButton.Text = I18N.GetString("Browser");
            OkButton.Text = I18N.GetString("OK");
            MyCancelButton.Text = I18N.GetString("Cancel");
        }

        private void CustomKCPTunForm_Load(object sender, EventArgs e)
        {
            KcpTunPathTextBox.Text = config.kcptun_path;
        }

        private void BrowserButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(KcpTunPathTextBox.Text))
                    openFileDialog1.FileName = KcpTunPathTextBox.Text;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    KcpTunPathTextBox.Text = openFileDialog1.FileName;
                }
            }
            catch(Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                controller.ConfigController.ChangeKCPTunPath(KcpTunPathTextBox.Text.Trim());
                this.Close();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            controller.ConfigController.KCPTunPathChanged -= OnConfigChanged;
            base.OnClosing(e);
        }

        private void OnConfigChanged(object sender, EventArgs e)
        {
            if (KcpTunPathTextBox.Text == config.kcptun_path)
            {
                config = controller.ConfigController.GetConfigurationCopy();
                KcpTunPathTextBox.Text = config.kcptun_path;
            }
            else
            {
                config = controller.ConfigController.GetConfigurationCopy();
            }
        }
    }
}
