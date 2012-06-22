using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PMA.ConfigManager;

namespace PMASysAlertsUI
{
    public partial class PanelActionController : UserControl, IUIManager
    {

        private PMAConfigManager configManager = PMAConfigManager.GetConfigManagerInstance;
        
        public PanelActionController()
        {
            InitializeComponent();

            listBox_AvailableAction.SelectionMode = SelectionMode.MultiExtended;
            listBox_AvailableAction.ContextMenu = new ContextMenu();
            listBox_AvailableAction.ContextMenu.MenuItems.Add("Remove");
            listBox_AvailableAction.ContextMenu.Popup += new EventHandler(contextMenu_OpenPopup_Click);
            listBox_AvailableAction.ContextMenu.MenuItems[0].Click += new EventHandler(contextMenu_Item_Click);
        }

        private void contextMenu_OpenPopup_Click(object sender, EventArgs e)
        {
            if (listBox_AvailableAction.SelectedItems.Count == 0)
            {
                listBox_AvailableAction.ContextMenu.MenuItems[0].Visible = false;
            }
            else
            {
                listBox_AvailableAction.ContextMenu.MenuItems[0].Visible = true;
            }
        }

        private void contextMenu_Item_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem();
        }

        private void RemoveSelectedItem()
        {
            while (listBox_AvailableAction.SelectedItems.Count > 0)
            {
                listBox_AvailableAction.Items.Remove(listBox_AvailableAction.SelectedItem);
            }
        }

        private void button_RemoveItem_Click(object sender, EventArgs e)
        {
            listBox_AvailableAction.Items.Remove(sender);
        }

        private void button_AddAction_Click(object sender, EventArgs e)
        {
            if (listBox_AvailableAction.Items.Contains(richTextBox_Action.Text))
            {
                MessageBox.Show(this,richTextBox_Action.Text + " Action already exists", "Action already exists");
            }
            else
            {
                listBox_AvailableAction.Items.Add(richTextBox_Action.Text);
                richTextBox_Action.Clear();
            }
           
        }

        private void button_Remove_Click(object sender, EventArgs e)
        {
            RemoveSelectedItem();
        }


        #region IUIManager Members

        public void UpdateUI()
        {
            foreach (string actionString in configManager.PMAServerManagerInfo.ListActions)
            {
                listBox_AvailableAction.Items.Add(actionString);
            }
        }

        public void UpdateConfig()
        {
            configManager.PMAServerManagerInfo.ListActions.Clear();
            for (int count = 0; count < listBox_AvailableAction.Items.Count; count++)
            {
                configManager.PMAServerManagerInfo.ListActions.Add(listBox_AvailableAction.Items[count].ToString());
            }
        }

        public bool CauseValidation()
        {
            return true;
        }

        #endregion
       
    }
}
