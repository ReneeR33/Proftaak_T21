using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Threading;

namespace SmartBike
{
    //Dit is de hoofdklasse voor ons programma
    public class LockMyBike
    {
        public enum AddingFingerprintStatus
        {
            FirstScanned,
            SecondScanned,
            Created,
            NotAddingFingerprint
        };

        public Serial serial { get; private set; }

        private Database database;
        public User UserLoggedIn { get; private set; }
        public List<User> Users { get; private set; }
        public int LastAddedFingerprintID { get; private set; }
        public LockMyBike()
        {
            serial = new Serial("COM3", 9600, new MessageBuilder('#', '%'));
            database = new Database();
            Users = database.GetUsers();
        }
        public bool Login(string userName, string password)
        {
            if(Users != null)
            {
                foreach (User user in Users)
                {
                    if (user.UserName == userName && user.Password == password)
                    {
                        UserLoggedIn = user;
                        return true;
                    }
                }

            }
            return false;
        }
        public AddingFingerprintStatus GetAddingFingerprintStatus()
        {
            AddingFingerprintStatus status = AddingFingerprintStatus.NotAddingFingerprint;
            string[] messages = serial.ReadMessages();
            if(messages != null)
            {
                if(messages != null && messages.Length > 0)
                {
                    foreach (string message in messages)
                    {
                        if (message == "FIRST_SCANNED") status = AddingFingerprintStatus.FirstScanned;
                        else if (message == "SECOND_SCANNED") status = AddingFingerprintStatus.SecondScanned;
                        else if (message.StartsWith("ADDED_FINGERPRINT:"))
                        {
                            status = AddingFingerprintStatus.Created;
                            message.Replace("ADDED_FINGERPRINT:", "");
                            int lastAdded;
                            if (Int32.TryParse(message, out lastAdded)) LastAddedFingerprintID = lastAdded;
                        }
                    }
                }
            }
            return status;
        }

        public void AddUser(User user)
        {
            database.addUser(user);
            Users = database.GetUsers();
        }
        
        public void RemoveUser(User user)
        {
            if(user != null)
            {
                bool deleted = false;
                if (user.FingerID != -1)
                {
                    serial.Connect();
                    serial.SendMessage("REMOVE_FINGERPRINT:" + user.FingerID.ToString());
                    Thread.Sleep(600);
                    string[] messages = serial.ReadMessages();
                    if(messages != null)
                    {
                        foreach (string message in messages)
                        {
                            if (message == "DELETION_SUCCESS")
                            {
                                deleted = true;
                            }
                        }
                    }
                    
                    serial.Disconnect();
                }
                else deleted = true;

                if (deleted)
                {
                    database.RemoveUser(user);
                    Users = database.GetUsers();
                    //System.Windows.Forms.MessageBox.Show("Deletion success");
                }
                
            }
        }


        public void OpenLock()
        {
            serial.Connect();
            serial.SendMessage("OPEN_LOCK"); 
            serial.Disconnect();
        }

        public void CloseLock()
        {
            serial.Connect();
            serial.SendMessage("CLOSE_LOCK"); 
            serial.Disconnect();
        }

        public void Test()
        {
            serial.Connect();
            serial.SendMessage("HALLO");
            Thread.Sleep(500);
            string[] messages = serial.ReadMessages();
            foreach (string message in messages)
            {
                System.Windows.Forms.MessageBox.Show(message);
            }
            serial.Disconnect();
        }

    }
}
