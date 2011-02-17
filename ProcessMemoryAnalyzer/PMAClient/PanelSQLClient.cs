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
    public partial class PanelSQLClient : UserControl, IUIManager
    {
        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;
        string sessionID;
        IPMACommunicationContract proxy;
        
        public PanelSQLClient()
        {
            InitializeComponent();
            comboBox_queryType.SelectedIndex = 0;

            sessionID = configManager.clientRuntimeInfo.sessionID;
            proxy = configManager.GetConnectionChannel;

            
        }

        #region IUIManager Members

        public void UpdateUI()
        {
            comboBox_Databases.DataSource = proxy.GetDatabasesNames(sessionID);
            if (comboBox_Databases.Items.Count > 0)
            {
                comboBox_Databases.SelectedIndex = 0;
            }
            label_sqlServerName.Text = proxy.GetSQLServerName(sessionID);
        }

        public void UpdateConfig()
        {
            
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion

        private void button_Execute_Click(object sender, EventArgs e)
        {
            ExcuteScript();
        }

        private void ExcuteScript()
        {
            try
            {
                if (comboBox_queryType.SelectedItem.ToString() == "SelectQuery")
                {
                    dataGridView_SQLResults.DataSource = proxy.ExcuteQuery(richTextBox_Query.Text, comboBox_Databases.SelectedValue.ToString(), decimal.ToInt32(numericUpDown_Records.Value), sessionID).Tables[0];
                }
                if (comboBox_queryType.SelectedItem.ToString() == "NonQuery")
                {
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Result");
                    DataRow dr = dt.Rows.Add(proxy.ExcuteNonQuery(richTextBox_Query.Text, comboBox_Databases.SelectedValue.ToString(), sessionID));
                    dataGridView_SQLResults.DataSource = dt;
                }
                for (int count = 0; count < dataGridView_SQLResults.Columns.Count; count++)
                {
                    dataGridView_SQLResults.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox_queryType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_queryType.SelectedItem.ToString() == "NonQuery")
            {
                numericUpDown_Records.Enabled = false;
            }
            else numericUpDown_Records.Enabled = true;
        }

        private void richTextBox_Query_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ExcuteScript();
            }
        }

       
        
    }
}
