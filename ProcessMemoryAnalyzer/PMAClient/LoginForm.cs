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
            IPMACommunicationContract proxy = configManager.GetConnectionChannel;

            PMAUserInfo userInfo = null;

            try
            {
                userInfo = proxy.GetUserInfo(textBox_User.Text, textBox_Password.Text);
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


            if (userInfo != null)
            {
                configManager.clientRuntimeInfo.UserInfo = userInfo;
                configManager.clientRuntimeInfo.IsUserLoggedIn = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("User Information does not matched");
            }
        }
    }
}
