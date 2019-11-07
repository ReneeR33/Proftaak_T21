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
        private Database database;
        public User UserLoggedIn { get; private set; }
        public List<User> Users { get; private set; }
        
        public LockMyBike()
        {
            database = new Database();
            Users = database.GetUsers();
        }
        public int Login(string userName, string password)
        {
            foreach (User user in Users)
            {
                if (user.UserName == userName && user.Password == password)
                {
                    UserLoggedIn = user;
                    return 1;
                }
            }
            return 0;
        }
    }
}
