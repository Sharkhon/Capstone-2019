using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.DAL
{
    public class CourseDAL
    {
        public DataTable GetCoursesByTeacherId(int id)
        {
            var dt = new DataTable();

            using (var db = DbConnection.GetConnection())
            {
                db.Open();
                var routine = "sp_getcoursesbyteacher";
                using(var cmd = new MySqlCommand(routine, db))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("teacherid", id);
                    using(var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

    }
}
