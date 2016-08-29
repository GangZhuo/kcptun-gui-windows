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
using kcptun_gui.Model;

namespace kcptun_gui.View.Forms
{
    public partial class StatisticsForm : Form
    {
        private MainController controller;

        public StatisticsForm(MainController controller)
        {
            this.controller = controller;
            InitializeComponent();
            TrafficChart.Resize += TrafficChart_Resize;

            controller.ConfigController.ConfigChanged += ConfigController_ConfigChanged;
            controller.TrafficChanged += Controller_TrafficChanged;
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = EnabledCheckBox.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
            topMostToolStripMenuItem.Checked = TopMostheckBox.Checked = TopMost;
            toolbarToolStripMenuItem.Checked = ToolbarPanel.Visible = false;

            refreshChartToolStripMenuItems();

            SpeedStatusLabel.Text = "";

            timer1.Enabled = true;
            timer1.Start();
        }

        private void refreshChartToolStripMenuItems()
        {
            foreach (MyToolStripMenuItem item in chartToolStripMenuItem.DropDownItems)
            {
                item.Checked = (item.TrafficLogSize == controller.trafficLogSize);
            }
        }

        private void ConfigController_ConfigChanged(object sender, EventArgs e)
        {
            if (EnabledCheckBox.InvokeRequired)
            {
                EnabledCheckBox.Invoke(new EventHandler((sender1, e1) =>
                {
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

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (Height <= 280)
            {
                panel2.Visible = false;
                menuStrip1.Visible = false;
                ToolbarPanel.Visible = false;
                statusStrip1.Visible = false;
            }
            else
            {
                panel2.Visible = true;
                menuStrip1.Visible = true;
                ToolbarPanel.Visible = toolbarToolStripMenuItem.Checked;
                statusStrip1.Visible = true;
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

        private void TrafficChart_Resize(object sender, EventArgs e)
        {
            if (TrafficChart.Height <= 80)
            {
                TrafficChart.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            }
            else
            {
                TrafficChart.Legends[0].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Right;
            }
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
            controller.traffic.raw.reset();
            controller.traffic.kcp.reset();
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
            controller.traffic.raw.reset();
            controller.traffic.kcp.reset();
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
            RawInbound.Text = Utils.FormatSize(controller.traffic.raw.inbound);
            RawOutbound.Text = Utils.FormatSize(controller.traffic.raw.outbound);
            KCPInbound.Text = Utils.FormatSize(controller.traffic.kcp.inbound);
            KCPOutbound.Text = Utils.FormatSize(controller.traffic.kcp.outbound);
            if (controller.traffic.raw.inbound > 0)
                InboundPercent.Text = $"{((double)controller.traffic.kcp.inbound / (double)controller.traffic.raw.inbound).ToString("F2")} times";
            else
                InboundPercent.Text = "";
            if (controller.traffic.raw.outbound > 0)
                OutboundPercent.Text = $"{((double)controller.traffic.kcp.outbound / (double)controller.traffic.raw.outbound).ToString("F2")} times";
            else
                OutboundPercent.Text = "";
            if ((controller.traffic.raw.inbound + controller.traffic.raw.outbound) > 0)
                TotalTimes.Text = $"Total {((double)(controller.traffic.kcp.inbound + controller.traffic.kcp.outbound) / (double)(controller.traffic.raw.inbound + controller.traffic.raw.outbound)).ToString("F2")} times";
            else
                TotalTimes.Text = "";
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

        private void UpdateTrafficChart()
        {
            long maxSpeedValue = 0;
            rawInboundPoints.Clear();
            rawOutboundPoints.Clear();
            kcpInboundPoints.Clear();
            kcpOutboundPoints.Clear();
            foreach (TrafficLog item in controller.trafficLogList)
            {
                rawInboundPoints.Add(item.rawSpeed.inbound);
                rawOutboundPoints.Add(item.rawSpeed.outbound);
                kcpInboundPoints.Add(item.kcpSpeed.inbound);
                kcpOutboundPoints.Add(item.kcpSpeed.outbound);

                maxSpeedValue = Math.Max(maxSpeedValue,
                    Math.Max(
                        Math.Max(item.rawSpeed.inbound, item.rawSpeed.outbound),
                        Math.Max(item.kcpSpeed.inbound, item.kcpSpeed.outbound)
                    )
                );
            }

            TrafficSpeed maxSpeed = new TrafficSpeed(maxSpeedValue);
            TrafficLog last = controller.trafficLogList.Last.Value;
            SpeedStatusLabel.Text = SpeedStatusLabel.ToolTipText
                = $"Raw: [In {new TrafficSpeed(last.rawSpeed.inbound)}, Out {new TrafficSpeed(last.rawSpeed.outbound)}], KCP: [In {new TrafficSpeed(last.kcpSpeed.inbound)}, Out {new TrafficSpeed(last.kcpSpeed.outbound)}]";

            for (int i = 0; i < rawInboundPoints.Count; i++)
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

        private void minutesMenuItem_Click(object sender, EventArgs e)
        {
            MyToolStripMenuItem menuitem = sender as MyToolStripMenuItem;
            if (menuitem != null)
            {
                controller.trafficLogSize = menuitem.TrafficLogSize;
                refreshChartToolStripMenuItems();
            }
        }
    }

    class MyToolStripMenuItem : ToolStripMenuItem
    {
        public int TrafficLogSize { get; set; } = 60;
    }

}
