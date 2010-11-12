using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;

namespace PMASysAlertsUI
{
    public partial class PanelServiceWatcher : UserControl, IUIConfigManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
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




        #region IUIConfigManager Members

        public void UpdateUI()
        {
            for (int i = 0; i < checkedListBox_Services.Items.Count; i++)
            {
                if (configManager.SystemAnalyzerInfo.ListServicesNames.Contains(checkedListBox_Services.Items[i].ToString()))
                {
                    checkedListBox_Services.SetItemChecked(i, true);
                }
            }

            checkBox_StoppedServiceAlert.Checked = configManager.SystemAnalyzerInfo.SetStartStoppedServicesAlerts;
            numericUpDown_ServiceMemLimit.Value = configManager.SystemAnalyzerInfo.ProcessPhysicalMemoryAlertAt;
        }

        public void UpdateConfig()
        {
            foreach (object item in checkedListBox_Services.CheckedItems)
            {
                if (!configManager.SystemAnalyzerInfo.ListServicesNames.Contains(item.ToString()))
                {
                    configManager.SystemAnalyzerInfo.ListServicesNames.Add(item.ToString());
                }
            }

            configManager.SystemAnalyzerInfo.SetStartStoppedServicesAlerts = checkBox_StoppedServiceAlert.Checked;
            configManager.SystemAnalyzerInfo.ProcessPhysicalMemoryAlertAt = decimal.ToInt32(numericUpDown_ServiceMemLimit.Value) ;
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion
    }
}
