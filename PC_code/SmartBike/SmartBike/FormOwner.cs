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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;

namespace SmartBike
{
    public partial class FormOwner : Form
    {
        private bool exitProgramWhenClosed = true;
        private LockMyBike lockMyBike;

        public FormOwner(LockMyBike LMB)
        {
            lockMyBike = LMB;
            this.FormClosed += new FormClosedEventHandler(FormOwner_FormClosed);
            InitializeComponent();
            UpdateListBox();
            label1.Text = lockMyBike.UserLoggedIn.Name;
            setLocation();
        }
        
        private void FormOwner_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (exitProgramWhenClosed)
            {
                Application.Exit();
            }
        }

        private void UpdateListBox()
        {
            listBoxAccess.Items.Clear();
            listBoxUsers.Items.Clear();
            
            foreach(User user in lockMyBike.Users)
            {
                listBoxUsers.Items.Add(user);
                if (user.HasAccess)
                {
                    listBoxAccess.Items.Add(user);
                }
            }
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
            try
            {
                lockMyBike.serial.Connect();
            }
            catch
            {
                labelConnected.Text = "disconnected";
            }
            finally
            {
                lockMyBike.serial.Disconnect();
            }
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
                User user = new User(formAddUser.Name, formAddUser.UserName, formAddUser.PassWord, -1, formAddUser.IsOwner, false);
                lockMyBike.AddUser(user);
                UpdateListBox();
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

                if (!selectedUser.HasAccess && selectedUser.FingerID != -1) buttonGiveAccess.Enabled = true;
                else buttonGiveAccess.Enabled = false;
                
            }
            else buttonAddFingerprint.Enabled = false;
        }

        private void ButtonAddFingerprint_Click(object sender, EventArgs e)
        {
            User selectedUser = lockMyBike.Users[listBoxUsers.SelectedIndex];

            FormAddFingerprint  formAddFingerprint = new FormAddFingerprint(lockMyBike);
            DialogResult result = formAddFingerprint.ShowDialog();

            if(result == DialogResult.OK)
            {
                MessageBox.Show(lockMyBike.LastAddedFingerprintID.ToString());
                lockMyBike.UpdateFingerprint(selectedUser, lockMyBike.LastAddedFingerprintID);
                UpdateListBox();
            }
            
        }
        private void setLocation()
        {
            double lat = 51.452749;
            double lng = 5.482001;

            var point = new PointLatLng(lat, lng);
            Map.DragButton = MouseButtons.Left;
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Position = point;
            Map.MinZoom = 5;
            Map.MaxZoom = 20;
            Map.Zoom = 15;
            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
            GMapOverlay markers = new GMapOverlay("markers");
            markers.Markers.Add(marker);
            Map.Overlays.Add(markers);            
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("logged out owner");
            FormLogin login = new FormLogin(lockMyBike);
            login.Show();
            exitProgramWhenClosed = false;
            this.Close();
        }

        private void ButtonChangeData_Click(object sender, EventArgs e)
        {
            User selectedUser = lockMyBike.Users[listBoxUsers.SelectedIndex];
            FormAddUser formAddUser = new FormAddUser(selectedUser);
            DialogResult result = formAddUser.ShowDialog();
            
            if(result == DialogResult.OK)
            {
                lockMyBike.UpdateUser(selectedUser, formAddUser.Name, formAddUser.UserName, formAddUser.PassWord, formAddUser.IsOwner);
                UpdateListBox();
            }
            
        }

        private void ListBoxUsers_Click(object sender, EventArgs e)
        {
            listBoxAccess.SelectedIndex = -1;
        }

        private void ListBoxAccess_Click(object sender, EventArgs e)
        {
            listBoxUsers.SelectedIndex = -1;
        }
    }
}
