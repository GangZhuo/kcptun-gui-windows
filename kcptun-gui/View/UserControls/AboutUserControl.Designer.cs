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
            this.panel1.Size = new System.Drawing.Size(401, 268);
            this.panel1.TabIndex = 9;
            // 
            // GUIVersion
            // 
            this.GUIVersion.AutoSize = true;
            this.GUIVersion.Location = new System.Drawing.Point(3, 241);
            this.GUIVersion.Name = "GUIVersion";
            this.GUIVersion.Size = new System.Drawing.Size(90, 13);
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
            this.KcptunVersion.Location = new System.Drawing.Point(3, 213);
            this.KcptunVersion.Name = "KcptunVersion";
            this.KcptunVersion.Size = new System.Drawing.Size(128, 13);
            this.KcptunVersion.TabIndex = 7;
            this.KcptunVersion.Text = "kcptun version 20160811";
            // 
            // AboutLabel
            // 
            this.AboutLabel.AutoSize = true;
            this.AboutLabel.Location = new System.Drawing.Point(3, 125);
            this.AboutLabel.Name = "AboutLabel";
            this.AboutLabel.Size = new System.Drawing.Size(80, 13);
            this.AboutLabel.TabIndex = 1;
            this.AboutLabel.Text = "GUI for kcptun.";
            // 
            // HomePageLabel
            // 
            this.HomePageLabel.AutoSize = true;
            this.HomePageLabel.Location = new System.Drawing.Point(3, 154);
            this.HomePageLabel.Name = "HomePageLabel";
            this.HomePageLabel.Size = new System.Drawing.Size(105, 13);
            this.HomePageLabel.TabIndex = 2;
            this.HomePageLabel.Text = "Report GUI issues to";
            // 
            // kcptunHomePageLinkLabel
            // 
            this.kcptunHomePageLinkLabel.AutoSize = true;
            this.kcptunHomePageLinkLabel.Location = new System.Drawing.Point(124, 184);
            this.kcptunHomePageLinkLabel.Name = "kcptunHomePageLinkLabel";
            this.kcptunHomePageLinkLabel.Size = new System.Drawing.Size(194, 13);
            this.kcptunHomePageLinkLabel.TabIndex = 5;
            this.kcptunHomePageLinkLabel.TabStop = true;
            this.kcptunHomePageLinkLabel.Text = "https://github.com/xtaci/kcptun/issues";
            this.kcptunHomePageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkClicked);
            // 
            // KcptunHomePageLabel
            // 
            this.KcptunHomePageLabel.AutoSize = true;
            this.KcptunHomePageLabel.Location = new System.Drawing.Point(3, 184);
            this.KcptunHomePageLabel.Name = "KcptunHomePageLabel";
            this.KcptunHomePageLabel.Size = new System.Drawing.Size(122, 13);
            this.KcptunHomePageLabel.TabIndex = 3;
            this.KcptunHomePageLabel.Text = "Report kcptun issues to ";
            // 
            // HomePageLinkLabel
            // 
            this.HomePageLinkLabel.AutoSize = true;
            this.HomePageLinkLabel.Location = new System.Drawing.Point(112, 154);
            this.HomePageLinkLabel.Name = "HomePageLinkLabel";
            this.HomePageLinkLabel.Size = new System.Drawing.Size(284, 13);
            this.HomePageLinkLabel.TabIndex = 4;
            this.HomePageLinkLabel.TabStop = true;
            this.HomePageLinkLabel.Text = "https://github.com/GangZhuo/kcptun-gui-windows/issues";
            this.HomePageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.OnLinkClicked);
            // 
            // AboutUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "AboutUserControl";
            this.Size = new System.Drawing.Size(401, 268);
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
