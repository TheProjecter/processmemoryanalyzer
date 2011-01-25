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
            this.richTextBox_EmailsAlerts = new System.Windows.Forms.RichTextBox();
            this.label_Emails = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_ClientInstanceName = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label_emailPMATask = new System.Windows.Forms.Label();
            this.richTextBox_EmailsPMAReport = new System.Windows.Forms.RichTextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox_EmailsAlerts
            // 
            this.richTextBox_EmailsAlerts.Location = new System.Drawing.Point(7, 16);
            this.richTextBox_EmailsAlerts.Name = "richTextBox_EmailsAlerts";
            this.richTextBox_EmailsAlerts.Size = new System.Drawing.Size(417, 62);
            this.richTextBox_EmailsAlerts.TabIndex = 1;
            this.richTextBox_EmailsAlerts.Text = "";
            // 
            // label_Emails
            // 
            this.label_Emails.AutoSize = true;
            this.label_Emails.Location = new System.Drawing.Point(4, 0);
            this.label_Emails.Name = "label_Emails";
            this.label_Emails.Size = new System.Drawing.Size(125, 13);
            this.label_Emails.TabIndex = 0;
            this.label_Emails.Text = "Emails : Alert Subscibtion";
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
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Instance Name";
            // 
            // textBox_ClientInstanceName
            // 
            this.textBox_ClientInstanceName.Location = new System.Drawing.Point(124, 31);
            this.textBox_ClientInstanceName.Name = "textBox_ClientInstanceName";
            this.textBox_ClientInstanceName.Size = new System.Drawing.Size(202, 20);
            this.textBox_ClientInstanceName.TabIndex = 3;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(6, 57);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.richTextBox_EmailsAlerts);
            this.splitContainer1.Panel1.Controls.Add(this.label_Emails);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label_emailPMATask);
            this.splitContainer1.Panel2.Controls.Add(this.richTextBox_EmailsPMAReport);
            this.splitContainer1.Size = new System.Drawing.Size(431, 188);
            this.splitContainer1.SplitterDistance = 82;
            this.splitContainer1.TabIndex = 4;
            // 
            // label_emailPMATask
            // 
            this.label_emailPMATask.AutoSize = true;
            this.label_emailPMATask.Location = new System.Drawing.Point(4, 11);
            this.label_emailPMATask.Name = "label_emailPMATask";
            this.label_emailPMATask.Size = new System.Drawing.Size(165, 13);
            this.label_emailPMATask.TabIndex = 1;
            this.label_emailPMATask.Text = "Emails : PMA Report Subscription";
            // 
            // richTextBox_EmailsPMAReport
            // 
            this.richTextBox_EmailsPMAReport.Location = new System.Drawing.Point(7, 27);
            this.richTextBox_EmailsPMAReport.Name = "richTextBox_EmailsPMAReport";
            this.richTextBox_EmailsPMAReport.Size = new System.Drawing.Size(416, 63);
            this.richTextBox_EmailsPMAReport.TabIndex = 0;
            this.richTextBox_EmailsPMAReport.Text = "";
            // 
            // PanelTransportController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox_ClientInstanceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PanelTransportController";
            this.Size = new System.Drawing.Size(500, 315);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Emails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_EmailsAlerts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ClientInstanceName;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label_emailPMATask;
        private System.Windows.Forms.RichTextBox richTextBox_EmailsPMAReport;
    }
}
