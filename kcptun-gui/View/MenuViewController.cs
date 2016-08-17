using System;
using System.Drawing;
using System.Windows.Forms;

using kcptun_gui.Model;
using kcptun_gui.Controller;
using kcptun_gui.Properties;

namespace kcptun_gui.View
{
    public class MenuViewController
    {
        private MainController controller;

        private NotifyIcon _notifyIcon;
        private ContextMenu contextMenu1;

        private MenuItem enableItem;
        private MenuItem ServersItem;
        private MenuItem seperatorItem;
        private MenuItem startItem;
        private MenuItem stopItem;
        private MenuItem restartItem;
        private MenuItem killAllItem;
        private MenuItem autoStartupItem;

        private EidtServersForm editServersForm;
        private AboutForm aboutForm;

        private bool _firstRun;

        public MenuViewController(MainController controller)
        {
            this.controller = controller;

            LoadMenu();

            controller.KCPTunnelController.Started += OnKCPTunnelStarted;
            controller.KCPTunnelController.Stoped += OnKCPTunnelStoped;
            controller.ConfigController.ConfigChanged += OnConfigChanged;

            _notifyIcon = new NotifyIcon();
            UpdateTrayIcon();
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenu = contextMenu1;

            LoadCurrentConfiguration();

            Configuration config = controller.ConfigController.GetCurrentConfiguration();
            _firstRun = config.isDefault;
            if (_firstRun)
            {
                ShowEditServicesForm();
            }
        }

        private void LoadCurrentConfiguration()
        {
            Configuration config = controller.ConfigController.GetConfigurationCopy();
            UpdateServersMenu();
            enableItem.Checked = config.enabled;
            autoStartupItem.Checked = AutoStartup.Check();
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
                this.enableItem = CreateMenuItem("Enable", new EventHandler(this.OnEnableItemClick)),
                this.ServersItem = CreateMenuGroup("Servers", new MenuItem[] {
                    this.seperatorItem = new MenuItem("-"),
                    CreateMenuItem("Edit Servers...", new EventHandler(this.OnConfigItemClick))
                }),
                new MenuItem("-"),
                CreateMenuGroup("Operations", new MenuItem[] {
                    this.startItem = CreateMenuItem("Start", new EventHandler(this.OnStartItemClick)),
                    this.stopItem = CreateMenuItem("Stop", new EventHandler(this.OnStopItemClick)),
                    this.restartItem = CreateMenuItem("Restart", new EventHandler(this.OnRestartItemClick)),
                    this.killAllItem = CreateMenuItem("Kill All", new EventHandler(this.OnKillAllItemClick)),
                }),
                new MenuItem("-"),
                this.autoStartupItem = CreateMenuItem("Start on Boot", new EventHandler(this.OnAutoStartupItemClick)),
                new MenuItem("-"),
                CreateMenuItem("Show Logs...", new EventHandler(this.OnShowLogItemClick)),
                CreateMenuItem("About...", new EventHandler(this.OnAboutItemClick)),
                new MenuItem("-"),
                CreateMenuItem("Quit", new EventHandler(this.OnQuitItemClick))
            });

