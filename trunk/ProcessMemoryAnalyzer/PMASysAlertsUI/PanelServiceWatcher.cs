using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.SystemAnalyzer;

namespace PMASysAlertsUI
{
    public partial class PanelServiceWatcher : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelServiceWatcher"/> class.
        /// </summary>
        public PanelServiceWatcher()
        {
            InitializeComponent();

            BindServicesCheckBox();
        }

        private void BindServicesCheckBox()
        {
            foreach (string serviceName in PMASystemAnalyzer.GetAllServicesNames())
            {
                checkedListBox_Services.Items.Add(serviceName);
            }
        }

        private void numericUpDown_ServiceMemLimit_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_ServiceMemLimit.Value > 100)
            {
                numericUpDown_ServiceMemLimit.Value = 99;
            }
        }

        

    }
}
