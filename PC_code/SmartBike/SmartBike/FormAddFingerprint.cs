using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace SmartBike
{
    public partial class FormAddFingerprint : Form
    {
        public LockMyBike LockMyBike;
        public int selectedIndex;
        public FormAddFingerprint(LockMyBike lockMyBike)
        {
            LockMyBike = lockMyBike;
            lockMyBike.serial.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            this.FormClosed += new FormClosedEventHandler(FormAddFingerprint_FormClosed);
            LockMyBike.serial.Connect();
            InitializeComponent();
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            LockMyBike.AddingFingerprintStatus status = LockMyBike.GetAddingFingerprintStatus();

            if (status == LockMyBike.AddingFingerprintStatus.FirstScanned) checkBoxFirst.Checked = true;

            else if (status == LockMyBike.AddingFingerprintStatus.SecondScanned) checkBoxSecond.Checked = true;

            else if (status == LockMyBike.AddingFingerprintStatus.Created)
            {
                checkBoxAdded.Checked = true;
                button.Enabled = true;
            }
            
            //string[] messages = LockMyBike.serial.ReadMessages();
            //if (messages != null && messages.Length != 0)
            //{
            //    foreach(string message in messages)
            //    {
            //        MessageBox.Show(message);
            //    }
            //}
        }
        void FormAddFingerprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            LockMyBike.serial.Disconnect();
        }

    }
}
