﻿using System;
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
    }
}
