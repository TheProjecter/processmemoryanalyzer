using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ProcessMemoryAnalyzer;
using PMA.ConfigManager;
using PMA.Info;

namespace PMASysAlertsUI
{
    public partial class PanelAnalyzeMemory : UserControl, IUIConfigManager
    {

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelAnalyzeMemory()
        {
            InitializeComponent();
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            
        }

        public void UpdateConfig()
        {
            configManager.PMAInfoObj.ClientName = textBox_MachineName.Text;
            configManager.PMAInfoObj.DisposeLogFile = checkBox_disposeFiles.Checked;
            configManager.PMAInfoObj.MailingTime = dateTimePicker_MailTime.Text;
        }

        public bool CauseValidation()
        {
            throw new NotImplementedException();
        }

        #endregion

        private void button_GetMachineName_Click(object sender, EventArgs e)
        {
            textBox_MachineName.Text = Environment.MachineName;
        }
    }
}
