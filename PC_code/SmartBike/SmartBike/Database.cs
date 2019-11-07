using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SmartBike
{
    class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        /// <summary>
        /// Creates a connection with our database.
        /// </summary>
        public Database()
        {
            this.server = "studmysql01.fhict.local";
            this.database = "dbi406377";
            this.uid = "dbi406377";
            this.password = "lock_my_bike_T21";
            string connectionString = "Server=" + server + ";" + "Uid=" + uid + ";" + "Database=" + database + ";" + "Pwd=" + password + ";";
            //Server = studmysql01.fhict.local; Uid = dbi406377; Database = dbi406377; Pwd = yourPassword;

            this.connection = new MySqlConnection(connectionString);
        }

        public bool Connect()
        {
            bool connected = false;
            try
            {
                if (this.connection.State == System.Data.ConnectionState.Closed)
                {
                    this.connection.Open();
                    connected = true;
                }
            }
            catch (MySqlException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            return connected;

        }

        public void Disconnect()
        {
            if (this.connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();

            if (this.Connect())
            {
                string query = "SELECT * FROM user";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    try
                    {
                        string name = (string)dataReader["name"];
                        string userName = (string)dataReader["username"];
                        string password = (string)dataReader["password"];

                        User user = new User(name, userName, password);

                        users.Add(user);
                    }
                    catch (IndexOutOfRangeException ie)
                    {
                        System.Windows.Forms.MessageBox.Show(ie.ToString());
                    }
                }

                dataReader.Close();
                this.Disconnect();
            }

            return users;
        }
    }

}
