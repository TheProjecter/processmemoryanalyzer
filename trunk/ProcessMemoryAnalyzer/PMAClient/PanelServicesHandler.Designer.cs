namespace PMA.Client
{
    partial class PanelServicesHandler
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
            this.label_ServicesScreen = new System.Windows.Forms.Label();
            this.label_Results = new System.Windows.Forms.Label();
            this.richTextBox_ResultServices = new System.Windows.Forms.RichTextBox();
            this.button_Execute = new System.Windows.Forms.Button();
            this.dataGridView_Services = new System.Windows.Forms.DataGridView();
            this.button_Refresh = new System.Windows.Forms.Button();
            this.selectService = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.serviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceAction = new System.Windows.Forms.DataGridViewComboBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Services)).BeginInit();
            this.SuspendLayout();
            // 
            // label_ServicesScreen
            // 
            this.label_ServicesScreen.AutoSize = true;
            this.label_ServicesScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ServicesScreen.Location = new System.Drawing.Point(13, 16);
            this.label_ServicesScreen.Name = "label_ServicesScreen";
            this.label_ServicesScreen.Size = new System.Drawing.Size(112, 13);
            this.label_ServicesScreen.TabIndex = 1;
            this.label_ServicesScreen.Text = "Available Services";
            // 
            // label_Results
            // 
            this.label_Results.AutoSize = true;
            this.label_Results.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Results.Location = new System.Drawing.Point(13, 301);
            this.label_Results.Name = "label_Results";
            this.label_Results.Size = new System.Drawing.Size(49, 13);
            this.label_Results.TabIndex = 3;
            this.label_Results.Text = "Results";
            // 
            // richTextBox_ResultServices
            // 
            this.richTextBox_ResultServices.Location = new System.Drawing.Point(16, 326);
            this.richTextBox_ResultServices.Name = "richTextBox_ResultServices";
            this.richTextBox_ResultServices.Size = new System.Drawing.Size(809, 82);
            this.richTextBox_ResultServices.TabIndex = 4;
            this.richTextBox_ResultServices.Text = "";
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(750, 253);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(75, 23);
            this.button_Execute.TabIndex = 5;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // dataGridView_Services
            // 
            this.dataGridView_Services.AllowUserToAddRows = false;
            this.dataGridView_Services.AllowUserToDeleteRows = false;
            this.dataGridView_Services.AllowUserToOrderColumns = true;
            this.dataGridView_Services.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Services.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectService,
            this.serviceName,
            this.serviceStatus,
            this.serviceAction});
            this.dataGridView_Services.Location = new System.Drawing.Point(16, 43);
            this.dataGridView_Services.Name = "dataGridView_Services";
            this.dataGridView_Services.Size = new System.Drawing.Size(809, 204);
            this.dataGridView_Services.TabIndex = 6;
            // 
            // button_Refresh
            // 
            this.button_Refresh.Location = new System.Drawing.Point(669, 253);
            this.button_Refresh.Name = "button_Refresh";
            this.button_Refresh.Size = new System.Drawing.Size(75, 23);
            this.button_Refresh.TabIndex = 7;
            this.button_Refresh.Text = "Refresh";
            this.button_Refresh.UseVisualStyleBackColor = true;
            this.button_Refresh.Click += new System.EventHandler(this.button_Refresh_Click);
            // 
            // selectService
            // 
            this.selectService.HeaderText = "Select";
            this.selectService.Name = "selectService";
            this.selectService.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.selectService.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.selectService.Width = 50;
            // 
            // serviceName
            // 
            this.serviceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.serviceName.HeaderText = "Service";
            this.serviceName.Name = "serviceName";
            this.serviceName.ReadOnly = true;
            // 
            // serviceStatus
            // 
            this.serviceStatus.HeaderText = "Status";
            this.serviceStatus.Name = "serviceStatus";
            this.serviceStatus.ReadOnly = true;
            // 
            // serviceAction
            // 
            this.serviceAction.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.serviceAction.HeaderText = "Action";
            this.serviceAction.Items.AddRange(new object[] {
            "START",
            "STOP",
            "RESTART"});
            this.serviceAction.Name = "serviceAction";
            this.serviceAction.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.serviceAction.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // PanelServicesHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Refresh);
            this.Controls.Add(this.dataGridView_Services);
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.richTextBox_ResultServices);
            this.Controls.Add(this.label_Results);
            this.Controls.Add(this.label_ServicesScreen);
            this.Name = "PanelServicesHandler";
            this.Size = new System.Drawing.Size(850, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Services)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ServicesScreen;
        private System.Windows.Forms.Label label_Results;
        private System.Windows.Forms.RichTextBox richTextBox_ResultServices;
        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.DataGridView dataGridView_Services;
        private System.Windows.Forms.Button button_Refresh;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectService;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceStatus;
        private System.Windows.Forms.DataGridViewComboBoxColumn serviceAction;
    }
}
