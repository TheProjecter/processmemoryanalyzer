namespace PMASysAlertsUI
{
    partial class PanelLogger
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
            this.comboBox_logs = new System.Windows.Forms.ComboBox();
            this.label_log = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_loggerFile = new System.Windows.Forms.TextBox();
            this.label_loggerSettings = new System.Windows.Forms.Label();
            this.checkBox_UseDefaultPath = new System.Windows.Forms.CheckBox();
            this.button_saveFile = new System.Windows.Forms.Button();
            this.saveFileDialog_log = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // comboBox_logs
            // 
            this.comboBox_logs.FormattingEnabled = true;
            this.comboBox_logs.Location = new System.Drawing.Point(98, 122);
            this.comboBox_logs.Name = "comboBox_logs";
            this.comboBox_logs.Size = new System.Drawing.Size(121, 21);
            this.comboBox_logs.TabIndex = 0;
            // 
            // label_log
            // 
            this.label_log.AutoSize = true;
            this.label_log.Location = new System.Drawing.Point(33, 125);
            this.label_log.Name = "label_log";
            this.label_log.Size = new System.Drawing.Size(59, 13);
            this.label_log.TabIndex = 1;
            this.label_log.Text = "Logs Level";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Logger File";
            // 
            // textBox_loggerFile
            // 
            this.textBox_loggerFile.Location = new System.Drawing.Point(98, 62);
            this.textBox_loggerFile.Name = "textBox_loggerFile";
            this.textBox_loggerFile.Size = new System.Drawing.Size(206, 20);
            this.textBox_loggerFile.TabIndex = 3;
            // 
            // label_loggerSettings
            // 
            this.label_loggerSettings.AutoSize = true;
            this.label_loggerSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_loggerSettings.Location = new System.Drawing.Point(33, 24);
            this.label_loggerSettings.Name = "label_loggerSettings";
            this.label_loggerSettings.Size = new System.Drawing.Size(96, 13);
            this.label_loggerSettings.TabIndex = 4;
            this.label_loggerSettings.Text = "Logger Settings";
            // 
            // checkBox_UseDefaultPath
            // 
            this.checkBox_UseDefaultPath.AutoSize = true;
            this.checkBox_UseDefaultPath.Location = new System.Drawing.Point(98, 88);
            this.checkBox_UseDefaultPath.Name = "checkBox_UseDefaultPath";
            this.checkBox_UseDefaultPath.Size = new System.Drawing.Size(104, 17);
            this.checkBox_UseDefaultPath.TabIndex = 5;
            this.checkBox_UseDefaultPath.Text = "Default File Path";
            this.checkBox_UseDefaultPath.UseVisualStyleBackColor = true;
            this.checkBox_UseDefaultPath.CheckedChanged += new System.EventHandler(this.checkBox_UseDefaultPath_CheckedChanged);
            // 
            // button_saveFile
            // 
            this.button_saveFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_saveFile.Location = new System.Drawing.Point(310, 60);
            this.button_saveFile.Name = "button_saveFile";
            this.button_saveFile.Size = new System.Drawing.Size(50, 23);
            this.button_saveFile.TabIndex = 6;
            this.button_saveFile.Text = "...";
            this.button_saveFile.UseVisualStyleBackColor = true;
            this.button_saveFile.Click += new System.EventHandler(this.button_saveFile_Click);
            // 
            // PanelLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_saveFile);
            this.Controls.Add(this.checkBox_UseDefaultPath);
            this.Controls.Add(this.label_loggerSettings);
            this.Controls.Add(this.textBox_loggerFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_log);
            this.Controls.Add(this.comboBox_logs);
            this.MaximumSize = new System.Drawing.Size(440, 260);
            this.MinimumSize = new System.Drawing.Size(440, 260);
            this.Name = "PanelLogger";
            this.Size = new System.Drawing.Size(500, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_logs;
        private System.Windows.Forms.Label label_log;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_loggerFile;
        private System.Windows.Forms.Label label_loggerSettings;
        private System.Windows.Forms.CheckBox checkBox_UseDefaultPath;
        private System.Windows.Forms.Button button_saveFile;
        private System.Windows.Forms.SaveFileDialog saveFileDialog_log;
    }
}
