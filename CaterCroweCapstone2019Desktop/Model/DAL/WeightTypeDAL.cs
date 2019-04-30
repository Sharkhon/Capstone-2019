using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class WeightTypeDAL
    {

        /// <summary>
        /// Gets all weight type names from the database.
        /// </summary>
        /// <returns>A dictionary of the ids and names of all weight types</returns>
        public Dictionary<int, string> getWeightTypes(MySqlConnection dbConnection)
        {
            var weights = new Dictionary<int, string>();

            using (dbConnection)
            {
                dbConnection.Open();

                var query = "SELECT * " +
                            "FROM weight_types";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        var idOrdinal = reader.GetOrdinal("id");
                        var nameOrdinal = reader.GetOrdinal("name");

                        while (reader.Read())
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

        /// <summary>
        /// Adds a new weight type to the database.
        /// </summary>
        /// <param name="name">The weight type to add.</param>
        /// <returns>The number of rows affected.</returns>
        public int addWeightType(string name, MySqlConnection dbConnection)
        {
            var result = -1;
            using (dbConnection)
            {
                dbConnection.Open();
                
                var query = "INSERT INTO weight_types(name) " +
                            "VALUES(@name)";

                using (var cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.Parameters.AddWithValue("name", name);
                    if(!DbConnection.IsOnline())
                    {
                        var save = Session.ConvertQueryToString(cmd.CommandText, cmd.Parameters);
                        Session.WriteQueryToFile(save);
                    }
                    try
                    {
                        result = Convert.ToInt32(cmd.ExecuteNonQuery());
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            }
            return result;
        }

    }
}
