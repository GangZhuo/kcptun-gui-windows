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
            UpdateText();
            TrafficChart.Resize += TrafficChart_Resize;

            controller.ConfigController.ConfigChanged += ConfigController_ConfigChanged;
            controller.TrafficChanged += Controller_TrafficChanged;
        }

        private void UpdateText()
        {
            Text = I18N.GetString("Traffic Statistics");
            fileToolStripMenuItem.Text = I18N.GetString("File");
            viewToolStripMenuItem.Text = I18N.GetString("View");
            chartToolStripMenuItem.Text = I18N.GetString("Chart");

            enabledToolStripMenuItem.Text = I18N.GetString("Enable");
            resetToolStripMenuItem.Text = I18N.GetString("Reset");
            exitToolStripMenuItem.Text = I18N.GetString("Exit");
            topMostToolStripMenuItem.Text = I18N.GetString("Top Most");
            minutesMenuItem_1.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 1);
            minutesMenuItem_2.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 2);
            minutesMenuItem_3.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 3);
            minutesMenuItem_4.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 4);
            minutesMenuItem_5.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 5);
            minutesMenuItem_10.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 10);
            minutesMenuItem_15.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 15);
            minutesMenuItem_30.Text = string.Format(I18N.GetString("Display data for last {0} minutes"), 30);
            resetChartToolStripMenuItem.Text = I18N.GetString("Reset Chart");
            RawGroupBox.Text = I18N.GetString("Raw");
            KCPGroupBox.Text = I18N.GetString("KCP");
            TrafficChartGroupBox.Text = I18N.GetString("Traffic Chart");
            RawInboundLabel.Text = I18N.GetString("Inbound:");
            RawOutboundLabel.Text = I18N.GetString("Outbound:");
            KCPInboundLabel.Text = I18N.GetString("Inbound:");
            KCPOutboundLabel.Text = I18N.GetString("Outbound:");
            TrafficChart.Series[0].LegendText = I18N.GetString("Raw Inbound");
            TrafficChart.Series[1].LegendText = I18N.GetString("Raw Outbound");
            TrafficChart.Series[2].LegendText = I18N.GetString("KCP Inbound");
            TrafficChart.Series[3].LegendText = I18N.GetString("KCP Outbound");
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            enabledToolStripMenuItem.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
            topMostToolStripMenuItem.Checked = TopMost;

            refreshChartToolStripMenuItems();

            SpeedStatusLabel.Text = "";

            timer1.Enabled = true;
            timer1.Start();
        }

        private void refreshChartToolStripMenuItems()
        {
            foreach (ToolStripItem item in chartToolStripMenuItem.DropDownItems)
            {
                if (item is MyToolStripMenuItem)
                {
                    ((MyToolStripMenuItem)item).Checked = (((MyToolStripMenuItem)item).TrafficLogSize == controller.trafficLogSize);
                }
            }
        }

        private void ConfigController_ConfigChanged(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler((sender1, e1) =>
                {
                    enabledToolStripMenuItem.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
                }), sender, e);
            }
            else
            {
                enabledToolStripMenuItem.Checked = controller.ConfigController.GetConfigurationCopy().statistics_enabled;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (Height <= 280)
            {
                panel2.Visible = false;
                menuStrip1.Visible = false;
                statusStrip1.Visible = false;
            }
            else
            {
                panel2.Visible = true;
                menuStrip1.Visible = true;
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

        private void enabledToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleStatisticsEnable(!enabledToolStripMenuItem.Checked);
        }

        private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TopMost = !TopMost;
            topMostToolStripMenuItem.Checked = TopMost;
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
                InboundPercent.Text = string.Format(I18N.GetString("{0} times"), ((double)controller.traffic.kcp.inbound / (double)controller.traffic.raw.inbound).ToString("F2"));
            else
                InboundPercent.Text = "";
            if (controller.traffic.raw.outbound > 0)
                OutboundPercent.Text = string.Format(I18N.GetString("{0} times"), ((double)controller.traffic.kcp.outbound / (double)controller.traffic.raw.outbound).ToString("F2"));
            else
                OutboundPercent.Text = "";
            if ((controller.traffic.raw.inbound + controller.traffic.raw.outbound) > 0)
                TotalTimes.Text = string.Format(I18N.GetString("Total {0} times"), ((double)(controller.traffic.kcp.inbound + controller.traffic.kcp.outbound) / (double)(controller.traffic.raw.inbound + controller.traffic.raw.outbound)).ToString("F2"));
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
                = string.Format(I18N.GetString("Raw: [In {0}, Out {1}], KCP: [In {2}, Out {3}]"),
                new TrafficSpeed(last.rawSpeed.inbound),
                new TrafficSpeed(last.rawSpeed.outbound),
                new TrafficSpeed(last.kcpSpeed.inbound),
                new TrafficSpeed(last.kcpSpeed.outbound));

            for (int i = 0; i < rawInboundPoints.Count; i++)
            {
                rawInboundPoints[i] /= maxSpeed.scale;
                rawOutboundPoints[i] /= maxSpeed.scale;
                kcpInboundPoints[i] /= maxSpeed.scale;
                kcpOutboundPoints[i] /= maxSpeed.scale;
            }

            TrafficChart.Series[0].Points.DataBindY(rawInboundPoints);
            TrafficChart.Series[1].Points.DataBindY(rawOutboundPoints);
            TrafficChart.Series[2].Points.DataBindY(kcpInboundPoints);
            TrafficChart.Series[3].Points.DataBindY(kcpOutboundPoints);
            TrafficChart.Series[0].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
            TrafficChart.Series[1].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
            TrafficChart.Series[2].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
            TrafficChart.Series[3].ToolTip = "#SERIESNAME #VALY{F2} " + maxSpeed.unit;
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

        private void resetChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.ClearTrafficList();
        }
    }

    class MyToolStripMenuItem : ToolStripMenuItem
    {
        public int TrafficLogSize { get; set; } = 60;
    }

}
