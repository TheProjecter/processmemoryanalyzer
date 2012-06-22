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
using ZedGraph;

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

      
        /// <summary>
        /// Handles the Click event of the buttonBrowse control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            openFileDialogReportFeed.DefaultExt = ".csv";
            openFileDialogReportFeed.ShowDialog();

            textBoxFeedFile.Text = openFileDialogReportFeed.FileName;
        }

        /// <summary>
        /// Handles the Click event of the buttonSelectFile control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Populates the feed process.
        /// </summary>
        private void PopulateFeedProcess()
        {
            listBoxAvailableProcess.Items.Clear();
            listBoxProcessToGraph.Items.Clear();

            string fileName = string.Empty;
            if (radioButtonSelectFile.Checked)
            {
                fileName = textBoxFeedFile.Text;
                GetProcessNamesFromFeed(fileName);
                listBoxAvailableProcess.DataSource = new BindingSource(dicProcessMemorey.Keys,null);
            }
            else if (radioButtonSelectFtpFeed.Checked)
            {
                fileName = string.Empty;
            }
        }

        /// <summary>
        /// Gets the process names from feed.
        /// </summary>
        /// <param name="feedFile">The feed file.</param>
        private void GetProcessNamesFromFeed(string feedFile)
        {
            dicProcessMemorey = new Dictionary<string, List<int>>();
            if (File.Exists(feedFile))
            {
                string[] rawFeed = File.ReadAllLines(feedFile);

                // Add more to ignore list later 
                timeLine = (from value in rawFeed[1].Split(',')
                            where value != "ProcessNames"
                            select value).ToList<string>();

                List<string> processNames = (from value in rawFeed
                                             where value.Split(',')[0] != "ProcessNames"
                                             orderby value.Split(',')[0]
                                             select value.Split(',')[0]).ToList<string>();

                
                
                List<int> listMemForProcess = null;
                string memRow = string.Empty;
                string[] memArrary = null;
                int result = 0;
                foreach (string processName in processNames)
                {
                    listMemForProcess = new List<int>();

                    memRow = (from value in rawFeed
                              where value.Split(',')[0].Equals(processName)
                              select value).First<string>();

                    memArrary = memRow.Split(',');

                    for (int i = 1; i < memArrary.Length; i++)
                    {
                        if(int.TryParse(memArrary[i],out result))
                        {
                            listMemForProcess.Add(result);
                        }
                        else listMemForProcess.Add(0);
                    }

                    dicProcessMemorey.Add(processName, listMemForProcess);
                }

            }
  
        }

        /// <summary>
        /// Handles the DoubleClick event of the listBoxAvailableProcess control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void listBoxAvailableProcess_DoubleClick(object sender, EventArgs e)
        {
            string color;
            colorDialog.SolidColorOnly = true;
            colorDialog.FullOpen = false;
            colorDialog.AllowFullOpen = false;
            colorDialog.ShowDialog();
           
            color = colorDialog.Color.Name;
            
            listBoxProcessToGraph.Items.Add(listBoxAvailableProcess.SelectedItem.ToString() + ":" + color);
        }

        /// <summary>
        /// Handles the Click event of the buttonShowGraph control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void buttonShowGraph_Click(object sender, EventArgs e)
        {
            CreateGraph();
            
        }

        private void CreateGraph()
        {
            GraphPane graphPane = zedGraphControl.GraphPane;

            graphPane.Title.Text = "Memory Graph : Start Time = " + timeLine[0] + ": End Time = " + timeLine[timeLine.Count - 1];
            graphPane.YAxis.Title.Text = "Memory(KB)";

            zedGraphControl.IsShowHScrollBar = true;
            zedGraphControl.IsShowVScrollBar = true;

            //zedGraphControl.YScrollRangeList.
            
            zedGraphControl.IsAutoScrollRange = true;


            // Horizontal pan and zoom allowed
            zedGraphControl.IsEnableHPan = true;
            zedGraphControl.IsEnableHZoom = true;

            // Vertical pan and zoom not allowed
            zedGraphControl.IsEnableVPan = true;
            zedGraphControl.IsEnableVZoom = true;


            if (timeLine.Count > 2)
            {
                DateTime time1 = DateTime.ParseExact(timeLine[0], "d/M/yyyy HH:mm:ss", null);
                DateTime time2 = DateTime.ParseExact(timeLine[1], "d/M/yyyy HH:mm:ss", null);
                int sec = (int)(time2.Subtract(time1)).TotalSeconds;
                graphPane.XAxis.Title.Text = "Time Line : Difference " + sec.ToString() + " Sec";
            }

            double[] xSpace = new double[timeLine.Count];
            xSpace[0] = 0;
            int temp = 0;
            Dictionary<string, PointPairList> dicpplist = new Dictionary<string, PointPairList>();
            for (int i = 0; i < xSpace.Length; i++)
            {
                temp = temp + 5;
                xSpace[i] = temp;
            }

            double[] ySpace = null;
            foreach (object processName in listBoxProcessToGraph.Items)
            {
                ySpace = new double[dicProcessMemorey[processName.ToString().Split(':')[0]].Count];
                for (int i = 0; i < ySpace.Length; i++)
                {
                    ySpace[i] = dicProcessMemorey[processName.ToString().Split(':')[0]][i];
                }
                dicpplist.Add(processName.ToString(), new PointPairList(xSpace, ySpace));
            }

            foreach (string processName in dicpplist.Keys)
            {
                graphPane.AddCurve(processName.Split(':')[0], dicpplist[processName], Color.FromName(processName.Split(':')[1]));
            }

            zedGraphControl.AxisChange();
        }


        /// <summary>
        /// Handles the Click event of the button_ClearList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button_ClearList_Click(object sender, EventArgs e)
        {
            zedGraphControl.GraphPane.CurveList.Clear();
            listBoxAvailableProcess.Items.Clear();
            PopulateFeedProcess();
        }

        /// <summary>
        /// Handles the Click event of the button_ClearGraph control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button_ClearGraph_Click(object sender, EventArgs e)
        {
            zedGraphControl.GraphPane.CurveList.Clear();
        }

      


    }
}
