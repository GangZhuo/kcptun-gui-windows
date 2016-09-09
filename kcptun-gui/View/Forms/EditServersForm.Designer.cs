namespace kcptun_gui.View
{
    partial class EidtServersForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EidtServersForm));
            this.ServerListBox = new System.Windows.Forms.ListBox();
            this.MoveDownButton = new System.Windows.Forms.Button();
            this.MoveUpButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.MyCancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.ServerPropertyGrid = new System.Windows.Forms.PropertyGrid();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.ServerGroupBox = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ArgumentsLabel = new System.Windows.Forms.Label();
            this.ArgumentsTextBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ImportButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel2.SuspendLayout();
            this.ServerGroupBox.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ServerListBox
            // 
            this.ServerListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerListBox.FormattingEnabled = true;
            this.ServerListBox.ItemHeight = 12;
            this.ServerListBox.Location = new System.Drawing.Point(6, 6);
            this.ServerListBox.Name = "ServerListBox";
            this.ServerListBox.Size = new System.Drawing.Size(203, 339);
            this.ServerListBox.TabIndex = 0;
            // 
            // MoveDownButton
            // 
            this.MoveDownButton.Location = new System.Drawing.Point(109, 30);
            this.MoveDownButton.Name = "MoveDownButton";
            this.MoveDownButton.Size = new System.Drawing.Size(100, 21);
            this.MoveDownButton.TabIndex = 5;
            this.MoveDownButton.Text = "Move Down";
            this.MoveDownButton.UseVisualStyleBackColor = true;
            this.MoveDownButton.Click += new System.EventHandler(this.MoveDownButton_Click);
            // 
            // MoveUpButton
            // 
            this.MoveUpButton.Location = new System.Drawing.Point(3, 30);
            this.MoveUpButton.Name = "MoveUpButton";
            this.MoveUpButton.Size = new System.Drawing.Size(100, 21);
            this.MoveUpButton.TabIndex = 4;
            this.MoveUpButton.Text = "Move Up";
            this.MoveUpButton.UseVisualStyleBackColor = true;
            this.MoveUpButton.Click += new System.EventHandler(this.MoveUpButton_Click);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(109, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(100, 21);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.UseVisualStyleBackColor = true;
            this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(100, 21);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "Add";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // MyCancelButton
            // 
            this.MyCancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MyCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.MyCancelButton.Location = new System.Drawing.Point(446, 17);
            this.MyCancelButton.Name = "MyCancelButton";
            this.MyCancelButton.Size = new System.Drawing.Size(89, 29);
            this.MyCancelButton.TabIndex = 7;
            this.MyCancelButton.Text = "Cancel";
            this.MyCancelButton.UseVisualStyleBackColor = true;
            this.MyCancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(351, 17);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(89, 29);
            this.OkButton.TabIndex = 6;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // ServerPropertyGrid
            // 
            this.ServerPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerPropertyGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ServerPropertyGrid.Location = new System.Drawing.Point(3, 17);
            this.ServerPropertyGrid.Name = "ServerPropertyGrid";
            this.ServerPropertyGrid.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.ServerPropertyGrid.Size = new System.Drawing.Size(314, 218);
            this.ServerPropertyGrid.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.MoveDownButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.AddButton, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.MoveUpButton, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.DeleteButton, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(212, 54);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ServerGroupBox
            // 
            this.ServerGroupBox.Controls.Add(this.ServerPropertyGrid);
            this.ServerGroupBox.Controls.Add(this.panel4);
            this.ServerGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerGroupBox.Location = new System.Drawing.Point(6, 6);
            this.ServerGroupBox.Name = "ServerGroupBox";
            this.ServerGroupBox.Size = new System.Drawing.Size(320, 339);
            this.ServerGroupBox.TabIndex = 3;
            this.ServerGroupBox.TabStop = false;
            this.ServerGroupBox.Text = "Server";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ArgumentsLabel);
            this.panel4.Controls.Add(this.ArgumentsTextBox);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 235);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(314, 101);
            this.panel4.TabIndex = 4;
            // 
            // ArgumentsLabel
            // 
            this.ArgumentsLabel.AutoSize = true;
            this.ArgumentsLabel.Location = new System.Drawing.Point(6, 8);
            this.ArgumentsLabel.Name = "ArgumentsLabel";
            this.ArgumentsLabel.Size = new System.Drawing.Size(65, 12);
            this.ArgumentsLabel.TabIndex = 2;
            this.ArgumentsLabel.Text = "Arguments:";
            // 
            // ArgumentsTextBox
            // 
            this.ArgumentsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArgumentsTextBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ArgumentsTextBox.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ArgumentsTextBox.Location = new System.Drawing.Point(3, 25);
            this.ArgumentsTextBox.MaxLength = 2147483647;
            this.ArgumentsTextBox.Multiline = true;
            this.ArgumentsTextBox.Name = "ArgumentsTextBox";
            this.ArgumentsTextBox.ReadOnly = true;
            this.ArgumentsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ArgumentsTextBox.Size = new System.Drawing.Size(308, 73);
            this.ArgumentsTextBox.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ImportButton);
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.MyCancelButton);
            this.panel1.Controls.Add(this.OkButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 351);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 63);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ServerListBox);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(6);
            this.panel2.Size = new System.Drawing.Size(215, 351);
            this.panel2.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ServerGroupBox);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(215, 0);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(6);
            this.panel3.Size = new System.Drawing.Size(332, 351);
            this.panel3.TabIndex = 10;
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(220, 7);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(85, 23);
            this.ImportButton.TabIndex = 8;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "json";
            this.openFileDialog1.FileName = "config.json";
            this.openFileDialog1.Filter = "JSON files|*.json|All files|*.*";
            this.openFileDialog1.Multiselect = true;
            // 
            // EidtServersForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 414);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(563, 453);
            this.Name = "EidtServersForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Servers";
            this.Load += new System.EventHandler(this.ServerConfigForm_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ServerGroupBox.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox ServerListBox;
        private System.Windows.Forms.Button MoveDownButton;
        private System.Windows.Forms.Button MoveUpButton;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button MyCancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.PropertyGrid ServerPropertyGrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox ServerGroupBox;
        private System.Windows.Forms.TextBox ArgumentsTextBox;
        private System.Windows.Forms.Label ArgumentsLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}