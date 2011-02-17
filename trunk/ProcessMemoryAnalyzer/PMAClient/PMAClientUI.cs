using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Info;
using PMA.ConfigManager.Client;


namespace PMA.Client
{
    public partial class PMAClientUI : Form
    {

        ENUMPanel PANEL;

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;

        PanelExecuteCommand panelExecuteCommand = null;
        PanelSQLClient panelSQLClient = null;
        PanelServicesHandler panelServiceHandler = null;

        LoginForm loginForm;

        private bool CauseValidation()
        {
            bool result = false;
            configManager.ErrorMessage.Clear();
            switch (PANEL)
            {
                case ENUMPanel.PANEL_ACTION_HANDLER:
                    result = panelExecuteCommand.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SERVICES_HANDLER:
                    result = panelServiceHandler.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SQL_CLIENT:
                    result = panelSQLClient.CauseValidation();
                    break;
                default:
                    result = false;
                    break;
            }
            return result;
        }

        private void UpdateConfig(ENUMPanel enumPanel)
        {

            switch (enumPanel)
            {
                case ENUMPanel.PANEL_ACTION_HANDLER:
                    panelExecuteCommand.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SERVICES_HANDLER:
                    panelServiceHandler.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SQL_CLIENT:
                    panelSQLClient.UpdateConfig();
                    break;
            }

        }

        private void ShowPanel(ENUMPanel enumPanel)
        {
            PANEL = enumPanel;
            switch (enumPanel)
            {
                case ENUMPanel.PANEL_ACTION_HANDLER:
                    HideAllControls();
                    panelExecuteCommand.Show();
                    break;
                case ENUMPanel.PANEL_SERVICES_HANDLER:
                    HideAllControls();
                    panelServiceHandler.Show();
                    break;
                case ENUMPanel.PANEL_SQL_CLIENT:
                    HideAllControls();
                    panelSQLClient.Show();
                    break;
            }

        }

        
        private void SetAccessibilityForUser()
        {
            if (configManager.clientRuntimeInfo.UserInfo != null)
            {
                label_Actions.Enabled = configManager.clientRuntimeInfo.UserInfo.IsActionUser;
                label_Services.Enabled = configManager.clientRuntimeInfo.UserInfo.IsServiceUser;
                label_SQL.Enabled = configManager.clientRuntimeInfo.UserInfo.IsSQLUser;
            }
        }

      
        
        public PMAClientUI()
        {
            InitializeComponent();
        }

        private void InitilizeUI()
        {
            InitializeAllPanels();
            HideAllControls();
            LoadConfigs();
            ChangeCursorStyle();
            DisableLeftMenu();
            SetAccessibilityForUser();
            ShowPanel(ENUMPanel.PANEL_ACTION_HANDLER);
        }

        private void InitializeAllPanels()
        {
            panelExecuteCommand = new PanelExecuteCommand();
            panel_MainContainer.Controls.Add(panelExecuteCommand);

            panelSQLClient = new PanelSQLClient();
            panel_MainContainer.Controls.Add(panelSQLClient);

            panelServiceHandler = new PanelServicesHandler();
            panel_MainContainer.Controls.Add(panelServiceHandler);
        }

        private void LoadConfigs()
        {
            panelServiceHandler.UpdateUI();
            panelExecuteCommand.UpdateUI();
            panelSQLClient.UpdateUI();
        }

        private void HideAllControls()
        {
            foreach (Control control in panel_MainContainer.Controls)
            {
                control.Hide();
            }
        }


        private void PMAClientUI_Shown(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void ShowLoginForm()
        {
            loginForm = new LoginForm();
            loginForm.ShowDialog(this);
            if (configManager.clientRuntimeInfo.sessionID != null)
            {
                InitilizeUI();
            }
            loginForm.Dispose();
        }


        private void ChangeCursorStyle()
        {
            foreach (Control control in tableLayoutPanel_LeftMenu.Controls)
            {
                if (control is Label)
                {
                    Label label = control as Label;
                    label.Cursor = Cursors.Hand;
                }
            }
        }

        private void DisableLeftMenu()
        {
            foreach (Control control in tableLayoutPanel_LeftMenu.Controls)
            {
                if (control is Label)
                {
                    Label label = control as Label;
                    label.Enabled = false;
                }
            }
        }

        private void label_SQL_Click(object sender, EventArgs e)
        {
            ChangePanel(ENUMPanel.PANEL_SQL_CLIENT);
        }

        private void label_Services_Click(object sender, EventArgs e)
        {
            ChangePanel(ENUMPanel.PANEL_SERVICES_HANDLER);
        }

        private void label_Actions_Click(object sender, EventArgs e)
        {
            ChangePanel(ENUMPanel.PANEL_ACTION_HANDLER);
        }

        private void ChangePanel(ENUMPanel panel)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(panel);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowLoginForm();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
            DisableLeftMenu();
            ShowLoginForm();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logout();
            this.Close();
        }

        private void Logout()
        {
            configManager.SaveConfiguration();
            configManager.GetConnectionChannel.LogoutSession(configManager.clientRuntimeInfo.sessionID);
            configManager.CloseConnectionChannel();
        }

        private void PMAClientUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout();
            this.Close();
        }
      
        
        
    }
}
