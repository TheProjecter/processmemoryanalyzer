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
            this.label_emailPMATask = new System.Windows.Forms.Label();
            this.richTextBox_EmailsPMAReport = new System.Windows.Forms.RichTextBox();
            this.richTextBox_sqlSubscibtion = new System.Windows.Forms.RichTextBox();
            this.label_sqlRemoteManagementEmails = new System.Windows.Forms.Label();
            this.richTextBox_ActionServices = new System.Windows.Forms.RichTextBox();
            this.label_serviceandActionRemoteManagement = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox_EmailsAlerts
            // 
            this.richTextBox_EmailsAlerts.Location = new System.Drawing.Point(13, 202);
            this.richTextBox_EmailsAlerts.Name = "richTextBox_EmailsAlerts";
            this.richTextBox_EmailsAlerts.Size = new System.Drawing.Size(470, 40);
            this.richTextBox_EmailsAlerts.TabIndex = 1;
            this.richTextBox_EmailsAlerts.Text = global::PMAClient.Resource.LoadingImage;
            // 
            // label_Emails
            // 
            this.label_Emails.AutoSize = true;
            this.label_Emails.Location = new System.Drawing.Point(10, 186);
            this.label_Emails.Name = "label_Emails";
            this.label_Emails.Size = new System.Drawing.Size(125, 13);
            this.label_Emails.TabIndex = 0;
            this.label_Emails.Text = "Emails : Alert Subscibtion";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Transport Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Client Instance Name";
            // 
            // textBox_ClientInstanceName
            // 
            this.textBox_ClientInstanceName.Location = new System.Drawing.Point(124, 18);
            this.textBox_ClientInstanceName.Name = "textBox_ClientInstanceName";
            this.textBox_ClientInstanceName.Size = new System.Drawing.Size(202, 20);
            this.textBox_ClientInstanceName.TabIndex = 3;
            // 
            // label_emailPMATask
            // 
            this.label_emailPMATask.AutoSize = true;
            this.label_emailPMATask.Location = new System.Drawing.Point(10, 256);
            this.label_emailPMATask.Name = "label_emailPMATask";
            this.label_emailPMATask.Size = new System.Drawing.Size(165, 13);
            this.label_emailPMATask.TabIndex = 1;
            this.label_emailPMATask.Text = "Emails : PMA Report Subscription";
            // 
            // richTextBox_EmailsPMAReport
            // 
            this.richTextBox_EmailsPMAReport.Location = new System.Drawing.Point(13, 272);
            this.richTextBox_EmailsPMAReport.Name = "richTextBox_EmailsPMAReport";
            this.richTextBox_EmailsPMAReport.Size = new System.Drawing.Size(470, 40);
            this.richTextBox_EmailsPMAReport.TabIndex = 0;
            this.richTextBox_EmailsPMAReport.Text = global::PMAClient.Resource.LoadingImage;
            // 
            // richTextBox_sqlSubscibtion
            // 
            this.richTextBox_sqlSubscibtion.Location = new System.Drawing.Point(13, 66);
            this.richTextBox_sqlSubscibtion.Name = "richTextBox_sqlSubscibtion";
            this.richTextBox_sqlSubscibtion.Size = new System.Drawing.Size(470, 40);
            this.richTextBox_sqlSubscibtion.TabIndex = 4;
            this.richTextBox_sqlSubscibtion.Text = global::PMAClient.Resource.LoadingImage;
            // 
            // label_sqlRemoteManagementEmails
            // 
            this.label_sqlRemoteManagementEmails.AutoSize = true;
            this.label_sqlRemoteManagementEmails.Location = new System.Drawing.Point(10, 50);
            this.label_sqlRemoteManagementEmails.Name = "label_sqlRemoteManagementEmails";
            this.label_sqlRemoteManagementEmails.Size = new System.Drawing.Size(172, 13);
            this.label_sqlRemoteManagementEmails.TabIndex = 5;
            this.label_sqlRemoteManagementEmails.Text = "Emails : SQL Remote Management";
            // 
            // richTextBox_ActionServices
            // 
            this.richTextBox_ActionServices.Location = new System.Drawing.Point(13, 133);
            this.richTextBox_ActionServices.Name = "richTextBox_ActionServices";
            this.richTextBox_ActionServices.Size = new System.Drawing.Size(470, 40);
            this.richTextBox_ActionServices.TabIndex = 6;
            this.richTextBox_ActionServices.Text = global::PMAClient.Resource.LoadingImage;
            // 
            // label_serviceandActionRemoteManagement
            // 
            this.label_serviceandActionRemoteManagement.AutoSize = true;
            this.label_serviceandActionRemoteManagement.Location = new System.Drawing.Point(10, 117);
            this.label_serviceandActionRemoteManagement.Name = "label_serviceandActionRemoteManagement";
            this.label_serviceandActionRemoteManagement.Size = new System.Drawing.Size(238, 13);
            this.label_serviceandActionRemoteManagement.TabIndex = 7;
            this.label_serviceandActionRemoteManagement.Text = "Emails : Remote Action and service management";
            // 
            // PanelTransportController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_serviceandActionRemoteManagement);
            this.Controls.Add(this.richTextBox_ActionServices);
            this.Controls.Add(this.label_sqlRemoteManagementEmails);
            this.Controls.Add(this.richTextBox_sqlSubscibtion);
            this.Controls.Add(this.label_emailPMATask);
            this.Controls.Add(this.label_Emails);
            this.Controls.Add(this.richTextBox_EmailsPMAReport);
            this.Controls.Add(this.richTextBox_EmailsAlerts);
            this.Controls.Add(this.textBox_ClientInstanceName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PanelTransportController";
            this.Size = new System.Drawing.Size(500, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Emails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox_EmailsAlerts;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_ClientInstanceName;
        private System.Windows.Forms.Label label_emailPMATask;
        private System.Windows.Forms.RichTextBox richTextBox_EmailsPMAReport;
        private System.Windows.Forms.RichTextBox richTextBox_sqlSubscibtion;
        private System.Windows.Forms.Label label_sqlRemoteManagementEmails;
        private System.Windows.Forms.RichTextBox richTextBox_ActionServices;
        private System.Windows.Forms.Label label_serviceandActionRemoteManagement;
    }
}
