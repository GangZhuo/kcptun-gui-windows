namespace kcptun_gui.View
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.MainTabPage = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Status = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.LocalAddress = new System.Windows.Forms.Label();
            this.LocalAddressLabel = new System.Windows.Forms.Label();
            this.RemoteAddress = new System.Windows.Forms.Label();
            this.RemoteAddressLabel = new System.Windows.Forms.Label();
            this.StopButton = new System.Windows.Forms.Button();
            this.RestartButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.ProfilesTabPage = new System.Windows.Forms.TabPage();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.LogTabPage = new System.Windows.Forms.TabPage();
            this.LogTextBox = new System.Windows.Forms.TextBox();
            this.AboutTabPage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LogoPictureBox = new System.Windows.Forms.PictureBox();
            this.KcptunVersion = new System.Windows.Forms.Label();
            this.AboutLabel = new System.Windows.Forms.Label();
            this.HomePageLabel = new System.Windows.Forms.Label();
            this.kcptunHomePageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.KcptunHomePageLabel = new System.Windows.Forms.Label();
            this.HomePageLinkLabel = new System.Windows.Forms.LinkLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wrapTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KillAllKcptunButton = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.MainTabPage.SuspendLayout();
            this.panel2.SuspendLayout();
            this.ProfilesTabPage.SuspendLayout();
            this.LogTabPage.SuspendLayout();
            this.AboutTabPage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.MainTabPage);
            this.tabControl1.Controls.Add(this.ProfilesTabPage);
            this.tabControl1.Controls.Add(this.LogTabPage);
            this.tabControl1.Controls.Add(this.AboutTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(372, 293);
            this.tabControl1.TabIndex = 0;
            // 
            // MainTabPage
            // 
            this.MainTabPage.Controls.Add(this.panel2);
            this.MainTabPage.Location = new System.Drawing.Point(4, 22);
            this.MainTabPage.Name = "MainTabPage";
            this.MainTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.MainTabPage.Size = new System.Drawing.Size(364, 267);
            this.MainTabPage.TabIndex = 0;
            this.MainTabPage.Text = "Main";
            this.MainTabPage.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.Controls.Add(this.KillAllKcptunButton);
            this.panel2.Controls.Add(this.Status);
            this.panel2.Controls.Add(this.StatusLabel);
            this.panel2.Controls.Add(this.LocalAddress);
            this.panel2.Controls.Add(this.LocalAddressLabel);
            this.panel2.Controls.Add(this.RemoteAddress);
            this.panel2.Controls.Add(this.RemoteAddressLabel);
            this.panel2.Controls.Add(this.StopButton);
            this.panel2.Controls.Add(this.RestartButton);
            this.panel2.Controls.Add(this.StartButton);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(358, 239);
            this.panel2.TabIndex = 2;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(120, 80);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(35, 13);
            this.Status.TabIndex = 8;
            this.Status.Text = "label1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Location = new System.Drawing.Point(20, 80);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(40, 13);
            this.StatusLabel.TabIndex = 7;
            this.StatusLabel.Text = "Status:";
            // 
            // LocalAddress
            // 
            this.LocalAddress.AutoSize = true;
            this.LocalAddress.Location = new System.Drawing.Point(120, 50);
            this.LocalAddress.Name = "LocalAddress";
            this.LocalAddress.Size = new System.Drawing.Size(35, 13);
            this.LocalAddress.TabIndex = 6;
            this.LocalAddress.Text = "label1";
            // 
            // LocalAddressLabel
            // 
            this.LocalAddressLabel.AutoSize = true;
            this.LocalAddressLabel.Location = new System.Drawing.Point(20, 50);
            this.LocalAddressLabel.Name = "LocalAddressLabel";
            this.LocalAddressLabel.Size = new System.Drawing.Size(77, 13);
            this.LocalAddressLabel.TabIndex = 5;
            this.LocalAddressLabel.Text = "Local Address:";
            // 
            // RemoteAddress
            // 
            this.RemoteAddress.AutoSize = true;
            this.RemoteAddress.Location = new System.Drawing.Point(120, 20);
            this.RemoteAddress.Name = "RemoteAddress";
            this.RemoteAddress.Size = new System.Drawing.Size(35, 13);
            this.RemoteAddress.TabIndex = 4;
            this.RemoteAddress.Text = "label1";
            // 
            // RemoteAddressLabel
            // 
            this.RemoteAddressLabel.AutoSize = true;
            this.RemoteAddressLabel.Location = new System.Drawing.Point(20, 20);
            this.RemoteAddressLabel.Name = "RemoteAddressLabel";
            this.RemoteAddressLabel.Size = new System.Drawing.Size(88, 13);
            this.RemoteAddressLabel.TabIndex = 3;
            this.RemoteAddressLabel.Text = "Remote Address:";
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(186, 149);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(75, 58);
            this.StopButton.TabIndex = 2;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // RestartButton
            // 
            this.RestartButton.Enabled = false;
            this.RestartButton.Location = new System.Drawing.Point(97, 149);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(75, 58);
            this.RestartButton.TabIndex = 1;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(8, 149);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(75, 58);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // ProfilesTabPage
            // 
            this.ProfilesTabPage.Controls.Add(this.propertyGrid1);
            this.ProfilesTabPage.Location = new System.Drawing.Point(4, 22);
            this.ProfilesTabPage.Name = "ProfilesTabPage";
            this.ProfilesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.ProfilesTabPage.Size = new System.Drawing.Size(364, 267);
            this.ProfilesTabPage.TabIndex = 1;
            this.ProfilesTabPage.Text = "Profiles";
            this.ProfilesTabPage.UseVisualStyleBackColor = true;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.Location = new System.Drawing.Point(3, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGrid1.Size = new System.Drawing.Size(358, 261);
            this.propertyGrid1.TabIndex = 0;
            // 
            // LogTabPage
            // 
            this.LogTabPage.Controls.Add(this.LogTextBox);
            this.LogTabPage.Controls.Add(this.menuStrip1);
            this.LogTabPage.Location = new System.Drawing.Point(4, 22);
            this.LogTabPage.Name = "LogTabPage";
            this.LogTabPage.Size = new System.Drawing.Size(364, 267);
            this.LogTabPage.TabIndex = 3;
            this.LogTabPage.Text = "Log";
            this.LogTabPage.UseVisualStyleBackColor = true;
            // 
            // LogTextBox
            // 
            this.LogTextBox.BackColor = System.Drawing.Color.Black;
            this.LogTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LogTextBox.ForeColor = System.Drawing.Color.White;
            this.LogTextBox.Location = new System.Drawing.Point(0, 24);
            this.LogTextBox.MaxLength = 2147483647;
            this.LogTextBox.Multiline = true;
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.ReadOnly = true;
            this.LogTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.LogTextBox.Size = new System.Drawing.Size(364, 243);
            this.LogTextBox.TabIndex = 0;
            this.LogTextBox.WordWrap = false;
            // 
            // AboutTabPage
            // 
            this.AboutTabPage.Controls.Add(this.panel1);
            this.AboutTabPage.Location = new System.Drawing.Point(4, 22);
            this.AboutTabPage.Name = "AboutTabPage";
            this.AboutTabPage.Size = new System.Drawing.Size(364, 267);
            this.AboutTabPage.TabIndex = 2;
            this.AboutTabPage.Text = "About";
            this.AboutTabPage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel1.Controls.Add(this.LogoPictureBox);
            this.panel1.Controls.Add(this.KcptunVersion);
            this.panel1.Controls.Add(this.AboutLabel);
            this.panel1.Controls.Add(this.HomePageLabel);
            this.panel1.Controls.Add(this.kcptunHomePageLinkLabel);
            this.panel1.Controls.Add(this.KcptunHomePageLabel);
            this.panel1.Controls.Add(this.HomePageLinkLabel);
            this.panel1.Location = new System.Drawing.Point(3, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 239);
            this.panel1.TabIndex = 8;
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
            this.KcptunVersion.Size = new System.Drawing.Size(55, 13);
            this.KcptunVersion.TabIndex = 7;
            this.KcptunVersion.Text = "20160811";
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
            this.HomePageLabel.Size = new System.Drawing.Size(38, 13);
            this.HomePageLabel.TabIndex = 2;
            this.HomePageLabel.Text = "Home:";
            // 
            // kcptunHomePageLinkLabel
            // 
            this.kcptunHomePageLinkLabel.AutoSize = true;
            this.kcptunHomePageLinkLabel.Location = new System.Drawing.Point(70, 184);
            this.kcptunHomePageLinkLabel.Name = "kcptunHomePageLinkLabel";
            this.kcptunHomePageLinkLabel.Size = new System.Drawing.Size(160, 13);
            this.kcptunHomePageLinkLabel.TabIndex = 5;
            this.kcptunHomePageLinkLabel.TabStop = true;
            this.kcptunHomePageLinkLabel.Text = "https://github.com/xtaci/kcptun";
            this.kcptunHomePageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.kcptunHomePageLinkLabel_LinkClicked);
            // 
            // KcptunHomePageLabel
            // 
            this.KcptunHomePageLabel.AutoSize = true;
            this.KcptunHomePageLabel.Location = new System.Drawing.Point(3, 184);
            this.KcptunHomePageLabel.Name = "KcptunHomePageLabel";
            this.KcptunHomePageLabel.Size = new System.Drawing.Size(44, 13);
            this.KcptunHomePageLabel.TabIndex = 3;
            this.KcptunHomePageLabel.Text = "Kcptun:";
            // 
            // HomePageLinkLabel
            // 
            this.HomePageLinkLabel.AutoSize = true;
            this.HomePageLinkLabel.Location = new System.Drawing.Point(70, 154);
            this.HomePageLinkLabel.Name = "HomePageLinkLabel";
            this.HomePageLinkLabel.Size = new System.Drawing.Size(206, 13);
            this.HomePageLinkLabel.TabIndex = 4;
            this.HomePageLinkLabel.TabStop = true;
            this.HomePageLinkLabel.Text = "https://github.com/GangZhuo/kcptun-gui";
            this.HomePageLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.HomePageLinkLabel_LinkClicked);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 271);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(372, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Visible = false;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(364, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocationToolStripMenuItem,
            this.cleanLogsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wrapTextToolStripMenuItem,
            this.changeFontToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // openLocationToolStripMenuItem
            // 
            this.openLocationToolStripMenuItem.Name = "openLocationToolStripMenuItem";
            this.openLocationToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openLocationToolStripMenuItem.Text = "Open Location";
            this.openLocationToolStripMenuItem.Click += new System.EventHandler(this.openLocationToolStripMenuItem_Click);
            // 
            // cleanLogsToolStripMenuItem
            // 
            this.cleanLogsToolStripMenuItem.Name = "cleanLogsToolStripMenuItem";
            this.cleanLogsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.cleanLogsToolStripMenuItem.Text = "Clean Logs";
            this.cleanLogsToolStripMenuItem.Click += new System.EventHandler(this.cleanLogsToolStripMenuItem_Click);
            // 
            // wrapTextToolStripMenuItem
            // 
            this.wrapTextToolStripMenuItem.Name = "wrapTextToolStripMenuItem";
            this.wrapTextToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.wrapTextToolStripMenuItem.Text = "Wrap Text";
            this.wrapTextToolStripMenuItem.Click += new System.EventHandler(this.wrapTextToolStripMenuItem_Click);
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.changeFontToolStripMenuItem.Text = "Change Font";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // KillAllKcptunButton
            // 
            this.KillAllKcptunButton.Location = new System.Drawing.Point(275, 149);
            this.KillAllKcptunButton.Name = "KillAllKcptunButton";
            this.KillAllKcptunButton.Size = new System.Drawing.Size(75, 58);
            this.KillAllKcptunButton.TabIndex = 3;
            this.KillAllKcptunButton.Text = "Kill All";
            this.KillAllKcptunButton.UseVisualStyleBackColor = true;
            this.KillAllKcptunButton.Click += new System.EventHandler(this.KillAllKcptunButton_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 293);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(380, 320);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TCP Tunnel";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.MainTabPage.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ProfilesTabPage.ResumeLayout(false);
            this.LogTabPage.ResumeLayout(false);
            this.LogTabPage.PerformLayout();
            this.AboutTabPage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LogoPictureBox)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage MainTabPage;
        private System.Windows.Forms.TabPage ProfilesTabPage;
        private System.Windows.Forms.TabPage AboutTabPage;
        private System.Windows.Forms.PictureBox LogoPictureBox;
        private System.Windows.Forms.Label KcptunHomePageLabel;
        private System.Windows.Forms.Label HomePageLabel;
        private System.Windows.Forms.Label AboutLabel;
        private System.Windows.Forms.LinkLabel HomePageLinkLabel;
        private System.Windows.Forms.LinkLabel kcptunHomePageLinkLabel;
        private System.Windows.Forms.Label KcptunVersion;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.TabPage LogTabPage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Button RestartButton;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.TextBox LogTextBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label RemoteAddressLabel;
        private System.Windows.Forms.Label RemoteAddress;
        private System.Windows.Forms.Label LocalAddress;
        private System.Windows.Forms.Label LocalAddressLabel;
        private System.Windows.Forms.Label Status;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wrapTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Button KillAllKcptunButton;
    }
}

