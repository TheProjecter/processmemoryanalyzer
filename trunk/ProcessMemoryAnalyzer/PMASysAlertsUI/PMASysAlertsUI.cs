using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMASysAlertsUI
{
    public partial class PMASysAlertsUI : Form
    {
        
        //Panels
        PanelDriveController panelDriveController = null;
        PanelPhyMemController panelPhyMemController = null;
        PanelServiceWatcher panelServiceWatcher = null;
        PanelDatabaseOptimizer panelDatabaseOptimizer = null;
        PanelTransportController panelTransportController = null;
        PanelSMTPSettings panelSMTPSettings = null;
        PanelFTPSettings panelFTPSettings = null;
        PanelHome panelHome = null;

        private void ShowPanelHome()
        {
            HideAllControls();
            panelHome.Show();
        }


        private void ShowPanelDriveController()
        {
            HideAllControls();
            panelDriveController.Show();
        }

        private void ShowPanelPhyMemController()
        {
            HideAllControls();
            panelPhyMemController.Show();
        }

        private void ShowPanelServiceWatcher()
        {
            HideAllControls();
            panelServiceWatcher.Show();
        }

        private void ShowPanelDatabaseOptimizer()
        {
            HideAllControls();
            panelDatabaseOptimizer.Show();
        }

        private void ShowPanelTransportController()
        {
            HideAllControls();
            panelTransportController.Show();
        }

        private void ShowPanelSMTPSettings()
        {
            HideAllControls();
            panelSMTPSettings.Show();
        }

        private void ShowPanelFTPSettings()
        {
            HideAllControls();
            panelFTPSettings.Show();
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
        
        
        public PMASysAlertsUI()
        {
            InitializeComponent();
            InitializeAllPanels();

            ShowPanelHome();
        }

        private void InitializeAllPanels()
        {
            panelHome = new PanelHome();
            panel_MainContainer.Controls.Add(panelHome);
            
            panelDriveController = new PanelDriveController();
            panel_MainContainer.Controls.Add(panelDriveController);

            panelPhyMemController = new PanelPhyMemController();
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

            ChangeCursorStyle();
        }

       

        private void stopServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label_Home_Click(object sender, EventArgs e)
        {
            ShowPanelHome();
        }

        private void label_Drives_Click(object sender, EventArgs e)
        {
            ShowPanelDriveController();
        }

        private void label_Service_Click(object sender, EventArgs e)
        {
            ShowPanelServiceWatcher();
        }

        private void label_PhysicalMemory_Click(object sender, EventArgs e)
        {
            ShowPanelPhyMemController();
        }

        private void label_DatabaseOptimizer_Click(object sender, EventArgs e)
        {
            ShowPanelDatabaseOptimizer();
        }

        private void label_Transport_Click(object sender, EventArgs e)
        {
            ShowPanelTransportController();
        }

        private void sMTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelSMTPSettings();
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPanelFTPSettings();
        }



        

        

        


        
    }
}
