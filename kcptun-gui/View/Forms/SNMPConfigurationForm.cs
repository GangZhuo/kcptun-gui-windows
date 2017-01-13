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
    public partial class SNMPConfigurationForm : Form
    {
        private MainController controller;
        private Configuration config;
        public SNMPConfigurationForm(MainController controller)
        {
            this.controller = controller;
            config = controller.ConfigController.GetConfigurationCopy();
            InitializeComponent();
            UpdateText();
            controller.ConfigController.SNMPConfigChanged += OnConfigChanged;
        }

        private void UpdateText()
        {
            Text = I18N.GetString("SNMP Configuration");
            EnableCheckBox.Text = I18N.GetString("Enable");
            SNMPLogFileLabel.Text = I18N.GetString("SNMP Log File:");
            SNMPPeriodLabel.Text = I18N.GetString("SNMP Configuration");
            OkButton.Text = I18N.GetString("OK");
            CancelButton.Text = I18N.GetString("Cancel");
        }

        private void SNMPConfigurationForm_Load(object sender, EventArgs e)
        {
            EnableCheckBox.Checked = config.snmp.enabled;
            SNMPLogFileTextBox.Text = config.snmp.snmplog;
            SNMPPeriodNumericUpDown.Value = config.snmp.snmpperiod;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                SNMPConfiguration snmp = new SNMPConfiguration
                {
                    enabled = EnableCheckBox.Checked,
                    snmplog = SNMPLogFileTextBox.Text.Trim(),
                    snmpperiod = (int)SNMPPeriodNumericUpDown.Value
                };
                controller.ConfigController.ChangeSNMPConfig(snmp);
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
            controller.ConfigController.SNMPConfigChanged -= OnConfigChanged;
            base.OnClosing(e);
        }

        private void OnConfigChanged(object sender, EventArgs e)
        {
            Configuration newconfig = controller.ConfigController.GetConfigurationCopy();
            if (EnableCheckBox.Checked == config.snmp.enabled)
                EnableCheckBox.Checked = newconfig.snmp.enabled;
            if (SNMPLogFileTextBox.Text == config.snmp.snmplog)
                SNMPLogFileTextBox.Text = newconfig.snmp.snmplog;
            if (SNMPPeriodNumericUpDown.Value == config.snmp.snmpperiod)
                SNMPPeriodNumericUpDown.Value = newconfig.snmp.snmpperiod;
            config = newconfig;
        }
    }
}
