using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    /// <summary>
    /// WeightTypeDAL handles all database access for the weight_types table.
    /// </summary>
    public class WeightTypeDAL
    {
        /// <summary>
        /// Gets all weight type names from the database.
        /// </summary>
        /// <returns>A dictionary of the ids and names of all weight types</returns>
        public Dictionary<int, string> getWeightTypes()
        {
            var weights = new Dictionary<int, string>();

            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM weight_types";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    using(var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");

                        while(reader.Read())
                        {
                            var key = reader[idOrdinal] == DBNull.Value ? throw new Exception("Failed to find id.") : reader.GetInt32(idOrdinal);
                            var value = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to find name.") : reader.GetString(nameOrdinal);
                            weights.Add(key, value);
                        }
                    }
                }
            }

            return weights;
        }


        public List<string> getWeightTypeList()
        {
            var weights = new List<string>();

            using (var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM weight_types";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var nameOrdinal = reader.GetOrdinal("name");

                        while (reader.Read())
                        {
                            var value = reader[nameOrdinal] == DBNull.Value ? throw new Exception("Failed to find name.") : reader.GetString(nameOrdinal);
                            weights.Add(value);
                        }
                    }
                }
            }

            return weights;
        }

        /// <summary>
        /// Adds a new weight type to the database.
        /// </summary>
        /// <param name="name">The weight type to add.</param>
        /// <returns>The number of rows affected.</returns>
        public int addWeightType(string name)
        {
            var result = -1;
            using(var dbConnection = DbConnection.DatabaseConnection())
            {
                dbConnection.Open();

                var query = "INSERT INTO weight_types(name) " +
                            "VALUES(@name)";

                using(var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("name", name);

                    result = Convert.ToInt32(cmd.ExecuteNonQuery());
                }
            }
            return result;
        }
    }
}