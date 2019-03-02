using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Utility
{
    public static class DbConnection
    {

        public static MySqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.AppSettings["DbConnection"];

            var connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}
