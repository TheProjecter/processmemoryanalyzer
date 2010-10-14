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
    public partial class PanelFTPSettings : UserControl, IUIConfigManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        public PanelFTPSettings()
        {
            InitializeComponent();
        }

        private void numericUpDown_port_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_port.Value > 65536)
            {
                numericUpDown_port.Value = 65535;
            }
        }

        public void UpdateUI()
        {
            textBox_FTPServer.Text = configManager.FtpInfo.FTPServer;
            textBox_User.Text = configManager.FtpInfo.UserName ;
            textBox_Password.Text = configManager.FtpInfo.Password;
            numericUpDown_port.Value = configManager.FtpInfo.Port;
            checkBox_EnableSSL.Checked = configManager.FtpInfo.SSL;
            textBox_DefaultFolder.Text= configManager.FtpInfo.FTPServerFolder;
            numericUpDown_Timeout.Value = configManager.FtpInfo.TimeOut;
        }

        public void UpdateConfig()
        {
            configManager.FtpInfo.FTPServer = textBox_FTPServer.Text;
            configManager.FtpInfo.UserName = textBox_User.Text;
            configManager.FtpInfo.Password = textBox_Password.Text;
            configManager.FtpInfo.ProtectPassword = true;
            configManager.FtpInfo.Port = decimal.ToInt32(numericUpDown_port.Value);
            configManager.FtpInfo.SSL = checkBox_EnableSSL.Checked;
            configManager.FtpInfo.FTPServerFolder = textBox_DefaultFolder.Text;
            configManager.FtpInfo.TimeOut = decimal.ToInt32(numericUpDown_Timeout.Value);
        }
    }
}
