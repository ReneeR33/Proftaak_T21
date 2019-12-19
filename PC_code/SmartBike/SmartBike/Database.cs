using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SmartBike
{
    //Dit is de klasse voor onze database.

    ///Om verbinding te maken met deze database moet je eerst de MySql.Data plugin downloaden,
    ///en verbinding maken met vdi.fhict.nl (VPN)
    public class Database
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        public Database()
        {
            this.server = "studmysql01.fhict.local";
            this.database = "dbi406377";
            this.uid = "dbi406377";
            this.password = "lock_my_bike_T21";
            string connectionString = "Server=" + server + ";" + "Uid=" + uid + ";" + "Database=" + database + ";" + "Pwd=" + password + ";";

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
                        int id = (int)dataReader["id"];
                        string name = (string)dataReader["name"];
                        string userName = (string)dataReader["username"];
                        string password = (string)dataReader["password"];
                        int fingerID = (int)dataReader["finger_id"];
                        bool isOwner = (bool)dataReader["is_owner"];
                        bool hasAccess = (bool)dataReader["has_access"];

                        User user = new User(id, name, userName, password, fingerID, isOwner, hasAccess);

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
        public void RemoveUser(User user)
        {
            string query = "DELETE FROM `user` WHERE `user`.`id` = @param_id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@param_id", user.ID);
            this.Connect();
            cmd.ExecuteScalar();
            this.Disconnect();
        }
        public void AddUser(User user)
        {
            string query = "INSERT INTO `user` (`name`, `username`, `password`, `finger_id`, `is_owner`) " +
                "VALUES (@param_name, @param_username, @param_password, '-1', @param_is_owner);";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@param_name", user.Name);
            cmd.Parameters.AddWithValue("@param_username", user.UserName);
            cmd.Parameters.AddWithValue("@param_password", user.Password);
            cmd.Parameters.AddWithValue("@param_is_owner", user.IsOwner);
            this.Connect();
            cmd.ExecuteScalar();
            this.Disconnect();
        }

        public void UpdateUserData(User user, string name, string username, string password, int fingerID, bool isOwner, bool has_access)
        {
            string query = "UPDATE `user` SET `name` = @name, `username` = @username, `password` = @password, `finger_id` = @finger_id, `is_owner` = @is_owner, `has_access`  = @has_access WHERE `user`.`id` = @user_id;";
            MySqlCommand cmd = new MySqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@user_id", user.ID);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@finger_id", fingerID);
            cmd.Parameters.AddWithValue("@is_owner", isOwner);
            cmd.Parameters.AddWithValue("@has_access", has_access);

            this.Connect();
            cmd.ExecuteScalar();
            this.Disconnect();
        }
    }
}
