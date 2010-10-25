using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Utils.ftp;
using PMA.Utils.smtp;
using PMA.SystemAnalyzer;

namespace PMASysAlertsUI
{
    
        
    public partial class PMASysAlertsUI : Form
    {

               
        ENUMPanel PANEL;
        
        PMAConfigManager configManager = null;
        
        #region Panels Declaration 
        PanelDriveController panelDriveController = null;
        PanelPhyMemWatcher panelPhyMemController = null;
        PanelServiceWatcher panelServiceWatcher = null;
        PanelDatabaseOptimizer panelDatabaseOptimizer = null;
        PanelTransportController panelTransportController = null;
        PanelSMTPSettings panelSMTPSettings = null;
        PanelFTPSettings panelFTPSettings = null;
        PanelHome panelHome = null;
        #endregion


        private bool CauseValidation()
        {
            bool result = false;
            switch (PANEL)
            {
                case ENUMPanel.PANEL_DATABASE_OPTIMIZER:
                    result = panelDatabaseOptimizer.CauseValidation();
                    break;
                case ENUMPanel.PANEL_DRIVE_CONTROLLER:
                    result = panelDriveController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_FTP_SETTINGS:
                    result = panelFTPSettings.CauseValidation();
                    break;
                case ENUMPanel.PANEL_HOME:
                    result = panelHome.CauseValidation();
                    break;
                case ENUMPanel.PANEL_PHY_MEM_WATCHER:
                    result = panelPhyMemController.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SERVICE_WATCHER:
                    result = panelServiceWatcher.CauseValidation();
                    break;
                case ENUMPanel.PANEL_SMTP_SETTINGS:
                    result = panelSMTPSettings.CauseValidation();
                    break;
                case ENUMPanel.PANEL_TRANSPORT_CONTROLLER:
                    result = panelTransportController.CauseValidation();
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
                case ENUMPanel.PANEL_DATABASE_OPTIMIZER:
                    panelDatabaseOptimizer.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_DRIVE_CONTROLLER:
                    panelDriveController.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_FTP_SETTINGS:
                    panelFTPSettings.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_HOME:
                    panelHome.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_PHY_MEM_WATCHER:
                    panelPhyMemController.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SERVICE_WATCHER:
                    panelServiceWatcher.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_SMTP_SETTINGS:
                    panelSMTPSettings.UpdateConfig();
                    break;
                case ENUMPanel.PANEL_TRANSPORT_CONTROLLER:
                    panelTransportController.UpdateConfig();
                    break;
            }

        }

        private void ShowPanel(ENUMPanel enumPanel)
        {
            PANEL = enumPanel;
            switch (enumPanel)
            {
                case ENUMPanel.PANEL_DATABASE_OPTIMIZER:
                    HideAllControls();
                    panelDatabaseOptimizer.Show();
                    break;
                case ENUMPanel.PANEL_DRIVE_CONTROLLER:
                    HideAllControls();
                    panelDriveController.Show();
                    break;
                case ENUMPanel.PANEL_FTP_SETTINGS:
                    HideAllControls();
                    panelFTPSettings.Show();
                    break;
                case ENUMPanel.PANEL_HOME:
                    HideAllControls();
                    panelHome.Show();
                    break;
                case ENUMPanel.PANEL_PHY_MEM_WATCHER:
                    HideAllControls();
                    panelPhyMemController.Show();
                    break;
                case ENUMPanel.PANEL_SERVICE_WATCHER:
                    HideAllControls();
                    panelServiceWatcher.Show();
                    break;
                case ENUMPanel.PANEL_SMTP_SETTINGS:
                    HideAllControls();
                    panelSMTPSettings.Show();
                    break;
                case ENUMPanel.PANEL_TRANSPORT_CONTROLLER:
                    HideAllControls();
                    panelTransportController.Show();
                    break;
            }

        }


        #region Initilize Form

        public PMASysAlertsUI()
        {
            InitializeComponent();
            InitializeAllPanels();
            ShowPanel(ENUMPanel.PANEL_HOME);
            configManager = PMAConfigManager.GetConfigManagerInstance;
        }

        

        private void InitializeAllPanels()
        {
            panelHome = new PanelHome();
            panel_MainContainer.Controls.Add(panelHome);
            
            panelDriveController = new PanelDriveController();
            panel_MainContainer.Controls.Add(panelDriveController);

            panelPhyMemController = new PanelPhyMemWatcher();
            panel_MainContainer.Controls.Add(panelPhyMemController);

            panelServiceWatcher = new PanelServiceWatcher();
            panel_MainContainer.Controls.Add(panelServiceWatcher);

            panelDatabaseOptimizer = new PanelDatabaseOptimizer();
            panel_MainContainer.Controls.Add(panelDatabaseOptimizer);

            panelTransportController = new PanelTransportController();
            panel_MainContainer.Controls.Add(panelTransportController);

            panelSMTPSettings = new PanelSMTPSettings();
            panel_MainContainer.Controls.Add(panelSMTPSettings);

            panelFTPSettings = new PanelFTPSettings();
            panel_MainContainer.Controls.Add(panelFTPSettings);

            HideAllControls();

            LoadConfigs();

            ChangeCursorStyle();
        }

        private void LoadConfigs()
        {
            panelHome.UpdateUI();
            panelDriveController.UpdateUI();
            panelPhyMemController.UpdateUI();
            panelServiceWatcher.UpdateUI();
            panelDatabaseOptimizer.UpdateUI();
            panelTransportController.UpdateUI();
            panelSMTPSettings.UpdateUI();
            panelFTPSettings.UpdateUI();
        }


       
        private void HideAllControls()
        {
            foreach (Control control in panel_MainContainer.Controls)
            {
                control.Hide();
            }
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

        #endregion

        #region Butten Events
        

        
        private void label_Home_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_HOME);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }

        private void label_Drives_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_DRIVE_CONTROLLER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }
        }

        private void label_Service_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_SERVICE_WATCHER);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void label_PhysicalMemory_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_PHY_MEM_WATCHER);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void label_DatabaseOptimizer_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_DATABASE_OPTIMIZER);
            }
            else
            {
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
            }

        }

        private void label_Transport_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_TRANSPORT_CONTROLLER);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void sMTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_SMTP_SETTINGS);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CauseValidation())
            {
                UpdateConfig(PANEL);
                ShowPanel(ENUMPanel.PANEL_FTP_SETTINGS);
            }
            else
                MessageBox.Show(this, configManager.GetConsolidatedError("Error"));
        }
        #endregion

        private void stopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            Environment.Exit(0);
        }

        private void PMASysAlertsUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
        }

        
        private void startServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            MessageBox.Show(PMASystemAnalyzer.StartService());

        }

        private void stopServiceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateConfig(PANEL);
            configManager.SaveConfiguration();
            MessageBox.Show(PMASystemAnalyzer.StopService());
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AboutBoxPMAAlerts aboutBox = new AboutBoxPMAAlerts();
            aboutBox.Show(this);
        }


    }
}
