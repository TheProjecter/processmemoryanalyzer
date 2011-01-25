namespace PMASysAlertsUI
{
    partial class PanelUserControl
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
            this.dataGridView_users = new System.Windows.Forms.DataGridView();
            this.label_UserControl = new System.Windows.Forms.Label();
            this.checkBox_Action = new System.Windows.Forms.CheckBox();
            this.checkBox_SQL = new System.Windows.Forms.CheckBox();
            this.checkBox_Services = new System.Windows.Forms.CheckBox();
            this.button_Add = new System.Windows.Forms.Button();
            this.label_Password = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_User = new System.Windows.Forms.TextBox();
            this.label_User = new System.Windows.Forms.Label();
            this.User = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PasswordString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Password = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Action = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SQL = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Services = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RemoveUser = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_users)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_users
            // 
            this.dataGridView_users.AllowUserToAddRows = false;
            this.dataGridView_users.AllowUserToDeleteRows = false;
            this.dataGridView_users.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_users.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.User,
            this.PasswordString,
            this.Password,
            this.Action,
            this.SQL,
            this.Services,
            this.RemoveUser});
            this.dataGridView_users.Location = new System.Drawing.Point(12, 124);
            this.dataGridView_users.Name = "dataGridView_users";
            this.dataGridView_users.ReadOnly = true;
            this.dataGridView_users.Size = new System.Drawing.Size(466, 177);
            this.dataGridView_users.TabIndex = 0;
            // 
            // label_UserControl
            // 
            this.label_UserControl.AutoSize = true;
            this.label_UserControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_UserControl.Location = new System.Drawing.Point(9, 9);
            this.label_UserControl.Name = "label_UserControl";
            this.label_UserControl.Size = new System.Drawing.Size(77, 13);
            this.label_UserControl.TabIndex = 2;
            this.label_UserControl.Text = "User Control";
            // 
            // checkBox_Action
            // 
            this.checkBox_Action.AutoSize = true;
            this.checkBox_Action.Location = new System.Drawing.Point(12, 95);
            this.checkBox_Action.Name = "checkBox_Action";
            this.checkBox_Action.Size = new System.Drawing.Size(56, 17);
            this.checkBox_Action.TabIndex = 5;
            this.checkBox_Action.Text = "Action";
            this.checkBox_Action.UseVisualStyleBackColor = true;
            // 
            // checkBox_SQL
            // 
            this.checkBox_SQL.AutoSize = true;
            this.checkBox_SQL.Location = new System.Drawing.Point(74, 95);
            this.checkBox_SQL.Name = "checkBox_SQL";
            this.checkBox_SQL.Size = new System.Drawing.Size(47, 17);
            this.checkBox_SQL.TabIndex = 6;
            this.checkBox_SQL.Text = "SQL";
            this.checkBox_SQL.UseVisualStyleBackColor = true;
            // 
            // checkBox_Services
            // 
            this.checkBox_Services.AutoSize = true;
            this.checkBox_Services.Location = new System.Drawing.Point(127, 95);
            this.checkBox_Services.Name = "checkBox_Services";
            this.checkBox_Services.Size = new System.Drawing.Size(67, 17);
            this.checkBox_Services.TabIndex = 7;
            this.checkBox_Services.Text = "Services";
            this.checkBox_Services.UseVisualStyleBackColor = true;
            // 
            // button_Add
            // 
            this.button_Add.Location = new System.Drawing.Point(403, 91);
            this.button_Add.Name = "button_Add";
            this.button_Add.Size = new System.Drawing.Size(75, 23);
            this.button_Add.TabIndex = 1;
            this.button_Add.Text = "Add";
            this.button_Add.UseVisualStyleBackColor = true;
            this.button_Add.Click += new System.EventHandler(this.button_Add_Click);
            // 
            // label_Password
            // 
            this.label_Password.AutoSize = true;
            this.label_Password.Location = new System.Drawing.Point(9, 59);
            this.label_Password.Name = "label_Password";
            this.label_Password.Size = new System.Drawing.Size(53, 13);
            this.label_Password.TabIndex = 4;
            this.label_Password.Text = "Password";
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(74, 56);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(139, 20);
            this.textBox_Password.TabIndex = 9;
            // 
            // textBox_User
            // 
            this.textBox_User.Location = new System.Drawing.Point(74, 31);
            this.textBox_User.Name = "textBox_User";
            this.textBox_User.Size = new System.Drawing.Size(139, 20);
            this.textBox_User.TabIndex = 8;
            // 
            // label_User
            // 
            this.label_User.AutoSize = true;
            this.label_User.Location = new System.Drawing.Point(9, 34);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(29, 13);
            this.label_User.TabIndex = 3;
            this.label_User.Text = "User";
            // 
            // User
            // 
            this.User.HeaderText = "User";
            this.User.Name = "User";
            this.User.ReadOnly = true;
            // 
            // PasswordString
            // 
            this.PasswordString.HeaderText = "HiddenPassword";
            this.PasswordString.Name = "PasswordString";
            this.PasswordString.ReadOnly = true;
            this.PasswordString.Visible = false;
            // 
            // Password
            // 
            this.Password.HeaderText = "Password";
            this.Password.Name = "Password";
            this.Password.ReadOnly = true;
            this.Password.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Password.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Password.Text = "Reset";
            this.Password.Width = 93;
            // 
            // Action
            // 
            this.Action.HeaderText = "Action";
            this.Action.Name = "Action";
            this.Action.ReadOnly = true;
            this.Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Action.Width = 50;
            // 
            // SQL
            // 
            this.SQL.HeaderText = "SQL";
            this.SQL.Name = "SQL";
            this.SQL.ReadOnly = true;
            this.SQL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SQL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SQL.Width = 30;
            // 
            // Services
            // 
            this.Services.HeaderText = "Services";
            this.Services.Name = "Services";
            this.Services.ReadOnly = true;
            this.Services.Width = 50;
            // 
            // RemoveUser
            // 
            this.RemoveUser.HeaderText = "RemoveUser";
            this.RemoveUser.Name = "RemoveUser";
            this.RemoveUser.ReadOnly = true;
            this.RemoveUser.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RemoveUser.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.RemoveUser.Text = "Remove";
            // 
            // PanelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_User);
            this.Controls.Add(this.checkBox_Services);
            this.Controls.Add(this.checkBox_SQL);
            this.Controls.Add(this.checkBox_Action);
            this.Controls.Add(this.label_Password);
            this.Controls.Add(this.label_User);
            this.Controls.Add(this.label_UserControl);
            this.Controls.Add(this.button_Add);
            this.Controls.Add(this.dataGridView_users);
            this.Name = "PanelUserControl";
            this.Size = new System.Drawing.Size(500, 315);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_users)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_users;
        private System.Windows.Forms.Label label_UserControl;
        private System.Windows.Forms.CheckBox checkBox_Action;
        private System.Windows.Forms.CheckBox checkBox_SQL;
        private System.Windows.Forms.CheckBox checkBox_Services;
        private System.Windows.Forms.Button button_Add;
        private System.Windows.Forms.Label label_Password;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_User;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.DataGridViewTextBoxColumn User;
        private System.Windows.Forms.DataGridViewTextBoxColumn PasswordString;
        private System.Windows.Forms.DataGridViewButtonColumn Password;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Action;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SQL;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Services;
        private System.Windows.Forms.DataGridViewButtonColumn RemoveUser;
    }
}
