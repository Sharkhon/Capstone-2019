using CaterCroweCapstone2019Desktop.Model.DAL;
using CaterCroweCapstone2019Desktop.Model.Users;
using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCroweCapstone2019Desktop.Model;

namespace CaterCroweCapstone2019Desktop.Controller
{
    public class CourseController
    {

        private MySqlConnection onlineConnection;
        private MySqlConnection offlineConnection;
        private CourseDAL courseDAL;

        public CourseController()
        {
            this.onlineConnection = DbConnection.GetConnection();
            this.offlineConnection = DbConnection.GetLocalConnection();
            this.courseDAL = new CourseDAL();
        }

        public DataTable GetCoursesByTeacherId(int id)
        {
            var dt = new DataTable();

            if(DbConnection.IsOnline())
            {
                try
                {
                    dt = this.courseDAL.GetCoursesByTeacherId(id, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            if(!DbConnection.IsOnline())
            {
                dt = this.courseDAL.GetCoursesByTeacherId(id, this.offlineConnection);
            }

            return dt;
        }

        public List<Student> GetAllStudentsInCourse(int courseId)
        {
            var students = new List<Student>();

            if(DbConnection.IsOnline())
            {
                try
                {
                    students = this.courseDAL.GetAllStudentsInCourse(courseId, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            if(!DbConnection.IsOnline())
            {
                students = this.courseDAL.GetAllStudentsInCourse(courseId, this.offlineConnection);
            }

            return students;
        }

    }
}
