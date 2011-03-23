namespace PMA.Client
{
    partial class PanelTaskManager
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
            this.label_SystemMonitor = new System.Windows.Forms.Label();
            this.dataGridView_TaskManager = new System.Windows.Forms.DataGridView();
            this.label_TotalMemory = new System.Windows.Forms.Label();
            this.label_CPUUsage = new System.Windows.Forms.Label();
            this.label_FreeMemory = new System.Windows.Forms.Label();
            this.label_MemoryValue = new System.Windows.Forms.Label();
            this.label_FreeMemoryValue = new System.Windows.Forms.Label();
            this.label_CPUUsageValue = new System.Windows.Forms.Label();
            this.textBox_Search = new System.Windows.Forms.TextBox();
            this.label_Search = new System.Windows.Forms.Label();
            this.checkBox_Refresh = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TaskManager)).BeginInit();
            this.SuspendLayout();
            // 
            // label_SystemMonitor
            // 
            this.label_SystemMonitor.AutoSize = true;
            this.label_SystemMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SystemMonitor.Location = new System.Drawing.Point(19, 15);
            this.label_SystemMonitor.Name = "label_SystemMonitor";
            this.label_SystemMonitor.Size = new System.Drawing.Size(114, 16);
            this.label_SystemMonitor.TabIndex = 0;
            this.label_SystemMonitor.Text = "System Monitor";
            // 
            // dataGridView_TaskManager
            // 
            this.dataGridView_TaskManager.AllowUserToAddRows = false;
            this.dataGridView_TaskManager.AllowUserToDeleteRows = false;
            this.dataGridView_TaskManager.AllowUserToOrderColumns = true;
            this.dataGridView_TaskManager.AllowUserToResizeRows = false;
            this.dataGridView_TaskManager.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView_TaskManager.Location = new System.Drawing.Point(22, 121);
            this.dataGridView_TaskManager.MaximumSize = new System.Drawing.Size(800, 310);
            this.dataGridView_TaskManager.MinimumSize = new System.Drawing.Size(800, 310);
            this.dataGridView_TaskManager.Name = "dataGridView_TaskManager";
            this.dataGridView_TaskManager.ReadOnly = true;
            this.dataGridView_TaskManager.Size = new System.Drawing.Size(800, 310);
            this.dataGridView_TaskManager.TabIndex = 1;
            // 
            // label_TotalMemory
            // 
            this.label_TotalMemory.AutoSize = true;
            this.label_TotalMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_TotalMemory.Location = new System.Drawing.Point(19, 76);
            this.label_TotalMemory.Name = "label_TotalMemory";
            this.label_TotalMemory.Size = new System.Drawing.Size(83, 13);
            this.label_TotalMemory.TabIndex = 2;
            this.label_TotalMemory.Text = "Total Memory";
            // 
            // label_CPUUsage
            // 
            this.label_CPUUsage.AutoSize = true;
            this.label_CPUUsage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CPUUsage.Location = new System.Drawing.Point(395, 76);
            this.label_CPUUsage.Name = "label_CPUUsage";
            this.label_CPUUsage.Size = new System.Drawing.Size(32, 13);
            this.label_CPUUsage.TabIndex = 3;
            this.label_CPUUsage.Text = "CPU";
            // 
            // label_FreeMemory
            // 
            this.label_FreeMemory.AutoSize = true;
            this.label_FreeMemory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_FreeMemory.Location = new System.Drawing.Point(199, 76);
            this.label_FreeMemory.Name = "label_FreeMemory";
            this.label_FreeMemory.Size = new System.Drawing.Size(79, 13);
            this.label_FreeMemory.TabIndex = 7;
            this.label_FreeMemory.Text = "Free Memory";
            // 
            // label_MemoryValue
            // 
            this.label_MemoryValue.AutoSize = true;
            this.label_MemoryValue.Location = new System.Drawing.Point(108, 76);
            this.label_MemoryValue.Name = "label_MemoryValue";
            this.label_MemoryValue.Size = new System.Drawing.Size(22, 13);
            this.label_MemoryValue.TabIndex = 8;
            this.label_MemoryValue.Text = "0.0";
            // 
            // label_FreeMemoryValue
            // 
            this.label_FreeMemoryValue.AutoSize = true;
            this.label_FreeMemoryValue.Location = new System.Drawing.Point(284, 76);
            this.label_FreeMemoryValue.Name = "label_FreeMemoryValue";
            this.label_FreeMemoryValue.Size = new System.Drawing.Size(22, 13);
            this.label_FreeMemoryValue.TabIndex = 9;
            this.label_FreeMemoryValue.Text = "0.0";
            // 
            // label_CPUUsageValue
            // 
            this.label_CPUUsageValue.AutoSize = true;
            this.label_CPUUsageValue.Location = new System.Drawing.Point(433, 76);
            this.label_CPUUsageValue.Name = "label_CPUUsageValue";
            this.label_CPUUsageValue.Size = new System.Drawing.Size(30, 13);
            this.label_CPUUsageValue.TabIndex = 10;
            this.label_CPUUsageValue.Text = "0.0%";
            // 
            // textBox_Search
            // 
            this.textBox_Search.Location = new System.Drawing.Point(679, 73);
            this.textBox_Search.Name = "textBox_Search";
            this.textBox_Search.Size = new System.Drawing.Size(143, 20);
            this.textBox_Search.TabIndex = 11;
            this.textBox_Search.TextChanged += new System.EventHandler(this.textBox_Search_TextChanged);
            // 
            // label_Search
            // 
            this.label_Search.AutoSize = true;
            this.label_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Search.Location = new System.Drawing.Point(626, 76);
            this.label_Search.Name = "label_Search";
            this.label_Search.Size = new System.Drawing.Size(47, 13);
            this.label_Search.TabIndex = 12;
            this.label_Search.Text = "Search";
            // 
            // checkBox_Refresh
            // 
            this.checkBox_Refresh.AutoSize = true;
            this.checkBox_Refresh.Location = new System.Drawing.Point(22, 46);
            this.checkBox_Refresh.Name = "checkBox_Refresh";
            this.checkBox_Refresh.Size = new System.Drawing.Size(128, 17);
            this.checkBox_Refresh.TabIndex = 13;
            this.checkBox_Refresh.Text = "Refresh Automatically";
            this.checkBox_Refresh.UseVisualStyleBackColor = true;
            this.checkBox_Refresh.CheckedChanged += new System.EventHandler(this.checkBox_Refresh_CheckedChanged);
            // 
            // PanelTaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.checkBox_Refresh);
            this.Controls.Add(this.label_Search);
            this.Controls.Add(this.textBox_Search);
            this.Controls.Add(this.label_CPUUsageValue);
            this.Controls.Add(this.label_FreeMemoryValue);
            this.Controls.Add(this.label_MemoryValue);
            this.Controls.Add(this.label_FreeMemory);
            this.Controls.Add(this.label_CPUUsage);
            this.Controls.Add(this.label_TotalMemory);
            this.Controls.Add(this.dataGridView_TaskManager);
            this.Controls.Add(this.label_SystemMonitor);
            this.Name = "PanelTaskManager";
            this.Size = new System.Drawing.Size(850, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_TaskManager)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_SystemMonitor;
        private System.Windows.Forms.DataGridView dataGridView_TaskManager;
        private System.Windows.Forms.Label label_TotalMemory;
        private System.Windows.Forms.Label label_CPUUsage;
        private System.Windows.Forms.Label label_FreeMemory;
        private System.Windows.Forms.Label label_MemoryValue;
        private System.Windows.Forms.Label label_FreeMemoryValue;
        private System.Windows.Forms.Label label_CPUUsageValue;
        private System.Windows.Forms.TextBox textBox_Search;
        private System.Windows.Forms.Label label_Search;
        private System.Windows.Forms.CheckBox checkBox_Refresh;
    }
}
