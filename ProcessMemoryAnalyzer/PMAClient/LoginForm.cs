using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager.Client;
using PMA.CommunicationAPI;
using PMA.Info;
using PMA.Utils;

namespace PMA.Client
{
    public partial class LoginForm : Form
    {

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;
        
        public LoginForm()
        {
            InitializeComponent();
            textBox_Server.Text = configManager.clientInfo.Server;
            numericUpDown_port.Value = decimal.Parse(configManager.clientInfo.Port);
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            try
            {
                IPMACommunicationContract proxy = configManager.CreateConnectionChannel(textBox_Server.Text, decimal.ToInt32(numericUpDown_port.Value));
                string md5Password = OperationUtils.EncodePasswordToMD5(textBox_Password.Text);
                configManager.clientRuntimeInfo.sessionID = proxy.GetSessionID(textBox_User.Text, md5Password);
                if (configManager.clientRuntimeInfo.sessionID != string.Empty)
                {
                    configManager.clientRuntimeInfo.UserInfo = proxy.GetUserInfo(configManager.clientRuntimeInfo.sessionID);
                    configManager.clientInfo.Server = textBox_Server.Text;
                    configManager.clientInfo.Port = numericUpDown_port.Value.ToString();
                    configManager.SaveConfiguration();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("User Information does not matched");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                configManager.CloseConnectionChannel();
            }

        }

        private void LoginForm_Enter(object sender, EventArgs e)
        {
            Login();
        }

      

        
    }
}
