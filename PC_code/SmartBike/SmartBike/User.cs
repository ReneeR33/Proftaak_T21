using System;
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
        public User(string name, string userName, string password)
        {
            Name = name;
            UserName = userName;
            Password = password;
        }
        public override string ToString()
        {
            return "Name: " + Name + ","
                 + " Username: " + UserName + ","
                 + " Password: " + Password;
        }
    }
}
