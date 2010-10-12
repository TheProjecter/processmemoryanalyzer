using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.SystemAnalyzer;
using System.IO;

namespace PMASysAlertsUI
{
    public partial class PanelDriveController : UserControl
    {
        public PanelDriveController()
        {
            InitializeComponent();

            InitializeDrives();
        }

        private void InitializeDrives()
        {
            DriveInfo[] driveInfo = PMASystemAnalyzer.GetSystemDiscs();

            foreach (DriveInfo drive in driveInfo)
            {
                if (drive.DriveType == DriveType.Fixed)
                {
                    checkedListBox_Drives.Items.Add(drive.Name);
                }
            }
        }

        private void numericUpDown_DriveUse_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_DriveUse.Value > 100)
            {
                numericUpDown_DriveUse.Value = 99;
            }
        }

    }
}
