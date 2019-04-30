using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            var connectionString = ConfigurationManager.AppSettings["DbConnection"];
            var connection = new MySqlConnection(connectionString);
            return connection;
        }

        public static void SwitchToOffline()
        {
            ConfigurationManager.AppSettings["IsOnline"] = "false";
            var result = MessageBox.Show("The application is switching to offline mode." +
                "You can continue to use the application, however, all updates made will not be stored " +
                "until the application is restarted with an internet connection.", "Offline mode", MessageBoxButtons.OK);
        }

        public static bool IsOnline()
        {
            return Boolean.Parse(ConfigurationManager.AppSettings["IsOnline"]);
        }
    }
}
