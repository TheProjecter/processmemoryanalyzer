﻿namespace PMASysAlertsUI
{
    partial class PanelPhyMemController
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
            this.numericUpDown_PhyMemLimit = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PhyMemLimit)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_PhyMemLimit
            // 
            this.numericUpDown_PhyMemLimit.Location = new System.Drawing.Point(172, 64);
            this.numericUpDown_PhyMemLimit.Name = "numericUpDown_PhyMemLimit";
            this.numericUpDown_PhyMemLimit.Size = new System.Drawing.Size(57, 20);
            this.numericUpDown_PhyMemLimit.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generate Memory Alert At";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "%";
            // 
            // PanelPhyMemController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_PhyMemLimit);
            this.Name = "PanelPhyMemController";
            this.Size = new System.Drawing.Size(288, 150);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PhyMemLimit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_PhyMemLimit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
