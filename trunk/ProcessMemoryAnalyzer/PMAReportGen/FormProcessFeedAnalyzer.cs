using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace PMAReportGen
{
    public partial class FormProcessFeedAnalyzer : Form
    {

        private List<string> timeLine;

        private Dictionary<string, List<int>> dicProcessMemorey;
        
        public FormProcessFeedAnalyzer()
        {
            InitializeComponent();
        }

        private void listBoxServicesToGraph_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            textBoxFeedFile.Text = openFileDialogReportFeed.FileName;
        }

        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            if (radioButtonSelectFile.Checked && textBoxFeedFile.Text == string.Empty)
            {
                MessageBox.Show("Please Select a Feed File");
            }
            else if (radioButtonSelectFtpFeed.Checked && comboBoxFeeds.SelectedText == "--Select--")
            {
                MessageBox.Show("Please Select a Feed");
            }
            else PopulateFeedProcess();
        }

        private void PopulateFeedProcess()
        {
            string fileName = string.Empty;
            if (radioButtonSelectFile.Checked)
            {
                fileName = textBoxFeedFile.Text;
            }
            else if (radioButtonSelectFtpFeed.Checked)
            {
                fileName = string.Empty;
            }


        }

        private void GetProcessNamesFromFeed(string feedFile)
        {
            if (File.Exists(feedFile))
            {
                string[] rawFeed = File.ReadAllLines(feedFile);

                timeLine = (from value in rawFeed[0].Split(',')
                            where value != "ProcessNames"
                            select value).ToList<string>();

                List<string> processNames = (from value in rawFeed
                                             where value != "ProcessNames"
                                             select value.Split(',')[0]).ToList<string>();

                List<int> memForProcess = null;
                foreach (string processName in processNames)
                {
                    //memForProcess = from value in rawFeed
                    //                where value.Split(',')[0] == processName
                    //                select
                }
            }
            

            
        }


    }
}
