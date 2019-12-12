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
        private delegate void SafeCallDelegate(bool enabled);
        private delegate void SafeCallDelegateCheckbox(CheckBox checkBox, bool checkBoxChecked);

        public LockMyBike LockMyBike;
        public int selectedIndex;
        public FormAddFingerprint(LockMyBike lockMyBike)
        {
            LockMyBike = lockMyBike;
            lockMyBike.serial.serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            this.FormClosed += new FormClosedEventHandler(FormAddFingerprint_FormClosed);
            LockMyBike.serial.Connect();
            InitializeComponent();
            button.Enabled = false;
            LockMyBike.serial.SendMessage("STATE:ADD_FINGERPRINT");
        }
        private void ChangeButtonEnabledSafe(bool enabled)
        {
            if (button.InvokeRequired)
            {
                var d = new SafeCallDelegate(ChangeButtonEnabledSafe);
                button.Invoke(d, new object[] { enabled });
            }
            else
            {
                button.Enabled = enabled;
            }
        }
        private void ChangeCheckboxCheckedSafe(CheckBox checkBox, bool checkBoxChecked)
        {
            if (button.InvokeRequired)
            {
                var d = new SafeCallDelegateCheckbox(ChangeCheckboxCheckedSafe);
                checkBox.Invoke(d, new object[] { checkBox, checkBoxChecked });
            }
            else
            {
                checkBox.Checked = checkBoxChecked;
            }
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            LockMyBike.AddingFingerprintStatus status = LockMyBike.GetAddingFingerprintStatus();

            if (status == LockMyBike.AddingFingerprintStatus.FirstScanned) ChangeCheckboxCheckedSafe(checkBoxFirst, true);

            else if (status == LockMyBike.AddingFingerprintStatus.SecondScanned) ChangeCheckboxCheckedSafe(checkBoxSecond, true);

            else if (status == LockMyBike.AddingFingerprintStatus.Created)
            {
                ChangeCheckboxCheckedSafe(checkBoxAdded, true);
                MessageBox.Show("added");
                ChangeButtonEnabledSafe(true);
            }

            //string[] messages = LockMyBike.serial.ReadMessages();
            //if (messages != null && messages.Length != 0)
            //{
            //    foreach (string message in messages)
            //    {
            //        string lastAddedString = "";
            //        MessageBox.Show(message);
            //        if (message.StartsWith("ADDED_FINGERPRINT:"))
            //            lastAddedString = message.Replace("ADDED_FINGERPRINT:", "");
            //        int lastAdded;
            //        if (Int32.TryParse(lastAddedString, out lastAdded))
            //        {
            //            MessageBox.Show("parsed");
            //            LockMyBike.LastAddedFingerprintID = lastAdded;
            //        }
            //        ChangeButtonEnabledSafe(true);
            //    }
            //}
        }
        void FormAddFingerprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            LockMyBike.serial.Disconnect();
        }

        
    }
}
