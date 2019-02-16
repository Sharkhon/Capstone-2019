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
                            var accessLevel = reader[accessLevelOrdinal] == DBNull.Value ? throw new Exception("Could not get user access level") : reader.GetInt32(accessLevelOrdinal);
                            var id = reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not get user id") : reader.GetInt32(idOrdinal);
                            var userName = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Could not get username") : reader.GetString(usernameOrdinal);

                            if (accessLevel == 1)
                            {
                                user = new Student()
                                {
                                    ID = id,
                                    Username = userName,
                                    AccessLevel = accessLevel,
                                    StudentId = this.GetStudentIDBasedOnUserID(id)
                                };
                            }
                            else
                            {
                                user = new Teacher()
                                {
                                    ID = id,
                                    Username = userName,
                                    AccessLevel = accessLevel,
                                    TeacherId = this.GetTeacherIDBasedOnUserID(id)
                                };
                            }
                        }
                    }
                }
            }

            return user;
        }

        private int GetStudentIDBasedOnUserID(int userID)
        {
            using (var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = @"SELECT id FROM students WHERE user_id = @userId";

                using (var cmd = new MySqlCommand(query, db))
                {

                    cmd.Parameters.AddWithValue("userId", userID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        var idOrdinal = reader.GetOrdinal("id");
                        return reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not get teacher id") : reader.GetInt32(idOrdinal);
                    }
                }
            }
        }

        private int GetTeacherIDBasedOnUserID(int userID)
        {
            using (var db = DbConnection.DatabaseConnection())
            {
                db.Open();
                var query = @"SELECT id FROM teachers WHERE user_id = @userId";

                using (var cmd = new MySqlCommand(query, db))
                {

                    cmd.Parameters.AddWithValue("userId", userID);

                    using (var reader = cmd.ExecuteReader())
                    {
                        reader.Read();
                        var idOrdinal = reader.GetOrdinal("id");
                        return reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not get teacher id") : reader.GetInt32(idOrdinal);
                    }
                }
            }   
        }
    }
}