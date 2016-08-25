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
using TrafficLog = kcptun_gui.Controller.MainController.TrafficLog;

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
            controller.TrafficChanged += Controller_TrafficChanged;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = EnabledCheckBox.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
            topMostToolStripMenuItem.Checked = TopMostheckBox.Checked = TopMost;
            toolbarToolStripMenuItem.Checked = ToolbarPanel.Visible = false;

            SpeedStatusLabel.Text = "";

            timer1.Enabled = true;
            timer1.Start();
        }

        private void ConfigController_ConfigChanged(object sender, EventArgs e)
        {
            if (EnabledCheckBox.InvokeRequired)
            {
                EnabledCheckBox.Invoke(new EventHandler((sender1, e1) => {
                    enabledToolStripMenuItem.Checked = EnabledCheckBox.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
                    //topMostToolStripMenuItem.Checked = TopMostheckBox.Checked = TopMost;
                }), sender, e);
            }
            else
            {
                enabledToolStripMenuItem.Checked = EnabledCheckBox.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
                //topMostToolStripMenuItem.Checked = TopMostheckBox.Checked = TopMost;
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            controller.TrafficChanged -= Controller_TrafficChanged;
            controller.ConfigController.ConfigChanged -= ConfigController_ConfigChanged;
            timer1.Enabled = false;
            timer1.Stop();
            base.OnClosing(e);
        }

        private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleStatisticsEnable(EnabledCheckBox.Checked);
        }

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleStatisticsEnable(!EnabledCheckBox.Checked);
        }

        private void TopMostheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = TopMostheckBox.Checked;
            topMostToolStripMenuItem.Checked = TopMost;
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            topMostToolStripMenuItem.Checked = TopMostheckBox.Checked = TopMost;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.rawTrafficStatistics.reset();
            controller.kcpTrafficStatistics.reset();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolbarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolbarToolStripMenuItem.Checked = ToolbarPanel.Visible = !ToolbarPanel.Visible;
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            controller.rawTrafficStatistics.reset();
            controller.kcpTrafficStatistics.reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler((sender2, e2) =>
                {
                    UpdateTrafficChart();
                }), sender, e);
            }
            else
            {
                UpdateTrafficStatistics();
            }
        }

        private void UpdateTrafficStatistics()
        {
            RawInbound.Text = Utils.FormatSize(controller.rawTrafficStatistics.inboundCounter);
            RawOutbound.Text = Utils.FormatSize(controller.rawTrafficStatistics.outboundCounter);
            KCPInbound.Text = Utils.FormatSize(controller.kcpTrafficStatistics.inboundCounter);
            KCPOutbound.Text = Utils.FormatSize(controller.kcpTrafficStatistics.outboundCounter);
            if (controller.rawTrafficStatistics.inboundCounter > 0)
                InboundPercent.Text = $"{((double)controller.kcpTrafficStatistics.inboundCounter / (double)controller.rawTrafficStatistics.inboundCounter).ToString("F2")} times";
            else
                InboundPercent.Text = "";
            if (controller.rawTrafficStatistics.outboundCounter > 0)
                OutboundPercent.Text = $"{((double)controller.kcpTrafficStatistics.outboundCounter / (double)controller.rawTrafficStatistics.outboundCounter).ToString("F2")} times";
            else
                OutboundPercent.Text = "";
        }

        private void Controller_TrafficChanged(object sender, EventArgs e)
        {
            if (TrafficChart.InvokeRequired)
            {
                TrafficChart.Invoke(new EventHandler((sender2, e2) =>
                {
                    UpdateTrafficChart();
                }), sender, e);
            }
            else
            {
                UpdateTrafficChart();
            }
        }

        private List<float> rawInboundPoints = new List<float>();
        private List<float> rawOutboundPoints = new List<float>();
        private List<float> kcpInboundPoints = new List<float>();
        private List<float> kcpOutboundPoints = new List<float>();
        private string[] units = new string[] { "B", "KiB", "MiB", "GiB" };

        private void UpdateTrafficChart()
        {
            TrafficLog previous = null;
            int i = 0;
            long maxSpeedValue = 0;
            rawInboundPoints.Clear();
            rawOutboundPoints.Clear();
            kcpInboundPoints.Clear();
            kcpOutboundPoints.Clear();
            foreach (TrafficLog item in controller.trafficLogList)
            {
                if (previous == null)
                {
                    rawInboundPoints.Add(item.raw.inboundCounter);
                    rawOutboundPoints.Add(item.raw.outboundCounter);
                    kcpInboundPoints.Add(item.kcp.inboundCounter);
                    kcpOutboundPoints.Add(item.kcp.outboundCounter);
                }
                else
                {
                    rawInboundPoints.Add(item.raw.inboundCounter - previous.raw.inboundCounter);
                    rawOutboundPoints.Add(item.raw.outboundCounter - previous.raw.outboundCounter);
                    kcpInboundPoints.Add(item.kcp.inboundCounter - previous.kcp.inboundCounter);
                    kcpOutboundPoints.Add(item.kcp.outboundCounter - previous.kcp.outboundCounter);
                }

                maxSpeedValue = Math.Max(maxSpeedValue,
                    Math.Max(
                        (long)Math.Max(rawInboundPoints[i], rawOutboundPoints[i]),
                        (long)Math.Max(kcpInboundPoints[i], kcpOutboundPoints[i])
                    )
                );

                previous = item;
                i++;
            }

            MySize maxSpeed = new MySize(maxSpeedValue);

            if (rawInboundPoints.Count > 0)
            {
                i = rawInboundPoints.Count - 1;
                SpeedStatusLabel.Text = SpeedStatusLabel.ToolTipText
                    = $"Raw: [In {new MySize((long)rawInboundPoints[i]).ToString()}/s Out {new MySize((long)rawOutboundPoints[i]).ToString()}/s] KCP: [In {new MySize((long)kcpInboundPoints[i]).ToString()}/s Out {new MySize((long)kcpOutboundPoints[i]).ToString()}/s]";
            }

            for (i = 0; i < rawInboundPoints.Count; i++)
            {
                rawInboundPoints[i] /= maxSpeed.scale;
                rawOutboundPoints[i] /= maxSpeed.scale;
                kcpInboundPoints[i] /= maxSpeed.scale;
                kcpOutboundPoints[i] /= maxSpeed.scale;
            }

            TrafficChart.Series["Raw Inbound"].Points.DataBindY(rawInboundPoints);
            TrafficChart.Series["Raw Outbound"].Points.DataBindY(rawOutboundPoints);
            TrafficChart.Series["KCP Inbound"].Points.DataBindY(kcpInboundPoints);
            TrafficChart.Series["KCP Outbound"].Points.DataBindY(kcpOutboundPoints);
            TrafficChart.Series["Raw Inbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
            TrafficChart.Series["Raw Outbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
            TrafficChart.Series["KCP Inbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
            TrafficChart.Series["KCP Outbound"].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
            TrafficChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0:0.##} " + maxSpeed.unit;

        }


    }
}
