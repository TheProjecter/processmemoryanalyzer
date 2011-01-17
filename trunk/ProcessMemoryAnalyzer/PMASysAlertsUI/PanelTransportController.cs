using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;
using System.Text.RegularExpressions;

namespace PMASysAlertsUI
{
    public partial class PanelTransportController : UserControl, IUIManager
    {

        private static string REGX_VERIFY_EMAIL = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";

        /// <summary>
        /// 
        /// </summary>
        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelTransportController()
        {
            InitializeComponent();
        }

        #region IUIConfigManager Members
        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the UI.
        /// </summary>
        public void UpdateUI()
        {
            StringBuilder sb = new StringBuilder();
            string tempString = string.Empty;
            textBox_ClientInstanceName.Text = configManager.SystemAnalyzerInfo.ClientInstanceName;
            List<string> tempList = configManager.SystemAnalyzerInfo.ListAlertMailSubscription;
            if (tempList != null)
            {
                for(int index = 0; index <tempList.Count ; index ++)
                {
                    tempString = tempList[index];
                    sb.Append(tempString);
                    if (index < tempList.Count - 1)
                    {
                        sb.Append(';');
                    }
                }
                richTextBox_EmailsAlerts.Text = sb.ToString();
            }

            sb = new StringBuilder();
            tempString = string.Empty;
            tempList = configManager.SystemAnalyzerInfo.ListPMAReportSubscription;
            if (tempList != null)
            {
                for (int index = 0; index < tempList.Count; index++)
                {
                    tempString = tempList[index];
                    sb.Append(tempString);
                    if (index < tempList.Count - 1)
                    {
                        sb.Append(';');
                    }
                }
                richTextBox_EmailsPMAReport.Text = sb.ToString();
            }

       
        }

        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the config.
        /// </summary>
        public void UpdateConfig()
        {
            configManager.SystemAnalyzerInfo.ClientInstanceName = textBox_ClientInstanceName.Text;
            configManager.SystemAnalyzerInfo.ListAlertMailSubscription.Clear();
            if (richTextBox_EmailsAlerts.Text != string.Empty)
            {
                configManager.SystemAnalyzerInfo.ListAlertMailSubscription = richTextBox_EmailsAlerts.Text.Split(';').ToList<string>();
            }
            configManager.SystemAnalyzerInfo.ListPMAReportSubscription.Clear();
            if (richTextBox_EmailsPMAReport.Text != string.Empty)
            {
                configManager.SystemAnalyzerInfo.ListPMAReportSubscription = richTextBox_EmailsPMAReport.Text.Split(';').ToList<string>();
            }
        }

        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Causes the validation.
        /// </summary>
        /// <returns></returns>
        public bool CauseValidation()
        {
            configManager.ClearErrorMessage();
            bool isValidEmail = true;
            string[] emails = null;

            if (richTextBox_EmailsAlerts.Text != string.Empty)
            {
                emails = richTextBox_EmailsAlerts.Text.Split(';');
                foreach (string email in emails)
                {
                    if (!Regex.IsMatch(email, REGX_VERIFY_EMAIL))
                    {
                        isValidEmail = false;
                        configManager.ErrorMessage.Add("Invalid Email : " + email);
                    }
                }
            }
            if (richTextBox_EmailsPMAReport.Text != string.Empty)
            {
                emails = richTextBox_EmailsPMAReport.Text.Split(';');
                foreach (string email in emails)
                {
                    if (!Regex.IsMatch(email, REGX_VERIFY_EMAIL))
                    {
                        isValidEmail = false;
                        configManager.ErrorMessage.Add("Invalid Email : " + email);
                    }
                }
            }
            
            if (isValidEmail)
            {
                return true;
            }
            else return false;
          
        }

        #endregion
    }
}
