#define TAR
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Collections.Generic;

using kcptun_gui.Model;
using kcptun_gui.Controller;
using kcptun_gui.Properties;
using kcptun_gui.View.Forms;
using kcptun_gui.Common;
using System.IO;
using System.Diagnostics;

namespace kcptun_gui.View
{
    public class MenuViewController : IDisposable
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
        private MenuItem verboseLoggingItem;
        private MenuItem checkGUIUpdateAtStartupItem;
        private MenuItem checkKcpTunUpdateAtStartupItem;
        private MenuItem upgradeKcpTunAtStartupItem;
        private MenuItem AboutItems;
        private MenuItem aboutSeperatorItem;

        private EidtServersForm editServersForm;
        private AboutForm aboutForm;
        private CustomKCPTunForm customKcptunForm;
        private StatisticsForm statisticsForm;
        private SNMPConfigurationForm snmpConfigForm;

        private bool _firstRun;
        private LinkedList<BalloonTipAction> _balloonTipActions;

        public MenuViewController(MainController controller)
        {
            this.controller = controller;

            Configuration config = controller.ConfigController.GetCurrentConfiguration();
            if (!string.IsNullOrEmpty(config.language))
                I18N.SetLang(config.language);

            I18N.LangChanged += onLanguageChanged;

            LoadMenu();

            controller.KCPTunnelController.Started += OnKCPTunnelStarted;
            controller.KCPTunnelController.Stoped += OnKCPTunnelStoped;
            controller.ConfigController.ConfigChanged += OnConfigChanged;
            controller.UpdateChecker.CheckUpdateCompleted += OnCheckUpdateCompleted;
            controller.UpdateChecker.DownloadCompleted += OnDownloadCompleted;

            _balloonTipActions = new LinkedList<BalloonTipAction>();
            _notifyIcon = new NotifyIcon();
            _notifyIcon.DoubleClick += OnNotifyIconDoubleClick;
            _notifyIcon.BalloonTipClicked += OnBalloonTipClicked;
            UpdateTrayIcon();
            _notifyIcon.Visible = true;
            _notifyIcon.ContextMenu = contextMenu1;

            LoadCurrentConfiguration();

            _firstRun = config.isDefault;
            if (_firstRun)
            {
                ShowEditServersForm();
            }

            if (config.check_gui_update)
            {
                controller.UpdateChecker.CheckUpdateForGUI(5000);
            }
            if (config.check_kcptun_update || config.auto_upgrade_kcptun)
            {
                controller.UpdateChecker.CheckUpdateForKCPTun(5000);
            }
        }

        private void onLanguageChanged(object sender, EventArgs e)
        {
            UpdateMenuItemsText(contextMenu1.MenuItems);
        }

        private void LoadCurrentConfiguration()
        {
            Configuration config = controller.ConfigController.GetConfigurationCopy();
            UpdateServersMenu();
            UpdateAboutMenu();
            enableItem.Checked = config.enabled;
            autoStartupItem.Checked = AutoStartup.Check();
            verboseLoggingItem.Checked = config.verbose;
            checkGUIUpdateAtStartupItem.Checked = config.check_gui_update;
            checkKcpTunUpdateAtStartupItem.Checked = config.check_kcptun_update;
            upgradeKcpTunAtStartupItem.Checked = config.auto_upgrade_kcptun;
        }

        private void UpdateMenuItemsText(Menu.MenuItemCollection items)
        {
            foreach(MenuItem item in items)
            {
                if (item is MyMenuItem)
                {
                    ((MyMenuItem)item).onLangChanged();
                }
                if (item.MenuItems.Count > 0)
                    UpdateMenuItemsText(item.MenuItems);
            }
        }

        private MenuItem CreateMenuItem(string text, EventHandler click)
        {
            return new MyMenuItem(text, click);
        }

        private MenuItem CreateMenuGroup(string text, MenuItem[] items)
        {
            return new MyMenuItem(text, items);
        }

