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
    public partial class PanelPhyMemWatcher : UserControl, IUIConfigManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelPhyMemWatcher()
        {
            InitializeComponent();
        }

        private void numericUpDown_PhyMemLimit_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_PhyMemLimit.Value > 100)
            {
                numericUpDown_PhyMemLimit.Value = 99;
            }
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            numericUpDown_PhyMemLimit.Value = configManager.SystemAnalyzerInfo.SystemPhysicalMemoryAlertAt;
        }

        public void UpdateConfig()
        {
            configManager.SystemAnalyzerInfo.SystemPhysicalMemoryAlertAt = decimal.ToInt32(numericUpDown_PhyMemLimit.Value);
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion
    }
}
