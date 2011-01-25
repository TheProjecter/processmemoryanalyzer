namespace PMASysAlertsUI
{
    partial class PanelServiceWatcher
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
            this.label_Services = new System.Windows.Forms.Label();
            this.checkedListBox_Services = new System.Windows.Forms.CheckedListBox();
            this.label_GeneAlertAt = new System.Windows.Forms.Label();
            this.numericUpDown_ServiceMemLimit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label_ConfigureServices = new System.Windows.Forms.Label();
            this.checkBox_StoppedServiceAlert = new System.Windows.Forms.CheckBox();
            this.checkBox_webProcessWatch = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ServiceMemLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Services
            // 
            this.label_Services.AutoSize = true;
            this.label_Services.Location = new System.Drawing.Point(32, 42);
            this.label_Services.Name = "label_Services";
            this.label_Services.Size = new System.Drawing.Size(48, 13);
            this.label_Services.TabIndex = 0;
            this.label_Services.Text = "Services";
            // 
            // checkedListBox_Services
            // 
            this.checkedListBox_Services.CheckOnClick = true;
            this.checkedListBox_Services.FormattingEnabled = true;
            this.checkedListBox_Services.Location = new System.Drawing.Point(35, 58);
            this.checkedListBox_Services.Name = "checkedListBox_Services";
            this.checkedListBox_Services.Size = new System.Drawing.Size(345, 139);
            this.checkedListBox_Services.TabIndex = 1;
            this.checkedListBox_Services.MouseHover += new System.EventHandler(this.checkedListBox_Services_MouseHover);
            // 
            // label_GeneAlertAt
            // 
            this.label_GeneAlertAt.AutoSize = true;
            this.label_GeneAlertAt.Location = new System.Drawing.Point(32, 260);
            this.label_GeneAlertAt.Name = "label_GeneAlertAt";
            this.label_GeneAlertAt.Size = new System.Drawing.Size(55, 13);
            this.label_GeneAlertAt.TabIndex = 2;
            this.label_GeneAlertAt.Text = "Alert Point";
            // 
            // numericUpDown_ServiceMemLimit
            // 
            this.numericUpDown_ServiceMemLimit.Location = new System.Drawing.Point(93, 258);
            this.numericUpDown_ServiceMemLimit.Name = "numericUpDown_ServiceMemLimit";
            this.numericUpDown_ServiceMemLimit.Size = new System.Drawing.Size(81, 20);
            this.numericUpDown_ServiceMemLimit.TabIndex = 3;
            this.numericUpDown_ServiceMemLimit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_ServiceMemLimit_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(180, 260);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "% Of RAM";
            // 
            // label_ConfigureServices
            // 
            this.label_ConfigureServices.AutoSize = true;
            this.label_ConfigureServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ConfigureServices.Location = new System.Drawing.Point(32, 13);
            this.label_ConfigureServices.Name = "label_ConfigureServices";
            this.label_ConfigureServices.Size = new System.Drawing.Size(96, 13);
            this.label_ConfigureServices.TabIndex = 5;
            this.label_ConfigureServices.Text = "Select Services";
            // 
            // checkBox_StoppedServiceAlert
            // 
            this.checkBox_StoppedServiceAlert.AutoSize = true;
            this.checkBox_StoppedServiceAlert.Location = new System.Drawing.Point(35, 235);
            this.checkBox_StoppedServiceAlert.Name = "checkBox_StoppedServiceAlert";
            this.checkBox_StoppedServiceAlert.Size = new System.Drawing.Size(176, 17);
            this.checkBox_StoppedServiceAlert.TabIndex = 6;
            this.checkBox_StoppedServiceAlert.Text = "Generate Stopped Service Alert";
            this.checkBox_StoppedServiceAlert.UseVisualStyleBackColor = true;
            // 
            // checkBox_webProcessWatch
            // 
            this.checkBox_webProcessWatch.AutoSize = true;
            this.checkBox_webProcessWatch.Location = new System.Drawing.Point(35, 212);
            this.checkBox_webProcessWatch.Name = "checkBox_webProcessWatch";
            this.checkBox_webProcessWatch.Size = new System.Drawing.Size(125, 17);
            this.checkBox_webProcessWatch.TabIndex = 7;
            this.checkBox_webProcessWatch.Text = "Watch Web Process";
            this.checkBox_webProcessWatch.UseVisualStyleBackColor = true;
            // 
            // PanelServiceWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_webProcessWatch);
            this.Controls.Add(this.checkBox_StoppedServiceAlert);
            this.Controls.Add(this.label_ConfigureServices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_ServiceMemLimit);
            this.Controls.Add(this.label_GeneAlertAt);
            this.Controls.Add(this.checkedListBox_Services);
            this.Controls.Add(this.label_Services);
            this.Name = "PanelServiceWatcher";
            this.Size = new System.Drawing.Size(500, 315);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ServiceMemLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Services;
        private System.Windows.Forms.CheckedListBox checkedListBox_Services;
        private System.Windows.Forms.Label label_GeneAlertAt;
        private System.Windows.Forms.NumericUpDown numericUpDown_ServiceMemLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_ConfigureServices;
        private System.Windows.Forms.CheckBox checkBox_StoppedServiceAlert;
        private System.Windows.Forms.CheckBox checkBox_webProcessWatch;
    }
}
