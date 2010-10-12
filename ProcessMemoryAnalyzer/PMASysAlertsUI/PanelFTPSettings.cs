using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMASysAlertsUI
{
    public partial class PanelFTPSettings : UserControl
    {
        public PanelFTPSettings()
        {
            InitializeComponent();
        }

        private void numericUpDown_port_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_port.Value > 65536)
            {
                numericUpDown_port.Value = 65535;
            }
        }
    }
}
