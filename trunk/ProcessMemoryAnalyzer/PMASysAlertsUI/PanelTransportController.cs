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

        private static string REGX_VERIFY_FTP = @"^[A-Za-z0-9][A-Za-z0-9]*$";

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

            sb = new StringBuilder();
            tempList = configManager.SystemAnalyzerInfo.ListPostFTPMessageOn;
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
                richTextBox_FtpFolder.Text = sb.ToString();
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
            configManager.SystemAnalyzerInfo.ListPostFTPMessageOn.Clear();
            if (richTextBox_FtpFolder.Text != string.Empty)
            {
                configManager.SystemAnalyzerInfo.ListPostFTPMessageOn = richTextBox_FtpFolder.Text.Split(';').ToList<string>();
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
            bool isValidFTP = true;
            string[] emails = richTextBox_Emails.Text.Split(';');
            string[] ftpFolders = richTextBox_FtpFolder.Text.Split(';');
            foreach (string email in emails)
            {
                if (!Regex.IsMatch(email, REGX_VERIFY_EMAIL))
                {
                    isValidEmail = false;
                    configManager.ErrorMessage.Add("Invalid Email : " + email);
                }
            }
            foreach (string ftpFolder in ftpFolders)
            {
                if (!Regex.IsMatch(ftpFolder, REGX_VERIFY_FTP))
                {
                    isValidFTP = false;
                    configManager.ErrorMessage.Add("Invalid FTP Folder : " + ftpFolder);
                }
            }

            if (isValidEmail && isValidFTP)
            {
                return true;
            }
            else return false;
            

            
        }

        #endregion
    }
}
