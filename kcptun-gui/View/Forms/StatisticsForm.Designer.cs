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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatisticsForm));
            this.EnabledCheckBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.RawGroupBox = new System.Windows.Forms.GroupBox();
            this.KCPGroupBox = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RawInbound = new System.Windows.Forms.Label();
            this.RawOutbound = new System.Windows.Forms.Label();
            this.KCPOutbound = new System.Windows.Forms.Label();
            this.KCPInbound = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ResetButton = new System.Windows.Forms.Button();
            this.TopMostheckBox = new System.Windows.Forms.CheckBox();
            this.InboundPercent = new System.Windows.Forms.Label();
            this.OutboundPercent = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.RawGroupBox.SuspendLayout();
            this.KCPGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnabledCheckBox
            // 
            this.EnabledCheckBox.AutoSize = true;
            this.EnabledCheckBox.Location = new System.Drawing.Point(10, 20);
            this.EnabledCheckBox.Name = "EnabledCheckBox";
            this.EnabledCheckBox.Size = new System.Drawing.Size(65, 17);
            this.EnabledCheckBox.TabIndex = 0;
            this.EnabledCheckBox.Text = "Enabled";
            this.EnabledCheckBox.UseVisualStyleBackColor = true;
            this.EnabledCheckBox.CheckedChanged += new System.EventHandler(this.EnabledCheckBox_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TopMostheckBox);
            this.panel1.Controls.Add(this.ResetButton);
            this.panel1.Controls.Add(this.EnabledCheckBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(567, 57);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 57);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(567, 163);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(567, 163);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // RawGroupBox
            // 
            this.RawGroupBox.Controls.Add(this.RawOutbound);
            this.RawGroupBox.Controls.Add(this.RawInbound);
            this.RawGroupBox.Controls.Add(this.label2);
            this.RawGroupBox.Controls.Add(this.label1);
            this.RawGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RawGroupBox.Location = new System.Drawing.Point(3, 3);
            this.RawGroupBox.Name = "RawGroupBox";
            this.RawGroupBox.Size = new System.Drawing.Size(277, 157);
            this.RawGroupBox.TabIndex = 0;
            this.RawGroupBox.TabStop = false;
            this.RawGroupBox.Text = "Raw";
            // 
            // KCPGroupBox
            // 
            this.KCPGroupBox.Controls.Add(this.OutboundPercent);
            this.KCPGroupBox.Controls.Add(this.InboundPercent);
            this.KCPGroupBox.Controls.Add(this.KCPOutbound);
            this.KCPGroupBox.Controls.Add(this.KCPInbound);
            this.KCPGroupBox.Controls.Add(this.label5);
            this.KCPGroupBox.Controls.Add(this.label6);
            this.KCPGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KCPGroupBox.Location = new System.Drawing.Point(286, 3);
            this.KCPGroupBox.Name = "KCPGroupBox";
            this.KCPGroupBox.Size = new System.Drawing.Size(278, 157);
            this.KCPGroupBox.TabIndex = 1;
            this.KCPGroupBox.TabStop = false;
            this.KCPGroupBox.Text = "KCP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inbound:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Outbound:";
            // 
            // RawInbound
            // 
            this.RawInbound.AutoSize = true;
            this.RawInbound.Location = new System.Drawing.Point(105, 31);
            this.RawInbound.Name = "RawInbound";
            this.RawInbound.Size = new System.Drawing.Size(71, 13);
            this.RawInbound.TabIndex = 2;
            this.RawInbound.Text = "Raw Inbound";
            // 
            // RawOutbound
            // 
            this.RawOutbound.AutoSize = true;
            this.RawOutbound.Location = new System.Drawing.Point(105, 87);
            this.RawOutbound.Name = "RawOutbound";
            this.RawOutbound.Size = new System.Drawing.Size(79, 13);
            this.RawOutbound.TabIndex = 3;
            this.RawOutbound.Text = "Raw Outbound";
            // 
            // KCPOutbound
            // 
            this.KCPOutbound.AutoSize = true;
            this.KCPOutbound.Location = new System.Drawing.Point(105, 87);
            this.KCPOutbound.Name = "KCPOutbound";
            this.KCPOutbound.Size = new System.Drawing.Size(78, 13);
            this.KCPOutbound.TabIndex = 7;
            this.KCPOutbound.Text = "KCP Outbound";
            // 
            // KCPInbound
            // 
            this.KCPInbound.AutoSize = true;
            this.KCPInbound.Location = new System.Drawing.Point(105, 31);
            this.KCPInbound.Name = "KCPInbound";
            this.KCPInbound.Size = new System.Drawing.Size(70, 13);
            this.KCPInbound.TabIndex = 6;
            this.KCPInbound.Text = "KCP Inbound";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 87);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Outbound:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Inbound:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ResetButton.Location = new System.Drawing.Point(436, 10);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(110, 37);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset Statistics";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // TopMostheckBox
            // 
            this.TopMostheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TopMostheckBox.AutoSize = true;
            this.TopMostheckBox.Location = new System.Drawing.Point(315, 20);
            this.TopMostheckBox.Name = "TopMostheckBox";
            this.TopMostheckBox.Size = new System.Drawing.Size(70, 17);
            this.TopMostheckBox.TabIndex = 2;
            this.TopMostheckBox.Text = "Top most";
            this.TopMostheckBox.UseVisualStyleBackColor = true;
            this.TopMostheckBox.CheckedChanged += new System.EventHandler(this.TopMostheckBox_CheckedChanged);
            // 
            // InboundPercent
            // 
            this.InboundPercent.AutoSize = true;
            this.InboundPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.InboundPercent.ForeColor = System.Drawing.Color.DimGray;
            this.InboundPercent.Location = new System.Drawing.Point(105, 52);
            this.InboundPercent.Name = "InboundPercent";
            this.InboundPercent.Size = new System.Drawing.Size(124, 13);
            this.InboundPercent.TabIndex = 8;
            this.InboundPercent.Text = " 0% bigger than raw data";
            // 
            // OutboundPercent
            // 
            this.OutboundPercent.AutoSize = true;
            this.OutboundPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.OutboundPercent.ForeColor = System.Drawing.Color.DimGray;
            this.OutboundPercent.Location = new System.Drawing.Point(105, 108);
            this.OutboundPercent.Name = "OutboundPercent";
            this.OutboundPercent.Size = new System.Drawing.Size(124, 13);
            this.OutboundPercent.TabIndex = 8;
            this.OutboundPercent.Text = " 0% bigger than raw data";
            // 
            // StatisticsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 407);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StatisticsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Traffic Statistics";
            this.Load += new System.EventHandler(this.StatisticsForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.RawGroupBox.ResumeLayout(false);
            this.RawGroupBox.PerformLayout();
            this.KCPGroupBox.ResumeLayout(false);
            this.KCPGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox EnabledCheckBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox RawGroupBox;
        private System.Windows.Forms.GroupBox KCPGroupBox;
        private System.Windows.Forms.Label RawOutbound;
        private System.Windows.Forms.Label RawInbound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label KCPOutbound;
        private System.Windows.Forms.Label KCPInbound;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.CheckBox TopMostheckBox;
        private System.Windows.Forms.Label InboundPercent;
        private System.Windows.Forms.Label OutboundPercent;
    }
}