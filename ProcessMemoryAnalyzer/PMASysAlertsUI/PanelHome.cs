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
    public partial class PanelHome : UserControl, IUIManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelHome()
        {
            InitializeComponent();
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            checkBox_DriveWatch.Checked = configManager.SystemAnalyzerInfo.SetDiscWatch;
            checkBox_DBOptimizer.Checked = configManager.SystemAnalyzerInfo.SetOptimizeDB;
            checkBox_MemWatch.Checked = configManager.SystemAnalyzerInfo.SetPhysicalMemWatch;
            checkBox_ServiceWatch.Checked = configManager.SystemAnalyzerInfo.SetServiceWatcher;
            checkBox_UseFTP.Checked = configManager.SystemAnalyzerInfo.SetPostFTP;
            checkBox_UseSMTP.Checked = configManager.SystemAnalyzerInfo.SetSendMail;
            checkBox_ProcessWatch.Checked = configManager.SystemAnalyzerInfo.SetPMA;
            checkBox_EventReporting.Checked = configManager.SystemAnalyzerInfo.SetCrashReporting;
        }

        public void UpdateConfig()
        {
            configManager.SystemAnalyzerInfo.SetDiscWatch = checkBox_DriveWatch.Checked;
            configManager.SystemAnalyzerInfo.SetOptimizeDB = checkBox_DBOptimizer.Checked;
            configManager.SystemAnalyzerInfo.SetPhysicalMemWatch = checkBox_MemWatch.Checked;
            configManager.SystemAnalyzerInfo.SetServiceWatcher = checkBox_ServiceWatch.Checked;
            configManager.SystemAnalyzerInfo.SetPostFTP = checkBox_UseFTP.Checked;
            configManager.SystemAnalyzerInfo.SetSendMail = checkBox_UseSMTP.Checked;
            configManager.SystemAnalyzerInfo.SetPMA = checkBox_ProcessWatch.Checked;
            configManager.SystemAnalyzerInfo.SetCrashReporting = checkBox_EventReporting.Checked;
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion

        private void checkBox_ProcessWatch_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
