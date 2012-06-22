namespace PMASysAlertsUI
{
    partial class PanelServiceController
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
            this.label_ServiceController = new System.Windows.Forms.Label();
            this.checkedListBox_Services = new System.Windows.Forms.CheckedListBox();
            this.label_AvailableServices = new System.Windows.Forms.Label();
            this.checkBox_SelectAllServices = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label_ServiceController
            // 
            this.label_ServiceController.AutoSize = true;
            this.label_ServiceController.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ServiceController.Location = new System.Drawing.Point(13, 11);
            this.label_ServiceController.Name = "label_ServiceController";
            this.label_ServiceController.Size = new System.Drawing.Size(108, 13);
            this.label_ServiceController.TabIndex = 0;
            this.label_ServiceController.Text = "Service Controller";
            // 
            // checkedListBox_Services
            // 
            this.checkedListBox_Services.CheckOnClick = true;
            this.checkedListBox_Services.FormattingEnabled = true;
            this.checkedListBox_Services.Location = new System.Drawing.Point(16, 99);
            this.checkedListBox_Services.Name = "checkedListBox_Services";
            this.checkedListBox_Services.Size = new System.Drawing.Size(457, 169);
            this.checkedListBox_Services.TabIndex = 1;
            this.checkedListBox_Services.MouseHover += new System.EventHandler(this.checkedListBox_Services_MouseHover);
            // 
            // label_AvailableServices
            // 
            this.label_AvailableServices.AutoSize = true;
            this.label_AvailableServices.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AvailableServices.Location = new System.Drawing.Point(13, 53);
            this.label_AvailableServices.Name = "label_AvailableServices";
            this.label_AvailableServices.Size = new System.Drawing.Size(112, 13);
            this.label_AvailableServices.TabIndex = 2;
            this.label_AvailableServices.Text = "Available Services";
            // 
            // checkBox_SelectAllServices
            // 
            this.checkBox_SelectAllServices.AutoSize = true;
            this.checkBox_SelectAllServices.Location = new System.Drawing.Point(16, 76);
            this.checkBox_SelectAllServices.Name = "checkBox_SelectAllServices";
            this.checkBox_SelectAllServices.Size = new System.Drawing.Size(70, 17);
            this.checkBox_SelectAllServices.TabIndex = 3;
            this.checkBox_SelectAllServices.Text = "Select All";
            this.checkBox_SelectAllServices.UseVisualStyleBackColor = true;
            this.checkBox_SelectAllServices.CheckedChanged += new System.EventHandler(this.checkBox_SelectAllServices_CheckedChanged);
            // 
            // PanelServiceController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_SelectAllServices);
            this.Controls.Add(this.label_AvailableServices);
            this.Controls.Add(this.checkedListBox_Services);
            this.Controls.Add(this.label_ServiceController);
            this.Name = "PanelServiceController";
            this.Size = new System.Drawing.Size(500, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ServiceController;
        private System.Windows.Forms.CheckedListBox checkedListBox_Services;
        private System.Windows.Forms.Label label_AvailableServices;
        private System.Windows.Forms.CheckBox checkBox_SelectAllServices;
    }
}
