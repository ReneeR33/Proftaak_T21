using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SmartBike
{
    //Dit is de hoofdklasse voor ons programma
    public class LockMyBike
    {
        private Serial serial;

        private Database database;
        public User UserLoggedIn { get; private set; }
        public List<User> Users { get; private set; }

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

        public void AddUser(User user)
        {

        }
        
        public void RemoveUser(User user)
        {
            if(user != null)
            {
                serial.Connect();
                serial.SendMessage("REMOVE_FINGERPRINT:" + user.FingerID.ToString());
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

        //nodig?
        //public void UseIncomingMessages()
        //{
        //    string[] messages = serial.ReadMessages();
        //    if (messages != null && messages.Length != 0)
        //    {
        //        foreach (string message in messages)
        //        {
        //            if (message == "")
        //            {
        //                //
        //            }
        //            else if (message == "")
        //            {

        //            }
        //            else if (message == "")
        //            {
        //                //
        //            }
        //        }
        //    }
        //}
    }
}
