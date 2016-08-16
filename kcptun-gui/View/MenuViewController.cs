using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

using kcptun_gui.Model;
using kcptun_gui.Controller;
using kcptun_gui.Properties;

namespace kcptun_gui.View
{
    public class MenuViewController
    {
        private KcptunController controller;

        private NotifyIcon _notifyIcon;
        private ContextMenu contextMenu1;

        private MenuItem OpenMainWindowItem;
        private MainForm mainForm;

        public MenuViewController(KcptunController controller)
        {
            this.controller = controller;

            LoadMenu();

            controller.KcptunStarted += _kcptun_Started;
            controller.KcptunStoped += _kcptun_Stoped;
            controller.ConfigChanged += Controller_ConfigChanged;

            _notifyIcon = new NotifyIcon();
            UpdateTrayIcon();
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenu = contextMenu1;

            ShowMainForm();
        }

        private MenuItem CreateMenuItem(string text, EventHandler click)
        {
            return new MenuItem(text, click);
        }

        private MenuItem CreateMenuGroup(string text, MenuItem[] items)
        {
            return new MenuItem(text, items);
        }

        private void LoadMenu()
        {
            this.contextMenu1 = new ContextMenu(new MenuItem[] {
                this.OpenMainWindowItem = CreateMenuItem("Open main window", new EventHandler(this.OpenMainWindowItem_Click)),
                new MenuItem("-"),
                CreateMenuItem("Quit", new EventHandler(this.Quit_Click))
            });
        }

        private void UpdateTrayIcon()
        {
            Bitmap bitmap = Resources.logo_small;

            Configuration config = controller.config;
            bool running = controller.IsKcptunRunning();

            bitmap = getTrayIconByState(bitmap, running);

            _notifyIcon.Icon = Icon.FromHandle(bitmap.GetHicon());

            string serverInfo = config.GetCurrentServer().FriendlyName();
            string text = "Kcptun" + " " + KcptunController.Version + "\n" +
                (running ? String.Format("Running: Local Addr {0}\n", controller.GetCurrentServer().localaddr) : "")
                + serverInfo;
            _notifyIcon.Text = text.Substring(0, Math.Min(63, text.Length));
        }

        private Bitmap getTrayIconByState(Bitmap originIcon, bool running)
        {
            Bitmap iconCopy = new Bitmap(originIcon);
            if (!running)
                iconCopy = Util.Utils.ToGray(iconCopy);
            return iconCopy;
        }

        void ShowBalloonTip(string title, string content, ToolTipIcon icon, int timeout)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = content;
            _notifyIcon.BalloonTipIcon = icon;
            _notifyIcon.ShowBalloonTip(timeout);
        }

        private void ShowMainForm()
        {
            if (mainForm != null)
            {
                mainForm.Activate();
            }
            else
            {
                mainForm = new MainForm(controller);
                mainForm.Show();
                mainForm.FormClosed += mainForm_FormClosed;
            }
        }

        void mainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm = null;
            ShowFirstTimeBalloon();
        }

        private void OpenMainWindowItem_Click(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            controller.Stop();
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        private void ShowFirstTimeBalloon()
        {
            _notifyIcon.BalloonTipTitle = "Kcptun is here";
            _notifyIcon.BalloonTipText = "You can turn main window in the context menu";
            _notifyIcon.BalloonTipIcon = ToolTipIcon.Info;
            _notifyIcon.ShowBalloonTip(0);
        }

        private void Controller_ConfigChanged(object sender, EventArgs e)
        {
            UpdateTrayIcon();
        }

        private void _kcptun_Started(object sender, EventArgs e)
        {
            UpdateTrayIcon();
        }

        private void _kcptun_Stoped(object sender, EventArgs e)
        {
            UpdateTrayIcon();
        }

    }
}
