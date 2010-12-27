namespace PMASysAlertsUI
{
    partial class PMASysAlertsUI
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label_DatabaseWatcher;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PMASysAlertsUI));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServiceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_MainContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel_LeftMenu = new System.Windows.Forms.TableLayoutPanel();
            this.label_Home = new System.Windows.Forms.Label();
            this.label_Drives = new System.Windows.Forms.Label();
            this.label_Service = new System.Windows.Forms.Label();
            this.label_PhysicalMemory = new System.Windows.Forms.Label();
            this.label_PMA = new System.Windows.Forms.Label();
            this.label_Transport = new System.Windows.Forms.Label();
            this.label_crash = new System.Windows.Forms.Label();
            this.notifyIconSystemAnalyzer = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStripNotifcationIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iISResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            label_DatabaseWatcher = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel_LeftMenu.SuspendLayout();
            this.contextMenuStripNotifcationIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_DatabaseWatcher
            // 
            label_DatabaseWatcher.AutoSize = true;
            label_DatabaseWatcher.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label_DatabaseWatcher.Location = new System.Drawing.Point(3, 99);
            label_DatabaseWatcher.Name = "label_DatabaseWatcher";
            label_DatabaseWatcher.Size = new System.Drawing.Size(113, 13);
            label_DatabaseWatcher.TabIndex = 3;
            label_DatabaseWatcher.Text = "Database Watcher";
            label_DatabaseWatcher.Click += new System.EventHandler(this.label_DatabaseWatcher_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transportToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(642, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServiceToolStripMenuItem,
            this.stopServiceToolStripMenuItem1,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startServiceToolStripMenuItem
            // 
            this.startServiceToolStripMenuItem.Name = "startServiceToolStripMenuItem";
            this.startServiceToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.startServiceToolStripMenuItem.Text = "Start Service";
            this.startServiceToolStripMenuItem.Click += new System.EventHandler(this.startServiceToolStripMenuItem_Click);
            // 
            // stopServiceToolStripMenuItem1
            // 
            this.stopServiceToolStripMenuItem1.Name = "stopServiceToolStripMenuItem1";
            this.stopServiceToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.stopServiceToolStripMenuItem1.Text = "Stop Service";
            this.stopServiceToolStripMenuItem1.Click += new System.EventHandler(this.stopServiceToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem1.Text = "Service Status";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // transportToolStripMenuItem
            // 
            this.transportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sMTPToolStripMenuItem,
            this.fTPToolStripMenuItem});
            this.transportToolStripMenuItem.Name = "transportToolStripMenuItem";
            this.transportToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.transportToolStripMenuItem.Text = "Transport";
            // 
            // sMTPToolStripMenuItem
            // 
            this.sMTPToolStripMenuItem.Name = "sMTPToolStripMenuItem";
            this.sMTPToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.sMTPToolStripMenuItem.Text = "SMTP";
            this.sMTPToolStripMenuItem.Click += new System.EventHandler(this.sMTPToolStripMenuItem_Click);
            // 
            // fTPToolStripMenuItem
            // 
            this.fTPToolStripMenuItem.Name = "fTPToolStripMenuItem";
            this.fTPToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.fTPToolStripMenuItem.Text = "FTP";
            this.fTPToolStripMenuItem.Click += new System.EventHandler(this.fTPToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loggerToolStripMenuItem,
            this.systemInformationToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // loggerToolStripMenuItem
            // 
            this.loggerToolStripMenuItem.Name = "loggerToolStripMenuItem";
            this.loggerToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.loggerToolStripMenuItem.Text = "Logger";
            this.loggerToolStripMenuItem.Click += new System.EventHandler(this.loggerToolStripMenuItem_Click_1);
            // 
            // systemInformationToolStripMenuItem
            // 
            this.systemInformationToolStripMenuItem.Name = "systemInformationToolStripMenuItem";
            this.systemInformationToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.systemInformationToolStripMenuItem.Text = "System Information";
            this.systemInformationToolStripMenuItem.Click += new System.EventHandler(this.systemInformationToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.aboutToolStripMenuItem1});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem1
            // 
            this.aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            this.aboutToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem1.Text = "About";
            this.aboutToolStripMenuItem1.Click += new System.EventHandler(this.aboutToolStripMenuItem1_Click);
            // 
            // panel_MainContainer
            // 
            this.panel_MainContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_MainContainer.Location = new System.Drawing.Point(175, 41);
            this.panel_MainContainer.Name = "panel_MainContainer";
            this.panel_MainContainer.Size = new System.Drawing.Size(450, 270);
            this.panel_MainContainer.TabIndex = 2;
            // 
            // tableLayoutPanel_LeftMenu
            // 
            this.tableLayoutPanel_LeftMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tableLayoutPanel_LeftMenu.ColumnCount = 1;
            this.tableLayoutPanel_LeftMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_Home, 0, 0);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_Drives, 0, 1);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_Service, 0, 2);
            this.tableLayoutPanel_LeftMenu.Controls.Add(label_DatabaseWatcher, 0, 3);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_PhysicalMemory, 0, 4);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_PMA, 0, 5);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_Transport, 0, 7);
            this.tableLayoutPanel_LeftMenu.Controls.Add(this.label_crash, 0, 6);
            this.tableLayoutPanel_LeftMenu.Location = new System.Drawing.Point(13, 40);
            this.tableLayoutPanel_LeftMenu.Name = "tableLayoutPanel_LeftMenu";
            this.tableLayoutPanel_LeftMenu.RowCount = 8;
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel_LeftMenu.Size = new System.Drawing.Size(130, 271);
            this.tableLayoutPanel_LeftMenu.TabIndex = 3;
            // 
            // label_Home
            // 
            this.label_Home.AutoSize = true;
            this.label_Home.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label_Home.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Home.Location = new System.Drawing.Point(3, 0);
            this.label_Home.Name = "label_Home";
            this.label_Home.Size = new System.Drawing.Size(39, 13);
            this.label_Home.TabIndex = 0;
            this.label_Home.Text = "Home";
            this.label_Home.Click += new System.EventHandler(this.label_Home_Click);
            // 
            // label_Drives
            // 
            this.label_Drives.AutoSize = true;
            this.label_Drives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Drives.Location = new System.Drawing.Point(3, 33);
            this.label_Drives.Name = "label_Drives";
            this.label_Drives.Size = new System.Drawing.Size(43, 13);
            this.label_Drives.TabIndex = 1;
            this.label_Drives.Text = "Drives";
            this.label_Drives.Click += new System.EventHandler(this.label_Drives_Click);
            // 
            // label_Service
            // 
            this.label_Service.AutoSize = true;
            this.label_Service.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Service.Location = new System.Drawing.Point(3, 66);
            this.label_Service.Name = "label_Service";
            this.label_Service.Size = new System.Drawing.Size(56, 13);
            this.label_Service.TabIndex = 2;
            this.label_Service.Text = "Services";
            this.label_Service.Click += new System.EventHandler(this.label_Service_Click);
            // 
            // label_PhysicalMemory
            // 
            this.label_PhysicalMemory.AutoSize = true;
            this.label_PhysicalMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PhysicalMemory.Location = new System.Drawing.Point(3, 132);
            this.label_PhysicalMemory.Name = "label_PhysicalMemory";
            this.label_PhysicalMemory.Size = new System.Drawing.Size(101, 13);
            this.label_PhysicalMemory.TabIndex = 4;
            this.label_PhysicalMemory.Text = "Physical Memory";
            this.label_PhysicalMemory.Click += new System.EventHandler(this.label_PhysicalMemory_Click);
            // 
            // label_PMA
            // 
            this.label_PMA.AutoSize = true;
            this.label_PMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PMA.Location = new System.Drawing.Point(3, 165);
            this.label_PMA.Name = "label_PMA";
            this.label_PMA.Size = new System.Drawing.Size(33, 13);
            this.label_PMA.TabIndex = 6;
            this.label_PMA.Text = "PMA";
            this.label_PMA.Click += new System.EventHandler(this.label_PMA_Click);
            // 
            // label_Transport
            // 
            this.label_Transport.AutoSize = true;
            this.label_Transport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Transport.Location = new System.Drawing.Point(3, 231);
            this.label_Transport.Name = "label_Transport";
            this.label_Transport.Size = new System.Drawing.Size(77, 13);
            this.label_Transport.TabIndex = 5;
            this.label_Transport.Text = "Subscription";
            this.label_Transport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_Transport.Click += new System.EventHandler(this.label_Transport_Click);
            // 
            // label_crash
            // 
            this.label_crash.AutoSize = true;
            this.label_crash.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_crash.Location = new System.Drawing.Point(3, 198);
            this.label_crash.Name = "label_crash";
            this.label_crash.Size = new System.Drawing.Size(99, 13);
            this.label_crash.TabIndex = 7;
            this.label_crash.Text = "Event Reporting";
            this.label_crash.Click += new System.EventHandler(this.label_crash_Click);
            // 
            // notifyIconSystemAnalyzer
            // 
            this.notifyIconSystemAnalyzer.BalloonTipText = "System Analyzer is minimized";
            this.notifyIconSystemAnalyzer.BalloonTipTitle = "System Analyzer";
            this.notifyIconSystemAnalyzer.ContextMenuStrip = this.contextMenuStripNotifcationIcon;
            this.notifyIconSystemAnalyzer.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconSystemAnalyzer.Icon")));
            this.notifyIconSystemAnalyzer.Text = "System Analyzer";
            this.notifyIconSystemAnalyzer.Visible = true;
            this.notifyIconSystemAnalyzer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconSystemAnalyzer_MouseDoubleClick);
            // 
            // contextMenuStripNotifcationIcon
            // 
            this.contextMenuStripNotifcationIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.hideToolStripMenuItem,
            this.iISResetToolStripMenuItem,
            this.exitToolStripMenuItem1});
            this.contextMenuStripNotifcationIcon.Name = "contextMenuStripNotifcationIcon";
            this.contextMenuStripNotifcationIcon.Size = new System.Drawing.Size(117, 92);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.showToolStripMenuItem.Text = "Show";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // hideToolStripMenuItem
            // 
            this.hideToolStripMenuItem.Name = "hideToolStripMenuItem";
            this.hideToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.hideToolStripMenuItem.Text = "Hide";
            this.hideToolStripMenuItem.Click += new System.EventHandler(this.hideToolStripMenuItem_Click);
            // 
            // iISResetToolStripMenuItem
            // 
            this.iISResetToolStripMenuItem.Name = "iISResetToolStripMenuItem";
            this.iISResetToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.iISResetToolStripMenuItem.Text = "IISReset";
            this.iISResetToolStripMenuItem.Click += new System.EventHandler(this.iISResetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem1
            // 
            this.exitToolStripMenuItem1.Name = "exitToolStripMenuItem1";
            this.exitToolStripMenuItem1.Size = new System.Drawing.Size(116, 22);
            this.exitToolStripMenuItem1.Text = "Exit";
            this.exitToolStripMenuItem1.Click += new System.EventHandler(this.exitToolStripMenuItem1_Click);
            // 
            // PMASysAlertsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(642, 323);
            this.Controls.Add(this.tableLayoutPanel_LeftMenu);
            this.Controls.Add(this.panel_MainContainer);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(650, 350);
            this.MinimumSize = new System.Drawing.Size(650, 350);
            this.Name = "PMASysAlertsUI";
            this.Text = "System Analyzer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PMASysAlertsUI_FormClosing);
            this.Resize += new System.EventHandler(this.PMASysAlertsUI_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel_LeftMenu.ResumeLayout(false);
            this.tableLayoutPanel_LeftMenu.PerformLayout();
            this.contextMenuStripNotifcationIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem1;
        private System.Windows.Forms.Panel panel_MainContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_LeftMenu;
        private System.Windows.Forms.Label label_Home;
        private System.Windows.Forms.Label label_Drives;
        private System.Windows.Forms.Label label_Service;
        private System.Windows.Forms.Label label_PhysicalMemory;
        private System.Windows.Forms.Label label_Transport;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loggerToolStripMenuItem;
        private System.Windows.Forms.Label label_PMA;
        private System.Windows.Forms.NotifyIcon notifyIconSystemAnalyzer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripNotifcationIcon;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iISResetToolStripMenuItem;
        private System.Windows.Forms.Label label_crash;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem systemInformationToolStripMenuItem;

    }
}

