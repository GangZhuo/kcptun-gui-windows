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
using kcptun_gui.Common;

namespace kcptun_gui.View.Forms
{
    public partial class StatisticsForm : Form
    {
        private MainController controller;

        public StatisticsForm(MainController controller)
        {
            this.controller = controller;
            InitializeComponent();
            controller.ConfigController.ConfigChanged += ConfigController_ConfigChanged;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            EnabledCheckBox.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
            TopMostheckBox.Checked = TopMost;

            timer1.Enabled = true;
            timer1.Start();
        }

        private void ConfigController_ConfigChanged(object sender, EventArgs e)
        {
            if (EnabledCheckBox.InvokeRequired)
            {
                EnabledCheckBox.Invoke(new EventHandler((sender1, e1) => {
                    EnabledCheckBox.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
                }), sender, e);
            }
            else
            {
                EnabledCheckBox.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            controller.ConfigController.ConfigChanged -= ConfigController_ConfigChanged;
            timer1.Enabled = false;
            timer1.Stop();
            base.OnClosing(e);
        }

        private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleStatisticsEnable(EnabledCheckBox.Checked);
        }

        private void TopMostheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostheckBox.Checked;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            controller.rawTrafficStatistics.reset();
            controller.kcpTrafficStatistics.reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateTrafficStatistics();
        }

        private void UpdateTrafficStatistics()
        {
            RawInbound.Text = Utils.FormatSize(controller.rawTrafficStatistics.inboundCounter);
            RawOutbound.Text = Utils.FormatSize(controller.rawTrafficStatistics.outboundCounter);
            KCPInbound.Text = Utils.FormatSize(controller.kcpTrafficStatistics.inboundCounter);
            KCPOutbound.Text = Utils.FormatSize(controller.kcpTrafficStatistics.outboundCounter);
            if (controller.rawTrafficStatistics.inboundCounter > 0)
                InboundPercent.Text = $"Growing {((double)controller.kcpTrafficStatistics.inboundCounter / (double)controller.rawTrafficStatistics.inboundCounter).ToString("F2")} times";
            else
                InboundPercent.Text = "";
            if (controller.rawTrafficStatistics.outboundCounter > 0)
                OutboundPercent.Text = $"Growing {((double)controller.kcpTrafficStatistics.outboundCounter / (double)controller.rawTrafficStatistics.outboundCounter).ToString("F2")} times";
            else
                OutboundPercent.Text = "";
        }
    }
}
