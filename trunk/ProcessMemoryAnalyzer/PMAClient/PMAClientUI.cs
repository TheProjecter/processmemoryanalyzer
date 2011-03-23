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
using PMA.CommunicationAPI;


namespace PMA.Client
{
    public partial class PMAClientUI : Form
    {

        ENUMPanel PANEL;

        PMAClientConfigManager configManager = PMAClientConfigManager.GetClientConfigurationInstance;

        PanelExecuteCommand panelExecuteCommand = null;
        PanelSQLClient panelSQLClient = null;
        PanelServicesHandler panelServiceHandler = null;
        PanelTaskManager panelTaskManager = null;
        PanelDateTime panelDateTime = null;

        string sessionID;

        IPMACommunicationContract proxy;

        System.Timers.Timer timer;

        LoginForm loginForm;

        delegate void ServerClock();

        ServerClock serverClock;

        private bool CauseValidation()
        {
            bool result = false;
            configManager.ErrorMessage.Clear();
            switch (PANEL)
            {
                case ENUMPanel.PANEL_ACTION_HANDLER:
                    result = panelExecuteCommand.ChangeView();
                    break;
                case ENUMPanel.PANEL_SERVICES_HANDLER:
                    result = panelServiceHandler.ChangeView();
                    break;
                case ENUMPanel.PANEL_SQL_CLIENT:
                    result = panelSQLClient.ChangeView();
                    break;
                case ENUMPanel.PANEL_TASK_MANAGER:
                    result = panelTaskManager.ChangeView();
                    break;
                case ENUMPanel.PANEL_DATE_TIME:
                    result = panelDateTime.ChangeView();
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
                case ENUMPanel.PANEL_TASK_MANAGER:
                    panelTaskManager.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_DATE_TIME :
                    panelDateTime.UpdateConfig();
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
                case ENUMPanel.PANEL_TASK_MANAGER:
                    HideAllControls();
                    panelTaskManager.Show();
                    break;
                case ENUMPanel.PANEL_DATE_TIME :
                    HideAllControls();
                    panelDateTime.Show();
                    break;
            }

        }

        
        private void SetAccessibilityForUser()
        {
            if (configManager.clientRuntimeInfo.UserInfo != null)
            {
                label_Actions.Enabled = configManager.clientRuntimeInfo.UserInfo.IsActionUser;
                label_DateTime.Enabled = configManager.clientRuntimeInfo.UserInfo.IsActionUser;
                label_Services.Enabled = configManager.clientRuntimeInfo.UserInfo.IsServiceUser;
                label_SQL.Enabled = configManager.clientRuntimeInfo.UserInfo.IsSQLUser;
                label_TaskManager.Enabled = true;
            }
        }

      
        
        public PMAClientUI()
        {
            InitializeComponent();
        }

        private void InitializeServerClock()
        {
            GetDateTime();
            serverClock = new ServerClock(GetDateTime);
            timer = new System.Timers.Timer();
            timer.Interval = 10000;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Start();
        }

      

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            label_DateTime.Invoke(serverClock);
        }

        private void GetDateTime()
        {
            DateTime dateTime = proxy.GetServerDateTime(sessionID);
            label_DateTime.Text = " " + dateTime.ToShortTimeString() + "\r\n" + dateTime.ToShortDateString();
        }


        private void InitilizeUI()
        {
            proxy = configManager.GetConnectionChannel;
            sessionID = configManager.clientRuntimeInfo.sessionID;
            InitializeAllPanels();
            HideAllControls();
            LoadConfigs();
            ChangeCursorStyle();
            DisableLeftMenu();
            SetAccessibilityForUser();
            InitializeServerClock();
            ShowPanel(ENUMPanel.PANEL_TASK_MANAGER);
        }

        private void InitializeAllPanels()
        {
            panelExecuteCommand = new PanelExecuteCommand();
            panel_MainContainer.Controls.Add(panelExecuteCommand);

            panelSQLClient = new PanelSQLClient();
            panel_MainContainer.Controls.Add(panelSQLClient);

            panelServiceHandler = new PanelServicesHandler();
            panel_MainContainer.Controls.Add(panelServiceHandler);

            panelTaskManager = new PanelTaskManager();
            panel_MainContainer.Controls.Add(panelTaskManager);

            panelDateTime = new PanelDateTime();
            panel_MainContainer.Controls.Add(panelDateTime);
        }

        private void LoadConfigs()
        {
            panelServiceHandler.UpdateUI();
            panelExecuteCommand.UpdateUI();
            panelSQLClient.UpdateUI();
            panelTaskManager.UpdateUI();
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

        private void label_TaskManager_Click(object sender, EventArgs e)
        {
            ChangePanel(ENUMPanel.PANEL_TASK_MANAGER);
        }

        private void label_DateTime_Click(object sender, EventArgs e)
        {
            ChangePanel(ENUMPanel.PANEL_DATE_TIME);
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
            this.Close();
        }

        private void Logout()
        {
            if (configManager.GetConnectionChannel != null)
            {
                configManager.GetConnectionChannel.LogoutSession(configManager.clientRuntimeInfo.sessionID);
                configManager.CloseConnectionChannel();
                configManager.SaveConfiguration();
            }
        }

       
        private void PMAClientUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            Logout();
        }

        

          
        
        
    }
}
