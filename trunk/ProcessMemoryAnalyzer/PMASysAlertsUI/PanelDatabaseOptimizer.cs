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
    public partial class PanelDatabaseOptimizer : UserControl
    {
        public PanelDatabaseOptimizer()
        {
            InitializeComponent();
            checkBox_IsWebServer.Checked = false;
            ToggleTextControls(false);
        }

        private void ToggleTextControls(bool enableControls)
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    TextBox tb = control as TextBox;
                    tb.Enabled = enableControls;
                }
            }
        }

        private void checkBox_IsWebServer_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_IsWebServer.Checked)
            {
                ToggleTextControls(true);
            }
            else
            {
                ToggleTextControls(false);
            }
        }
    }
}
