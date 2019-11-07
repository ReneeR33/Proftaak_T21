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
        }

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            if(lockMyBike.Login(textBoxUsername.Text, textBoxPassword.Text))
            {
                MessageBox.Show("Login success!");
                Form1 form1 = new Form1(lockMyBike);
                form1.Show();
                this.Hide();
            }
        }
    }
}
