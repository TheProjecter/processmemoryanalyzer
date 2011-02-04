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
            this.listBox_AvailableServices = new System.Windows.Forms.ListBox();
            this.label_ServicesScreen = new System.Windows.Forms.Label();
            this.label_Results = new System.Windows.Forms.Label();
            this.richTextBox_ResultServices = new System.Windows.Forms.RichTextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.button_Stop = new System.Windows.Forms.Button();
            this.button_Restart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox_AvailableServices
            // 
            this.listBox_AvailableServices.FormattingEnabled = true;
            this.listBox_AvailableServices.Location = new System.Drawing.Point(16, 60);
            this.listBox_AvailableServices.Name = "listBox_AvailableServices";
            this.listBox_AvailableServices.Size = new System.Drawing.Size(809, 186);
            this.listBox_AvailableServices.TabIndex = 0;
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
            // button_Start
            // 
            this.button_Start.Location = new System.Drawing.Point(588, 252);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(75, 23);
            this.button_Start.TabIndex = 5;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            // 
            // button_Stop
            // 
            this.button_Stop.Location = new System.Drawing.Point(669, 252);
            this.button_Stop.Name = "button_Stop";
            this.button_Stop.Size = new System.Drawing.Size(75, 23);
            this.button_Stop.TabIndex = 6;
            this.button_Stop.Text = "Stop";
            this.button_Stop.UseVisualStyleBackColor = true;
            // 
            // button_Restart
            // 
            this.button_Restart.Location = new System.Drawing.Point(750, 252);
            this.button_Restart.Name = "button_Restart";
            this.button_Restart.Size = new System.Drawing.Size(75, 23);
            this.button_Restart.TabIndex = 7;
            this.button_Restart.Text = "Restart";
            this.button_Restart.UseVisualStyleBackColor = true;
            // 
            // PanelServicesHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Restart);
            this.Controls.Add(this.button_Stop);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.richTextBox_ResultServices);
            this.Controls.Add(this.label_Results);
            this.Controls.Add(this.label_ServicesScreen);
            this.Controls.Add(this.listBox_AvailableServices);
            this.Name = "PanelServicesHandler";
            this.Size = new System.Drawing.Size(850, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_AvailableServices;
        private System.Windows.Forms.Label label_ServicesScreen;
        private System.Windows.Forms.Label label_Results;
        private System.Windows.Forms.RichTextBox richTextBox_ResultServices;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.Button button_Stop;
        private System.Windows.Forms.Button button_Restart;
    }
}
