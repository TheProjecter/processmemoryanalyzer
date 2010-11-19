namespace PMASysAlertsUI
{
    partial class PanelFTPSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_FTPServer = new System.Windows.Forms.Label();
            this.textBox_FTPServer = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.numericUpDown_port = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_DefaultFolder = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.checkBox_EnableSSL = new System.Windows.Forms.CheckBox();
            this.label_FTPSettings = new System.Windows.Forms.Label();
            this.numericUpDown_Timeout = new System.Windows.Forms.NumericUpDown();
            this.label_Timeout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Timeout)).BeginInit();
            this.SuspendLayout();
            // 
            // label_FTPServer
            // 
            this.label_FTPServer.AutoSize = true;
            this.label_FTPServer.Location = new System.Drawing.Point(26, 39);
            this.label_FTPServer.Name = "label_FTPServer";
            this.label_FTPServer.Size = new System.Drawing.Size(61, 13);
            this.label_FTPServer.TabIndex = 0;
            this.label_FTPServer.Text = "FTP Server";
            // 
            // textBox_FTPServer
            // 
            this.textBox_FTPServer.Location = new System.Drawing.Point(102, 36);
            this.textBox_FTPServer.Name = "textBox_FTPServer";
            this.textBox_FTPServer.Size = new System.Drawing.Size(219, 20);
            this.textBox_FTPServer.TabIndex = 1;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(26, 71);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(26, 13);
            this.label_port.TabIndex = 2;
            this.label_port.Text = "Port";
            // 
            // numericUpDown_port
            // 
            this.numericUpDown_port.Location = new System.Drawing.Point(102, 69);
            this.numericUpDown_port.Maximum = new decimal(new int[] {
            65536,
            0,
            0,
            0});
            this.numericUpDown_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_port.Name = "numericUpDown_port";
            this.numericUpDown_port.Size = new System.Drawing.Size(70, 20);
            this.numericUpDown_port.TabIndex = 3;
            this.numericUpDown_port.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_port.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_port_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Default Folder";
            // 
            // textBox_DefaultFolder
            // 
            this.textBox_DefaultFolder.Location = new System.Drawing.Point(102, 118);
            this.textBox_DefaultFolder.Name = "textBox_DefaultFolder";
            this.textBox_DefaultFolder.Size = new System.Drawing.Size(100, 20);
            this.textBox_DefaultFolder.TabIndex = 5;
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(102, 144);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(219, 20);
            this.textBox_User.TabIndex = 6;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(23, 147);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(29, 13);
            this.label_User.TabIndex = 7;
            this.label_User.Text = "User";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(102, 169);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(219, 20);
            this.textBox_Password.TabIndex = 8;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(23, 172);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 9;
            this.label_Password.Text = "Password";
            // 
            // checkBox_EnableSSL
            // 
            this.checkBox_EnableSSL.AutoSize = true;
            this.checkBox_EnableSSL.Location = new System.Drawing.Point(102, 95);
            this.checkBox_EnableSSL.Name = "checkBox_EnableSSL";
            this.checkBox_EnableSSL.Size = new System.Drawing.Size(82, 17);
            this.checkBox_EnableSSL.TabIndex = 10;
            this.checkBox_EnableSSL.Text = "Enable SSL";
            this.checkBox_EnableSSL.UseVisualStyleBackColor = true;
            // 
            // label_FTPSettings
            // 
            this.label_FTPSettings.AutoSize = true;
            this.label_FTPSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FTPSettings.Location = new System.Drawing.Point(23, 9);
            this.label_FTPSettings.Name = "label_FTPSettings";
            this.label_FTPSettings.Size = new System.Drawing.Size(80, 13);
            this.label_FTPSettings.TabIndex = 11;
            this.label_FTPSettings.Text = "FTP Settings";
            // 
            // numericUpDown_Timeout
            // 
            this.numericUpDown_Timeout.Location = new System.Drawing.Point(242, 69);
            this.numericUpDown_Timeout.Name = "numericUpDown_Timeout";
            this.numericUpDown_Timeout.Size = new System.Drawing.Size(79, 20);
            this.numericUpDown_Timeout.TabIndex = 12;
            this.numericUpDown_Timeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_Timeout
            // 
            this.label_Timeout.AutoSize = true;
            this.label_Timeout.Location = new System.Drawing.Point(191, 71);
            this.label_Timeout.Name = "label_Timeout";
            this.label_Timeout.Size = new System.Drawing.Size(45, 13);
            this.label_Timeout.TabIndex = 13;
            this.label_Timeout.Text = "Timeout";
            // 
            // PanelFTPSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_Timeout);
            this.Controls.Add(this.numericUpDown_Timeout);
            this.Controls.Add(this.label_FTPSettings);
            this.Controls.Add(this.checkBox_EnableSSL);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.textBox_DefaultFolder);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_port);
            this.Controls.Add(this.label_port);
            this.Controls.Add(this.textBox_FTPServer);
            this.Controls.Add(this.label_FTPServer);
            this.Name = "PanelFTPSettings";
            this.Size = new System.Drawing.Size(440, 260);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Timeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_FTPServer;
        private System.Windows.Forms.TextBox textBox_FTPServer;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.NumericUpDown numericUpDown_port;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_DefaultFolder;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.CheckBox checkBox_EnableSSL;
        private System.Windows.Forms.Label label_FTPSettings;
        private System.Windows.Forms.NumericUpDown numericUpDown_Timeout;
        private System.Windows.Forms.Label label_Timeout;
    }
}
