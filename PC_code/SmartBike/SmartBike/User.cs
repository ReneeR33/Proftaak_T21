using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBike
{
    public class User
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public int FingerID { get; private set; }
        public bool IsOwner { get; private set; }
        public bool HasAccess { get; private set; }
        public User(string name, string userName, string password, int fingerID, bool isOwner, bool hasAccess)
        {
            ID = 0;
            Name = name;
            UserName = userName;
            Password = password;
            FingerID = fingerID;
            IsOwner = isOwner;
            HasAccess = hasAccess;
        }
        public User(int id, string name, string userName, string password, int fingerID, bool isOwner, bool hasAccess)
        {
            ID = id;
            Name = name;
            UserName = userName;
            Password = password;
            FingerID = fingerID;
            IsOwner = isOwner;
            HasAccess = hasAccess;
        }
        public override string ToString()
        {
            string idString;
            if (FingerID != -1) idString = FingerID.ToString();
            else idString = "no fingerprint";
            return "Name: " + Name + ","
                 + " FingerID: " + idString + ","
                 + " ID: " + ID.ToString();
        }
    }
}
