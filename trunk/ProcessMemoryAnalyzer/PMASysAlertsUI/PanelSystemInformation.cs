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
    public partial class PanelSystemInformation : UserControl, IUIConfigManager
    {

        private static string REGX_VERIFY_EMAIL = @"^[\w\.=-]+@[\w\.-]+\.[\w]{2,3}$";

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        

        public PanelSystemInformation()
        {
            InitializeComponent();
        }

        #region IUIConfigManager Members

        public void UpdateUI()
        {
            richTextBox_SystemInformation.Text = PMASystemAnalyzer.GetSystemInformation();
        }

        public void UpdateConfig()
        {
            
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion

        private void button_Post_Click(object sender, EventArgs e)
        {
            StringBuilder errorMessage = new StringBuilder();
            if (ValidateEmails(out errorMessage))
            {
                List<string> emails = new List<string>();
                if (textBox_emails.Text != string.Empty)
                {
                    emails = textBox_emails.Text.Split(';').ToList<string>();
                }
                string subject = "PMA System Alerts : General : " + Environment.MachineName + " System Information";
                PMASystemAnalyzer.SendMail(subject, richTextBox_SystemInformation.Text, emails, null);
                MessageBox.Show(this, "Message Posted Successfully");
            }
            else
            {
                MessageBox.Show(this,errorMessage.ToString());
            }
        }

        private bool ValidateEmails(out StringBuilder errorMessage)
        {
            string[] emails = null;
            errorMessage = new StringBuilder();
            bool isValidEmail = true;
            if (textBox_emails.Text != string.Empty)
            {
                emails = textBox_emails.Text.Split(';');
                foreach (string email in emails)
                {
                    if (!Regex.IsMatch(email, REGX_VERIFY_EMAIL))
                    {
                        isValidEmail = false;
                        errorMessage.AppendLine("Invalid Email : " + email);
                    }
                }
            }
            else
            {
                isValidEmail = false;
                errorMessage.AppendLine("No email Address is given");
            }
            return isValidEmail;
        }
    }
}