            this.startItem.Enabled = true;
            this.restartItem.Enabled = false;
            this.stopItem.Enabled = false;
        }

        private void UpdateServersMenu()
        {
            var items = ServersItem.MenuItems;
            while (items[0] != seperatorItem)
            {
                items.RemoveAt(0);
            }
            Configuration configuration = controller.ConfigController.GetConfigurationCopy();
            for (int i = 0; i < configuration.servers.Count; i++)
            {
                Server server = configuration.servers[i];
                MenuItem item = new MenuItem(server.FriendlyName());
                item.Tag = i;
                item.Click += OnServerItemClick;
                if (i == configuration.index)
                    item.Checked = true;
                items.Add(i, item);
            }
        }

        private void UpdateTrayIcon()
        {
            Bitmap bitmap = Resources.logo_small;
            Bitmap iconCopy = new Bitmap(bitmap);

            Configuration config = controller.ConfigController.GetCurrentConfiguration();
            Server server = config.GetCurrentServer();
            string runningInfo = "";

            if (controller.IsKcptunRunning)
            {
                /*do nothing*/
            }
            else if (!config.enabled)
            {
                iconCopy = Util.Utils.ToGray(iconCopy);
            }
            else
            {
                iconCopy = Util.Utils.ToBlue(iconCopy);
                runningInfo = "Running\n";
            }

            string text = $"kcptun {MainController.Version}\n" + runningInfo + "Local: (" + server.localaddr + ")\nRemote: " + server.FriendlyName() + "";

            _notifyIcon.Icon = Icon.FromHandle(iconCopy.GetHicon());
            _notifyIcon.Text = text.Substring(0, Math.Min(63, text.Length));

            iconCopy.Dispose();
        }

        private void ShowBalloonTip(string title, string content, ToolTipIcon icon, int timeout)
        {
            _notifyIcon.BalloonTipTitle = title;
            _notifyIcon.BalloonTipText = content;
            _notifyIcon.BalloonTipIcon = icon;
            _notifyIcon.ShowBalloonTip(timeout);
        }

        private void ShowFirstTimeBalloon()
        {
            ShowBalloonTip("kcptun is here",
                "You can turn on/off kcptun in the context menu.",
                ToolTipIcon.Info, 0);
        }

        private void ShowAboutForm()
        {
            if (aboutForm != null)
            {
                aboutForm.Activate();
            }
            else
            {
                aboutForm = new AboutForm();
                aboutForm.Show();
                aboutForm.FormClosed += OnAboutFormClosed;
            }
        }

        private void OnAboutFormClosed(object sender, FormClosedEventArgs e)
        {
            aboutForm = null;
        }

        private void ShowEditServicesForm()
        {
            if (editServersForm != null)
            {
                editServersForm.Activate();
            }
            else
            {
                editServersForm = new EidtServersForm(controller);
                editServersForm.Show();
                editServersForm.FormClosed += OnEditServersFormClosed;
            }
        }

        private void OnEditServersFormClosed(object sender, FormClosedEventArgs e)
        {
            editServersForm = null;
            if (_firstRun)
            {
                _firstRun = false;
                ShowFirstTimeBalloon();
            }
        }

        private void OnEnableItemClick(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleEnable(!enableItem.Checked);
        }

        private void OnServerItemClick(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            controller.ConfigController.SelectServerIndex((int)item.Tag);
        }

        private void OnConfigItemClick(object sender, EventArgs e)
        {
            ShowEditServicesForm();
        }

        private void OnStartItemClick(object sender, EventArgs e)
        {
            try
            {
                controller.KCPTunnelController.Server = controller.ConfigController.GetCurrentServer();
                controller.KCPTunnelController.Start();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnStopItemClick(object sender, EventArgs e)
        {
            try
            {
                controller.KCPTunnelController.Stop();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnRestartItemClick(object sender, EventArgs e)
        {
            try
            {
                if (controller.KCPTunnelController.IsRunning)
                    controller.KCPTunnelController.Stop();
                controller.KCPTunnelController.Server = controller.ConfigController.GetCurrentServer();
                controller.KCPTunnelController.Start();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnKillAllItemClick(object sender, EventArgs e)
        {
            try
            {
                KCPTunnelController.KillAll();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnAutoStartupItemClick(object sender, EventArgs e)
        {
            autoStartupItem.Checked = !autoStartupItem.Checked;
            if (!AutoStartup.Set(autoStartupItem.Checked))
            {
                MessageBox.Show("Failed to update registry");
            }
        }

        private void OnShowLogItemClick(object sender, EventArgs e)
        {
            new LogForm().Show();
        }

        private void OnAboutItemClick(object sender, EventArgs e)
        {
            ShowAboutForm();
        }

        private void OnQuitItemClick(object sender, EventArgs e)
        {
            controller.Stop();
            _notifyIcon.Visible = false;
            Application.Exit();
        }

        private void OnConfigChanged(object sender, EventArgs e)
        {
            LoadCurrentConfiguration();
            UpdateTrayIcon();
        }

        private void OnKCPTunnelStarted(object sender, EventArgs e)
        {
            UpdateTrayIcon();
            this.startItem.Enabled = false;
            this.restartItem.Enabled = true;
            this.stopItem.Enabled = true;
        }

        private void OnKCPTunnelStoped(object sender, EventArgs e)
        {
            UpdateTrayIcon();
            this.startItem.Enabled = true;
            this.restartItem.Enabled = false;
            this.stopItem.Enabled = false;
        }

    }
}
