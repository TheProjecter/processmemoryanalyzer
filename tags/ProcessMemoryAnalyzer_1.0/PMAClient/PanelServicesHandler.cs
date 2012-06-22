using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Info;
using PMA.ConfigManager.Client;
using PMA.CommunicationAPI;
using System.ServiceProcess;


namespace PMA.Client
{
    public partial class PanelServicesHandler : UserControl, IUIManager
    {

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;
        string sessionID;
        IPMACommunicationContract proxy;
        
        public PanelServicesHandler()
        {
            InitializeComponent();

            sessionID = configManager.clientRuntimeInfo.sessionID;
            proxy = configManager.GetConnectionChannel;
        }

        #region IUIManager Members

        public void UpdateUI()
        {
            BindGrid();
            
        }

        private void BindGrid()
        {
            try
            {
                Dictionary<string, ServiceControllerStatus> availableService = proxy.GetAvailableServices(sessionID);
                dataGridView_Services.Rows.Clear();
                DataGridViewRow row = null;
                DataGridViewComboBoxColumn comboboxColumn = new DataGridViewComboBoxColumn();
                //int rowCount;
                if (availableService != null)
                {
                    foreach (string service in availableService.Keys)
                    {
                        row = dataGridView_Services.Rows[dataGridView_Services.Rows.Add()];
                        row.Cells["serviceName"].Value = service;
                        row.Cells["serviceStatus"].Value = availableService[service].ToString();
                        row.Cells["serviceAction"].Value = "START";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateConfig()
        {
            // no use here            
        }

        public bool ChangeView()
        {
            return true;
        }

        #endregion

        private void button_Refresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }


        private void button_Execute_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> dicServiceActions = new Dictionary<string, string>();
            DataGridViewCheckBoxCell checkBoxCell;
            foreach (DataGridViewRow row in dataGridView_Services.Rows)
            {

                checkBoxCell = row.Cells["selectService"] as DataGridViewCheckBoxCell;

                if (Convert.ToBoolean(checkBoxCell.Value))
                {
                    dicServiceActions.Add(row.Cells["serviceName"].Value.ToString(), row.Cells["serviceAction"].Value.ToString());
                }
                

            }
            if (dicServiceActions.Count > 0)
            {
                richTextBox_ResultServices.Text = proxy.ServiceActions(dicServiceActions, sessionID);
                BindGrid();
            }
            else
            {
                richTextBox_ResultServices.Text = "There is no service selected";
            }
        }

       
    }
}
