namespace PMASysAlertsUI
{
    partial class PanelSystemInformation
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
            this.richTextBox_SystemInformation = new System.Windows.Forms.RichTextBox();
            this.button_Post = new System.Windows.Forms.Button();
            this.label_SystemInformation = new System.Windows.Forms.Label();
            this.textBox_emails = new System.Windows.Forms.TextBox();
            this.label_email = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox_SystemInformation
            // 
            this.richTextBox_SystemInformation.Location = new System.Drawing.Point(29, 42);
            this.richTextBox_SystemInformation.Name = "richTextBox_SystemInformation";
            this.richTextBox_SystemInformation.Size = new System.Drawing.Size(371, 126);
            this.richTextBox_SystemInformation.TabIndex = 0;
            this.richTextBox_SystemInformation.Text = "";
            // 
            // button_Post
            // 
            this.button_Post.Location = new System.Drawing.Point(29, 212);
            this.button_Post.Name = "button_Post";
            this.button_Post.Size = new System.Drawing.Size(75, 23);
            this.button_Post.TabIndex = 1;
            this.button_Post.Text = "Post";
            this.button_Post.UseVisualStyleBackColor = true;
            this.button_Post.Click += new System.EventHandler(this.button_Post_Click);
            // 
            // label_SystemInformation
            // 
            this.label_SystemInformation.AutoSize = true;
            this.label_SystemInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SystemInformation.Location = new System.Drawing.Point(26, 17);
            this.label_SystemInformation.Name = "label_SystemInformation";
            this.label_SystemInformation.Size = new System.Drawing.Size(114, 13);
            this.label_SystemInformation.TabIndex = 2;
            this.label_SystemInformation.Text = "System Information";
            // 
            // textBox_emails
            // 
            this.textBox_emails.Location = new System.Drawing.Point(75, 177);
            this.textBox_emails.Name = "textBox_emails";
            this.textBox_emails.Size = new System.Drawing.Size(325, 20);
            this.textBox_emails.TabIndex = 3;
            // 
            // label_email
            // 
            this.label_email.AutoSize = true;
            this.label_email.Location = new System.Drawing.Point(26, 180);
            this.label_email.Name = "label_email";
            this.label_email.Size = new System.Drawing.Size(43, 13);
            this.label_email.TabIndex = 4;
            this.label_email.Text = "Email(s)";
            // 
            // PanelSystemInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label_email);
            this.Controls.Add(this.textBox_emails);
            this.Controls.Add(this.label_SystemInformation);
            this.Controls.Add(this.button_Post);
            this.Controls.Add(this.richTextBox_SystemInformation);
            this.MaximumSize = new System.Drawing.Size(440, 260);
            this.MinimumSize = new System.Drawing.Size(440, 260);
            this.Name = "PanelSystemInformation";
            this.Size = new System.Drawing.Size(440, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_SystemInformation;
        private System.Windows.Forms.Button button_Post;
        private System.Windows.Forms.Label label_SystemInformation;
        private System.Windows.Forms.TextBox textBox_emails;
        private System.Windows.Forms.Label label_email;
    }
}
