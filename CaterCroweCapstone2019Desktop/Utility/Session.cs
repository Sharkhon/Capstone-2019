using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaterCroweCapstone2019Desktop.Utility
{
    public static class Session
    {

        public static Dictionary<string, object> UserSession = new Dictionary<string, object>();
        public static Stack<Form> FormStack = new Stack<Form>();
        private static readonly string DirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
                + Path.DirectorySeparatorChar + "Capstone";
        private static readonly string FilePath = DirectoryPath + Path.DirectorySeparatorChar + "OfflineStore.txt";

        public static string getDirectoryPath()
        {
            return DirectoryPath;
        }

        public static string getFilePath()
        {
            return FilePath;
        }
        
        public static void GoBack()
        {
            FormStack.Pop().Dispose();
            FormStack.Peek().Show();
        }

        public static bool IsOnline()
        {
            if (ConfigurationManager.AppSettings["IsOnline"] == "true")
            {
                return true;
            }
            return false;
        }

        public static void WriteQueryToFile(string query)
        {
            try
            {
                File.AppendAllText(FilePath, query);
            }
            catch (DirectoryNotFoundException dnfe)
            {
                Directory.CreateDirectory(DirectoryPath);
                File.AppendAllText(FilePath, query);
            }
        }

        public static string ConvertQueryToString(string query, MySqlParameterCollection parameters)
        {
            var result = query;
            foreach(MySqlParameter p in parameters)
            {
                if (p.DbType == System.Data.DbType.String || p.DbType == System.Data.DbType.StringFixedLength 
                    || p.DbType == System.Data.DbType.AnsiString || p.DbType == System.Data.DbType.AnsiStringFixedLength)
                {
                    result = result.Replace("@" + p.ParameterName, "'" + p.Value.ToString() + "'");
                } else if (p.DbType == System.Data.DbType.Date || p.DbType == System.Data.DbType.DateTime
                    || p.DbType == System.Data.DbType.DateTime2 || p.DbType == System.Data.DbType.Time)
                {
                    DateTime holder = (DateTime) p.Value;
                    result = result.Replace("@" + p.ParameterName, "'" + holder.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                } else
                {
                    result = result.Replace("@" + p.ParameterName, p.Value.ToString());
                }
                
            }

            result = result + ";" + Environment.NewLine;

            return result;
        }
    }
}
