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

        //private static string REGX_VERIFY_EMAIL = @"^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$";

        //private static string REGX_VERIFY_FTP = @"^[A-Za-z0-9][A-Za-z0-9]+[:]?[0-9A-Za-z]*$";

        /// <summary>
        /// 
        /// </summary>
        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelTransportController()
        {
            InitializeComponent();
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            StringBuilder sb = new StringBuilder();

            textBox_ClientInstanceName.Text = configManager.SystemAnalyzerInfo.ClientInstanceName;
            
            if (configManager.SystemAnalyzerInfo.ListSendMailTo != null)
            {
                foreach (string email in configManager.SystemAnalyzerInfo.ListSendMailTo)
                {
                    sb.Append(email);
                    sb.Append(';');
                }
                richTextBox_Emails.Text = sb.ToString();
            }

            sb = new StringBuilder();
            if (configManager.SystemAnalyzerInfo.ListPostFTPMessageOn != null)
            {
                foreach (string ftpFolder in configManager.SystemAnalyzerInfo.ListPostFTPMessageOn)
                {
                    sb.Append(ftpFolder);
                    sb.Append(';');
                }
                richTextBox_FtpFolder.Text = sb.ToString();
            }
        }

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

        public bool CauseValidation()
        {
            configManager.ClearErrorMessage();
            //if ((richTextBox_Emails.Text == string.Empty || Regex.IsMatch(richTextBox_Emails.Text, REGX_VERIFY_EMAIL)) &&
            //    (richTextBox_FtpFolder.Text == string.Empty || Regex.IsMatch(richTextBox_FtpFolder.Text, REGX_VERIFY_FTP)))
            //{
            //    return true;
            //}
            //else
            //{
            //    if (!(Regex.IsMatch(richTextBox_Emails.Text, REGX_VERIFY_EMAIL)))
            //        configManager.ErrorMessage.Add("Invalid or no Email Address");
            //    if (!Regex.IsMatch(richTextBox_FtpFolder.Text, REGX_VERIFY_FTP))
            //        configManager.ErrorMessage.Add("Invalid or no FTP Folders");
            //    return false;
            //}
            return true;
        }

        #endregion
    }
}
