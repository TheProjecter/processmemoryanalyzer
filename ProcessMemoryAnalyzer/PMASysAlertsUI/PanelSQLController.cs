using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.SystemAnalyzer;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Data.SqlClient;
using PMA.ConfigManager;

namespace PMASysAlertsUI
{
    
    
    public partial class PanelSQLController : UserControl, IUIManager
    {

        delegate void LabelOperation();

        private string _connectionMessage = string.Empty;

        private bool isConnectionSet = false;

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelSQLController"/> class.
        /// </summary>
        public PanelSQLController()
        {
            InitializeComponent();
            label_connection.Visible = false;
        }

        #region IUIManager Members

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the UI.
        /// </summary>
        public void UpdateUI()
        {
            textBox_Database.Text = configManager.PMAServerManagerInfo.DatabaseServer;
            textBox_User.Text = configManager.PMAServerManagerInfo.DatabaseUser;
            textBox_Password.Text = configManager.PMAServerManagerInfo.DatabaseUserPassword;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the config.
        /// </summary>
        public void UpdateConfig()
        {
            configManager.PMAServerManagerInfo.DatabaseServer = textBox_Database.Text ;
            configManager.PMAServerManagerInfo.DatabaseUser = textBox_User.Text;
            configManager.PMAServerManagerInfo.DatabaseUserPassword = textBox_Password.Text;
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Causes the validation.
        /// </summary>
        /// <returns></returns>
        public bool CauseValidation()
        {
            if (textBox_Database.Text != string.Empty)
            {
                TestConnection();
                if (isConnectionSet)
                {
                    return true;
                }
                else return false;
            }
            else return true;

        }

        #endregion

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the button_TestConnection control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button_TestConnection_Click(object sender, EventArgs e)
        {
            label_connection.Show();
            this.Refresh();
            LabelOperation labelOperation = new LabelOperation(TestConnection);
            labelOperation.BeginInvoke(LabelOperationCallBack, null);
        }


        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Tests the connection.
        /// </summary>
        private void TestConnection()
        {
            PMADatabaseController dbController = new PMADatabaseController(textBox_Database.Text, textBox_User.Text, textBox_Password.Text);
            if (dbController.IsConnectionSet)
            {
                _connectionMessage = "Connection is setup Properly";
                isConnectionSet = true;
            }
            else
            {
                _connectionMessage = dbController.Message;
                isConnectionSet = false;
            }
            MessageBox.Show(_connectionMessage);
            
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Labels the operation call back.
        /// </summary>
        /// <param name="result">The result.</param>
        private void LabelOperationCallBack(IAsyncResult result)
        {
            HideConnectionLabel();
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Hides the connection label.
        /// </summary>
        private void HideConnectionLabel()
        {
            if (label_connection.InvokeRequired)
            {
                LabelOperation labelOperation = new LabelOperation(HideConnectionLabel);
                label_connection.Invoke(labelOperation);
            }
            else
            {
                label_connection.Visible = false;
            }
        }

        
    }
}
