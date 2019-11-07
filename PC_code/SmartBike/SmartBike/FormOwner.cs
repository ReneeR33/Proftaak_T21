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

        Serial serial = new Serial("COM3", 9600, new MessageBuilder('#', '%'));
        public FormOwner(LockMyBike LMB)
        {
            //serial.Connect();
            lockMyBike = LMB;
            this.FormClosed += new FormClosedEventHandler(FormOwner_FormClosed);
            InitializeComponent();
            label1.Text = lockMyBike.UserLoggedIn.Name;

        }
        
        void FormOwner_FormClosed(object sender, FormClosedEventArgs e)
        {
            //serial.Disconnect();
            Application.Exit();
        }

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                serial.SendMessage("LOCK_OPEN");
            }
            else if(checkBox1.Checked == false)
            {
                serial.SendMessage("LOCK_CLOSE");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string[] messages = serial.ReadMessages();
            if (messages != null && messages.Length != 0)
            {
                foreach (string message in messages)
                {
                    if (message == "")
                    {
                        //
                    }
                    else if(message == "")
                    {

                    }
                    else if (message == "")
                    {
                        //
                    }
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Database database = new Database();
            //users = database.GetUsers();
            //listBox1.DataSource = users;
        }
    }
}
