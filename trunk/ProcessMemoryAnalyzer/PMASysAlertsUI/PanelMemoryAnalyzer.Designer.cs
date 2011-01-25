namespace PMASysAlertsUI
{
    partial class PanelMemoryAnalyzer
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
            this.label_PerformanceWatch = new System.Windows.Forms.Label();
            this.label_TriggerSeed = new System.Windows.Forms.Label();
            this.numericUpDown_Trigger = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_MachineName = new System.Windows.Forms.TextBox();
            this.button_GetMachineName = new System.Windows.Forms.Button();
            this.checkBox_disposeFiles = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_MailTime = new System.Windows.Forms.DateTimePicker();
            this.label_ReportInterval = new System.Windows.Forms.Label();
            this.numericUpDown_ReportInterval = new System.Windows.Forms.NumericUpDown();
            this.label_min = new System.Windows.Forms.Label();
            this.label_hour = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Trigger)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReportInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // label_PerformanceWatch
            // 
            this.label_PerformanceWatch.AutoSize = true;
            this.label_PerformanceWatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_PerformanceWatch.Location = new System.Drawing.Point(28, 16);
            this.label_PerformanceWatch.Name = "label_PerformanceWatch";
            this.label_PerformanceWatch.Size = new System.Drawing.Size(93, 13);
            this.label_PerformanceWatch.TabIndex = 0;
            this.label_PerformanceWatch.Text = "Process Watch";
            // 
            // label_TriggerSeed
            // 
            this.label_TriggerSeed.AutoSize = true;
            this.label_TriggerSeed.Location = new System.Drawing.Point(28, 78);
            this.label_TriggerSeed.Name = "label_TriggerSeed";
            this.label_TriggerSeed.Size = new System.Drawing.Size(68, 13);
            this.label_TriggerSeed.TabIndex = 1;
            this.label_TriggerSeed.Text = "Trigger Seed";
            // 
            // numericUpDown_Trigger
            // 
            this.numericUpDown_Trigger.Location = new System.Drawing.Point(113, 76);
            this.numericUpDown_Trigger.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numericUpDown_Trigger.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_Trigger.Name = "numericUpDown_Trigger";
            this.numericUpDown_Trigger.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_Trigger.TabIndex = 2;
            this.numericUpDown_Trigger.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Machine Name";
            // 
            // textBox_MachineName
            // 
            this.textBox_MachineName.Location = new System.Drawing.Point(113, 47);
            this.textBox_MachineName.Name = "textBox_MachineName";
            this.textBox_MachineName.Size = new System.Drawing.Size(179, 20);
            this.textBox_MachineName.TabIndex = 4;
            // 
            // button_GetMachineName
            // 
            this.button_GetMachineName.Location = new System.Drawing.Point(298, 45);
            this.button_GetMachineName.Name = "button_GetMachineName";
            this.button_GetMachineName.Size = new System.Drawing.Size(75, 23);
            this.button_GetMachineName.TabIndex = 5;
            this.button_GetMachineName.Text = "Get";
            this.button_GetMachineName.UseVisualStyleBackColor = true;
            this.button_GetMachineName.Click += new System.EventHandler(this.button_GetMachineName_Click);
            // 
            // checkBox_disposeFiles
            // 
            this.checkBox_disposeFiles.AutoSize = true;
            this.checkBox_disposeFiles.Location = new System.Drawing.Point(34, 165);
            this.checkBox_disposeFiles.Name = "checkBox_disposeFiles";
            this.checkBox_disposeFiles.Size = new System.Drawing.Size(83, 17);
            this.checkBox_disposeFiles.TabIndex = 6;
            this.checkBox_disposeFiles.Text = "Dispose File";
            this.checkBox_disposeFiles.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 106);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Mailing Time";
            // 
            // dateTimePicker_MailTime
            // 
            this.dateTimePicker_MailTime.CustomFormat = "MM/dd/yyyy HH:mm:ss";
            this.dateTimePicker_MailTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker_MailTime.Location = new System.Drawing.Point(113, 102);
            this.dateTimePicker_MailTime.Name = "dateTimePicker_MailTime";
            this.dateTimePicker_MailTime.Size = new System.Drawing.Size(147, 20);
            this.dateTimePicker_MailTime.TabIndex = 9;
            // 
            // label_ReportInterval
            // 
            this.label_ReportInterval.AutoSize = true;
            this.label_ReportInterval.Location = new System.Drawing.Point(31, 133);
            this.label_ReportInterval.Name = "label_ReportInterval";
            this.label_ReportInterval.Size = new System.Drawing.Size(77, 13);
            this.label_ReportInterval.TabIndex = 10;
            this.label_ReportInterval.Text = "Report Intervel";
            // 
            // numericUpDown_ReportInterval
            // 
            this.numericUpDown_ReportInterval.Location = new System.Drawing.Point(113, 131);
            this.numericUpDown_ReportInterval.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.numericUpDown_ReportInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_ReportInterval.Name = "numericUpDown_ReportInterval";
            this.numericUpDown_ReportInterval.Size = new System.Drawing.Size(56, 20);
            this.numericUpDown_ReportInterval.TabIndex = 11;
            this.numericUpDown_ReportInterval.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label_min
            // 
            this.label_min.AutoSize = true;
            this.label_min.Location = new System.Drawing.Point(175, 78);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(23, 13);
            this.label_min.TabIndex = 12;
            this.label_min.Text = "min";
            // 
            // label_hour
            // 
            this.label_hour.AutoSize = true;
            this.label_hour.Location = new System.Drawing.Point(175, 133);
            this.label_hour.Name = "label_hour";
            this.label_hour.Size = new System.Drawing.Size(35, 13);
            this.label_hour.TabIndex = 13;
            this.label_hour.Text = "Hours";
            // 
            // PanelMemoryAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_hour);
            this.Controls.Add(this.label_min);
            this.Controls.Add(this.numericUpDown_ReportInterval);
            this.Controls.Add(this.label_ReportInterval);
            this.Controls.Add(this.dateTimePicker_MailTime);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.checkBox_disposeFiles);
            this.Controls.Add(this.button_GetMachineName);
            this.Controls.Add(this.textBox_MachineName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_Trigger);
            this.Controls.Add(this.label_TriggerSeed);
            this.Controls.Add(this.label_PerformanceWatch);
            this.Name = "PanelMemoryAnalyzer";
            this.Size = new System.Drawing.Size(500, 315);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Trigger)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ReportInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_PerformanceWatch;
        private System.Windows.Forms.Label label_TriggerSeed;
        private System.Windows.Forms.NumericUpDown numericUpDown_Trigger;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_MachineName;
        private System.Windows.Forms.Button button_GetMachineName;
        private System.Windows.Forms.CheckBox checkBox_disposeFiles;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_MailTime;
        private System.Windows.Forms.Label label_ReportInterval;
        private System.Windows.Forms.NumericUpDown numericUpDown_ReportInterval;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.Label label_hour;
    }
}
