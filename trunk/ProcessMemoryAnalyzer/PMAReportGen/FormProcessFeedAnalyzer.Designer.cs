namespace PMAReportGen
{
    partial class FormProcessFeedAnalyzer
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProcessFeedAnalyzer));
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBoxAvailableProcess = new System.Windows.Forms.ListBox();
            this.listBoxProcessToGraph = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.comboBoxFeeds = new System.Windows.Forms.ComboBox();
            this.radioButtonSelectFtpFeed = new System.Windows.Forms.RadioButton();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.textBoxFeedFile = new System.Windows.Forms.TextBox();
            this.radioButtonSelectFile = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelAvailableServices = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_ClearGraph = new System.Windows.Forms.Button();
            this.button_ClearList = new System.Windows.Forms.Button();
            this.buttonShowGraph = new System.Windows.Forms.Button();
            this.openFileDialogReportFeed = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.Location = new System.Drawing.Point(13, 355);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0;
            this.zedGraphControl.ScrollMaxX = 0;
            this.zedGraphControl.ScrollMaxY = 0;
            this.zedGraphControl.ScrollMaxY2 = 0;
            this.zedGraphControl.ScrollMinX = 0;
            this.zedGraphControl.ScrollMinY = 0;
            this.zedGraphControl.ScrollMinY2 = 0;
            this.zedGraphControl.Size = new System.Drawing.Size(1003, 345);
            this.zedGraphControl.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1027, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStripFileMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearAllToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transportToolStripMenuItem,
            this.localToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(58, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // transportToolStripMenuItem
            // 
            this.transportToolStripMenuItem.Name = "transportToolStripMenuItem";
            this.transportToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.transportToolStripMenuItem.Text = "Transport";
            // 
            // localToolStripMenuItem
            // 
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.localToolStripMenuItem.Text = "Local";
            // 
            // listBoxAvailableProcess
            // 
            this.listBoxAvailableProcess.FormattingEnabled = true;
            this.listBoxAvailableProcess.Location = new System.Drawing.Point(21, 27);
            this.listBoxAvailableProcess.Name = "listBoxAvailableProcess";
            this.listBoxAvailableProcess.Size = new System.Drawing.Size(250, 147);
            this.listBoxAvailableProcess.TabIndex = 2;
            this.listBoxAvailableProcess.DoubleClick += new System.EventHandler(this.listBoxAvailableProcess_DoubleClick);
            // 
            // listBoxProcessToGraph
            // 
            this.listBoxProcessToGraph.FormattingEnabled = true;
            this.listBoxProcessToGraph.Location = new System.Drawing.Point(383, 27);
            this.listBoxProcessToGraph.Name = "listBoxProcessToGraph";
            this.listBoxProcessToGraph.Size = new System.Drawing.Size(241, 147);
            this.listBoxProcessToGraph.TabIndex = 3;

            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonSelectFile);
            this.panel1.Controls.Add(this.comboBoxFeeds);
            this.panel1.Controls.Add(this.radioButtonSelectFtpFeed);
            this.panel1.Controls.Add(this.buttonBrowse);
            this.panel1.Controls.Add(this.textBoxFeedFile);
            this.panel1.Controls.Add(this.radioButtonSelectFile);
            this.panel1.Location = new System.Drawing.Point(13, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 193);
            this.panel1.TabIndex = 4;
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(15, 150);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(90, 23);
            this.buttonSelectFile.TabIndex = 13;
            this.buttonSelectFile.Text = "Select";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // comboBoxFeeds
            // 
            this.comboBoxFeeds.FormattingEnabled = true;
            this.comboBoxFeeds.Location = new System.Drawing.Point(15, 96);
            this.comboBoxFeeds.Name = "comboBoxFeeds";
            this.comboBoxFeeds.Size = new System.Drawing.Size(182, 21);
            this.comboBoxFeeds.TabIndex = 12;
            // 
            // radioButtonSelectFtpFeed
            // 
            this.radioButtonSelectFtpFeed.AutoSize = true;
            this.radioButtonSelectFtpFeed.Location = new System.Drawing.Point(15, 73);
            this.radioButtonSelectFtpFeed.Name = "radioButtonSelectFtpFeed";
            this.radioButtonSelectFtpFeed.Size = new System.Drawing.Size(105, 17);
            this.radioButtonSelectFtpFeed.TabIndex = 11;
            this.radioButtonSelectFtpFeed.TabStop = true;
            this.radioButtonSelectFtpFeed.Text = "Select FTP Feed";
            this.radioButtonSelectFtpFeed.UseVisualStyleBackColor = true;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(232, 34);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 21);
            this.buttonBrowse.TabIndex = 10;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // textBoxFeedFile
            // 
            this.textBoxFeedFile.Enabled = false;
            this.textBoxFeedFile.Location = new System.Drawing.Point(15, 34);
            this.textBoxFeedFile.Name = "textBoxFeedFile";
            this.textBoxFeedFile.Size = new System.Drawing.Size(211, 20);
            this.textBoxFeedFile.TabIndex = 9;
            // 
            // radioButtonSelectFile
            // 
            this.radioButtonSelectFile.AutoSize = true;
            this.radioButtonSelectFile.Location = new System.Drawing.Point(15, 11);
            this.radioButtonSelectFile.Name = "radioButtonSelectFile";
            this.radioButtonSelectFile.Size = new System.Drawing.Size(74, 17);
            this.radioButtonSelectFile.TabIndex = 8;
            this.radioButtonSelectFile.TabStop = true;
            this.radioButtonSelectFile.Text = "Select File";
            this.radioButtonSelectFile.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ImageLocation = ".\\\\Images\\\\arrow-right.jpg";
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(277, 73);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // labelAvailableServices
            // 
            this.labelAvailableServices.AutoSize = true;
            this.labelAvailableServices.Location = new System.Drawing.Point(18, 11);
            this.labelAvailableServices.Name = "labelAvailableServices";
            this.labelAvailableServices.Size = new System.Drawing.Size(91, 13);
            this.labelAvailableServices.TabIndex = 5;
            this.labelAvailableServices.Text = "AvailableServices";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(380, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Services To Graph";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelAvailableServices);
            this.panel2.Controls.Add(this.listBoxAvailableProcess);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.listBoxProcessToGraph);
            this.panel2.Location = new System.Drawing.Point(383, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(633, 193);
            this.panel2.TabIndex = 7;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button_ClearGraph);
            this.panel3.Controls.Add(this.button_ClearList);
            this.panel3.Controls.Add(this.buttonShowGraph);
            this.panel3.Location = new System.Drawing.Point(13, 265);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1002, 66);
            this.panel3.TabIndex = 8;
            // 
            // button_ClearGraph
            // 
            this.button_ClearGraph.Location = new System.Drawing.Point(812, 15);
            this.button_ClearGraph.Name = "button_ClearGraph";
            this.button_ClearGraph.Size = new System.Drawing.Size(75, 23);
            this.button_ClearGraph.TabIndex = 2;
            this.button_ClearGraph.Text = "ClearGraph";
            this.button_ClearGraph.UseVisualStyleBackColor = true;
            this.button_ClearGraph.Click += new System.EventHandler(this.button_ClearGraph_Click);
            // 
            // button_ClearList
            // 
            this.button_ClearList.Location = new System.Drawing.Point(919, 15);
            this.button_ClearList.Name = "button_ClearList";
            this.button_ClearList.Size = new System.Drawing.Size(75, 23);
            this.button_ClearList.TabIndex = 1;
            this.button_ClearList.Text = "ClearList";
            this.button_ClearList.UseVisualStyleBackColor = true;
            this.button_ClearList.Click += new System.EventHandler(this.button_ClearList_Click);
            // 
            // buttonShowGraph
            // 
            this.buttonShowGraph.Location = new System.Drawing.Point(15, 15);
            this.buttonShowGraph.Name = "buttonShowGraph";
            this.buttonShowGraph.Size = new System.Drawing.Size(75, 23);
            this.buttonShowGraph.TabIndex = 0;
            this.buttonShowGraph.Text = "ShowGraph";
            this.buttonShowGraph.UseVisualStyleBackColor = true;
            this.buttonShowGraph.Click += new System.EventHandler(this.buttonShowGraph_Click);
            // 
            // openFileDialogReportFeed
            // 
            this.openFileDialogReportFeed.DefaultExt = "csv";
            this.openFileDialogReportFeed.FileName = "openFileDialogReportFeed";
            this.openFileDialogReportFeed.Title = "Select Report Feed";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // FormProcessFeedAnalyzer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1027, 712);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.zedGraphControl);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormProcessFeedAnalyzer";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
        private System.Windows.Forms.ListBox listBoxAvailableProcess;
        private System.Windows.Forms.ListBox listBoxProcessToGraph;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelAvailableServices;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.TextBox textBoxFeedFile;
        private System.Windows.Forms.RadioButton radioButtonSelectFile;
        private System.Windows.Forms.ComboBox comboBoxFeeds;
        private System.Windows.Forms.RadioButton radioButtonSelectFtpFeed;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonShowGraph;
        private System.Windows.Forms.OpenFileDialog openFileDialogReportFeed;
        private System.Windows.Forms.Button button_ClearGraph;
        private System.Windows.Forms.Button button_ClearList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ColorDialog colorDialog;
    }
}

