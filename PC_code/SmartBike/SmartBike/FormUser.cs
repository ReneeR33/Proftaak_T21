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
    public partial class FormUser : Form
    {
        private LockMyBike lockMyBike;
        public FormUser(LockMyBike LMB)
        {
            lockMyBike = LMB;
            this.FormClosed += new FormClosedEventHandler(FormUser_FormClosed);
            InitializeComponent();
        }
        void FormUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

    }
}
