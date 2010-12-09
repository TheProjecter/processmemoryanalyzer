namespace PMASysAlertsUI
{
    partial class PanelEventReporting
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
            this.dataGridView_CrashReporting = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.Column_LogName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CrashReporting)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_CrashReporting
            // 
            this.dataGridView_CrashReporting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_CrashReporting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_LogName,
            this.Column_Type,
            this.Column_Source,
            this.Column_Description});
            this.dataGridView_CrashReporting.Location = new System.Drawing.Point(17, 47);
            this.dataGridView_CrashReporting.Name = "dataGridView_CrashReporting";
            this.dataGridView_CrashReporting.Size = new System.Drawing.Size(415, 200);
            this.dataGridView_CrashReporting.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Crash Monitoring";
            // 
            // Column_LogName
            // 
            this.Column_LogName.HeaderText = "LogName";
            this.Column_LogName.Items.AddRange(new object[] {
            "System",
            "Application",
            "Security"});
            this.Column_LogName.Name = "Column_LogName";
            // 
            // Column_Type
            // 
            this.Column_Type.DataPropertyName = "EventType";
            this.Column_Type.HeaderText = "EventType";
            this.Column_Type.Items.AddRange(new object[] {
            "Error",
            "Information",
            "Warning"});
            this.Column_Type.Name = "Column_Type";
            // 
            // Column_Source
            // 
            this.Column_Source.DataPropertyName = "EventSource";
            this.Column_Source.HeaderText = "EventSource";
            this.Column_Source.Name = "Column_Source";
            this.Column_Source.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_Description
            // 
            this.Column_Description.DataPropertyName = "EventMessage";
            this.Column_Description.HeaderText = "EventMessage";
            this.Column_Description.Name = "Column_Description";
            this.Column_Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Description.Width = 127;
            // 
            // PanelCrashReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView_CrashReporting);
            this.Name = "PanelCrashReporting";
            this.Size = new System.Drawing.Size(450, 270);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_CrashReporting)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_CrashReporting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_LogName;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Description;
    }
}
