namespace kcptun_gui.View.Forms
{
    partial class StatisticsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RawGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.RawInboundLabel = new System.Windows.Forms.Label();
            this.RawInbound = new System.Windows.Forms.Label();
            this.RawOutboundLabel = new System.Windows.Forms.Label();
            this.RawOutbound = new System.Windows.Forms.Label();
            this.TotalTimes = new System.Windows.Forms.Label();
            this.KCPGroupBox = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.OutboundPercent = new System.Windows.Forms.Label();
            this.KCPInboundLabel = new System.Windows.Forms.Label();
            this.KCPOutboundLabel = new System.Windows.Forms.Label();
            this.InboundPercent = new System.Windows.Forms.Label();
            this.KCPOutbound = new System.Windows.Forms.Label();
            this.KCPInbound = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enabledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topMostToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TrafficChartGroupBox = new System.Windows.Forms.GroupBox();
            this.TrafficChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.SpeedStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.minutesMenuItem_1 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.minutesMenuItem_2 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.minutesMenuItem_3 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.minutesMenuItem_4 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.minutesMenuItem_5 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.minutesMenuItem_10 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.minutesMenuItem_15 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.minutesMenuItem_30 = new kcptun_gui.View.Forms.MyToolStripMenuItem();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.RawGroupBox.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.KCPGroupBox.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.TrafficChartGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(442, 105);
            this.panel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.RawGroupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.KCPGroupBox, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 105F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(442, 105);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RawGroupBox
            // 
            this.RawGroupBox.Controls.Add(this.tableLayoutPanel2);
            this.RawGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawGroupBox.Location = new System.Drawing.Point(3, 3);
            this.RawGroupBox.Name = "RawGroupBox";
            this.RawGroupBox.Size = new System.Drawing.Size(215, 99);
            this.RawGroupBox.TabIndex = 0;
            this.RawGroupBox.TabStop = false;
            this.RawGroupBox.Text = "Raw";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel2.Controls.Add(this.RawInboundLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.RawInbound, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.RawOutboundLabel, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.RawOutbound, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.TotalTimes, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(209, 80);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // RawInboundLabel
            // 
            this.RawInboundLabel.AutoEllipsis = true;
            this.RawInboundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawInboundLabel.Location = new System.Drawing.Point(3, 0);
            this.RawInboundLabel.Name = "RawInboundLabel";
            this.RawInboundLabel.Size = new System.Drawing.Size(62, 20);
            this.RawInboundLabel.TabIndex = 0;
            this.RawInboundLabel.Text = "Inbound:";
            this.RawInboundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RawInbound
            // 
            this.RawInbound.AutoEllipsis = true;
            this.RawInbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawInbound.Location = new System.Drawing.Point(71, 0);
            this.RawInbound.Name = "RawInbound";
            this.RawInbound.Size = new System.Drawing.Size(135, 20);
            this.RawInbound.TabIndex = 2;
            this.RawInbound.Text = "Raw Inbound";
            this.RawInbound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RawOutboundLabel
            // 
            this.RawOutboundLabel.AutoEllipsis = true;
            this.RawOutboundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawOutboundLabel.Location = new System.Drawing.Point(3, 40);
            this.RawOutboundLabel.Name = "RawOutboundLabel";
            this.RawOutboundLabel.Size = new System.Drawing.Size(62, 20);
            this.RawOutboundLabel.TabIndex = 1;
            this.RawOutboundLabel.Text = "Outbound:";
            this.RawOutboundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RawOutbound
            // 
            this.RawOutbound.AutoEllipsis = true;
            this.RawOutbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawOutbound.Location = new System.Drawing.Point(71, 40);
            this.RawOutbound.Name = "RawOutbound";
            this.RawOutbound.Size = new System.Drawing.Size(135, 20);
            this.RawOutbound.TabIndex = 3;
            this.RawOutbound.Text = "Raw Outbound";
            this.RawOutbound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TotalTimes
            // 
            this.TotalTimes.AutoEllipsis = true;
            this.TotalTimes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TotalTimes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TotalTimes.ForeColor = System.Drawing.Color.DimGray;
            this.TotalTimes.Location = new System.Drawing.Point(71, 60);
            this.TotalTimes.Name = "TotalTimes";
            this.TotalTimes.Size = new System.Drawing.Size(135, 20);
            this.TotalTimes.TabIndex = 9;
            this.TotalTimes.Text = "total 1.0 times";
            this.TotalTimes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KCPGroupBox
            // 
            this.KCPGroupBox.Controls.Add(this.tableLayoutPanel3);
            this.KCPGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KCPGroupBox.Location = new System.Drawing.Point(224, 3);
            this.KCPGroupBox.Name = "KCPGroupBox";
            this.KCPGroupBox.Size = new System.Drawing.Size(215, 99);
            this.KCPGroupBox.TabIndex = 1;
            this.KCPGroupBox.TabStop = false;
            this.KCPGroupBox.Text = "KCP";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67F));
            this.tableLayoutPanel3.Controls.Add(this.OutboundPercent, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.KCPInboundLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.KCPOutboundLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.InboundPercent, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.KCPOutbound, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.KCPInbound, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(209, 80);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // OutboundPercent
            // 
            this.OutboundPercent.AutoEllipsis = true;
            this.OutboundPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutboundPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OutboundPercent.ForeColor = System.Drawing.Color.DimGray;
            this.OutboundPercent.Location = new System.Drawing.Point(71, 60);
            this.OutboundPercent.Name = "OutboundPercent";
            this.OutboundPercent.Size = new System.Drawing.Size(135, 20);
            this.OutboundPercent.TabIndex = 8;
            this.OutboundPercent.Text = "1.0 times";
            this.OutboundPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KCPInboundLabel
            // 
            this.KCPInboundLabel.AutoEllipsis = true;
            this.KCPInboundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KCPInboundLabel.Location = new System.Drawing.Point(3, 0);
            this.KCPInboundLabel.Name = "KCPInboundLabel";
            this.KCPInboundLabel.Size = new System.Drawing.Size(62, 20);
            this.KCPInboundLabel.TabIndex = 4;
            this.KCPInboundLabel.Text = "Inbound:";
            this.KCPInboundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KCPOutboundLabel
            // 
            this.KCPOutboundLabel.AutoEllipsis = true;
            this.KCPOutboundLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KCPOutboundLabel.Location = new System.Drawing.Point(3, 40);
            this.KCPOutboundLabel.Name = "KCPOutboundLabel";
            this.KCPOutboundLabel.Size = new System.Drawing.Size(62, 20);
            this.KCPOutboundLabel.TabIndex = 5;
            this.KCPOutboundLabel.Text = "Outbound:";
            this.KCPOutboundLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InboundPercent
            // 
            this.InboundPercent.AutoEllipsis = true;
            this.InboundPercent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InboundPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InboundPercent.ForeColor = System.Drawing.Color.DimGray;
            this.InboundPercent.Location = new System.Drawing.Point(71, 20);
            this.InboundPercent.Name = "InboundPercent";
            this.InboundPercent.Size = new System.Drawing.Size(135, 20);
            this.InboundPercent.TabIndex = 8;
            this.InboundPercent.Text = "1.0 times";
            this.InboundPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KCPOutbound
            // 
            this.KCPOutbound.AutoEllipsis = true;
            this.KCPOutbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KCPOutbound.Location = new System.Drawing.Point(71, 40);
            this.KCPOutbound.Name = "KCPOutbound";
            this.KCPOutbound.Size = new System.Drawing.Size(135, 20);
            this.KCPOutbound.TabIndex = 7;
            this.KCPOutbound.Text = "KCP Outbound";
            this.KCPOutbound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KCPInbound
            // 
            this.KCPInbound.AutoEllipsis = true;
            this.KCPInbound.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KCPInbound.Location = new System.Drawing.Point(71, 0);
            this.KCPInbound.Name = "KCPInbound";
            this.KCPInbound.Size = new System.Drawing.Size(135, 20);
            this.KCPInbound.TabIndex = 6;
            this.KCPInbound.Text = "KCP Inbound";
            this.KCPInbound.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.chartToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(442, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.enabledToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // enabledToolStripMenuItem
            // 
            this.enabledToolStripMenuItem.Name = "enabledToolStripMenuItem";
            this.enabledToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.enabledToolStripMenuItem.Text = "Enabled";
            this.enabledToolStripMenuItem.Click += new System.EventHandler(this.enabledToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.topMostToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // topMostToolStripMenuItem
            // 
            this.topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
            this.topMostToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.topMostToolStripMenuItem.Text = "Top most";
            this.topMostToolStripMenuItem.Click += new System.EventHandler(this.topMostToolStripMenuItem_Click);
            // 
            // chartToolStripMenuItem
            // 
            this.chartToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.minutesMenuItem_1,
            this.minutesMenuItem_2,
            this.minutesMenuItem_3,
            this.minutesMenuItem_4,
            this.minutesMenuItem_5,
            this.minutesMenuItem_10,
            this.minutesMenuItem_15,
            this.minutesMenuItem_30});
            this.chartToolStripMenuItem.Name = "chartToolStripMenuItem";
            this.chartToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.chartToolStripMenuItem.Text = "Chart";
            // 
            // TrafficChartGroupBox
            // 
            this.TrafficChartGroupBox.Controls.Add(this.TrafficChart);
            this.TrafficChartGroupBox.Controls.Add(this.statusStrip1);
            this.TrafficChartGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TrafficChartGroupBox.Location = new System.Drawing.Point(0, 129);
            this.TrafficChartGroupBox.Name = "TrafficChartGroupBox";
            this.TrafficChartGroupBox.Size = new System.Drawing.Size(442, 203);
            this.TrafficChartGroupBox.TabIndex = 5;
            this.TrafficChartGroupBox.TabStop = false;
            this.TrafficChartGroupBox.Text = "Traffic Chart";
            // 
            // TrafficChart
            // 
            this.TrafficChart.BackColor = System.Drawing.Color.Transparent;
            chartArea1.AxisX.LabelStyle.Enabled = false;
            chartArea1.AxisX.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX.MajorGrid.Interval = 3D;
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisX2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisX2.MajorGrid.Enabled = false;
            chartArea1.AxisX2.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX2.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount;
            chartArea1.AxisY.LabelAutoFitMaxFontSize = 8;
            chartArea1.AxisY.LabelStyle.Interval = 0D;
            chartArea1.AxisY.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.LineColor = System.Drawing.Color.DimGray;
            chartArea1.AxisY2.MajorGrid.LineColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisY2.MajorTickMark.Enabled = false;
            chartArea1.AxisY2.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.TrafficChart.ChartAreas.Add(chartArea1);
            this.TrafficChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Font = new System.Drawing.Font("Consolas", 8F);
            legend1.IsTextAutoFit = false;
            legend1.MaximumAutoSize = 80F;
            legend1.Name = "Legend1";
            this.TrafficChart.Legends.Add(legend1);
            this.TrafficChart.Location = new System.Drawing.Point(3, 16);
            this.TrafficChart.Name = "TrafficChart";
            this.TrafficChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Font = new System.Drawing.Font("Consolas", 8F);
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Raw Inbound";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Font = new System.Drawing.Font("Consolas", 8F);
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Raw Outbound";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Font = new System.Drawing.Font("Consolas", 8F);
            series3.IsXValueIndexed = true;
            series3.Legend = "Legend1";
            series3.Name = "KCP Inbound";
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Font = new System.Drawing.Font("Consolas", 8F);
            series4.IsXValueIndexed = true;
            series4.Legend = "Legend1";
            series4.Name = "KCP Outbound";
            this.TrafficChart.Series.Add(series1);
            this.TrafficChart.Series.Add(series2);
            this.TrafficChart.Series.Add(series3);
            this.TrafficChart.Series.Add(series4);
            this.TrafficChart.Size = new System.Drawing.Size(436, 162);
            this.TrafficChart.TabIndex = 0;
            this.TrafficChart.Text = "Traffic Chart";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SpeedStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(3, 178);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(436, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // SpeedStatusLabel
            // 
            this.SpeedStatusLabel.AutoToolTip = true;
            this.SpeedStatusLabel.Name = "SpeedStatusLabel";
            this.SpeedStatusLabel.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.SpeedStatusLabel.Size = new System.Drawing.Size(70, 17);
            this.SpeedStatusLabel.Text = "Speed Label";
            this.SpeedStatusLabel.ToolTipText = "Speed";
            // 
            // minutesMenuItem_1
            // 
            this.minutesMenuItem_1.Name = "minutesMenuItem_1";
            this.minutesMenuItem_1.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_1.Text = "Display data for last 1 minutes";
            this.minutesMenuItem_1.TrafficLogSize = 60;
            this.minutesMenuItem_1.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // minutesMenuItem_2
            // 
            this.minutesMenuItem_2.Name = "minutesMenuItem_2";
            this.minutesMenuItem_2.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_2.Text = "Display data for last 2 minutes";
            this.minutesMenuItem_2.TrafficLogSize = 120;
            this.minutesMenuItem_2.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // minutesMenuItem_3
            // 
            this.minutesMenuItem_3.Name = "minutesMenuItem_3";
            this.minutesMenuItem_3.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_3.Text = "Display data for last 3 minutes";
            this.minutesMenuItem_3.TrafficLogSize = 180;
            this.minutesMenuItem_3.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // minutesMenuItem_4
            // 
            this.minutesMenuItem_4.Name = "minutesMenuItem_4";
            this.minutesMenuItem_4.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_4.Text = "Display data for last 4 minutes";
            this.minutesMenuItem_4.TrafficLogSize = 240;
            this.minutesMenuItem_4.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // minutesMenuItem_5
            // 
            this.minutesMenuItem_5.Name = "minutesMenuItem_5";
            this.minutesMenuItem_5.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_5.Text = "Display data for last 5 minutes";
            this.minutesMenuItem_5.TrafficLogSize = 300;
            this.minutesMenuItem_5.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // minutesMenuItem_10
            // 
            this.minutesMenuItem_10.Name = "minutesMenuItem_10";
            this.minutesMenuItem_10.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_10.Text = "Display data for last 10 minutes";
            this.minutesMenuItem_10.TrafficLogSize = 600;
            this.minutesMenuItem_10.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // minutesMenuItem_15
            // 
            this.minutesMenuItem_15.Name = "minutesMenuItem_15";
            this.minutesMenuItem_15.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_15.Text = "Display data for last 15 minutes";
            this.minutesMenuItem_15.TrafficLogSize = 900;
            this.minutesMenuItem_15.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // minutesMenuItem_30
            // 
            this.minutesMenuItem_30.Name = "minutesMenuItem_30";
            this.minutesMenuItem_30.Size = new System.Drawing.Size(238, 22);
            this.minutesMenuItem_30.Text = "Display data for last 30 minutes";
            this.minutesMenuItem_30.TrafficLogSize = 1800;
            this.minutesMenuItem_30.Click += new System.EventHandler(this.minutesMenuItem_Click);
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 332);
            this.Controls.Add(this.TrafficChartGroupBox);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.RawGroupBox.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.KCPGroupBox.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.TrafficChartGroupBox.ResumeLayout(false);
            this.TrafficChartGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrafficChart)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox RawGroupBox;
        private System.Windows.Forms.GroupBox KCPGroupBox;
        private System.Windows.Forms.Label RawOutbound;
        private System.Windows.Forms.Label RawInbound;
        private System.Windows.Forms.Label RawOutboundLabel;
        private System.Windows.Forms.Label RawInboundLabel;
        private System.Windows.Forms.Label KCPOutbound;
        private System.Windows.Forms.Label KCPInbound;
        private System.Windows.Forms.Label KCPOutboundLabel;
        private System.Windows.Forms.Label KCPInboundLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label InboundPercent;
        private System.Windows.Forms.Label OutboundPercent;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enabledToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topMostToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.GroupBox TrafficChartGroupBox;
        private System.Windows.Forms.DataVisualization.Charting.Chart TrafficChart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel SpeedStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem chartToolStripMenuItem;
        private MyToolStripMenuItem minutesMenuItem_1;
        private MyToolStripMenuItem minutesMenuItem_2;
        private MyToolStripMenuItem minutesMenuItem_3;
        private MyToolStripMenuItem minutesMenuItem_4;
        private MyToolStripMenuItem minutesMenuItem_5;
        private MyToolStripMenuItem minutesMenuItem_10;
        private MyToolStripMenuItem minutesMenuItem_15;
        private MyToolStripMenuItem minutesMenuItem_30;
        private System.Windows.Forms.Label TotalTimes;
    }
}