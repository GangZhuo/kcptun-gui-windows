namespace kcptun_gui.View
{
    partial class LogForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLocationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.wrapTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logViewerUserControl1 = new kcptun_gui.View.LogViewerUserControl();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(426, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLocationToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openLocationToolStripMenuItem
            // 
            this.openLocationToolStripMenuItem.Name = "openLocationToolStripMenuItem";
            this.openLocationToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openLocationToolStripMenuItem.Text = "Open Location";
            this.openLocationToolStripMenuItem.Click += new System.EventHandler(this.openLocationToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanLogsToolStripMenuItem,
            this.toolStripSeparator2,
            this.wrapTextToolStripMenuItem,
            this.changeFontToolStripMenuItem,
            this.resetFontToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // cleanLogsToolStripMenuItem
            // 
            this.cleanLogsToolStripMenuItem.Name = "cleanLogsToolStripMenuItem";
            this.cleanLogsToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.cleanLogsToolStripMenuItem.Text = "Clean Logs";
            this.cleanLogsToolStripMenuItem.Click += new System.EventHandler(this.cleanLogsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // wrapTextToolStripMenuItem
            // 
            this.wrapTextToolStripMenuItem.Name = "wrapTextToolStripMenuItem";
            this.wrapTextToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.wrapTextToolStripMenuItem.Text = "Wrap Text";
            this.wrapTextToolStripMenuItem.Click += new System.EventHandler(this.wrapTextToolStripMenuItem_Click);
            // 
            // changeFontToolStripMenuItem
            // 
            this.changeFontToolStripMenuItem.Name = "changeFontToolStripMenuItem";
            this.changeFontToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.changeFontToolStripMenuItem.Text = "Change Font";
            this.changeFontToolStripMenuItem.Click += new System.EventHandler(this.changeFontToolStripMenuItem_Click);
            // 
            // resetFontToolStripMenuItem
            // 
            this.resetFontToolStripMenuItem.Name = "resetFontToolStripMenuItem";
            this.resetFontToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.resetFontToolStripMenuItem.Text = "Reset Font";
            this.resetFontToolStripMenuItem.Click += new System.EventHandler(this.resetFontToolStripMenuItem_Click);
            // 
            // logViewerUserControl1
            // 
            this.logViewerUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logViewerUserControl1.Location = new System.Drawing.Point(0, 24);
            this.logViewerUserControl1.Name = "logViewerUserControl1";
            this.logViewerUserControl1.Size = new System.Drawing.Size(426, 306);
            this.logViewerUserControl1.TabIndex = 3;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 330);
            this.Controls.Add(this.logViewerUserControl1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Log Viewer";
            this.Load += new System.EventHandler(this.LogForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLocationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cleanLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wrapTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeFontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetFontToolStripMenuItem;
        private LogViewerUserControl logViewerUserControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}