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
            this.button_Execute = new System.Windows.Forms.Button();
            this.comboBox_queryType = new System.Windows.Forms.ComboBox();
            this.label_queryType = new System.Windows.Forms.Label();
            this.numericUpDown_Records = new System.Windows.Forms.NumericUpDown();
            this.label_NumberOfRecords = new System.Windows.Forms.Label();
            this.label_sqlServerName = new System.Windows.Forms.Label();
            this.label_query = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_PreScripts = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SQLResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Records)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_SQLResults
            // 
            this.dataGridView_SQLResults.AllowUserToAddRows = false;
            this.dataGridView_SQLResults.AllowUserToDeleteRows = false;
            this.dataGridView_SQLResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SQLResults.Location = new System.Drawing.Point(18, 194);
            this.dataGridView_SQLResults.Name = "dataGridView_SQLResults";
            this.dataGridView_SQLResults.Size = new System.Drawing.Size(815, 236);
            this.dataGridView_SQLResults.TabIndex = 0;
            // 
            // richTextBox_Query
            // 
            this.richTextBox_Query.Location = new System.Drawing.Point(18, 97);
            this.richTextBox_Query.Name = "richTextBox_Query";
            this.richTextBox_Query.Size = new System.Drawing.Size(815, 62);
            this.richTextBox_Query.TabIndex = 1;
            this.richTextBox_Query.Text = "";
            this.richTextBox_Query.KeyUp += new System.Windows.Forms.KeyEventHandler(this.richTextBox_Query_KeyUp);
            // 
            // comboBox_Databases
            // 
            this.comboBox_Databases.FormattingEnabled = true;
            this.comboBox_Databases.Location = new System.Drawing.Point(78, 36);
            this.comboBox_Databases.Name = "comboBox_Databases";
            this.comboBox_Databases.Size = new System.Drawing.Size(119, 21);
            this.comboBox_Databases.TabIndex = 2;
            // 
            // label_Databases
            // 
            this.label_Databases.AutoSize = true;
            this.label_Databases.Location = new System.Drawing.Point(19, 39);
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
            this.label_SQLClientScreen.Size = new System.Drawing.Size(159, 13);
            this.label_SQLClientScreen.TabIndex = 4;
            this.label_SQLClientScreen.Text = "SQL Client Connected to : ";
            // 
            // button_Execute
            // 
            this.button_Execute.Location = new System.Drawing.Point(758, 164);
            this.button_Execute.Name = "button_Execute";
            this.button_Execute.Size = new System.Drawing.Size(75, 24);
            this.button_Execute.TabIndex = 6;
            this.button_Execute.Text = "Execute";
            this.button_Execute.UseVisualStyleBackColor = true;
            this.button_Execute.Click += new System.EventHandler(this.button_Execute_Click);
            // 
            // comboBox_queryType
            // 
            this.comboBox_queryType.FormattingEnabled = true;
            this.comboBox_queryType.Items.AddRange(new object[] {
            "SelectQuery",
            "NonQuery"});
            this.comboBox_queryType.Location = new System.Drawing.Point(279, 36);
            this.comboBox_queryType.Name = "comboBox_queryType";
            this.comboBox_queryType.Size = new System.Drawing.Size(121, 21);
            this.comboBox_queryType.TabIndex = 7;
            this.comboBox_queryType.SelectedIndexChanged += new System.EventHandler(this.comboBox_queryType_SelectedIndexChanged);
            // 
            // label_queryType
            // 
            this.label_queryType.AutoSize = true;
            this.label_queryType.Location = new System.Drawing.Point(214, 39);
            this.label_queryType.Name = "label_queryType";
            this.label_queryType.Size = new System.Drawing.Size(59, 13);
            this.label_queryType.TabIndex = 8;
            this.label_queryType.Text = "QueryType";
            // 
            // numericUpDown_Records
            // 
            this.numericUpDown_Records.Location = new System.Drawing.Point(496, 36);
            this.numericUpDown_Records.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numericUpDown_Records.Name = "numericUpDown_Records";
            this.numericUpDown_Records.Size = new System.Drawing.Size(85, 20);
            this.numericUpDown_Records.TabIndex = 9;
            // 
            // label_NumberOfRecords
            // 
            this.label_NumberOfRecords.AutoSize = true;
            this.label_NumberOfRecords.Location = new System.Drawing.Point(420, 39);
            this.label_NumberOfRecords.Name = "label_NumberOfRecords";
            this.label_NumberOfRecords.Size = new System.Drawing.Size(70, 13);
            this.label_NumberOfRecords.TabIndex = 10;
            this.label_NumberOfRecords.Text = "Max Records";
            // 
            // label_sqlServerName
            // 
            this.label_sqlServerName.AutoSize = true;
            this.label_sqlServerName.Location = new System.Drawing.Point(180, 10);
            this.label_sqlServerName.Name = "label_sqlServerName";
            this.label_sqlServerName.Size = new System.Drawing.Size(76, 13);
            this.label_sqlServerName.TabIndex = 11;
            this.label_sqlServerName.Text = "<serverName>";
            // 
            // label_query
            // 
            this.label_query.AutoSize = true;
            this.label_query.Location = new System.Drawing.Point(19, 73);
            this.label_query.Name = "label_query";
            this.label_query.Size = new System.Drawing.Size(38, 13);
            this.label_query.TabIndex = 13;
            this.label_query.Text = "T-SQL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(619, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Pre Scripts";
            // 
            // comboBox_PreScripts
            // 
            this.comboBox_PreScripts.FormattingEnabled = true;
            this.comboBox_PreScripts.Location = new System.Drawing.Point(683, 36);
            this.comboBox_PreScripts.Name = "comboBox_PreScripts";
            this.comboBox_PreScripts.Size = new System.Drawing.Size(150, 21);
            this.comboBox_PreScripts.TabIndex = 15;
            this.comboBox_PreScripts.SelectedIndexChanged += new System.EventHandler(this.comboBox_PreScripts_SelectedIndexChanged);
            // 
            // PanelSQLClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.comboBox_PreScripts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_Databases);
            this.Controls.Add(this.comboBox_Databases);
            this.Controls.Add(this.label_query);
            this.Controls.Add(this.label_queryType);
            this.Controls.Add(this.label_NumberOfRecords);
            this.Controls.Add(this.comboBox_queryType);
            this.Controls.Add(this.numericUpDown_Records);
            this.Controls.Add(this.button_Execute);
            this.Controls.Add(this.label_sqlServerName);
            this.Controls.Add(this.label_SQLClientScreen);
            this.Controls.Add(this.dataGridView_SQLResults);
            this.Controls.Add(this.richTextBox_Query);
            this.Name = "PanelSQLClient";
            this.Size = new System.Drawing.Size(850, 450);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SQLResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Records)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_SQLResults;
        private System.Windows.Forms.RichTextBox richTextBox_Query;
        private System.Windows.Forms.ComboBox comboBox_Databases;
        private System.Windows.Forms.Label label_Databases;
        private System.Windows.Forms.Label label_SQLClientScreen;
        private System.Windows.Forms.Button button_Execute;
        private System.Windows.Forms.ComboBox comboBox_queryType;
        private System.Windows.Forms.Label label_queryType;
        private System.Windows.Forms.NumericUpDown numericUpDown_Records;
        private System.Windows.Forms.Label label_NumberOfRecords;
        private System.Windows.Forms.Label label_sqlServerName;
        private System.Windows.Forms.Label label_query;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_PreScripts;
    }
}
