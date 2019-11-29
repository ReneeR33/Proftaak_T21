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

        public AddingFingerprintStatus addingFingerprintStatus;
        private Serial serial;

        private Database database;
        public User UserLoggedIn { get; private set; }
        public List<User> Users { get; private set; }

      
        public LockMyBike()
        {
            serial = new Serial("COM5", 9600, new MessageBuilder('#', '%'));
            database = new Database();
            Users = database.GetUsers();
            addingFingerprintStatus = AddingFingerprintStatus.NotAddingFingerprint;
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
        //public AddingFingerprintStatus GetFingerprintStatus()
        //{
        //    //
        //}

        public void AddUser(User user)
        {
            database.addUser(user);
            Users = database.GetUsers();
        }
        
        public void RemoveUser(User user)
        {
            if(user != null)
            {
                serial.Connect();
                serial.SendMessage("REMOVE_FINGERPRINT:" + user.FingerID.ToString());
                Thread.Sleep(200);
                string[] messages = serial.ReadMessages();
                foreach (string message in messages)
                {
                    System.Windows.Forms.MessageBox.Show(message);
                }
                serial.Disconnect();
                database.RemoveUser(user);
                Users = database.GetUsers();
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
