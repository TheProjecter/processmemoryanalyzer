﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;
using PMA.Utils;

namespace PMASysAlertsUI
{
    public partial class PanelSMTPSettings : UserControl, IUIManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        public PanelSMTPSettings()
        {
            InitializeComponent();
        }

        private void numericUpDown_port_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_port.Value > 65534)
            {
                numericUpDown_port.Value = 65533;
            }
        }

        public void UpdateUI()
        {
            textBox_SMTPServer.Text = configManager.SmtpInfo.SmtpServer;
            textBox_UserName.Text = configManager.SmtpInfo.UserName;
            textBox_Password.Text = OperationUtils.EncryptDecrypt(configManager.SmtpInfo.Password);
            numericUpDown_PollingTimeout.Value = configManager.SmtpInfo.TimeOut;
            numericUpDown_port.Value = configManager.SmtpInfo.Port;
            checkBox_EnableSSL.Checked = configManager.SmtpInfo.SSL;
            checkBox_HTMLMode.Checked = configManager.SmtpInfo.IsBodyHtml;
        }

        public void UpdateConfig()
        {
            configManager.SmtpInfo.SmtpServer = textBox_SMTPServer.Text;
            configManager.SmtpInfo.UserName = textBox_UserName.Text;
            configManager.SmtpInfo.Password = OperationUtils.EncryptDecrypt(textBox_Password.Text);
            configManager.SmtpInfo.TimeOut = decimal.ToInt32(numericUpDown_PollingTimeout.Value);
            configManager.SmtpInfo.Port = decimal.ToInt32(numericUpDown_port.Value);
            configManager.SmtpInfo.SSL = checkBox_EnableSSL.Checked;
            configManager.SmtpInfo.IsBodyHtml = checkBox_HTMLMode.Checked;

            configManager.SmtpInfo.ProtectPassword = true;
        }

        public bool CauseValidation()
        {
            return true;
        }

      
    }
}
