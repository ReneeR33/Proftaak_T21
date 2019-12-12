using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBike
{
    public partial class FormOwner : Form
    {
        private LockMyBike lockMyBike;

        public FormOwner(LockMyBike LMB)
        {
            lockMyBike = LMB;
            this.FormClosed += new FormClosedEventHandler(FormOwner_FormClosed);
            InitializeComponent();
            listBoxUsers.DataSource = lockMyBike.Users;
            label1.Text = lockMyBike.UserLoggedIn.Name;

        }
        
        void FormOwner_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            //if(checkBox1.Checked == true)
            //{
            //    serial.SendMessage("LOCK_OPEN");
            //}
            //else if(checkBox1.Checked == false)
            //{
            //    serial.SendMessage("LOCK_CLOSE");
            //}
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //niet nodig
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Database database = new Database();
            //users = database.GetUsers();
            //listBox1.DataSource = users;
        }

        private void ButtonLock_Click(object sender, EventArgs e)
        {
            lockMyBike.OpenLock();
        }
        private void ButtonAddUser_Click(object sender, EventArgs e)
        {
            FormAddUser formAddUser = new FormAddUser();
            DialogResult result = formAddUser.ShowDialog();

            if(result == DialogResult.OK)
            {
                User user = new User(formAddUser.Name, formAddUser.UserName, formAddUser.PassWord, -1, formAddUser.IsOwner);
                lockMyBike.AddUser(user);
                listBoxUsers.DataSource = null;
                listBoxUsers.DataSource = lockMyBike.Users; 
            }
        }

        private void ButtonRemoveUser_Click(object sender, EventArgs e)
        {
            if(listBoxUsers.SelectedIndex > -1)
            {
                User selectedUser = lockMyBike.Users[listBoxUsers.SelectedIndex];
                if(selectedUser.ID == lockMyBike.UserLoggedIn.ID)
                {
                    MessageBox.Show("You cannot delete your own account");
                }
                else
                {
                    lockMyBike.RemoveUser(selectedUser);
                    listBoxUsers.DataSource = null; listBoxUsers.DataSource = lockMyBike.Users;
                    MessageBox.Show("Deleted");
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            lockMyBike.Test();
        }

        private void ListBoxUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBoxUsers.SelectedIndex > -1)
            {
                User selectedUser = lockMyBike.Users[listBoxUsers.SelectedIndex];
                if (selectedUser.FingerID == -1) buttonAddFingerprint.Enabled = true;
                else buttonAddFingerprint.Enabled = false;
            }
            else buttonAddFingerprint.Enabled = false;
        }

        private void ButtonAddFingerprint_Click(object sender, EventArgs e)
        {
            FormAddFingerprint  formAddFingerprint = new FormAddFingerprint(lockMyBike);
            DialogResult result = formAddFingerprint.ShowDialog();
            
        }
    }
}