        private void LoadMenu()
        {
            this.contextMenu1 = new ContextMenu(new MenuItem[] {
                this.enableItem = CreateMenuItem("Enable", new EventHandler(this.OnEnableItemClick)),
                this.ServersItem = CreateMenuGroup("Servers", new MenuItem[] {
                    this.seperatorItem = new MenuItem("-"),
                    CreateMenuItem("Edit Servers...", new EventHandler(this.OnConfigItemClick)),
                    new MenuItem("-"),
                    CreateMenuGroup("Start/Stop/Restart kcptun client...", new MenuItem[] {
                        this.startItem = CreateMenuItem("Start", new EventHandler(this.OnStartItemClick)),
                        this.restartItem = CreateMenuItem("Restart", new EventHandler(this.OnRestartItemClick)),
                        this.stopItem = CreateMenuItem("Stop", new EventHandler(this.OnStopItemClick)),
                        new MenuItem("-"),
                        this.killAllItem = CreateMenuItem("Kill all kcptun clients", new EventHandler(this.OnKillAllItemClick)),
                    }),
                }),
                new MenuItem("-"),
                this.autoStartupItem = CreateMenuItem("Start on Boot", new EventHandler(this.OnAutoStartupItemClick)),
                new MenuItem("-"),
                CreateMenuGroup("More...", new MenuItem[] {
                    this.verboseLoggingItem = CreateMenuItem("Turn on KCP Log", new EventHandler(this.OnVerboseLoggingItemClick)),
                    CreateMenuItem("Custome KCPTun", new EventHandler(this.OnCustomeKCPTunItemClick)),
                }),
                CreateMenuItem("Traffic Statistics", new EventHandler(this.OnStatisticsItemClick)),
                CreateMenuItem("Show Logs...", new EventHandler(this.OnShowLogItemClick)),
                CreateMenuGroup("Update...", new MenuItem[] {
                    CreateMenuItem("Check GUI updates...", new EventHandler(this.OnCheckGUIUpdatesItemClick)),
                    CreateMenuItem("Check kcptun updates...", new EventHandler(this.OnCheckKcpTunUpdatesItemClick)),
                    new MenuItem("-"),
                    this.checkGUIUpdateAtStartupItem = CreateMenuItem("Check GUI updates at startup", new EventHandler(this.OnCheckGUIUpdateAtStartupItemClick)),
                    this.checkKcpTunUpdateAtStartupItem = CreateMenuItem("Check kcptun updates at startup", new EventHandler(this.OnCheckKcpTunUpdateAtStartupItemClick)),
                    this.upgradeKcpTunAtStartupItem = CreateMenuItem("Upgrade kcptun updates at startup", new EventHandler(this.OnUpgradeKcpTunAtStartupItemClick)),
                }),
                CreateMenuGroup("SNMP...", new MenuItem[] {
                    CreateMenuItem("View SNMP...", new EventHandler(this.OnShowSNMPItemClick)),
                    new MenuItem("-"),
                    CreateMenuItem("SNMP Configurations...", new EventHandler(this.OnSNMPConfigurationItemClick)),
                }),
                this.AboutItems = CreateMenuGroup("About...", new MenuItem[] {
                    this.aboutSeperatorItem = new MenuItem("-"),
                    CreateMenuItem("About Form", new EventHandler(this.OnAboutItemClick)),
                }),
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

        private void UpdateAboutMenu()
        {
            var items = AboutItems.MenuItems;
            while (items[0] != aboutSeperatorItem)
            {
                items.RemoveAt(0);
            }

            Configuration config = controller.ConfigController.GetConfigurationCopy();
            if (!string.IsNullOrEmpty(config.language))
                I18N.SetLang(config.language);

            IList<I18N.Lang> langlist = I18N.GetLangList();
            for (int i = 0; i < langlist.Count; i++)
            {
                I18N.Lang lang = langlist[i];
                MenuItem item = new MenuItem(I18N.GetString(lang.fullname));
                item.Tag = lang;
                item.Click += OnLanguageItemClick;
                if (lang == I18N.Current)
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
                iconCopy = Utils.ToGray(iconCopy);
            }
            else
            {
                iconCopy = Utils.ToBlue(iconCopy);
                runningInfo = I18N.GetString("Running...") + "\n";
            }

            string text = $"kcptun {UpdateChecker.GUI_VERSION}\n" + runningInfo + I18N.GetString("Local:") +" (" + server.localaddr + ")\n"+ I18N.GetString("Remote:") + " " + server.FriendlyName() + "";

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
            ShowBalloonTip(I18N.GetString("kcptun is here"),
                I18N.GetString("You can turn on/off kcptun in the context menu."),
                ToolTipIcon.Info, 0);
        }

        private void OnNotifyIconDoubleClick(object sender, EventArgs e)
        {
            ShowEditServersForm();
        }

        private void OnBalloonTipClicked(object sender, EventArgs e)
        {
            while (_balloonTipActions.Count > 0)
            {
                BalloonTipAction action = _balloonTipActions.First.Value;
                _balloonTipActions.RemoveFirst();
                action.Execute(sender, e);
                action.Dispose();
            }
        }

        private void ShowAboutForm()
        {
            if (aboutForm != null)
            {
                aboutForm.Activate();
            }
            else
            {
                aboutForm = new AboutForm(controller);
                aboutForm.Show();
                aboutForm.FormClosed += OnAboutFormClosed;
            }
        }

        private void OnAboutFormClosed(object sender, FormClosedEventArgs e)
        {
            aboutForm = null;
        }

        private void ShowCustomKCPTunForm()
        {
            if (customKcptunForm != null)
            {
                customKcptunForm.Activate();
            }
            else
            {
                customKcptunForm = new CustomKCPTunForm(controller);
                customKcptunForm.Show();
                customKcptunForm.FormClosed += OnCustomKCPTunFormClosed;
            }
        }

        private void OnCustomKCPTunFormClosed(object sender, FormClosedEventArgs e)
        {
            customKcptunForm = null;
        }

        private void ShowEditServersForm()
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

        private void ShowStatisticsForm()
        {
            if (statisticsForm != null)
            {
                statisticsForm.Activate();
            }
            else
            {
                statisticsForm = new StatisticsForm(controller);
                statisticsForm.Show();
                statisticsForm.FormClosed += OnStatisticsFormClosed;
            }
        }

        private void OnStatisticsFormClosed(object sender, FormClosedEventArgs e)
        {
            statisticsForm = null;
        }

        private void ShowSNMPConfigForm()
        {
            if (snmpConfigForm != null)
            {
                snmpConfigForm.Activate();
            }
            else
            {
                snmpConfigForm = new SNMPConfigurationForm(controller);
                snmpConfigForm.Show();
                snmpConfigForm.FormClosed += OnSNMPConfigFormClosed;
            }
        }

        private void OnSNMPConfigFormClosed(object sender, FormClosedEventArgs e)
        {
            snmpConfigForm = null;
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
            ShowEditServersForm();
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
                MessageBox.Show(ex.Message, I18N.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, I18N.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, I18N.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnKillAllItemClick(object sender, EventArgs e)
        {
            try
            {
                controller.KCPTunnelController.KillAll();
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, I18N.GetString("Error"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnAutoStartupItemClick(object sender, EventArgs e)
        {
            autoStartupItem.Checked = !autoStartupItem.Checked;
            if (!AutoStartup.Set(autoStartupItem.Checked))
            {
                MessageBox.Show(I18N.GetString("Failed to update registry"));
            }
        }

        private void OnVerboseLoggingItemClick(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleVerboseLogging(!verboseLoggingItem.Checked);
        }

        private void OnCustomeKCPTunItemClick(object sender, EventArgs e)
        {
            ShowCustomKCPTunForm();
        }

        private void OnStatisticsItemClick(object sender, EventArgs e)
        {
            ShowStatisticsForm();
        }

        private void OnShowLogItemClick(object sender, EventArgs e)
        {
            new LogForm(controller).Show();
        }

        private void OnShowSNMPItemClick(object sender, EventArgs e)
        {
            SNMPConfiguration snmp = controller.ConfigController.GetCurrentConfiguration().snmp;
            if (!string.IsNullOrEmpty(snmp.snmplog))
            {
                FileInfo fi = new FileInfo(Path.Combine(Utils.GetTempPath(), snmp.snmplog));
                string argument = "/select, \"" + fi.FullName + "\"";
                Process.Start("explorer.exe", argument);
            }
        }

        private void OnSNMPConfigurationItemClick(object sender, EventArgs e)
        {
            ShowSNMPConfigForm();
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

        private void OnCheckUpdateCompleted(object sender, UpdateChecker.CheckUpdateEventArgs e)
        {
            try
            {
                string text = null;
                if (e.App == UpdateChecker.App.GUI)
                {
                    text = e.ReleaseList.Count == 0 ?
                        I18N.GetString("GUI is up to date") :
                        string.Format(I18N.GetString("New GUI version {0} is available"), e.ReleaseList[0].version);
                    ShowBalloonTip("", text, ToolTipIcon.Info, 3000);
                    if (e.ReleaseList.Count > 0)
                    {
                        BalloonTopOpenWebPageAction action = new BalloonTopOpenWebPageAction(UpdateChecker.GUI_RELEASE_PAGE, 4000);
                        action.Timeout += OnBalloonTipActionTimeout;
                        action.Tag = _balloonTipActions.AddLast(action);
                    }
                }
                else if (e.App == UpdateChecker.App.KCPTun)
                {
                    UpdateChecker.Release release = null;
                    string arch = Environment.Is64BitOperatingSystem ? "windows-amd64" : "windows-386";
                    foreach (UpdateChecker.Release r in e.ReleaseList)
                    {
                        if (r.name.IndexOf(arch) > 0)
                        {
                            release = r;
                            break;
                        }
                    }
                    if (release != null)
                    {
                        if (e.UserState != null || controller.ConfigController.GetConfigurationCopy().auto_upgrade_kcptun)
                        {
                            controller.UpdateChecker.Download(release);
                        }
                        else
                        {
                            text = string.Format(I18N.GetString("New kcptun version {0} is available"), release.version);
                            ShowBalloonTip("", text, ToolTipIcon.Info, 3000);
                            BalloonTopOpenWebPageAction action = new BalloonTopOpenWebPageAction(UpdateChecker.KCPTUN_RELEASE_PAGE, 3000);
                            action.Timeout += OnBalloonTipActionTimeout;
                            action.Tag = _balloonTipActions.AddLast(action);
                        }
                    }
                    else
                    {
                        text = I18N.GetString("kcptun is up to date");
                        ShowBalloonTip("", text, ToolTipIcon.Info, 3000);
                    }
                }
                else
                {
                    /* do nothing */
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void OnBalloonTipActionTimeout(object sender, EventArgs e)
        {
            BalloonTipAction action = (BalloonTipAction)sender;
            try
            {
                Logging.Debug("balloon tip action timeout");
                if (action.Tag is LinkedListNode<BalloonTipAction>)
                {
                    LinkedListNode<BalloonTipAction> node = action.Tag as LinkedListNode<BalloonTipAction>;
                    _balloonTipActions.Remove(node);
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
            finally
            {
                action.Dispose();
            }
        }

        private void OnDownloadCompleted(object sender, UpdateChecker.DownloadEventArgs e)
        {
            try
            {
                string text = null;
                if (e.Error != null)
                {
                    text = string.Format(I18N.GetString("failed to download {0}"), e.Release.name);
                    ShowBalloonTip("", text, ToolTipIcon.Error, 3000);
                    if (File.Exists(e.SaveTo))
                        try
                        {
                            File.Delete(e.SaveTo);
                        }
                        catch (Exception ex)
                        {
                            Logging.LogUsefulException(ex);
                        }
                }
                else
                {
#if TAR
                    string dstFilename = controller.KCPTunnelController.GetKCPTunPath();
                    try
                    {
                        Directory.SetCurrentDirectory(Utils.GetTempPath());
                        Ionic.Tar.Options opts = new Ionic.Tar.Options();
                        opts.Overwrite = true;
                        Ionic.Tar.Extract(e.SaveTo, opts);
                        Directory.SetCurrentDirectory(Application.StartupPath);
                        bool running = controller.KCPTunnelController.IsRunning;
                        if (running)
                            controller.KCPTunnelController.Stop();
                        if (File.Exists(dstFilename))
                            File.Delete(dstFilename);
                        File.Move(Utils.GetTempPath("client_windows_amd64.exe"), dstFilename);
                        if (running)
                            controller.KCPTunnelController.Start();
                        if (File.Exists(Utils.GetTempPath("client_windows_amd64.exe")))
                            File.Delete(Utils.GetTempPath("client_windows_amd64.exe"));
                        if (File.Exists(Utils.GetTempPath("server_windows_amd64.exe")))
                            File.Delete(Utils.GetTempPath("server_windows_amd64.exe"));
                        if (File.Exists(e.SaveTo))
                            File.Delete(e.SaveTo);
                        text = string.Format(I18N.GetString("kcptun updated to {0}"), controller.KCPTunnelController.GetKcptunVersionNumber());
                        ShowBalloonTip("", text, ToolTipIcon.Info, 3000);
                    }
                    catch (Exception ex)
                    {
                        Logging.LogUsefulException(ex);
                        text = string.Format(I18N.GetString("failed to uncompress {0}"), e.SaveTo);
                        ShowBalloonTip("", text, ToolTipIcon.Error, 3000);
                    }
                    finally
                    {
                        Directory.SetCurrentDirectory(Application.StartupPath);
                    }
#else
                    text = string.Format(I18N.GetString("New kcptun version {0} is available"), e.Release.version);
                    ShowBalloonTip("", text, ToolTipIcon.Error, 3000);
                    string argument = "/select, \"" + e.SaveTo + "\"";
                    Process.Start("explorer.exe", argument);
#endif
                }
            }
            catch (Exception ex)
            {
                Logging.LogUsefulException(ex);
            }
        }

        private void OnCheckGUIUpdateAtStartupItemClick(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleCheckGUIUpdate(!checkGUIUpdateAtStartupItem.Checked);
        }

        private void OnCheckKcpTunUpdateAtStartupItemClick(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleCheckKCPTunUpdate(!checkKcpTunUpdateAtStartupItem.Checked);
        }

        private void OnUpgradeKcpTunAtStartupItemClick(object sender, EventArgs e)
        {
            controller.ConfigController.ToggleAutoUpgradeKCPTun(!upgradeKcpTunAtStartupItem.Checked);
        }

        private void OnCheckGUIUpdatesItemClick(object sender, EventArgs e)
        {
            controller.UpdateChecker.CheckUpdateForGUI(100, this);
        }

        private void OnCheckKcpTunUpdatesItemClick(object sender, EventArgs e)
        {
            controller.UpdateChecker.CheckUpdateForKCPTun(100, this);
        }

        private void OnLanguageItemClick(object sender, EventArgs e)
        {
            MenuItem item = (MenuItem)sender;
            I18N.Lang lang = (I18N.Lang)item.Tag;
            I18N.SetLang(lang.name);
            controller.ConfigController.SelectLanguage(lang);
        }

        public void Dispose()
        {
            while (_balloonTipActions.Count > 0)
            {
                BalloonTipAction action = _balloonTipActions.First.Value;
                _balloonTipActions.RemoveFirst();
                action.Dispose();
            }
        }

        class MyMenuItem : MenuItem
        {
            private string _originalText;

            public MyMenuItem(string text, EventHandler onClick)
                : base(I18N.GetString(text), onClick)
            {
                _originalText = text;
            }

            public MyMenuItem(string text, MenuItem[] items)
                : base(I18N.GetString(text), items)
            {
                _originalText = text;
            }

            public void onLangChanged()
            {
                this.Text = I18N.GetString(_originalText);
            }
        }

        abstract class BalloonTipAction : IDisposable
        {
            private System.Timers.Timer _timer;

            public event EventHandler Timeout;

            public object Tag { get; set; }

            public BalloonTipAction()
            { }

            public BalloonTipAction(int timeout)
            {
                _timer = new System.Timers.Timer(timeout);
                _timer.Elapsed += _timer_Elapsed;
                _timer.AutoReset = false;
                _timer.Enabled = true;
            }

            private void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                disposeTimer();
                Timeout?.Invoke(this, new EventArgs());
            }

            private void disposeTimer()
            {
                try
                {
                    if (_timer != null)
                    {
                        _timer.Enabled = false;
                        _timer.Dispose();
                        _timer = null;
                    }
                }
                catch (Exception ex)
                {
                    Logging.LogUsefulException(ex);
                }
            }

            public void Execute(object sender, EventArgs e)
            {
                disposeTimer();
                OnExecute(sender, e);
            }

            protected abstract void OnExecute(object sender, EventArgs e);

            public void Dispose()
            {
                disposeTimer();
                Timeout = null;
            }
        }

        class BalloonTopOpenWebPageAction : BalloonTipAction
        {
            private string _url;

            public BalloonTopOpenWebPageAction(string url, int timeout)
                : base(timeout)
            {
                _url = url;
            }

            protected override void OnExecute(object sender, EventArgs e)
            {
                try
                {
                    Process.Start(_url);
                }
                catch (Exception ex)
                {
                    Logging.LogUsefulException(ex);
                }
            }
        }
    }
}
