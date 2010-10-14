﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMASysAlertsUI
{
    public partial class PanelPhyMemController : UserControl
    {
        public PanelPhyMemController()
        {
            InitializeComponent();
        }

        private void numericUpDown_PhyMemLimit_KeyUp(object sender, KeyEventArgs e)
        {
            if (numericUpDown_PhyMemLimit.Value > 100)
            {
                numericUpDown_PhyMemLimit.Value = 99;
            }
        }
    }
}