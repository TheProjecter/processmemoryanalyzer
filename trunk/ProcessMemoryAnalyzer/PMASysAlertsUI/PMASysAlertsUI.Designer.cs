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
            System.Windows.Forms.Label label_DatabaseOptimizer;
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopServiceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.transportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_MainContainer = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_Home = new System.Windows.Forms.Label();
            this.label_Drives = new System.Windows.Forms.Label();
            this.label_Service = new System.Windows.Forms.Label();
            this.label_PhysicalMemory = new System.Windows.Forms.Label();
            this.label_Transport = new System.Windows.Forms.Label();
            label_DatabaseOptimizer = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_DatabaseOptimizer
            // 
            label_DatabaseOptimizer.AutoSize = true;
            label_DatabaseOptimizer.Location = new System.Drawing.Point(3, 108);
            label_DatabaseOptimizer.Name = "label_DatabaseOptimizer";
            label_DatabaseOptimizer.Size = new System.Drawing.Size(99, 13);
            label_DatabaseOptimizer.TabIndex = 3;
            label_DatabaseOptimizer.Text = "Database Optimizer";
            label_DatabaseOptimizer.Click += new System.EventHandler(this.label_DatabaseOptimizer_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.transportToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(605, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startServiceToolStripMenuItem,
            this.stopServiceToolStripMenuItem,
            this.stopServiceToolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // startServiceToolStripMenuItem
            // 
            this.startServiceToolStripMenuItem.Name = "startServiceToolStripMenuItem";
            this.startServiceToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.startServiceToolStripMenuItem.Text = "Home";
            // 
            // stopServiceToolStripMenuItem
            // 
            this.stopServiceToolStripMenuItem.Name = "stopServiceToolStripMenuItem";
            this.stopServiceToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.stopServiceToolStripMenuItem.Text = "Start Service";
            this.stopServiceToolStripMenuItem.Click += new System.EventHandler(this.stopServiceToolStripMenuItem_Click);
            // 
            // stopServiceToolStripMenuItem1
            // 
            this.stopServiceToolStripMenuItem1.Name = "stopServiceToolStripMenuItem1";
            this.stopServiceToolStripMenuItem1.Size = new System.Drawing.Size(136, 22);
            this.stopServiceToolStripMenuItem1.Text = "Stop Service";
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
            // 
            // fTPToolStripMenuItem
            // 
            this.fTPToolStripMenuItem.Name = "fTPToolStripMenuItem";
            this.fTPToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.fTPToolStripMenuItem.Text = "FTP";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panel_MainContainer
            // 
            this.panel_MainContainer.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel_MainContainer.Location = new System.Drawing.Point(172, 40);
            this.panel_MainContainer.Name = "panel_MainContainer";
            this.panel_MainContainer.Size = new System.Drawing.Size(421, 221);
            this.panel_MainContainer.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_Home, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label_Drives, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Service, 0, 2);
            this.tableLayoutPanel1.Controls.Add(label_DatabaseOptimizer, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label_PhysicalMemory, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label_Transport, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 40);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(112, 221);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // label_Home
            // 
            this.label_Home.AutoSize = true;
            this.label_Home.Location = new System.Drawing.Point(3, 0);
            this.label_Home.Name = "label_Home";
            this.label_Home.Size = new System.Drawing.Size(35, 13);
            this.label_Home.TabIndex = 0;
            this.label_Home.Text = "Home";
            this.label_Home.Click += new System.EventHandler(this.label_Home_Click);
            // 
            // label_Drives
            // 
            this.label_Drives.AutoSize = true;
            this.label_Drives.Location = new System.Drawing.Point(3, 36);
            this.label_Drives.Name = "label_Drives";
            this.label_Drives.Size = new System.Drawing.Size(37, 13);
            this.label_Drives.TabIndex = 1;
            this.label_Drives.Text = "Drives";
            this.label_Drives.Click += new System.EventHandler(this.label_Drives_Click);
            // 
            // label_Service
            // 
            this.label_Service.AutoSize = true;
            this.label_Service.Location = new System.Drawing.Point(3, 72);
            this.label_Service.Name = "label_Service";
            this.label_Service.Size = new System.Drawing.Size(48, 13);
            this.label_Service.TabIndex = 2;
            this.label_Service.Text = "Services";
            this.label_Service.Click += new System.EventHandler(this.label_Service_Click);
            // 
            // label_PhysicalMemory
            // 
            this.label_PhysicalMemory.AutoSize = true;
            this.label_PhysicalMemory.Location = new System.Drawing.Point(3, 144);
            this.label_PhysicalMemory.Name = "label_PhysicalMemory";
            this.label_PhysicalMemory.Size = new System.Drawing.Size(86, 13);
            this.label_PhysicalMemory.TabIndex = 4;
            this.label_PhysicalMemory.Text = "Physical Memory";
            this.label_PhysicalMemory.Click += new System.EventHandler(this.label_PhysicalMemory_Click);
            // 
            // label_Transport
            // 
            this.label_Transport.AutoSize = true;
            this.label_Transport.Location = new System.Drawing.Point(3, 180);
            this.label_Transport.Name = "label_Transport";
            this.label_Transport.Size = new System.Drawing.Size(57, 13);
            this.label_Transport.TabIndex = 5;
            this.label_Transport.Text = "Transports";
            this.label_Transport.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label_Transport.Click += new System.EventHandler(this.label_Transport_Click);
            // 
            // PMASysAlertsUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Desktop;
            this.ClientSize = new System.Drawing.Size(605, 273);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel_MainContainer);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PMASysAlertsUI";
            this.Text = "System Analyzer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopServiceToolStripMenuItem1;
        private System.Windows.Forms.Panel panel_MainContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_Home;
        private System.Windows.Forms.Label label_Drives;
        private System.Windows.Forms.Label label_Service;
        private System.Windows.Forms.Label label_PhysicalMemory;
        private System.Windows.Forms.Label label_Transport;

    }
}

