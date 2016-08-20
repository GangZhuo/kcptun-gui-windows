namespace kcptun_gui.View
{
    partial class AboutUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.GUIVersion = new System.Windows.Forms.Label();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.KcptunVersion = new System.Windows.Forms.Label();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.HomePageLabel = new System.Windows.Forms.Label();
            this.kcptunHomePageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.KcptunHomePageLabel = new System.Windows.Forms.Label();
            this.HomePageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.GUIVersion);
            this.panel1.Controls.Add(this.LogoPictureBox);
            this.panel1.Controls.Add(this.KcptunVersion);
            this.panel1.Controls.Add(this.AboutLabel);
            this.panel1.Controls.Add(this.HomePageLabel);
            this.panel1.Controls.Add(this.kcptunHomePageLinkLabel);
            this.panel1.Controls.Add(this.KcptunHomePageLabel);
            this.panel1.Controls.Add(this.HomePageLinkLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(481, 247);
            this.panel1.TabIndex = 9;
            // 
            // GUIVersion
            // 
            this.GUIVersion.AutoSize = true;
            this.GUIVersion.Location = new System.Drawing.Point(3, 222);
            this.GUIVersion.Name = "GUIVersion";
            this.GUIVersion.Size = new System.Drawing.Size(107, 12);
            this.GUIVersion.TabIndex = 8;
            this.GUIVersion.Text = "GUI version 1.1.1";
            // 
            // LogoPictureBox
            // 
            this.LogoPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.LogoPictureBox.Image = global::kcptun_gui.Properties.Resources.logo;
            this.LogoPictureBox.Location = new System.Drawing.Point(3, 3);
            this.LogoPictureBox.Name = "LogoPictureBox";
            this.LogoPictureBox.Size = new System.Drawing.Size(352, 108);
            this.LogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.LogoPictureBox.TabIndex = 0;
            this.LogoPictureBox.TabStop = false;
            // 
            // KcptunVersion
            // 
            this.KcptunVersion.AutoSize = true;
            this.KcptunVersion.Location = new System.Drawing.Point(3, 197);
            this.KcptunVersion.Name = "KcptunVersion";
            this.KcptunVersion.Size = new System.Drawing.Size(143, 12);
            this.KcptunVersion.TabIndex = 7;
            this.KcptunVersion.Text = "kcptun version 20160811";
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Location = new System.Drawing.Point(3, 115);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(95, 12);
            this.AboutLabel.TabIndex = 1;
            this.AboutLabel.Text = "GUI for kcptun.";
            // 
            // HomePageLabel
            // 
            this.HomePageLabel.AutoSize = true;
            this.HomePageLabel.Location = new System.Drawing.Point(3, 142);
            this.HomePageLabel.Name = "HomePageLabel";
            this.HomePageLabel.Size = new System.Drawing.Size(125, 12);
            this.HomePageLabel.TabIndex = 2;
            this.HomePageLabel.Text = "Report GUI issues to";
            // 
            // kcptunHomePageLinkLabel
            // 
            this.kcptunHomePageLinkLabel.AutoSize = true;
            this.kcptunHomePageLinkLabel.Location = new System.Drawing.Point(158, 170);
            this.kcptunHomePageLinkLabel.Name = "kcptunHomePageLinkLabel";
            this.kcptunHomePageLinkLabel.Size = new System.Drawing.Size(233, 12);
            this.kcptunHomePageLinkLabel.TabIndex = 5;
            this.kcptunHomePageLinkLabel.TabStop = true;
            this.kcptunHomePageLinkLabel.Text = "https://github.com/xtaci/kcptun/issues";
            this.kcptunHomePageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkClicked);
            // 
            // KcptunHomePageLabel
            // 
            this.KcptunHomePageLabel.AutoSize = true;
            this.KcptunHomePageLabel.Location = new System.Drawing.Point(3, 170);
            this.KcptunHomePageLabel.Name = "KcptunHomePageLabel";
            this.KcptunHomePageLabel.Size = new System.Drawing.Size(149, 12);
            this.KcptunHomePageLabel.TabIndex = 3;
            this.KcptunHomePageLabel.Text = "Report kcptun issues to ";
            // 
            // HomePageLinkLabel
            // 
            this.HomePageLinkLabel.AutoSize = true;
            this.HomePageLinkLabel.Location = new System.Drawing.Point(144, 142);
            this.HomePageLinkLabel.Name = "HomePageLinkLabel";
            this.HomePageLinkLabel.Size = new System.Drawing.Size(323, 12);
            this.HomePageLinkLabel.TabIndex = 4;
            this.HomePageLinkLabel.TabStop = true;
            this.HomePageLinkLabel.Text = "https://github.com/GangZhuo/kcptun-gui-windows/issues";
            this.HomePageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkClicked);
            // 
            // AboutUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AboutUserControl";
            this.Size = new System.Drawing.Size(481, 247);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label KcptunVersion;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.Label HomePageLabel;
        private System.Windows.Forms.LinkLabel kcptunHomePageLinkLabel;
        private System.Windows.Forms.Label KcptunHomePageLabel;
        private System.Windows.Forms.LinkLabel HomePageLinkLabel;
        private System.Windows.Forms.Label GUIVersion;
    }
}
