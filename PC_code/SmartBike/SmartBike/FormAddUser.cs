﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBike
{
    public partial class FormAddUser : Form
    {
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string PassWord { get; private set; }
        public bool IsOwner { get; private set; }
        public FormAddUser()
        {
            InitializeComponent();
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            Name = textBoxName.Text;
            UserName = textBoxUserName.Text;
            UserName = textBoxUserName.Text;
            PassWord = textBoxPassword.Text;
            IsOwner = checkBoxIsOwner.Checked;

            if ((Name != "" &&
                UserName != "" &&
                PassWord != "") &&
                PassWord == textBoxConfirmPassword.Text) buttonCreate.Enabled = true;

            else buttonCreate.Enabled = false;
        }
    }
}
