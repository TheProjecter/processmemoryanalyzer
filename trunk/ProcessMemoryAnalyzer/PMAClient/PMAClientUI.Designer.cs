namespace PMA.Client
{
    partial class PMAClientUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_LeftMenu = new System.Windows.Forms.TableLayoutPanel();
            this.label_Actions = new System.Windows.Forms.Label();
            this.label_Services = new System.Windows.Forms.Label();
            this.label_SQL = new System.Windows.Forms.Label();
            this.label_TaskManager = new System.Windows.Forms.Label();
            this.panel_MainContainer = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_Time = new System.Windows.Forms.Label();
            this.label_Date = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel_LeftMenu.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1047, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.logoutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.fileToolStripMenuItem.Text = "System";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.tableLayoutPanel_LeftMenu);
            this.panel1.Location = new System.Drawing.Point(13, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(146, 460);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel_LeftMenu
            // 
            this.tableLayoutPanel_LeftMenu.ColumnCount = 1;
            this.tableLayoutPanel_LeftMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_LeftMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_Actions, 0, 3);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_Services, 0, 2);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_SQL, 0, 1);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_TaskManager, 0, 0);
            this.tableLayoutPanel_LeftMenu.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_LeftMenu.Name = "tableLayoutPanel_LeftMenu";
            this.tableLayoutPanel_LeftMenu.RowCount = 4;
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_LeftMenu.Size = new System.Drawing.Size(140, 348);
            this.tableLayoutPanel_LeftMenu.TabIndex = 0;
            // 
            // label_Actions
            // 
            this.label_Actions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Actions.AutoSize = true;
            this.label_Actions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Actions.Location = new System.Drawing.Point(35, 294);
            this.label_Actions.Name = "label_Actions";
            this.label_Actions.Size = new System.Drawing.Size(69, 20);
            this.label_Actions.TabIndex = 2;
            this.label_Actions.Text = "Actions";
            this.label_Actions.Click += new System.EventHandler(this.label_Actions_Click);
            // 
            // label_Services
            // 
            this.label_Services.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_Services.AutoSize = true;
            this.label_Services.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Services.Location = new System.Drawing.Point(31, 207);
            this.label_Services.Name = "label_Services";
            this.label_Services.Size = new System.Drawing.Size(77, 20);
            this.label_Services.TabIndex = 1;
            this.label_Services.Text = "Services";
            this.label_Services.Click += new System.EventHandler(this.label_Services_Click);
            // 
            // label_SQL
            // 
            this.label_SQL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_SQL.AutoSize = true;
            this.label_SQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SQL.Location = new System.Drawing.Point(48, 120);
            this.label_SQL.Name = "label_SQL";
            this.label_SQL.Size = new System.Drawing.Size(44, 20);
            this.label_SQL.TabIndex = 0;
            this.label_SQL.Text = "SQL";
            this.label_SQL.Click += new System.EventHandler(this.label_SQL_Click);
            // 
            // label_TaskManager
            // 
            this.label_TaskManager.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_TaskManager.AutoSize = true;
            this.label_TaskManager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TaskManager.Location = new System.Drawing.Point(9, 33);
            this.label_TaskManager.Name = "label_TaskManager";
            this.label_TaskManager.Size = new System.Drawing.Size(122, 20);
            this.label_TaskManager.TabIndex = 3;
            this.label_TaskManager.Text = "Task Manager";
            this.label_TaskManager.Click += new System.EventHandler(this.label_TaskManager_Click);
            // 
            // panel_MainContainer
            // 
            this.panel_MainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_MainContainer.Location = new System.Drawing.Point(181, 46);
            this.panel_MainContainer.Name = "panel_MainContainer";
            this.panel_MainContainer.Size = new System.Drawing.Size(852, 460);
            this.panel_MainContainer.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label_Date);
            this.panel2.Controls.Add(this.label_Time);
            this.panel2.Location = new System.Drawing.Point(3, 357);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(140, 100);
            this.panel2.TabIndex = 1;
            // 
            // label_Time
            // 
            this.label_Time.AutoSize = true;
            this.label_Time.Location = new System.Drawing.Point(49, 34);
            this.label_Time.Name = "label_Time";
            this.label_Time.Size = new System.Drawing.Size(44, 13);
            this.label_Time.TabIndex = 0;
            this.label_Time.Text = "HH:MM";
            // 
            // label_Date
            // 
            this.label_Date.AutoSize = true;
            this.label_Date.Location = new System.Drawing.Point(36, 61);
            this.label_Date.Name = "label_Date";
            this.label_Date.Size = new System.Drawing.Size(79, 13);
            this.label_Date.TabIndex = 1;
            this.label_Date.Text = "DD/MM/YYYY";
            // 
            // PMAClientUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GrayText;
            this.ClientSize = new System.Drawing.Size(1047, 527);
            this.Controls.Add(this.panel_MainContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PMAClientUI";
            this.Text = "PMAClient";
            this.Shown += new System.EventHandler(this.PMAClientUI_Shown);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMAClientUI_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel_LeftMenu.ResumeLayout(false);
            this.tableLayoutPanel_LeftMenu.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_MainContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_LeftMenu;
        private System.Windows.Forms.Label label_SQL;
        private System.Windows.Forms.Label label_Services;
        private System.Windows.Forms.Label label_Actions;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label_TaskManager;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_Date;
        private System.Windows.Forms.Label label_Time;
    }
}

