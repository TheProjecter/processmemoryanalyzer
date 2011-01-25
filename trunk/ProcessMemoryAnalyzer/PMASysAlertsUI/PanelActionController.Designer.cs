namespace PMASysAlertsUI
{
    partial class PanelActionController
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
            this.label_ActionController = new System.Windows.Forms.Label();
            this.label_Action = new System.Windows.Forms.Label();
            this.richTextBox_Action = new System.Windows.Forms.RichTextBox();
            this.listBox_AvailableAction = new System.Windows.Forms.ListBox();
            this.button_AddAction = new System.Windows.Forms.Button();
            this.label_AvailableActions = new System.Windows.Forms.Label();
            this.button_Remove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_ActionController
            // 
            this.label_ActionController.AutoSize = true;
            this.label_ActionController.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ActionController.Location = new System.Drawing.Point(18, 16);
            this.label_ActionController.Name = "label_ActionController";
            this.label_ActionController.Size = new System.Drawing.Size(101, 13);
            this.label_ActionController.TabIndex = 0;
            this.label_ActionController.Text = "Action Controller";
            // 
            // label_Action
            // 
            this.label_Action.AutoSize = true;
            this.label_Action.Location = new System.Drawing.Point(18, 52);
            this.label_Action.Name = "label_Action";
            this.label_Action.Size = new System.Drawing.Size(37, 13);
            this.label_Action.TabIndex = 2;
            this.label_Action.Text = "Action";
            // 
            // richTextBox_Action
            // 
            this.richTextBox_Action.Location = new System.Drawing.Point(21, 68);
            this.richTextBox_Action.Name = "richTextBox_Action";
            this.richTextBox_Action.Size = new System.Drawing.Size(453, 56);
            this.richTextBox_Action.TabIndex = 3;
            this.richTextBox_Action.Text = "";
            // 
            // listBox_AvailableAction
            // 
            this.listBox_AvailableAction.FormattingEnabled = true;
            this.listBox_AvailableAction.Location = new System.Drawing.Point(21, 178);
            this.listBox_AvailableAction.Name = "listBox_AvailableAction";
            this.listBox_AvailableAction.Size = new System.Drawing.Size(453, 95);
            this.listBox_AvailableAction.TabIndex = 4;
            // 
            // button_AddAction
            // 
            this.button_AddAction.Location = new System.Drawing.Point(399, 130);
            this.button_AddAction.Name = "button_AddAction";
            this.button_AddAction.Size = new System.Drawing.Size(75, 23);
            this.button_AddAction.TabIndex = 5;
            this.button_AddAction.Text = "Add";
            this.button_AddAction.UseVisualStyleBackColor = true;
            this.button_AddAction.Click += new System.EventHandler(this.button_AddAction_Click);
            // 
            // label_AvailableActions
            // 
            this.label_AvailableActions.AutoSize = true;
            this.label_AvailableActions.Location = new System.Drawing.Point(18, 162);
            this.label_AvailableActions.Name = "label_AvailableActions";
            this.label_AvailableActions.Size = new System.Drawing.Size(83, 13);
            this.label_AvailableActions.TabIndex = 6;
            this.label_AvailableActions.Text = "Available Action";
            // 
            // button_Remove
            // 
            this.button_Remove.Location = new System.Drawing.Point(399, 280);
            this.button_Remove.Name = "button_Remove";
            this.button_Remove.Size = new System.Drawing.Size(75, 23);
            this.button_Remove.TabIndex = 7;
            this.button_Remove.Text = "Remove";
            this.button_Remove.UseVisualStyleBackColor = true;
            this.button_Remove.Click += new System.EventHandler(this.button_Remove_Click);
            // 
            // PanelActionController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Remove);
            this.Controls.Add(this.label_AvailableActions);
            this.Controls.Add(this.button_AddAction);
            this.Controls.Add(this.listBox_AvailableAction);
            this.Controls.Add(this.richTextBox_Action);
            this.Controls.Add(this.label_Action);
            this.Controls.Add(this.label_ActionController);
            this.Name = "PanelActionController";
            this.Size = new System.Drawing.Size(500, 315);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_ActionController;
        private System.Windows.Forms.Label label_Action;
        private System.Windows.Forms.RichTextBox richTextBox_Action;
        private System.Windows.Forms.ListBox listBox_AvailableAction;
        private System.Windows.Forms.Button button_AddAction;
        private System.Windows.Forms.Label label_AvailableActions;
        private System.Windows.Forms.Button button_Remove;
    }
}
