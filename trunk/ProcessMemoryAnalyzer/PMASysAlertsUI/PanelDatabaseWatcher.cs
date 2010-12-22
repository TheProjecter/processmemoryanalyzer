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
    public partial class PanelDatabaseWatcher : UserControl, IUIConfigManager
    {
        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelDatabaseWatcher()
        {
            InitializeComponent();
            label_Wait.Visible = false;
            ToggleTextControls(true);
        }

        private void ToggleTextControls(bool enableControls)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tb = control as TextBox;
                    tb.Enabled = enableControls;
                }
            }
        }

        private void checkBox_IsWebServer_CheckedChanged(object sender, EventArgs e)
        {
            //if (checkBox_IsWebServer.Checked)
            //{
            //    ToggleTextControls(true);
            //}
            //else
            //{
            //    ToggleTextControls(false);
            //}
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            textBox_Database.Text = configManager.SystemAnalyzerInfo.Database;
            textBox_DBUser.Text = configManager.SystemAnalyzerInfo.DBUser;
            textBox_DBPassword.Text = configManager.SystemAnalyzerInfo.DBPassword;
            checkBox_GenerateSessionStateAlert.Checked = configManager.SystemAnalyzerInfo.SetSessionStateSizeAlerts;
            checkBox_TempDBAlert.Checked = configManager.SystemAnalyzerInfo.SetTempDBSizeAlerts;
            numericUpDown_SessionAlert.Value = configManager.SystemAnalyzerInfo.SessionStateSizeAlertLevel;
            numericUpDown_TempTB.Value = configManager.SystemAnalyzerInfo.TempDBSizeAlertLevel;
        }

        public void UpdateConfig()
        {
            configManager.SystemAnalyzerInfo.Database = textBox_Database.Text;
            configManager.SystemAnalyzerInfo.DBUser = textBox_DBUser.Text;
            configManager.SystemAnalyzerInfo.DBPassword = textBox_DBPassword.Text;
            configManager.SystemAnalyzerInfo.SetSessionStateSizeAlerts = checkBox_GenerateSessionStateAlert.Checked;
            configManager.SystemAnalyzerInfo.SetTempDBSizeAlerts = checkBox_TempDBAlert.Checked;
            configManager.SystemAnalyzerInfo.SessionStateSizeAlertLevel = decimal.ToInt32(numericUpDown_SessionAlert.Value);
            configManager.SystemAnalyzerInfo.TempDBSizeAlertLevel = decimal.ToInt32(numericUpDown_TempTB.Value);
        }

        public bool CauseValidation()
        {
            configManager.ClearErrorMessage();
            label_Wait.Visible = true;
            bool result = false;
            PMADatabaseController dbController = new PMADatabaseController();
            if (textBox_Database.Text != string.Empty && !dbController.CreateDBConnection(textBox_Database.Text, textBox_DBUser.Text, textBox_DBPassword.Text))
            {
                configManager.ErrorMessage.Add(dbController.Message);
                result = false;
            }
            else result = true;
            label_Wait.Visible = false;
            return result;
        }

        #endregion

        private void checkBox_GenerateSessionStateAlert_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_GenerateSessionStateAlert.Checked)
            {
                numericUpDown_SessionAlert.Enabled = true;
            }
            else numericUpDown_SessionAlert.Enabled = false;
        }

        private void checkBox_TempDBAlert_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_TempDBAlert.Checked)
            {
                numericUpDown_TempTB.Enabled = true;
            }
            else numericUpDown_TempTB.Enabled = false;
        }

               

        
    }
}
