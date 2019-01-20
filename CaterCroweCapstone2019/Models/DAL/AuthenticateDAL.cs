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
            var result = "failed";

            using(var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = "SELECT COUNT(*) FROM `user` " +
                               "WHERE name = @username AND " +
                               "password = @pwd";

                using(var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("pwd", password);

                    var count = Convert.ToInt32(cmd.ExecuteScalar());
                    if(count > 0)
                    {
                        if(username == "student")
                        {
                            result = "student";
                        }
                        else if(username == "teacher")
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