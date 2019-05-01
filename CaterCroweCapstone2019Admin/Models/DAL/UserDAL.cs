using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019Admin.Models.DAL
{
    public class UserDAL
    {
        public List<Teacher> GetAllTeachers()
        {
            var teachers = new List<Teacher>();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * FROM teachers " +
                            "JOIN user on user.id = user_id";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var usernameOrdinal = reader.GetOrdinal("user_name");
                        var passwordOrdinal = reader.GetOrdinal("password");
                        var accessLevelOrdinal = reader.GetOrdinal("access_level");
                        var fnameOrdinal = reader.GetOrdinal("fname");
                        var minitOrdinal = reader.GetOrdinal("minit");
                        var lnameOrdinal = reader.GetOrdinal("lname");
                        var userIDOrdinal = reader.GetOrdinal("user_id");

                        while (reader.Read())
                        {
                            teachers.Add(new Teacher()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get user id.") : reader.GetInt32(idOrdinal),
                                Username = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Failed to get username.") : reader.GetString(usernameOrdinal),
                                Password = reader[passwordOrdinal] == DBNull.Value ? throw new Exception("Failed to get password.") : reader.GetString(passwordOrdinal),
                                AccessLevel = reader[accessLevelOrdinal] == DBNull.Value ? throw new Exception("Failed to get access level.") : reader.GetInt32(accessLevelOrdinal),
                                FirstName = reader[fnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get first name.") : reader.GetString(fnameOrdinal),
                                MInit = reader[minitOrdinal] == DBNull.Value ? "" : reader.GetString(minitOrdinal),
                                LastName = reader[lnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get last name.") : reader.GetString(lnameOrdinal),
                                TeacherId = reader[userIDOrdinal] == DBNull.Value ? throw new Exception("Failed to get user id") : reader.GetInt32(userIDOrdinal)
                            });
                        }

                    }
                }
            }

            return teachers;
        }
        public bool MakeUser(User user)
        {
            var result = false;
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "INSERT INTO user " +
                            "(user_name, password, access_level, fname, minit, lname) " +
                            "VALUES " +
                            "(@user_name, @password, @access_level, @fname, @minit, @lname)";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("user_name", user.Username);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("access_level", user.AccessLevel);
                    cmd.Parameters.AddWithValue("fname", user.FirstName);
                    cmd.Parameters.AddWithValue("minit", user.MInit);
                    cmd.Parameters.AddWithValue("lname", user.LastName);
                    cmd.ExecuteNonQuery();
                    if(user.AccessLevel == 1)
                    {
                        result = this.CreateStudent(cmd.LastInsertedId);
                    } else if (user.AccessLevel == 2)
                    {
                        result = this.CreateTeacher(cmd.LastInsertedId);
                    }
                }
            }
            return result;
        }

        public bool UpdateUser(User user)
        {
            var result = false;

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "UPDATE user " +
                            "SET user_name = @user_name, " +
                            "password = @password, " +
                            "fname = @fname, " +
                            "minit = @minit," +
                            "lname = @lname " +
                            "WHERE id = @id";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("id", user.ID);
                    cmd.Parameters.AddWithValue("user_name", user.Username);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("fname", user.FirstName);
                    cmd.Parameters.AddWithValue("minit", user.MInit);
                    cmd.Parameters.AddWithValue("lname", user.LastName);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        private bool CreateStudent(long id)
        {
            var result = false;
            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "INSERT INTO students " +
                            "(user_id) " +
                            "VALUES " +
                            "(@user_id)";
                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("user_id", id);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public User GetUserByUsername(string username)
        {
            User user = null;

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * FROM user " +
                            "WHERE user_name = @user_name";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("user_name", username);

                    using(var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var usernameOrdinal = reader.GetOrdinal("user_name");
                        var passwordOrdinal = reader.GetOrdinal("password");
                        var accessLevelOrdinal = reader.GetOrdinal("access_level");
                        var fnameOrdinal = reader.GetOrdinal("fname");
                        var minitOrdinal = reader.GetOrdinal("minit");
                        var lnameOrdinal = reader.GetOrdinal("lname");

                        while(reader.Read())
                        {
                            user = new User()
                            {
                                ID = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to get user id.") : reader.GetInt32(idOrdinal),
                                Username = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Failed to get username.") : reader.GetString(usernameOrdinal),
                                Password = reader[passwordOrdinal] == DBNull.Value ? throw new Exception("Failed to get password.") : reader.GetString(passwordOrdinal),
                                AccessLevel = reader[accessLevelOrdinal] == DBNull.Value ? throw new Exception("Failed to get access level.") : reader.GetInt32(accessLevelOrdinal),
                                FirstName = reader[fnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get first name.") : reader.GetString(fnameOrdinal),
                                MInit = reader[minitOrdinal] == DBNull.Value ? "" : reader.GetString(minitOrdinal),
                                LastName = reader[lnameOrdinal] == DBNull.Value ? throw new Exception("Failed to get last name.") : reader.GetString(lnameOrdinal),
                            };
                        }

                    }
                }
            }

            return user;
        }

        private bool CreateTeacher(long id)
        {
            var result = false;
            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "INSERT INTO teachers " +
                            "(user_id) " +
                            "VALUES " +
                            "(@user_id)";
                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("user_id", id);

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }
    }
}