using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;
using System.IO;

namespace PMASysAlertsUI
{
    public partial class PanelDriveController : UserControl, IUIConfigManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelDriveController()
        {
            InitializeComponent();

            InitializeDrives();
        }

        private void InitializeDrives()
        {
            DriveInfo[] driveInfo = PMASystemAnalyzer.GetSystemDiscs();

            foreach (DriveInfo drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    checkedListBox_Drives.Items.Add(drive.Name);
                }
            }
        }

        private void numericUpDown_DriveUse_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_DriveUse.Value > 100)
            {
                numericUpDown_DriveUse.Value = 99;
            }
        }


        #region IUIConfigManager Members

        public void UpdateUI()
        {
            numericUpDown_DriveUse.Value = configManager.SystemAnalyzerInfo.LowDiscAlertAt;

            for (int i = 0; i < checkedListBox_Drives.Items.Count; i++)
            {
                if (configManager.SystemAnalyzerInfo.ListDrivesToWatch.Contains(checkedListBox_Drives.Items[i].ToString()))
                {
                    checkedListBox_Drives.SetItemChecked(i,true);
                    //checkedListBox_Drives.GetItemChecked(i);
                }
            }
        }

        public void UpdateConfig()
        {
            configManager.SystemAnalyzerInfo.ListDrivesToWatch.Clear();
            foreach (object item in checkedListBox_Drives.CheckedItems)
            {
                if (!configManager.SystemAnalyzerInfo.ListDrivesToWatch.Contains(item.ToString()))
                {
                    configManager.SystemAnalyzerInfo.ListDrivesToWatch.Add(item.ToString());
                }
            }

            configManager.SystemAnalyzerInfo.LowDiscAlertAt = decimal.ToInt32(numericUpDown_DriveUse.Value);
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion
    }
}
