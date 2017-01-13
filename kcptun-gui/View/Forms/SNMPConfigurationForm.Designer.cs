namespace kcptun_gui.View.Forms
{
    partial class SNMPConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SNMPConfigurationForm));
            this.SNMPLogFileLabel = new System.Windows.Forms.Label();
            this.SNMPLogFileTextBox = new System.Windows.Forms.TextBox();
            this.SNMPPeriodLabel = new System.Windows.Forms.Label();
            this.SNMPPeriodNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.EnableCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.SNMPPeriodNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // SNMPLogFileLabel
            // 
            this.SNMPLogFileLabel.AutoSize = true;
            this.SNMPLogFileLabel.Location = new System.Drawing.Point(12, 31);
            this.SNMPLogFileLabel.Name = "SNMPLogFileLabel";
            this.SNMPLogFileLabel.Size = new System.Drawing.Size(81, 13);
            this.SNMPLogFileLabel.TabIndex = 0;
            this.SNMPLogFileLabel.Text = "SNMP Log File:";
            // 
            // SNMPLogFileTextBox
            // 
            this.SNMPLogFileTextBox.Location = new System.Drawing.Point(31, 52);
            this.SNMPLogFileTextBox.Name = "SNMPLogFileTextBox";
            this.SNMPLogFileTextBox.Size = new System.Drawing.Size(287, 20);
            this.SNMPLogFileTextBox.TabIndex = 1;
            // 
            // SNMPPeriodLabel
            // 
            this.SNMPPeriodLabel.AutoSize = true;
            this.SNMPPeriodLabel.Location = new System.Drawing.Point(12, 87);
            this.SNMPPeriodLabel.Name = "SNMPPeriodLabel";
            this.SNMPPeriodLabel.Size = new System.Drawing.Size(125, 13);
            this.SNMPPeriodLabel.TabIndex = 2;
            this.SNMPPeriodLabel.Text = "SNMP Period (Seconds):";
            // 
            // SNMPPeriodNumericUpDown
            // 
            this.SNMPPeriodNumericUpDown.Location = new System.Drawing.Point(31, 109);
            this.SNMPPeriodNumericUpDown.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.SNMPPeriodNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.SNMPPeriodNumericUpDown.Name = "SNMPPeriodNumericUpDown";
            this.SNMPPeriodNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.SNMPPeriodNumericUpDown.TabIndex = 3;
            this.SNMPPeriodNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(162, 140);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(243, 140);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // EnableCheckBox
            // 
            this.EnableCheckBox.AutoSize = true;
            this.EnableCheckBox.Location = new System.Drawing.Point(15, 8);
            this.EnableCheckBox.Name = "EnableCheckBox";
            this.EnableCheckBox.Size = new System.Drawing.Size(59, 17);
            this.EnableCheckBox.TabIndex = 5;
            this.EnableCheckBox.Text = "Enable";
            this.EnableCheckBox.UseVisualStyleBackColor = true;
            // 
            // SNMPConfigurationForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 175);
            this.Controls.Add(this.EnableCheckBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.SNMPPeriodNumericUpDown);
            this.Controls.Add(this.SNMPPeriodLabel);
            this.Controls.Add(this.SNMPLogFileTextBox);
            this.Controls.Add(this.SNMPLogFileLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SNMPConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SNMPConfigurationForm";
            this.Load += new System.EventHandler(this.SNMPConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SNMPPeriodNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SNMPLogFileLabel;
        private System.Windows.Forms.TextBox SNMPLogFileTextBox;
        private System.Windows.Forms.Label SNMPPeriodLabel;
        private System.Windows.Forms.NumericUpDown SNMPPeriodNumericUpDown;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox EnableCheckBox;
    }
}