using System;
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
    public partial class FormLogin : Form
    {
        LockMyBike lockMyBike;
        
        public FormLogin()
        {
            lockMyBike = new LockMyBike();
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FormLogin_FormClosed);
        }
        public FormLogin(LockMyBike LMB)
        {
            lockMyBike = LMB;
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FormLogin_FormClosed);

        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(lockMyBike.Login(textBoxUsername.Text, textBoxPassword.Text))
            {
                MessageBox.Show("Login success!");
                if (lockMyBike.UserLoggedIn.IsOwner)
                {
                    MessageBox.Show("Logged in as owner");
                    FormOwner formOwner = new FormOwner(lockMyBike);
                    formOwner.Show();
                }
                else
                {
                    MessageBox.Show("Logged in as user");
                    FormUser formUser = new FormUser(lockMyBike);
                    formUser.Show();
                }
                this.Hide();
            }
        }
    }
}
