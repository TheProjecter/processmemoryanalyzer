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
    public partial class PanelTransportController : UserControl, IUIConfigManager
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
            List<string> tempList = configManager.SystemAnalyzerInfo.ListSendMailTo;
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
                richTextBox_Emails.Text = sb.ToString();
            }

       
        }

        //--------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the config.
        /// </summary>
        public void UpdateConfig()
        {
            configManager.SystemAnalyzerInfo.ListSendMailTo.Clear();
            if (richTextBox_Emails.Text != string.Empty)
            {
                configManager.SystemAnalyzerInfo.ListSendMailTo = richTextBox_Emails.Text.Split(';').ToList<string>();
            }
            configManager.SystemAnalyzerInfo.ClientInstanceName = textBox_ClientInstanceName.Text;
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
            string[] emails = richTextBox_Emails.Text.Split(';');
            foreach (string email in emails)
            {
                if (!Regex.IsMatch(email, REGX_VERIFY_EMAIL))
                {
                    isValidEmail = false;
                    configManager.ErrorMessage.Add("Invalid Email : " + email);
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
