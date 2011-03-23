using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;
using PMA.Info;
using PMA.Utils;

namespace PMASysAlertsUI
{
    public partial class PanelUserControl : UserControl, IUIManager
    {

        PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        Form PasswordResetForm;
        TextBox textBox_NewPassword;


        Button button_ChangePassword;
        Button button_Cancel;

        private int rowIndex = 0;

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initializes a new instance of the <see cref="PanelUserControl"/> class.
        /// </summary>
        public PanelUserControl()
        {
            InitializeComponent();
            dataGridView_users.CellContentClick += new DataGridViewCellEventHandler(dataGridView_users_CellContentClick);
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the CellContentClick event of the dataGridView_users control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.DataGridViewCellEventArgs"/> instance containing the event data.</param>
        void dataGridView_users_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_users.Columns["Password"].Index == e.ColumnIndex)
            {
                ResetPassword(e.RowIndex);
            }
            else if (dataGridView_users.Columns["RemoveUser"].Index == e.ColumnIndex)
            {
                dataGridView_users.Rows.Remove(dataGridView_users.Rows[e.RowIndex]);
                UpdateConfig();
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Resets the password.
        /// </summary>
        /// <param name="rowIndex">Index of the row.</param>
        private void ResetPassword(int rowIndex)
        {

            this.rowIndex = rowIndex;
            
            PasswordResetForm = new Form();

            PasswordResetForm.Size = new Size(220, 100);

            Panel panel = new Panel { Size = new Size(218, 98) };

            PasswordResetForm.Controls.Add(panel);
            Label label = new Label { Text = "New Password :", Anchor = (AnchorStyles.Left | AnchorStyles.Top), Location = new Point(3, 4) };
            textBox_NewPassword = new TextBox { Anchor = (AnchorStyles.Top | AnchorStyles.Right),Location = new Point(100,4), PasswordChar = '*' };
            button_ChangePassword = new Button { Text = "Change", Anchor = (AnchorStyles.Bottom | AnchorStyles.Right), Location = new Point(130, 40) };
            button_Cancel = new Button { Text = "Cancel", Anchor = (AnchorStyles.Bottom | AnchorStyles.Left), Location = new Point(50, 40) };

            PasswordResetForm.Text = "Reset Password";

            panel.Controls.Add(label);
            panel.Controls.Add(this.textBox_NewPassword);
            panel.Controls.Add(button_Cancel);
            panel.Controls.Add(button_ChangePassword);

            button_Cancel.Click += new EventHandler(button_Cancel_Click);
            button_ChangePassword.Click += new EventHandler(button_ChangePassword_Click);

            PasswordResetForm.ShowDialog(this);
           

        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the button_ChangePassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button_ChangePassword_Click(object sender, EventArgs e)
        {
            dataGridView_users.Rows[rowIndex].Cells["PasswordString"].Value = OperationUtils.EncodePasswordToMD5(textBox_NewPassword.Text);
            PasswordResetForm.Close();
            PasswordResetForm.Dispose();
            MessageBox.Show("Password is changed for user " + dataGridView_users.Rows[rowIndex].Cells["User"].Value.ToString());
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the button_Cancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button_Cancel_Click(object sender, EventArgs e)
        {
            PasswordResetForm.Close();
            PasswordResetForm.Dispose();
        }


        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Handles the Click event of the button_Add control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void button_Add_Click(object sender, EventArgs e)
        {
            bool isCheckedBox = false;
            foreach (Control ctrl in this.Controls)
            {
                if ((ctrl is CheckBox) && (ctrl as CheckBox).Checked) 
                {
                    isCheckedBox = true;
                    break;
                }
            }
            if (textBox_User.Text != string.Empty && textBox_Password.Text != string.Empty && isCheckedBox && !IsUserAlreadyExist(textBox_User.Text))
            {
                DataGridViewRow row = dataGridView_users.Rows[dataGridView_users.Rows.Add()];
                row.Cells["User"].Value = textBox_User.Text;
                row.Cells["PasswordString"].Value = OperationUtils.EncodePasswordToMD5(textBox_Password.Text);
                row.Cells["SQL"].Value = checkBox_SQL.Checked;
                row.Cells["Action"].Value = checkBox_Action.Checked;
                row.Cells["Services"].Value = checkBox_Services.Checked;
                row.Cells["TaskManagerAdmin"].Value = checkBox_TaskManagerAdmin.Checked;
                row.Cells["Password"].Value = "Reset";
                row.Cells["RemoveUser"].Value = "Remove";
                UpdateConfig();
            }
            else
            {
                StringBuilder message = new StringBuilder();
                if (!isCheckedBox)
                {
                    message.AppendLine("Please select one feature for admin");
                }
                else if(IsUserAlreadyExist(textBox_User.Text))
                {
                    message.AppendLine("User Already exist");
                }
                else message.AppendLine("Please provide valid credentials");

                MessageBox.Show(this,message.ToString());
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Determines whether [is user already exist] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <returns>
        /// 	<c>true</c> if [is user already exist] [the specified user name]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsUserAlreadyExist(string userName)
        {
            int count = (from userinfo in configManager.PMAUsers.ListPMAUserInfo
                         where userinfo.UserName == userName
                         select userinfo).ToList<PMAUserInfo>().Count;
            if (count > 0)
            {
                return true;
            }
            else return false;
        }


        #region IUIManager Members

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the UI.
        /// </summary>
        public void UpdateUI()
        {
            dataGridView_users.Rows.Clear();
            foreach (PMAUserInfo userInfo in configManager.PMAUsers.ListPMAUserInfo)
            {
                DataGridViewRow row = dataGridView_users.Rows[dataGridView_users.Rows.Add()];
                row.Cells["User"].Value = userInfo.UserName;
                row.Cells["PasswordString"].Value = userInfo.UserPassword;
                row.Cells["SQL"].Value = userInfo.IsSQLUser;
                row.Cells["Action"].Value = userInfo.IsActionUser;
                row.Cells["Services"].Value = userInfo.IsServiceUser;
                row.Cells["TaskManagerAdmin"].Value = userInfo.IsTaskManagerAdminUser;
                row.Cells["Password"].Value = "Reset";
                row.Cells["RemoveUser"].Value = "Remove";
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Updates the config.
        /// </summary>
        public void UpdateConfig()
        {
            PMAUserInfo userInfo = null;
            configManager.PMAUsers.ListPMAUserInfo.Clear();
            foreach (DataGridViewRow row in dataGridView_users.Rows)
            {
                userInfo = new PMAUserInfo();
                userInfo.UserName = row.Cells["User"].Value.ToString();
                userInfo.UserPassword = row.Cells["PasswordString"].Value.ToString();
                userInfo.IsActionUser = bool.Parse( row.Cells["Action"].Value.ToString());
                userInfo.IsServiceUser = bool.Parse(row.Cells["Services"].Value.ToString());
                userInfo.IsSQLUser = bool.Parse(row.Cells["SQL"].Value.ToString());
                userInfo.IsTaskManagerAdminUser = bool.Parse(row.Cells["TaskManagerAdmin"].Value.ToString());
                configManager.PMAUsers.ListPMAUserInfo.Add(userInfo);               
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Causes the validation.
        /// </summary>
        /// <returns></returns>
        public bool CauseValidation()
        {
            return true;
        }

        #endregion
    }
}
