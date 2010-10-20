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
    public partial class PanelDatabaseOptimizer : UserControl, IUIConfigManager
    {
        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelDatabaseOptimizer()
        {
            InitializeComponent();
            checkBox_IsWebServer.Checked = false;
            label_Wait.Visible = false;
            ToggleTextControls(false);
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
            if (checkBox_IsWebServer.Checked)
            {
                ToggleTextControls(true);
            }
            else
            {
                ToggleTextControls(false);
            }
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            checkBox_IsWebServer.Checked = configManager.SystemAnalyzerInfo.IsWebServer;
            textBox_Database.Text = configManager.SystemAnalyzerInfo.Database;
            textBox_DBUser.Text = configManager.SystemAnalyzerInfo.DBUser;
            textBox_DBPassword.Text = configManager.SystemAnalyzerInfo.DBPassword;
        }

        public void UpdateConfig()
        {
            configManager.SystemAnalyzerInfo.IsWebServer = checkBox_IsWebServer.Checked;
            configManager.SystemAnalyzerInfo.Database = textBox_Database.Text;
            configManager.SystemAnalyzerInfo.DBUser = textBox_DBUser.Text;
            configManager.SystemAnalyzerInfo.DBPassword = textBox_DBPassword.Text;
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

        
    }
}
