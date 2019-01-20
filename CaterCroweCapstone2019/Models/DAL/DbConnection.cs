using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL
{
    public static class DbConnection
    {
        public static MySqlConnection DatabaseConnection()
        {
            string connectionString = "server=160.10.25.16; port=3306; uid=cs4982s19e;" +
                                      "pwd=EyaJzbZUosdj356V;database=cs4982s19e;";

            var connection = new MySqlConnection(connectionString);

            return connection;
        }
    }
}