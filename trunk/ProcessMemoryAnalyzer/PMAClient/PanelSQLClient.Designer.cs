namespace PMA.Client
{
    partial class PanelSQLClient
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
            this.dataGridView_SQLResults = new System.Windows.Forms.DataGridView();
            this.richTextBox_Query = new System.Windows.Forms.RichTextBox();
            this.comboBox_Databases = new System.Windows.Forms.ComboBox();
            this.label_Databases = new System.Windows.Forms.Label();
            this.label_SQLClientScreen = new System.Windows.Forms.Label();
            this.label_Query = new System.Windows.Forms.Label();
            this.button_Execute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SQLResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_SQLResults
            // 
            this.dataGridView_SQLResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SQLResults.Location = new System.Drawing.Point(18, 170);
            this.dataGridView_SQLResults.Name = "dataGridView_SQLResults";
            this.dataGridView_SQLResults.Size = new System.Drawing.Size(815, 259);
            this.dataGridView_SQLResults.TabIndex = 0;
            // 
            // richTextBox_Query
            // 
            this.richTextBox_Query.Location = new System.Drawing.Point(18, 88);
            this.richTextBox_Query.Name = "richTextBox_Query";
            this.richTextBox_Query.Size = new System.Drawing.Size(815, 62);
            this.richTextBox_Query.TabIndex = 1;
            this.richTextBox_Query.Text = "";
            // 
            // comboBox_Databases
            // 
            this.comboBox_Databases.FormattingEnabled = true;
            this.comboBox_Databases.Location = new System.Drawing.Point(74, 44);
            this.comboBox_Databases.Name = "comboBox_Databases";
            this.comboBox_Databases.Size = new System.Drawing.Size(211, 21);
            this.comboBox_Databases.TabIndex = 2;
            // 
            // label_Databases
            // 
            this.label_Databases.AutoSize = true;
            this.label_Databases.Location = new System.Drawing.Point(15, 47);
            this.label_Databases.Name = "label_Databases";
            this.label_Databases.Size = new System.Drawing.Size(53, 13);
            this.label_Databases.TabIndex = 3;
            this.label_Databases.Text = "Database";
            // 
            // label_SQLClientScreen
            // 
            this.label_SQLClientScreen.AutoSize = true;
            this.label_SQLClientScreen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_SQLClientScreen.Location = new System.Drawing.Point(15, 10);
            this.label_SQLClientScreen.Name = "label_SQLClientScreen";
            this.label_SQLClientScreen.Size = new System.Drawing.Size(67, 13);
            this.label_SQLClientScreen.TabIndex = 4;
            this.label_SQLClientScreen.Text = "SQL Client";
            // 
            // label_Query
            // 
            this.label_Query.AutoSize = true;
            this.label_Query.Location = new System.Drawing.Point(15, 72);
            this.label_Query.Name = "label_Query";
            this.label_Query.Size = new System.Drawing.Size(35, 13);
            this.label_Query.TabIndex = 5;
            this.label_Query.Text = "Query";
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(758, 47);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(75, 23);
            this.button_Execute.TabIndex = 6;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            // 
            // PanelSQLClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.label_Query);
            this.Controls.Add(this.label_SQLClientScreen);
            this.Controls.Add(this.label_Databases);
            this.Controls.Add(this.comboBox_Databases);
            this.Controls.Add(this.richTextBox_Query);
            this.Controls.Add(this.dataGridView_SQLResults);
            this.Name = "PanelSQLClient";
            this.Size = new System.Drawing.Size(850, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SQLResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_SQLResults;
        private System.Windows.Forms.RichTextBox richTextBox_Query;
        private System.Windows.Forms.ComboBox comboBox_Databases;
        private System.Windows.Forms.Label label_Databases;
        private System.Windows.Forms.Label label_SQLClientScreen;
        private System.Windows.Forms.Label label_Query;
        private System.Windows.Forms.Button button_Execute;
    }
}
