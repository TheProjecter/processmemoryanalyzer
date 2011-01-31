﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.Info;


namespace PMA.Client
{
    public partial class PMAClientUI : Form
    {
        public PMAClientUI()
        {
            InitializeComponent();
            OpenLoginWindow();
        }

        private void OpenLoginWindow()
        {
            LoginForm loginForm = new LoginForm();

            loginForm.Show();
        }
    }
}