﻿namespace PMA.Client
{
    partial class PanelExecuteCommand
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
            this.checkedListBox_AvailableActions = new System.Windows.Forms.CheckedListBox();
            this.label_ActionScreen = new System.Windows.Forms.Label();
            this.button_Execute = new System.Windows.Forms.Button();
            this.label_Results = new System.Windows.Forms.Label();
            this.richTextBox_ActionResults = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // checkedListBox_AvailableActions
            // 
            this.checkedListBox_AvailableActions.FormattingEnabled = true;
            this.checkedListBox_AvailableActions.Location = new System.Drawing.Point(18, 60);
            this.checkedListBox_AvailableActions.Name = "checkedListBox_AvailableActions";
            this.checkedListBox_AvailableActions.Size = new System.Drawing.Size(801, 184);
            this.checkedListBox_AvailableActions.TabIndex = 0;
            // 
            // label_ActionScreen
            // 
            this.label_ActionScreen.AutoSize = true;
            this.label_ActionScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ActionScreen.Location = new System.Drawing.Point(15, 18);
            this.label_ActionScreen.Name = "label_ActionScreen";
            this.label_ActionScreen.Size = new System.Drawing.Size(105, 13);
            this.label_ActionScreen.TabIndex = 1;
            this.label_ActionScreen.Text = "Available Actions";
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(744, 250);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(75, 23);
            this.button_Execute.TabIndex = 2;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            // 
            // label_Results
            // 
            this.label_Results.AutoSize = true;
            this.label_Results.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Results.Location = new System.Drawing.Point(18, 306);
            this.label_Results.Name = "label_Results";
            this.label_Results.Size = new System.Drawing.Size(49, 13);
            this.label_Results.TabIndex = 3;
            this.label_Results.Text = "Results";
            // 
            // richTextBox_ActionResults
            // 
            this.richTextBox_ActionResults.Location = new System.Drawing.Point(18, 333);
            this.richTextBox_ActionResults.Name = "richTextBox_ActionResults";
            this.richTextBox_ActionResults.Size = new System.Drawing.Size(801, 96);
            this.richTextBox_ActionResults.TabIndex = 4;
            this.richTextBox_ActionResults.Text = "";
            // 
            // PanelExecuteCommand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.richTextBox_ActionResults);
            this.Controls.Add(this.label_Results);
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.label_ActionScreen);
            this.Controls.Add(this.checkedListBox_AvailableActions);
            this.Name = "PanelExecuteCommand";
            this.Size = new System.Drawing.Size(850, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBox_AvailableActions;
        private System.Windows.Forms.Label label_ActionScreen;
        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.Label label_Results;
        private System.Windows.Forms.RichTextBox richTextBox_ActionResults;
    }
}