namespace PMASysAlertsUI
{
    partial class PanelSQLController
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
            this.label_SQLController = new System.Windows.Forms.Label();
            this.label_Database = new System.Windows.Forms.Label();
            this.label_User = new System.Windows.Forms.Label();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Database = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.button_TestConnection = new System.Windows.Forms.Button();
            this.label_connection = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_SQLController
            // 
            this.label_SQLController.AutoSize = true;
            this.label_SQLController.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SQLController.Location = new System.Drawing.Point(15, 17);
            this.label_SQLController.Name = "label_SQLController";
            this.label_SQLController.Size = new System.Drawing.Size(89, 13);
            this.label_SQLController.TabIndex = 0;
            this.label_SQLController.Text = "SQL Controller";
            // 
            // label_Database
            // 
            this.label_Database.AutoSize = true;
            this.label_Database.Location = new System.Drawing.Point(21, 61);
            this.label_Database.Name = "label_Database";
            this.label_Database.Size = new System.Drawing.Size(53, 13);
            this.label_Database.TabIndex = 1;
            this.label_Database.Text = "Database";
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(21, 87);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(29, 13);
            this.label_User.TabIndex = 2;
            this.label_User.Text = "User";
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(21, 115);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 3;
            this.label_Password.Text = "Password";
            // 
            // textBox_Database
            // 
            this.textBox_Database.Location = new System.Drawing.Point(91, 58);
            this.textBox_Database.Name = "textBox_Database";
            this.textBox_Database.Size = new System.Drawing.Size(193, 20);
            this.textBox_Database.TabIndex = 4;
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(91, 84);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(193, 20);
            this.textBox_User.TabIndex = 5;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(91, 112);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(193, 20);
            this.textBox_Password.TabIndex = 6;
            // 
            // button_TestConnection
            // 
            this.button_TestConnection.Location = new System.Drawing.Point(24, 152);
            this.button_TestConnection.Name = "button_TestConnection";
            this.button_TestConnection.Size = new System.Drawing.Size(110, 23);
            this.button_TestConnection.TabIndex = 7;
            this.button_TestConnection.Text = "Test Connection";
            this.button_TestConnection.UseVisualStyleBackColor = true;
            this.button_TestConnection.Click += new System.EventHandler(this.button_TestConnection_Click);
            // 
            // label_connection
            // 
            this.label_connection.AutoSize = true;
            this.label_connection.Location = new System.Drawing.Point(156, 157);
            this.label_connection.Name = "label_connection";
            this.label_connection.Size = new System.Drawing.Size(162, 13);
            this.label_connection.TabIndex = 8;
            this.label_connection.Text = "Testing Connection Please Wait.";
            // 
            // PanelSQLController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_connection);
            this.Controls.Add(this.button_TestConnection);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.textBox_Database);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.label_Database);
            this.Controls.Add(this.label_SQLController);
            this.Name = "PanelSQLController";
            this.Size = new System.Drawing.Size(500, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_SQLController;
        private System.Windows.Forms.Label label_Database;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Database;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.Button button_TestConnection;
        private System.Windows.Forms.Label label_connection;
    }
}
