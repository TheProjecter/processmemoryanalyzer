namespace PMASysAlertsUI
{
    partial class PanelTransportController
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.richTextBox_Emails = new System.Windows.Forms.RichTextBox();
            this.label_Emails = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.richTextBox_FtpFolder = new System.Windows.Forms.RichTextBox();
            this.label_FTPFolders = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ClientInstanceName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(417, 165);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.richTextBox_Emails);
            this.panel1.Controls.Add(this.label_Emails);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(411, 76);
            this.panel1.TabIndex = 0;
            // 
            // richTextBox_Emails
            // 
            this.richTextBox_Emails.Location = new System.Drawing.Point(7, 21);
            this.richTextBox_Emails.Name = "richTextBox_Emails";
            this.richTextBox_Emails.Size = new System.Drawing.Size(388, 52);
            this.richTextBox_Emails.TabIndex = 1;
            this.richTextBox_Emails.Text = "";
            // 
            // label_Emails
            // 
            this.label_Emails.AutoSize = true;
            this.label_Emails.Location = new System.Drawing.Point(4, 4);
            this.label_Emails.Name = "label_Emails";
            this.label_Emails.Size = new System.Drawing.Size(46, 13);
            this.label_Emails.TabIndex = 0;
            this.label_Emails.Text = "EMAILS";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.richTextBox_FtpFolder);
            this.panel2.Controls.Add(this.label_FTPFolders);
            this.panel2.Location = new System.Drawing.Point(3, 85);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 77);
            this.panel2.TabIndex = 1;
            // 
            // richTextBox_FtpFolder
            // 
            this.richTextBox_FtpFolder.Location = new System.Drawing.Point(7, 20);
            this.richTextBox_FtpFolder.Name = "richTextBox_FtpFolder";
            this.richTextBox_FtpFolder.Size = new System.Drawing.Size(388, 46);
            this.richTextBox_FtpFolder.TabIndex = 1;
            this.richTextBox_FtpFolder.Text = "";
            // 
            // label_FTPFolders
            // 
            this.label_FTPFolders.AutoSize = true;
            this.label_FTPFolders.Location = new System.Drawing.Point(4, 4);
            this.label_FTPFolders.Name = "label_FTPFolders";
            this.label_FTPFolders.Size = new System.Drawing.Size(64, 13);
            this.label_FTPFolders.TabIndex = 0;
            this.label_FTPFolders.Text = "FTP Folders";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transport Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Instance Name";
            // 
            // textBox_ClientInstanceName
            // 
            this.textBox_ClientInstanceName.Location = new System.Drawing.Point(124, 38);
            this.textBox_ClientInstanceName.Name = "textBox_ClientInstanceName";
            this.textBox_ClientInstanceName.Size = new System.Drawing.Size(202, 20);
            this.textBox_ClientInstanceName.TabIndex = 3;
            // 
            // PanelTransportController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_ClientInstanceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PanelTransportController";
            this.Size = new System.Drawing.Size(440, 260);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_Emails;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_FTPFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_Emails;
        private System.Windows.Forms.RichTextBox richTextBox_FtpFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ClientInstanceName;
    }
}
