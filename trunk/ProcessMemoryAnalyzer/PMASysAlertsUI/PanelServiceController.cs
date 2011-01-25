using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.SystemAnalyzer;
using PMA.ConfigManager;

namespace PMASysAlertsUI
{
    public partial class PanelServiceController : UserControl, IUIManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelServiceController()
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

        #region IUIManager Members

        public void UpdateUI()
        {
            for (int i = 0; i < checkedListBox_Services.Items.Count; i++)
            {
                if (configManager.PMAServerManagerInfo.ListServices.Contains(checkedListBox_Services.Items[i].ToString()))
                {
                    checkedListBox_Services.SetItemChecked(i, true);
                }
            }
        }

        public void UpdateConfig()
        {
            configManager.PMAServerManagerInfo.ListServices.Clear();
            foreach (object item in checkedListBox_Services.CheckedItems)
            {
                if (!configManager.PMAServerManagerInfo.ListServices.Contains(item.ToString()))
                {
                    configManager.PMAServerManagerInfo.ListServices.Add(item.ToString());
                }
            }

        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion

        private void checkBox_SelectAllServices_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_SelectAllServices.Checked)
            {
                for (int count = 0; count < checkedListBox_Services.Items.Count; count++)
                {
                    checkedListBox_Services.SetItemChecked(count, true);
                }
            }
            else
            {
                for (int count = 0; count < checkedListBox_Services.Items.Count; count++)
                {
                    checkedListBox_Services.SetItemChecked(count, false);
                }
            }
        }

        private void checkedListBox_Services_MouseHover(object sender, EventArgs e)
        {
            checkedListBox_Services.Focus();
        }
    }
}
