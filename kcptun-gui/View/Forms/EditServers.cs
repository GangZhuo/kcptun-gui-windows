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

            ServerListBox.SelectedIndexChanged += ServerListBox_SelectedIndexChanged;

            controller.ConfigController.ConfigChanged += OnConfigChanged;
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
            ServerPropertyGrid.SelectedObject = GetSelectedServer();
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
