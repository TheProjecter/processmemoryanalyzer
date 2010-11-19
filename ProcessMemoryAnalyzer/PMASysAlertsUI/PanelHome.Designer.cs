namespace PMASysAlertsUI
{
    partial class PanelHome
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_DriveWatch = new System.Windows.Forms.CheckBox();
            this.checkBox_ServiceWatch = new System.Windows.Forms.CheckBox();
            this.checkBox_MemWatch = new System.Windows.Forms.CheckBox();
            this.checkBox_DBOptimizer = new System.Windows.Forms.CheckBox();
            this.checkBox_ProcessWatch = new System.Windows.Forms.CheckBox();
            this.panel_Transport = new System.Windows.Forms.Panel();
            this.checkBox_UseSMTP = new System.Windows.Forms.CheckBox();
            this.checkBox_UseFTP = new System.Windows.Forms.CheckBox();
            this.checkBox_CrashReporting = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_Transport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.checkBox_DriveWatch, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_ServiceWatch, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_MemWatch, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_DBOptimizer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_ProcessWatch, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel_Transport, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_CrashReporting, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 31);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox_DriveWatch
            // 
            this.checkBox_DriveWatch.AutoSize = true;
            this.checkBox_DriveWatch.Location = new System.Drawing.Point(3, 3);
            this.checkBox_DriveWatch.Name = "checkBox_DriveWatch";
            this.checkBox_DriveWatch.Size = new System.Drawing.Size(86, 17);
            this.checkBox_DriveWatch.TabIndex = 0;
            this.checkBox_DriveWatch.Text = "Drive Watch";
            this.checkBox_DriveWatch.UseVisualStyleBackColor = true;
            // 
            // checkBox_ServiceWatch
            // 
            this.checkBox_ServiceWatch.AutoSize = true;
            this.checkBox_ServiceWatch.Location = new System.Drawing.Point(3, 48);
            this.checkBox_ServiceWatch.Name = "checkBox_ServiceWatch";
            this.checkBox_ServiceWatch.Size = new System.Drawing.Size(97, 17);
            this.checkBox_ServiceWatch.TabIndex = 1;
            this.checkBox_ServiceWatch.Text = "Service Watch";
            this.checkBox_ServiceWatch.UseVisualStyleBackColor = true;
            // 
            // checkBox_MemWatch
            // 
            this.checkBox_MemWatch.AutoSize = true;
            this.checkBox_MemWatch.Location = new System.Drawing.Point(195, 3);
            this.checkBox_MemWatch.Name = "checkBox_MemWatch";
            this.checkBox_MemWatch.Size = new System.Drawing.Size(98, 17);
            this.checkBox_MemWatch.TabIndex = 2;
            this.checkBox_MemWatch.Text = "Memory Watch";
            this.checkBox_MemWatch.UseVisualStyleBackColor = true;
            // 
            // checkBox_DBOptimizer
            // 
            this.checkBox_DBOptimizer.AutoSize = true;
            this.checkBox_DBOptimizer.Location = new System.Drawing.Point(195, 48);
            this.checkBox_DBOptimizer.Name = "checkBox_DBOptimizer";
            this.checkBox_DBOptimizer.Size = new System.Drawing.Size(118, 17);
            this.checkBox_DBOptimizer.TabIndex = 3;
            this.checkBox_DBOptimizer.Text = "Database Optimizer";
            this.checkBox_DBOptimizer.UseVisualStyleBackColor = true;
            // 
            // checkBox_ProcessWatch
            // 
            this.checkBox_ProcessWatch.AutoSize = true;
            this.checkBox_ProcessWatch.Location = new System.Drawing.Point(3, 93);
            this.checkBox_ProcessWatch.Name = "checkBox_ProcessWatch";
            this.checkBox_ProcessWatch.Size = new System.Drawing.Size(99, 17);
            this.checkBox_ProcessWatch.TabIndex = 6;
            this.checkBox_ProcessWatch.Text = "Process Watch";
            this.checkBox_ProcessWatch.UseVisualStyleBackColor = true;
            this.checkBox_ProcessWatch.CheckedChanged += new System.EventHandler(this.checkBox_ProcessWatch_CheckedChanged);
            // 
            // panel_Transport
            // 
            this.panel_Transport.Controls.Add(this.checkBox_UseSMTP);
            this.panel_Transport.Controls.Add(this.checkBox_UseFTP);
            this.panel_Transport.Location = new System.Drawing.Point(3, 138);
            this.panel_Transport.Name = "panel_Transport";
            this.panel_Transport.Size = new System.Drawing.Size(179, 39);
            this.panel_Transport.TabIndex = 5;
            // 
            // checkBox_UseSMTP
            // 
            this.checkBox_UseSMTP.AutoSize = true;
            this.checkBox_UseSMTP.Location = new System.Drawing.Point(0, 17);
            this.checkBox_UseSMTP.Name = "checkBox_UseSMTP";
            this.checkBox_UseSMTP.Size = new System.Drawing.Size(126, 17);
            this.checkBox_UseSMTP.TabIndex = 1;
            this.checkBox_UseSMTP.Text = "Use SMTP Transport";
            this.checkBox_UseSMTP.UseVisualStyleBackColor = true;
            // 
            // checkBox_UseFTP
            // 
            this.checkBox_UseFTP.AutoSize = true;
            this.checkBox_UseFTP.Location = new System.Drawing.Point(0, 3);
            this.checkBox_UseFTP.Name = "checkBox_UseFTP";
            this.checkBox_UseFTP.Size = new System.Drawing.Size(116, 17);
            this.checkBox_UseFTP.TabIndex = 0;
            this.checkBox_UseFTP.Text = "Use FTP Transport";
            this.checkBox_UseFTP.UseVisualStyleBackColor = true;
            // 
            // checkBox_CrashReporting
            // 
            this.checkBox_CrashReporting.AutoSize = true;
            this.checkBox_CrashReporting.Location = new System.Drawing.Point(195, 93);
            this.checkBox_CrashReporting.Name = "checkBox_CrashReporting";
            this.checkBox_CrashReporting.Size = new System.Drawing.Size(102, 17);
            this.checkBox_CrashReporting.TabIndex = 7;
            this.checkBox_CrashReporting.Text = "Crash Reporting";
            this.checkBox_CrashReporting.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Home";
            // 
            // PanelHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PanelHome";
            this.Size = new System.Drawing.Size(400, 214);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_Transport.ResumeLayout(false);
            this.panel_Transport.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_DriveWatch;
        private System.Windows.Forms.CheckBox checkBox_ServiceWatch;
        private System.Windows.Forms.CheckBox checkBox_MemWatch;
        private System.Windows.Forms.CheckBox checkBox_DBOptimizer;
        private System.Windows.Forms.Panel panel_Transport;
        private System.Windows.Forms.CheckBox checkBox_UseSMTP;
        private System.Windows.Forms.CheckBox checkBox_UseFTP;
        private System.Windows.Forms.CheckBox checkBox_ProcessWatch;
        private System.Windows.Forms.CheckBox checkBox_CrashReporting;
        private System.Windows.Forms.Label label1;
    }
}
