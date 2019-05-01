using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019Admin.Models.DAL
{
    public class AuthenticateDAL
    {
        public User AuthenticateLogin(string username, string password)
        {
            User user = null;

            using (var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = "SELECT id, user_name, access_level, fname, lname, minit FROM `user` " +
                               "WHERE user_name = @username AND " +
                               "password = @pwd AND " +
                               "access_level = 3";

                using (var cmd = new MySqlCommand(query, db))
                {
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("pwd", password);

                    var count = Convert.ToInt32(cmd.ExecuteScalar());

                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var usernameOrdinal = reader.GetOrdinal("user_name");
                        var accessLevelOrdinal = reader.GetOrdinal("access_level");
                        var fnameOrdinal = reader.GetOrdinal("fname");
                        var minitOrdinal = reader.GetOrdinal("minit");
                        var lnameOrdinal = reader.GetOrdinal("lname");

                        while (reader.Read())
                        {
                            var accessLevel = reader[accessLevelOrdinal] == DBNull.Value ? throw new Exception("Could not get user access level") : reader.GetInt32(accessLevelOrdinal);
                            var id = reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not get user id") : reader.GetInt32(idOrdinal);
                            var userName = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Could not get username") : reader.GetString(usernameOrdinal);
                            var firstname = reader[fnameOrdinal] == DBNull.Value ? throw new Exception("Could not get first name") : reader.GetString(fnameOrdinal);
                            var lastName = reader[lnameOrdinal] == DBNull.Value ? throw new Exception("Could not get last name") : reader.GetString(lnameOrdinal);
                            var minit = reader[minitOrdinal] == DBNull.Value ? null : reader.GetString(minitOrdinal);

                            user = new User()
                            {
                                AccessLevel = 3,
                                FirstName = firstname,
                                ID = id,
                                LastName = lastName,
                                MInit = minit,
                                Username = username,
                                Password = password
                            };

                        }
                    }
                }
            }

            return user;
        }
    }
}