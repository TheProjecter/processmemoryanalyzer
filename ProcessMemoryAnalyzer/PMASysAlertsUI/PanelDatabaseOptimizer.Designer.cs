namespace PMASysAlertsUI
{
    partial class PanelDatabaseOptimizer
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
            this.checkBox_IsWebServer = new System.Windows.Forms.CheckBox();
            this.textBox_Database = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Location = new System.Drawing.Point(25, 86);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(53, 13);
            this.label_Database.TabIndex = 0;
            this.label_Database.Text = "Database";
            // 
            // checkBox_IsWebServer
            // 
            this.checkBox_IsWebServer.AutoSize = true;
            this.checkBox_IsWebServer.Location = new System.Drawing.Point(28, 48);
            this.checkBox_IsWebServer.Name = "checkBox_IsWebServer";
            this.checkBox_IsWebServer.Size = new System.Drawing.Size(94, 17);
            this.checkBox_IsWebServer.TabIndex = 1;
            this.checkBox_IsWebServer.Text = "Is Web Server";
            this.checkBox_IsWebServer.UseVisualStyleBackColor = true;
            this.checkBox_IsWebServer.CheckedChanged += new System.EventHandler(this.checkBox_IsWebServer_CheckedChanged);
            // 
            // textBox_Database
            // 
            this.textBox_Database.Location = new System.Drawing.Point(95, 83);
            this.textBox_Database.Name = "textBox_Database";
            this.textBox_Database.Size = new System.Drawing.Size(174, 20);
            this.textBox_Database.TabIndex = 2;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(25, 112);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(29, 13);
            this.label_User.TabIndex = 3;
            this.label_User.Text = "User";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(95, 109);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(174, 20);
            this.textBox2.TabIndex = 4;
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(25, 138);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 5;
            this.label_Password.Text = "Password";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(95, 135);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(174, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Database Optimizer";
            // 
            // PanelDatabaseOptimizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.textBox_Database);
            this.Controls.Add(this.checkBox_IsWebServer);
            this.Controls.Add(this.label_Database);
            this.Name = "PanelDatabaseOptimizer";
            this.Size = new System.Drawing.Size(400, 200);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.CheckBox checkBox_IsWebServer;
        private System.Windows.Forms.TextBox textBox_Database;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label1;
    }
}
