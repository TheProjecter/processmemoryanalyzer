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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_TotalMemory = new System.Windows.Forms.TextBox();
            this.textBox_CPU = new System.Windows.Forms.TextBox();
            this.label_FreeMemory = new System.Windows.Forms.Label();
            this.textBox_FreeMemory = new System.Windows.Forms.TextBox();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Total Memory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(382, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "CPU";
            // 
            // textBox_TotalMemory
            // 
            this.textBox_TotalMemory.Location = new System.Drawing.Point(96, 73);
            this.textBox_TotalMemory.Name = "textBox_TotalMemory";
            this.textBox_TotalMemory.Size = new System.Drawing.Size(83, 20);
            this.textBox_TotalMemory.TabIndex = 5;
            // 
            // textBox_CPU
            // 
            this.textBox_CPU.Location = new System.Drawing.Point(428, 73);
            this.textBox_CPU.Name = "textBox_CPU";
            this.textBox_CPU.Size = new System.Drawing.Size(87, 20);
            this.textBox_CPU.TabIndex = 6;
            // 
            // label_FreeMemory
            // 
            this.label_FreeMemory.AutoSize = true;
            this.label_FreeMemory.Location = new System.Drawing.Point(199, 76);
            this.label_FreeMemory.Name = "label_FreeMemory";
            this.label_FreeMemory.Size = new System.Drawing.Size(68, 13);
            this.label_FreeMemory.TabIndex = 7;
            this.label_FreeMemory.Text = "Free Memory";
            // 
            // textBox_FreeMemory
            // 
            this.textBox_FreeMemory.Location = new System.Drawing.Point(282, 73);
            this.textBox_FreeMemory.Name = "textBox_FreeMemory";
            this.textBox_FreeMemory.Size = new System.Drawing.Size(74, 20);
            this.textBox_FreeMemory.TabIndex = 8;
            // 
            // PanelTaskManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox_FreeMemory);
            this.Controls.Add(this.label_FreeMemory);
            this.Controls.Add(this.textBox_CPU);
            this.Controls.Add(this.textBox_TotalMemory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_TotalMemory;
        private System.Windows.Forms.TextBox textBox_CPU;
        private System.Windows.Forms.Label label_FreeMemory;
        private System.Windows.Forms.TextBox textBox_FreeMemory;
    }
}
