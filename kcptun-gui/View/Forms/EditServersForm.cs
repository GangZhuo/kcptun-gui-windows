using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using kcptun_gui.Controller;
using kcptun_gui.Model;

namespace kcptun_gui.View
{
    public partial class EidtServersForm : Form
    {
        private MainController controller;
        private Configuration _config;

        private int _selectedIndex;

        public EidtServersForm(MainController controller)
        {
            this.controller = controller;

            InitializeComponent();
            UpdateText();

            ServerListBox.SelectedIndexChanged += ServerListBox_SelectedIndexChanged;
            ServerPropertyGrid.PropertyValueChanged += ServerPropertyGrid_PropertyValueChanged;

            controller.ConfigController.ConfigChanged += OnConfigChanged;
        }

        private void UpdateText()
        {
            Text = I18N.GetString("Edit Servers");
            ServerGroupBox.Text = I18N.GetString("Server");
            ArgumentsLabel.Text = I18N.GetString("Arguments:");

            AddButton.Text = I18N.GetString("Add");
            DeleteButton.Text = I18N.GetString("Delete");
            MoveUpButton.Text = I18N.GetString("Move Up");
            MoveDownButton.Text = I18N.GetString("Move Down");
            OkButton.Text = I18N.GetString("OK");
            MyCancelButton.Text = I18N.GetString("Cancel");
            ImportButton.Text = I18N.GetString("Import");
            openFileDialog1.Title = I18N.GetString("Select configuration file ...");
            openFileDialog1.Filter = I18N.GetString("JSON files|*.json|All files|*.*");
        }

        private void LoadServerList()
        {
            _config = controller.ConfigController.GetConfigurationCopy();

            ServerListBox.BeginUpdate();
            ServerListBox.Items.Clear();

            foreach (Server server in _config.servers)
            {
                ServerListBox.Items.Add(server.FriendlyName());
            }

            ServerListBox.EndUpdate();

            if (_selectedIndex >= 0 && _selectedIndex < ServerListBox.Items.Count)
                ServerListBox.SelectedIndex = _selectedIndex;
        }

        private Server GetSelectedServer()
        {
            int index = ServerListBox.SelectedIndex;
            Server server;
            if (index >= 0 && index < _config.servers.Count)
                server = _config.servers[index];
            else
                server = null;
            return server;
        }

        private void LoadServer()
        {
            Server server = GetSelectedServer();
            ServerPropertyGrid.SelectedObject = server;
            RefreshServerArgumentTextBox();
        }

        private void RefreshServerArgumentTextBox()
        {
            Server server = GetSelectedServer();
            if (server != null)
                ArgumentsTextBox.Text = KCPTunnelController.BuildArguments(server);
            else
                ArgumentsTextBox.Text = "";
        }

        private void RefreshButtons()
        {
            AddButton.Enabled = true;
            DeleteButton.Enabled = ServerListBox.SelectedIndex != -1;
            MoveUpButton.Enabled = ServerListBox.SelectedIndex > 0;
            MoveDownButton.Enabled = ServerListBox.SelectedIndex < ServerListBox.Items.Count - 1;
        }

        private void SaveOldServer()
        {
            int index = _selectedIndex;
            if (index >= 0 && index < _config.servers.Count)
            {
                Server server = _config.servers[index];
                object prevItem = ServerListBox.Items[index];
                if (prevItem.ToString() != server.FriendlyName())
                {
                    ServerListBox.Items.RemoveAt(index);
                    ServerListBox.Items.Insert(index, server.FriendlyName());
                }
            }
        }

        private void ServerConfigForm_Load(object sender, EventArgs e)
        {
            LoadServerList();
            RefreshButtons();
        }

        private void ServerPropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            RefreshServerArgumentTextBox();
        }

        private bool indexChangeLock = false;
        private void ServerListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!indexChangeLock)
            {
                indexChangeLock = true;

                SaveOldServer();
                _selectedIndex = ServerListBox.SelectedIndex;
                LoadServer();
                RefreshButtons();

                indexChangeLock = false;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Server server = Configuration.GetDefaultServer();
            _config.servers.Add(server);
            ServerListBox.Items.Add("New Server");
            ServerListBox.SelectedIndex = ServerListBox.Items.Count - 1;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            int index = ServerListBox.SelectedIndex;
            if (index >= 0 && index < _config.servers.Count)
            {
                _config.servers.RemoveAt(index);
                ServerListBox.Items.RemoveAt(index);
                _selectedIndex = -1;
                if (index < _config.servers.Count)
                    ServerListBox.SelectedIndex = index;
                else if (index > 0)
                    ServerListBox.SelectedIndex = index - 1;
                else
                    ServerListBox.SelectedIndex = -1;
            }
        }

        private void MoveUpButton_Click(object sender, EventArgs e)
        {
            int index = ServerListBox.SelectedIndex;
            if (index > 0 && index < _config.servers.Count)
            {
                Server server = _config.servers[index];
                _config.servers.RemoveAt(index);
                _config.servers.Insert(index - 1, server);
                _selectedIndex = -1;
                ServerListBox.Items.RemoveAt(index);
                ServerListBox.Items.Insert(index - 1, server);
                ServerListBox.SelectedIndex = index - 1;
            }
        }

        private void MoveDownButton_Click(object sender, EventArgs e)
        {
            int index = ServerListBox.SelectedIndex;
            if (index >= 0 && index + 1 < _config.servers.Count)
            {
                Server server = _config.servers[index];
                _config.servers.RemoveAt(index);
                _config.servers.Insert(index + 1, server);
                _selectedIndex = -1;
                ServerListBox.Items.RemoveAt(index);
                ServerListBox.Items.Insert(index + 1, server);
                ServerListBox.SelectedIndex = index + 1;
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            controller.ConfigController.SaveConfig(_config);
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string[] files = openFileDialog1.FileNames;
                    int num = 0;
                    foreach(string file in files)
                    {
                        try
                        {
                            Server server = Configuration.GetServerFromConfigFile(file);
                            _config.servers.Add(server);
                            num++;
                        }
                        catch (Exception ex)
                        {
                            Logging.LogUsefulException(ex);
                        }
                    }
                    if (num > 0)
                    {
                        controller.ConfigController.SaveConfig(_config);
                    }
                }
            }
            catch(Exception ex)
            {
                Logging.LogUsefulException(ex);
                MessageBox.Show(ex.Message, I18N.GetString("kcptun-gui"), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            controller.ConfigController.ConfigChanged -= OnConfigChanged;
            base.OnClosing(e);
        }

        private void OnConfigChanged(object sender, EventArgs e)
        {
            LoadServerList();
            RefreshButtons();
        }
    }
}
