using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void AddUser()
        {
            ///!!!!!
        }

        public void CloseLock()
        {
            serial.Connect();
            serial.SendMessage("CLOSELOCK"); //voorbeeld
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
