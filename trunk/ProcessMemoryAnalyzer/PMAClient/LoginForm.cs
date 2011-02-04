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

namespace PMA.Client
{
    public partial class LoginForm : Form
    {

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;
        
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button_Login_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            IPMACommunicationContract proxy = configManager.GetConnectionChannel;

            try
            {
                configManager.clientRuntimeInfo.sessionID = proxy.GetSessionID(textBox_User.Text, textBox_Password.Text);
                if (configManager.clientRuntimeInfo.sessionID != string.Empty)
                {
                    configManager.clientRuntimeInfo.UserInfo = proxy.GetUserInfo(configManager.clientRuntimeInfo.sessionID);
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
