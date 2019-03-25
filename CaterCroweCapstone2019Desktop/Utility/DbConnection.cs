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

        public static MySqlConnection GetLocalConnection()
        {
            var connectionString = ConfigurationManager.AppSettings["LocalConnection"];
            var connection = new MySqlConnection(connectionString);
            return connection;
        }

        public static MySqlConnection GetLocalSetup()
        {
            var connectionString = ConfigurationManager.AppSettings["LocalSetup"];
            var connection = new MySqlConnection(connectionString);
            return connection;
        }

        public static MySqlConnection GetConnection()
        {
            var connectionString = "";
            if(ConfigurationManager.AppSettings["IsOnline"] == "true")
            {
                connectionString = ConfigurationManager.AppSettings["DbConnection"];
            }
            else
            {
                connectionString = ConfigurationManager.AppSettings["LocalConnection"];
            }

            var connection = new MySqlConnection(connectionString);

            return connection;
        }

        public static void SwitchToOffline()
        {
            ConfigurationManager.AppSettings["IsOnline"] = "false";
        }
    }
}
