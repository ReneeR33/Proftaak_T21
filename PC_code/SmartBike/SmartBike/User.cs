﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike
{
    public class User
    {
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int FingerID { get; private set; }
        public bool IsOwner { get; private set; }
        public User(string name, string userName, string password, int fingerID, bool isOwner)
        {
            Name = name;
            UserName = userName;
            Password = password;
            FingerID = fingerID;
            IsOwner = isOwner;
        }
        public override string ToString()
        {
            return "Name: " + Name + ","
                 + " Username: " + UserName + ","
                 + " Password: " + Password;
        }
    }
}
