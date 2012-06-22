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
            this.label_DiscDrives = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_DriveUse)).BeginInit();
            this.SuspendLayout();
            // 
            // label_Drives
            // 
            this.label_Drives.AutoSize = true;
            this.label_Drives.Location = new System.Drawing.Point(40, 32);
            this.label_Drives.Name = "label_Drives";
            this.label_Drives.Size = new System.Drawing.Size(37, 13);
            this.label_Drives.TabIndex = 0;
            this.label_Drives.Text = "Dirves";
            // 
            // checkedListBox_Drives
            // 
            this.checkedListBox_Drives.CheckOnClick = true;
            this.checkedListBox_Drives.FormattingEnabled = true;
            this.checkedListBox_Drives.Location = new System.Drawing.Point(40, 48);
            this.checkedListBox_Drives.Name = "checkedListBox_Drives";
            this.checkedListBox_Drives.Size = new System.Drawing.Size(225, 94);
            this.checkedListBox_Drives.TabIndex = 1;
            // 
            // label_UseLimit
            // 
            this.label_UseLimit.AutoSize = true;
            this.label_UseLimit.Location = new System.Drawing.Point(37, 166);
            this.label_UseLimit.Name = "label_UseLimit";
            this.label_UseLimit.Size = new System.Drawing.Size(220, 13);
            this.label_UseLimit.TabIndex = 2;
            this.label_UseLimit.Text = "Generate Alert When Free Space is less then";
            // 
            // numericUpDown_DriveUse
            // 
            this.numericUpDown_DriveUse.Location = new System.Drawing.Point(263, 164);
            this.numericUpDown_DriveUse.Name = "numericUpDown_DriveUse";
            this.numericUpDown_DriveUse.Size = new System.Drawing.Size(72, 20);
            this.numericUpDown_DriveUse.TabIndex = 3;
            this.numericUpDown_DriveUse.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown_DriveUse_KeyUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(341, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "%";
            // 
            // label_DiscDrives
            // 
            this.label_DiscDrives.AutoSize = true;
            this.label_DiscDrives.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_DiscDrives.Location = new System.Drawing.Point(37, 9);
            this.label_DiscDrives.Name = "label_DiscDrives";
            this.label_DiscDrives.Size = new System.Drawing.Size(73, 13);
            this.label_DiscDrives.TabIndex = 5;
            this.label_DiscDrives.Text = "Drive Alerts";
            // 
            // PanelDriveController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_DiscDrives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_DriveUse);
            this.Controls.Add(this.label_UseLimit);
            this.Controls.Add(this.checkedListBox_Drives);
            this.Controls.Add(this.label_Drives);
            this.Name = "PanelDriveController";
            this.Size = new System.Drawing.Size(500, 315);
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
        private System.Windows.Forms.Label label_DiscDrives;
    }
}
