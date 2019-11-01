 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toets2App
{
    public partial class Form1 : Form
    {
        Serial serial = new Serial("COM3", 9600, new MessageBuilder('|', '~'));
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

        private void buttonManual_Click(object sender, EventArgs e)
        {
            serial.SendMessage("SET_MODE:MANUAL");
        }

        private void buttonAutomatic_Click(object sender, EventArgs e)
        {
            serial.SendMessage("SET_MODE:AUTOMATIC");
        }

        private void buttonSignalling_Click(object sender, EventArgs e)
        {
            serial.SendMessage("SET_MODE:SIGNALLING");
        }
        private void button1_Click(object sender, EventArgs e)
        {
            serial.SendMessage("SET_MODE:CALAMITY");
        }

        private void buttonGreen1_Click(object sender, EventArgs e)
        {
            serial.SendMessage("SET_LANE:LEFT");
        }

        private void buttonGreen2_Click(object sender, EventArgs e)
        {
            serial.SendMessage("SET_LANE:RIGHT");
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            string[] messages = serial.ReadMessages();
            if (messages != null && messages.Length != 0)
            {
                foreach (string message in messages)
                {
                    if (message == "LANE1:RED")
                    {
                        pictureBox1.Image = Toets2App.Properties.Resources.stoplichten_rood;
                    }
                    else if (message == "LANE1:ORANGE")
                    {
                        pictureBox1.Image = Toets2App.Properties.Resources.stoplichten_oranje;
                    }
                    else if (message == "LANE1:GREEN")
                    {
                        pictureBox1.Image = Toets2App.Properties.Resources.stoplichten_groen;
                    }
                    else if (message == "LANE2:RED")
                    {
                        pictureBox2.Image = Toets2App.Properties.Resources.stoplichten_rood;
                    }
                    else if (message == "LANE2:ORANGE")
                    {
                        pictureBox2.Image = Toets2App.Properties.Resources.stoplichten_oranje;
                    }
                    else if (message == "LANE2:GREEN")
                    {
                        pictureBox2.Image = Toets2App.Properties.Resources.stoplichten_groen;
                    }

                    else if (message.StartsWith("MODE:"))
                    {
                        labelCurrentMode.Text = message.Replace("MODE:", "");
                    }

                   
                    else if (message.StartsWith("CARSONLANE:"))
                    {
                        labelAmountOfCars1.Text = message.Replace("CARSONLANE:", "");
                    }
                    else if (message.StartsWith("GREENTIME:"))
                    {
                        labelTime1.Text = message.Replace("GREENTIME:", "") + "  seconds";
                    }
                    else if (message.StartsWith("CARSLEFT:"))
                    {
                        labelCarsRemaining.Text = message.Replace("CARSLEFT:", "");
                    }

                }
            }
            bool isAutomatic = labelCurrentMode.Text == "AUTOMATIC";
            bool isManual = labelCurrentMode.Text == "MANUAL";

            labelAmountOfCars1.Visible = isAutomatic;
            labelTime1.Visible = isAutomatic;
            labelCarsRemaining.Visible = isAutomatic;
            label3.Visible = isAutomatic;
            label4.Visible = isAutomatic;
            label7.Visible = isAutomatic;
            buttonGreen1.Visible = isManual;
            buttonGreen2.Visible = isManual;
          

        }

    }
}
