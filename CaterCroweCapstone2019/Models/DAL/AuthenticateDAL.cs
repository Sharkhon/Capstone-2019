using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    /// <summary>
    /// AuthenticateDAL handles all Database requests for login and login checks.
    /// </summary>
    public class AuthenticateDAL
    {
        /// <summary>
        /// Checks that a given username and password combo exists within the database.
        /// </summary>
        /// <param name="username">The username to check.</param>
        /// <param name="password">The password to check.</param>
        /// <returns>The status of the login.</returns>
        public User AuthenticateLogin(string username, string password)
        {
            User user = null;

            using(var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = "SELECT id, user_name, access_level FROM `user` " +
                               "WHERE user_name = @username AND " +
                               "password = @pwd";

                using(var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("pwd", password);

                    var count = Convert.ToInt32(cmd.ExecuteScalar());

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var usernameOrdinal = reader.GetOrdinal("user_name");
                        var accessLevelOrdinal = reader.GetOrdinal("access_level");

                        while (reader.Read())
                        {
                            user = new User()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not get user id") : reader.GetInt32(idOrdinal),
                                Username = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Could not get username") : reader.GetString(usernameOrdinal),
                                AccessLevel = reader[accessLevelOrdinal] == DBNull.Value ? throw new Exception("Could not get user access level") : reader.GetInt32(accessLevelOrdinal)
                            };
                        }
                    }
                }
            }

            return user;
        }
    }
}