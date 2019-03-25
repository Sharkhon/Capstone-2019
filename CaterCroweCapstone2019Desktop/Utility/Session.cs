using System;
using System.Collections.Generic;
using System.Configuration;
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
    }
}
