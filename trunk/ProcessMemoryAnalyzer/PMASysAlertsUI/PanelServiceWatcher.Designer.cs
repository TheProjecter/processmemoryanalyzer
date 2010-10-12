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
            this.checkedListBox_Services.FormattingEnabled = true;
            this.checkedListBox_Services.Location = new System.Drawing.Point(35, 58);
            this.checkedListBox_Services.Name = "checkedListBox_Services";
            this.checkedListBox_Services.Size = new System.Drawing.Size(216, 94);
            this.checkedListBox_Services.TabIndex = 1;
            // 
            // label_GeneAlertAt
            // 
            this.label_GeneAlertAt.AutoSize = true;
            this.label_GeneAlertAt.Location = new System.Drawing.Point(32, 165);
            this.label_GeneAlertAt.Name = "label_GeneAlertAt";
            this.label_GeneAlertAt.Size = new System.Drawing.Size(55, 13);
            this.label_GeneAlertAt.TabIndex = 2;
            this.label_GeneAlertAt.Text = "Alert Point";
            // 
            // numericUpDown_ServiceMemLimit
            // 
            this.numericUpDown_ServiceMemLimit.Location = new System.Drawing.Point(93, 163);
            this.numericUpDown_ServiceMemLimit.Name = "numericUpDown_ServiceMemLimit";
            this.numericUpDown_ServiceMemLimit.Size = new System.Drawing.Size(59, 20);
            this.numericUpDown_ServiceMemLimit.TabIndex = 3;
            this.numericUpDown_ServiceMemLimit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_ServiceMemLimit_KeyUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 165);
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
            // PanelServiceWatcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_ConfigureServices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_ServiceMemLimit);
            this.Controls.Add(this.label_GeneAlertAt);
            this.Controls.Add(this.checkedListBox_Services);
            this.Controls.Add(this.label_Services);
            this.Name = "PanelServiceWatcher";
            this.Size = new System.Drawing.Size(400, 200);
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
    }
}
