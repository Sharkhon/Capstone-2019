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
    public class BackupDAL
    {
        public void backupDatabase()
        {
            using(var dbConnection = DbConnection.GetConnection())
            {
                using(MySqlCommand cmd = new MySqlCommand())
                {
                    using (MySqlBackup mb = new MySqlBackup(cmd))
                    {
                        cmd.Connection = dbConnection;
                        dbConnection.Open();
                        var path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "backup.sql";
                        mb.ExportToFile(path);
                    }
                }
            }
        }

        public bool updateLocalDatabase()
        {
            this.createDatabase();
            var result = false;

            using (var dbConnection = DbConnection.GetLocalConnection())
            {
                dbConnection.Open();
                var query = this.getDatabaseCreationQuery();
                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection))
                {
                    cmd.ExecuteNonQuery();
                }

            }

            return result;
        }

        private bool createDatabase()
        {
            var result = false;
            using (var dbConnection = DbConnection.GetLocalSetup())
            {
                dbConnection.Open();
                var query = "CREATE DATABASE IF NOT EXISTS `cs4982s19e`;";

                using (MySqlCommand cmd = new MySqlCommand(query, dbConnection))
                {
                    result = 0 < cmd.ExecuteNonQuery();
                }
            }

            return result;
        }

        private string getDatabaseCreationQuery()
        {
            var path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "backup.sql";
            var query = "";
            if (File.Exists(path))
            {
                query = File.ReadAllText(path);
            }
            else
            {
                throw new Exception("Backup file has not been created yet. Application will not work in offline mode until an internet connection can be established.");
            }
            return query;
        }
    }
}
