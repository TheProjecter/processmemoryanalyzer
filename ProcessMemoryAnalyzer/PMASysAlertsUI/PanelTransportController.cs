using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.SystemAnalyzer;
using System.Text.RegularExpressions;

namespace PMASysAlertsUI
{
    public partial class PanelTransportController : UserControl, IUIConfigManager
    {

        private static string REGX_VERIFY_EMAIL = @"^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$";

        private static string REGX_VERIFY_FTP = @"^[\w\d]*";

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
            if (configManager.SystemAnalyzerInfo.ListSendMailTo != null)
            {
                foreach (string email in configManager.SystemAnalyzerInfo.ListSendMailTo)
                {
                    sb.Append(email);
                    sb.Append(';');
                }
            }
            sb = new StringBuilder();
            if (configManager.SystemAnalyzerInfo.ListPostFTPMessageOn != null)
            {
                foreach (string ftpFolder in configManager.SystemAnalyzerInfo.ListPostFTPMessageOn)
                {
                    sb.Append(ftpFolder);
                    sb.Append(';');
                }
            }
        }

        public void UpdateConfig()
        {
            if (richTextBox_Emails.Text != string.Empty)
            {
                configManager.SystemAnalyzerInfo.ListSendMailTo = richTextBox_Emails.Text.Split(';').ToList<string>();
            }
            if (richTextBox_FtpFolder.Text != string.Empty)
            {
                configManager.SystemAnalyzerInfo.ListPostFTPMessageOn = richTextBox_FtpFolder.Text.Split(';').ToList<string>();
            }
        }

        public bool CauseValidation()
        {
            if (Regex.IsMatch(richTextBox_Emails.Text, REGX_VERIFY_EMAIL))
            {
                return true;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
