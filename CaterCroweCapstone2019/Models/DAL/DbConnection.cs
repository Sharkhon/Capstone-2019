using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    /// <summary>
    /// Class provides the connection to the database.
    /// </summary>
    public static class DbConnection
    {
        /// <summary>
        /// Used to gain access to the database.
        /// </summary>
        /// <returns>The database connection.</returns>
        public static MySqlConnection DatabaseConnection()
        {
            string connectionString = "server=160.10.25.16; port=3306; uid=cs4982s19e;" +
                                      "pwd=EyaJzbZUosdj356V;database=cs4982s19e;";

            var connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}