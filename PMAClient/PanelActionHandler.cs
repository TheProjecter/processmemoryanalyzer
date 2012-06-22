using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager.Client;
using PMA.CommunicationAPI;

namespace PMA.Client
{
    public partial class PanelExecuteCommand : UserControl, IUIManager
    {
        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;
        string sessionID;
        IPMACommunicationContract proxy;
        
        public PanelExecuteCommand()
        {
            InitializeComponent();

            sessionID = configManager.clientRuntimeInfo.sessionID;
            proxy = configManager.GetConnectionChannel;
        }

        #region IUIManager Members

        public void UpdateUI()
        {
            BindActionList();
        }

        private void BindActionList()
        {
            List<string> availableActions = proxy.GetAvailableActions(sessionID);
            checkedListBox_AvailableActions.Items.Clear();
            if (availableActions != null && availableActions.Count > 0)
            {
                checkedListBox_AvailableActions.Items.AddRange(proxy.GetAvailableActions(sessionID).ToArray());
            }
        }


        public void UpdateConfig()
        {
            // no use here.            
        }

        public bool ChangeView()
        {
            return true;
        }

        #endregion

        private void button_Execute_Click(object sender, EventArgs e)
        {
            List<string> actionList = new List<string>();
            foreach(object actionName in checkedListBox_AvailableActions.CheckedItems)
            {
                actionList.Add(actionName.ToString());
            }
            if (actionList.Count > 0)
            {
                richTextBox_ActionResults.Text = proxy.ExecuteActions(actionList, sessionID);
            }
            else richTextBox_ActionResults.Text = "No action is selected";
        }

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            BindActionList();
        }

       
    }
}
