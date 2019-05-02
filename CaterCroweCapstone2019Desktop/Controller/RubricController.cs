using CaterCroweCapstone2019Desktop.Model;
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
    public class RubricController
    {

        private MySqlConnection onlineConnection;
        private MySqlConnection offlineConnection;
        private RubricDAL rubricDAL;

        public RubricController()
        {
            this.onlineConnection = DbConnection.GetConnection();
            this.offlineConnection = DbConnection.GetLocalConnection();
            this.rubricDAL = new RubricDAL();
        }

        public Rubric GetRubricByCourseId(int id)
        {
            var rubric = new Rubric();

            if(DbConnection.IsOnline())
            {
                try
                {
                    rubric = this.rubricDAL.getRubricByCourseId(id, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            if(!DbConnection.IsOnline())
            {
                rubric = this.rubricDAL.getRubricByCourseId(id, this.offlineConnection);
            }

            return rubric;
        }

        public int UpdateRubricByRubric(Rubric rubric)
        {
            int result = -1;

            if(DbConnection.IsOnline())
            {
                try
                {
                    result = this.rubricDAL.updateRubricByRubric(rubric, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            var holder = this.rubricDAL.updateRubricByRubric(rubric, this.offlineConnection);
            if(!DbConnection.IsOnline())
            {
                result = holder;
            }

            return result;
        }

        public string GetWeightTypeById(int id)
        {
            string result = "";

            if (DbConnection.IsOnline())
            {
                try
                {
                    result = this.rubricDAL.GetWeightTypeById(id, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            if (!DbConnection.IsOnline())
            {
                result = this.rubricDAL.GetWeightTypeById(id, this.offlineConnection);
            }

            return result;
        }

    }
}
