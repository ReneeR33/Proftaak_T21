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
    public partial class Form1 : Form
    {
        Serial serial = new Serial("COM3", 9600, new MessageBuilder('#', '%'));
        public Form1()
        {
            serial.Connect();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            InitializeComponent();
        }
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serial.Disconnect();
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
    }
}
