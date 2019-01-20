using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    public class AuthenticateDAL
    {
        public string AuthenticateLogin(string username, string password)
        {
            string result = "failed";

            using(var db = DbConnection.DatabaseConnection())
            {
                string query = "SELECT COUNT(*) FROM `user`" +
                               "WHERE name = @name AND" +
                               "password = @password";

                using(var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters["@name"].Value = username;
                    cmd.Parameters["@password"].Value = password;

                    int count = (int) cmd.ExecuteScalar();
                    if(count > 0)
                    {
                        if(username == "student")
                        {
                            result = "student";
                        } else if(username == "teacher")
                        {
                            result = "teacher";
                        }
                    }
                }
            }

            return result;
        }
    }
}