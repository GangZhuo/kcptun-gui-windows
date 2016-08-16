using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

using kcptun_gui.Model;
using kcptun_gui.Controller;

namespace kcptun_gui.View
{
    public partial class MainForm : Form
    {
        const int BACK_OFFSET = 65536;
        private long lastOffset;

        private Font _LogFont;

        private KcptunController controller;
        //public KCPTunnel _kcptun;
        //private Configuration _config;

        public MainForm(KcptunController controller)
        {
            this.controller = controller;

            //_kcptun = controller.kcptun;
            //_config = controller.config;

            InitializeComponent();
            propertyGrid1.PropertyValueChanged += PropertyGrid1_PropertyValueChanged;
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;

            controller.KcptunStarted += _kcptun_Started;
            controller.KcptunStoped += _kcptun_Stoped;
            controller.ConfigChanged += Controller_ConfigChanged;

            _LogFont = LogTextBox.Font;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadConfiguration();

            RefreshButtons();

            InitContent();

            KcptunVersion.Text = KCPTunnel.GetKcptunVersion();
        }

        private void RefreshButtons()
        {
            if (controller.IsKcptunRunning())
            {
                Status.Text = "Running";
                StartButton.Enabled = false;
                RestartButton.Enabled = true;
                StopButton.Enabled = true;
            }
            else
            {
                Status.Text = "Stoped";
                StartButton.Enabled = true;
                RestartButton.Enabled = false;
                StopButton.Enabled = false;
            }
        }

        private void LoadConfiguration()
        {
            Server server = controller.GetCurrentServer();
            propertyGrid1.SelectedObject = server;
            RemoteAddress.Text = server.remoteaddr;
            LocalAddress.Text = server.localaddr;

        }

        private void Controller_ConfigChanged(object sender, EventArgs e)
        {
            LoadConfiguration();
        }

        private void _kcptun_Started(object sender, EventArgs e)
        {
            if (Status.InvokeRequired)
            {
                Status.Invoke(new EventHandler(delegate (object sender2, EventArgs e2) {
                    RefreshButtons();
                    statusStrip1.Visible = false;
                }), sender, e);
            }
            else
            {
                RefreshButtons();
                statusStrip1.Visible = false;
            }
        }

        private void _kcptun_Stoped(object sender, EventArgs e)
        {
            if (Status.InvokeRequired)
            {
                Status.Invoke(new EventHandler(delegate (object sender2, EventArgs e2) {
                    RefreshButtons();
                }), sender, e);
            }
            else
            {
                RefreshButtons();
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            controller.KcptunStarted -= _kcptun_Started;
            controller.KcptunStoped -= _kcptun_Stoped;

            if (timer1.Enabled)
            {
                timer1.Stop();
                timer1.Enabled = false;
            }

            base.OnClosing(e);
        }

        private void PropertyGrid1_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            Configuration.Save(controller.config);
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == LogTabPage)
            {
                UpdateContent();
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                timer1.Enabled = false;
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((Control)sender).Enabled = false;
                controller.Start();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ((Control)sender).Enabled = true;
            }
        }

        private void RestartButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((Control)sender).Enabled = false;
                controller.Reload();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ((Control)sender).Enabled = true;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((Control)sender).Enabled = false;
                controller.Stop();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ((Control)sender).Enabled = true;
            }
        }

        private void KillAllKcptunButton_Click(object sender, EventArgs e)
        {
            try
            {
                ((Control)sender).Enabled = false;
                KCPTunnel.KillAll();
                ((Control)sender).Enabled = true;
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                ((Control)sender).Enabled = true;
            }
        }

        private void HomePageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }

        private void kcptunHomePageLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Text);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateContent();
        }

        private void DoCleanLogs()
        {
            if (timer1.Enabled)
                timer1.Stop();
            try
            {
                Logging.clear();
                lastOffset = 0;
                LogTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (timer1.Enabled)
                timer1.Start();
        }

        private void DoChangeFont()
        {
            try
            {
                FontDialog fd = new FontDialog();
                fd.Font = LogTextBox.Font;
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    LogTextBox.Font = new Font(fd.Font.FontFamily, fd.Font.Size, fd.Font.Style);
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message);
            }
        }

        bool wrapTextTrigger = false;
        bool wrapTextTriggerLock = false;

        private void TriggerWrapText()
        {
            wrapTextTriggerLock = true;

            wrapTextTrigger = !wrapTextTrigger;
            LogTextBox.WordWrap = wrapTextTrigger;
            LogTextBox.ScrollToCaret();
            wrapTextToolStripMenuItem.Checked = wrapTextTrigger;

            wrapTextTriggerLock = false;
        }

        private void InitContent()
        {
            using (StreamReader reader = new StreamReader(new FileStream(Logging.LogFilePath,
                     FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                if (reader.BaseStream.Length > BACK_OFFSET)
                {
                    reader.BaseStream.Seek(-BACK_OFFSET, SeekOrigin.End);
                    reader.ReadLine();
                }

                string line = "";
                while ((line = reader.ReadLine()) != null)
                    LogTextBox.AppendText(line + Environment.NewLine);

                LogTextBox.ScrollToCaret();

                lastOffset = reader.BaseStream.Position;
            }
        }

        private void UpdateContent()
        {
            try
            {
                using (StreamReader reader = new StreamReader(new FileStream(Logging.LogFilePath,
                         FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
                {
                    reader.BaseStream.Seek(lastOffset, SeekOrigin.Begin);

                    string line = "";
                    bool changed = false;
                    while ((line = reader.ReadLine()) != null)
                    {
                        changed = true;
                        LogTextBox.AppendText(line + Environment.NewLine);
                    }

                    if (changed)
                    {
                        LogTextBox.ScrollToCaret();
                    }

                    lastOffset = reader.BaseStream.Position;
                }
            }
            catch (FileNotFoundException)
            {
            }
        }

        private void openLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string argument = "/select, \"" + Logging.LogFilePath + "\"";
            Process.Start("explorer.exe", argument);
        }

        private void cleanLogsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoCleanLogs();
        }

        private void wrapTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!wrapTextTriggerLock)
            {
                TriggerWrapText();
            }
        }

        private void changeFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoChangeFont();
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wrapTextTrigger && !wrapTextTriggerLock)
            {
                TriggerWrapText();
            }
            LogTextBox.Font = _LogFont;
        }
    }
}
