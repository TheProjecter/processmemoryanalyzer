namespace PMASysAlertsUI
{
    partial class PanelDatabaseWatcher
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
            this.label_Database = new System.Windows.Forms.Label();
            this.textBox_Database = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox_DBUser = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_DBPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Wait = new System.Windows.Forms.Label();
            this.checkBox_GenerateSessionStateAlert = new System.Windows.Forms.CheckBox();
            this.checkBox_TempDBAlert = new System.Windows.Forms.CheckBox();
            this.numericUpDown_TempTB = new System.Windows.Forms.NumericUpDown();
            this.label_MB2 = new System.Windows.Forms.Label();
            this.numericUpDown_SessionAlert = new System.Windows.Forms.NumericUpDown();
            this.label_MB1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TempTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SessionAlert)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Location = new System.Drawing.Point(25, 38);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(53, 13);
            this.label_Database.TabIndex = 0;
            this.label_Database.Text = "Database";
            // 
            // textBox_Database
            // 
            this.textBox_Database.Location = new System.Drawing.Point(95, 35);
            this.textBox_Database.Name = "textBox_Database";
            this.textBox_Database.Size = new System.Drawing.Size(174, 20);
            this.textBox_Database.TabIndex = 2;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(25, 64);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(29, 13);
            this.label_User.TabIndex = 3;
            this.label_User.Text = "User";
            // 
            // textBox_DBUser
            // 
            this.textBox_DBUser.Location = new System.Drawing.Point(95, 61);
            this.textBox_DBUser.Name = "textBox_DBUser";
            this.textBox_DBUser.Size = new System.Drawing.Size(174, 20);
            this.textBox_DBUser.TabIndex = 4;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(25, 90);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // textBox_DBPassword
            // 
            this.textBox_DBPassword.Location = new System.Drawing.Point(95, 87);
            this.textBox_DBPassword.Name = "textBox_DBPassword";
            this.textBox_DBPassword.PasswordChar = '*';
            this.textBox_DBPassword.Size = new System.Drawing.Size(174, 20);
            this.textBox_DBPassword.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Database Watcher";
            // 
            // label_Wait
            // 
            this.label_Wait.AutoSize = true;
            this.label_Wait.Location = new System.Drawing.Point(288, 90);
            this.label_Wait.Name = "label_Wait";
            this.label_Wait.Size = new System.Drawing.Size(82, 13);
            this.label_Wait.TabIndex = 8;
            this.label_Wait.Text = "Please Wait .... ";
            // 
            // checkBox_GenerateSessionStateAlert
            // 
            this.checkBox_GenerateSessionStateAlert.AutoSize = true;
            this.checkBox_GenerateSessionStateAlert.Location = new System.Drawing.Point(28, 134);
            this.checkBox_GenerateSessionStateAlert.Name = "checkBox_GenerateSessionStateAlert";
            this.checkBox_GenerateSessionStateAlert.Size = new System.Drawing.Size(128, 17);
            this.checkBox_GenerateSessionStateAlert.TabIndex = 9;
            this.checkBox_GenerateSessionStateAlert.Text = "Session State Alert At";
            this.checkBox_GenerateSessionStateAlert.UseVisualStyleBackColor = true;
            this.checkBox_GenerateSessionStateAlert.CheckedChanged += new System.EventHandler(this.checkBox_GenerateSessionStateAlert_CheckedChanged);
            // 
            // checkBox_TempDBAlert
            // 
            this.checkBox_TempDBAlert.AutoSize = true;
            this.checkBox_TempDBAlert.Location = new System.Drawing.Point(28, 157);
            this.checkBox_TempDBAlert.Name = "checkBox_TempDBAlert";
            this.checkBox_TempDBAlert.Size = new System.Drawing.Size(108, 17);
            this.checkBox_TempDBAlert.TabIndex = 10;
            this.checkBox_TempDBAlert.Text = "Temp DB Alert At";
            this.checkBox_TempDBAlert.UseVisualStyleBackColor = true;
            this.checkBox_TempDBAlert.CheckedChanged += new System.EventHandler(this.checkBox_TempDBAlert_CheckedChanged);
            // 
            // numericUpDown_TempTB
            // 
            this.numericUpDown_TempTB.Location = new System.Drawing.Point(170, 156);
            this.numericUpDown_TempTB.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_TempTB.Name = "numericUpDown_TempTB";
            this.numericUpDown_TempTB.Size = new System.Drawing.Size(87, 20);
            this.numericUpDown_TempTB.TabIndex = 11;
            // 
            // label_MB2
            // 
            this.label_MB2.AutoSize = true;
            this.label_MB2.Location = new System.Drawing.Point(264, 158);
            this.label_MB2.Name = "label_MB2";
            this.label_MB2.Size = new System.Drawing.Size(23, 13);
            this.label_MB2.TabIndex = 12;
            this.label_MB2.Text = "MB";
            // 
            // numericUpDown_SessionAlert
            // 
            this.numericUpDown_SessionAlert.Location = new System.Drawing.Point(170, 133);
            this.numericUpDown_SessionAlert.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_SessionAlert.Name = "numericUpDown_SessionAlert";
            this.numericUpDown_SessionAlert.Size = new System.Drawing.Size(87, 20);
            this.numericUpDown_SessionAlert.TabIndex = 13;
            // 
            // label_MB1
            // 
            this.label_MB1.AutoSize = true;
            this.label_MB1.Location = new System.Drawing.Point(264, 135);
            this.label_MB1.Name = "label_MB1";
            this.label_MB1.Size = new System.Drawing.Size(23, 13);
            this.label_MB1.TabIndex = 14;
            this.label_MB1.Text = "MB";
            // 
            // PanelDatabaseWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_MB1);
            this.Controls.Add(this.numericUpDown_SessionAlert);
            this.Controls.Add(this.label_MB2);
            this.Controls.Add(this.numericUpDown_TempTB);
            this.Controls.Add(this.checkBox_TempDBAlert);
            this.Controls.Add(this.checkBox_GenerateSessionStateAlert);
            this.Controls.Add(this.label_Wait);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_DBPassword);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox_DBUser);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.textBox_Database);
            this.Controls.Add(this.label_Database);
            this.Name = "PanelDatabaseWatcher";
            this.Size = new System.Drawing.Size(440, 260);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TempTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SessionAlert)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.TextBox textBox_Database;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox_DBUser;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_DBPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Wait;
        private System.Windows.Forms.CheckBox checkBox_GenerateSessionStateAlert;
        private System.Windows.Forms.CheckBox checkBox_TempDBAlert;
        private System.Windows.Forms.NumericUpDown numericUpDown_TempTB;
        private System.Windows.Forms.Label label_MB2;
        private System.Windows.Forms.NumericUpDown numericUpDown_SessionAlert;
        private System.Windows.Forms.Label label_MB1;
    }
}
