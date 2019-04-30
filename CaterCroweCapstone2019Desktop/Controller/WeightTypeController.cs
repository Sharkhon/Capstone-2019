using CaterCroweCapstone2019Desktop.Model.DAL;
using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Controller
{
    public class WeightTypeController
    {

        private MySqlConnection onlineConnection;
        private MySqlConnection offlineConnection;
        private WeightTypeDAL weightTypeDAL;

        public WeightTypeController()
        {
            this.onlineConnection = DbConnection.GetConnection();
            this.offlineConnection = DbConnection.GetLocalConnection();
            this.weightTypeDAL = new WeightTypeDAL();
        }

        public Dictionary<int, string> getWeightTypes()
        {
            Dictionary<int, string> result = null;

            if(DbConnection.IsOnline())
            {
                try
                {
                    result = this.weightTypeDAL.getWeightTypes(this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }


            if(!DbConnection.IsOnline()) {
                result = this.weightTypeDAL.getWeightTypes(this.offlineConnection);
            }

            return result;
        }

        public int addWeightType(string name)
        {
            var result = -1;

            if(DbConnection.IsOnline())
            {
                try
                {
                    result = this.weightTypeDAL.addWeightType(name, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            var holder = this.weightTypeDAL.addWeightType(name, this.offlineConnection);
            if(!DbConnection.IsOnline())
            {
                result = holder;
            }

            return result;
        }
    }
}
