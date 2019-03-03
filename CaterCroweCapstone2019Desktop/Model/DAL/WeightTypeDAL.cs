using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
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
        public Dictionary<int, string> getWeightTypes()
        {
            var weights = new Dictionary<int, string>();

            using (var dbConnection = DbConnection.GetConnection())
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

    }
}
