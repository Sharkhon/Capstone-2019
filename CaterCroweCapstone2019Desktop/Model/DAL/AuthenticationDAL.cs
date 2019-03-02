using CaterCroweCapstone2019Desktop.Model.Users;
using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class AuthenticationDAL
    {

        public User AuthenticateUser(string username, string password)
        {
            User user = null;

            using(var db = DbConnection.GetConnection())
            {
                db.Open();
                var routine = "sp_authenticate_user";
                using(var cmd = new MySqlCommand(routine, db))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("username", username);
                    cmd.Parameters.AddWithValue("pass", password);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var idOrdinal = reader.GetOrdinal("id");
                            var usernameOrdinal = reader.GetOrdinal("user_name");
                            var accessLevelOrdinal = reader.GetOrdinal("access_level");

                            var accessLevel = reader[accessLevelOrdinal] == DBNull.Value ? throw new Exception("Could not get user access level") : reader.GetInt32(accessLevelOrdinal);
                            var id = reader[idOrdinal] == DBNull.Value ? throw new Exception("Could not get user id") : reader.GetInt32(idOrdinal);
                            var userName = reader[usernameOrdinal] == DBNull.Value ? throw new Exception("Could not get username") : reader.GetString(usernameOrdinal);

                            user = new Teacher
                            {
                                ID = id,
                                Username = userName,
                                AccessLevel = accessLevel,
                                TeacherId = this.GetTeacherIdBasedOnUserId(id)
                            };
                        }
                    }
                }
            }

            return user;
        }

        private int GetTeacherIdBasedOnUserId(int id)
        {
            using (var db = DbConnection.GetConnection())
            {
                db.Open();
                var query = @"SELECT id FROM teachers WHERE user_id = @userId";

                using (var cmd = new MySqlCommand(query, db))
                {

                    cmd.Parameters.AddWithValue("userId", id);

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
