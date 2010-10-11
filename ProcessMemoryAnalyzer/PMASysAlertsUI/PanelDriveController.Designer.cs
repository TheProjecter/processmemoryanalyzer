namespace PMASysAlertsUI
{
    partial class PanelDriveController
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
            this.label_Drives = new System.Windows.Forms.Label();
            this.checkedListBox_Drives = new System.Windows.Forms.CheckedListBox();
            this.label_UseLimit = new System.Windows.Forms.Label();
            this.numericUpDown_DriveUse = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DriveUse)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Drives
            // 
            this.label_Drives.AutoSize = true;
            this.label_Drives.Location = new System.Drawing.Point(23, 50);
            this.label_Drives.Name = "label_Drives";
            this.label_Drives.Size = new System.Drawing.Size(37, 13);
            this.label_Drives.TabIndex = 0;
            this.label_Drives.Text = "Dirves";
            // 
            // checkedListBox_Drives
            // 
            this.checkedListBox_Drives.FormattingEnabled = true;
            this.checkedListBox_Drives.Location = new System.Drawing.Point(103, 23);
            this.checkedListBox_Drives.Name = "checkedListBox_Drives";
            this.checkedListBox_Drives.Size = new System.Drawing.Size(123, 79);
            this.checkedListBox_Drives.TabIndex = 1;
            // 
            // label_UseLimit
            // 
            this.label_UseLimit.AutoSize = true;
            this.label_UseLimit.Location = new System.Drawing.Point(23, 130);
            this.label_UseLimit.Name = "label_UseLimit";
            this.label_UseLimit.Size = new System.Drawing.Size(35, 13);
            this.label_UseLimit.TabIndex = 2;
            this.label_UseLimit.Text = "label2";
            // 
            // numericUpDown_DriveUse
            // 
            this.numericUpDown_DriveUse.Location = new System.Drawing.Point(103, 130);
            this.numericUpDown_DriveUse.Name = "numericUpDown_DriveUse";
            this.numericUpDown_DriveUse.Size = new System.Drawing.Size(46, 20);
            this.numericUpDown_DriveUse.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
            // 
            // PanelDriveController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_DriveUse);
            this.Controls.Add(this.label_UseLimit);
            this.Controls.Add(this.checkedListBox_Drives);
            this.Controls.Add(this.label_Drives);
            this.Name = "PanelDriveController";
            this.Size = new System.Drawing.Size(313, 204);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DriveUse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Drives;
        private System.Windows.Forms.CheckedListBox checkedListBox_Drives;
        private System.Windows.Forms.Label label_UseLimit;
        private System.Windows.Forms.NumericUpDown numericUpDown_DriveUse;
        private System.Windows.Forms.Label label3;
    }
}
