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