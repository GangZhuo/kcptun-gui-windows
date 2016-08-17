using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using kcptun_gui.Controller;

namespace kcptun_gui.View
{
    public partial class LogViewerUserControl : UserControl
    {
        const int BACK_OFFSET = 65536;
        private long lastOffset;

        private Font _LogFont;

        public LogViewerUserControl()
        {
            InitializeComponent();
            _LogFont = LogTextBox.Font;
        }

        private void LogViewerUserControl_Load(object sender, EventArgs e)
        {
            InitContent();
            timer1.Enabled = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            UpdateContent();
        }

        public void DoCleanLogs()
        {
            bool timerEnabled = timer1.Enabled;
            if (timerEnabled)
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

            if (timerEnabled)
                timer1.Start();
        }

        public void DoChangeFont()
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

        public void ResetViewerFont()
        {
            if (LogTextBox.WordWrap)
            {
                TriggerWrapText();
            }
            LogTextBox.Font = _LogFont;
        }

        public bool TriggerWrapText()
        {
            LogTextBox.WordWrap = !LogTextBox.WordWrap;
            LogTextBox.ScrollToCaret();
            return LogTextBox.WordWrap;
        }

        private void InitContent()
        {
            if (string.IsNullOrEmpty(Logging.LogFilePath))
                return;
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
            if (string.IsNullOrEmpty(Logging.LogFilePath))
                return;
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

    }
}
