namespace PMASysAlertsUI
{
    partial class PanelCrashReporting
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Type = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Column_Source = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Type,
            this.Column_Source,
            this.Column_Description});
            this.dataGridView1.Location = new System.Drawing.Point(17, 50);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(370, 138);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column_Type
            // 
            this.Column_Type.HeaderText = "Type";
            this.Column_Type.Name = "Column_Type";
            // 
            // Column_Source
            // 
            this.Column_Source.HeaderText = "Source";
            this.Column_Source.Name = "Column_Source";
            this.Column_Source.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Column_Description
            // 
            this.Column_Description.HeaderText = "Description";
            this.Column_Description.Name = "Column_Description";
            this.Column_Description.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_Description.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Description.Width = 127;
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
            // PanelCrashReporting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PanelCrashReporting";
            this.Size = new System.Drawing.Size(400, 200);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Source;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Description;
        private System.Windows.Forms.Label label1;
    }
}
