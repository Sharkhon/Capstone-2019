using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Configuration;

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
            string connectionString = ConfigurationManager.AppSettings["DbConnectionString"];

            var connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}