using CaterCroweCapstone2019Desktop.Model;
using CaterCroweCapstone2019Desktop.Model.DAL;
using CaterCroweCapstone2019Desktop.Utility;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CaterCroweCapstone2019Desktop.Model.Users;

namespace CaterCroweCapstone2019Desktop.Controller
{
    public class GradeItemController
    {

        private MySqlConnection onlineConnection;
        private MySqlConnection offlineConnection;
        private GradeItemDAL gradeItemDAL;

        public GradeItemController()
        {
            this.onlineConnection = DbConnection.GetConnection();
            this.offlineConnection = DbConnection.GetLocalConnection();
            this.gradeItemDAL = new GradeItemDAL();
        }

        public List<GradeItem> GetGradeItemsForCourse(int courseId)
        {
            var gradeItems = new List<GradeItem>();

            if(DbConnection.IsOnline())
            {
                try
                {
                    gradeItems = this.gradeItemDAL.GetGradeItemsForCourse(courseId, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            if(!DbConnection.IsOnline())
            {
                gradeItems = this.gradeItemDAL.GetGradeItemsForCourse(courseId, this.offlineConnection);
            }

            return gradeItems;
        }

        public GradeItem GetGradeItemForStudent(int studentId, int gradeItemId)
        {
            var result = new GradeItem();

            if(DbConnection.IsOnline())
            {
                try
                {
                    result = this.gradeItemDAL.GetGradeItemForStudent(studentId, gradeItemId, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            if(!DbConnection.IsOnline())
            {
                result = this.gradeItemDAL.GetGradeItemForStudent(studentId, gradeItemId, this.offlineConnection);
            }

            return result;
        }

        public bool GradeGradeItemByGradeItem(GradeItem gradeItem)
        {
            var result = false;

            if (DbConnection.IsOnline())
            {
                try
                {
                    result = this.gradeItemDAL.GradeGradeItemByGradeItem(gradeItem, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            var holder = this.gradeItemDAL.GradeGradeItemByGradeItem(gradeItem, this.offlineConnection);
            if (!DbConnection.IsOnline())
            {
                result = holder;
            }

            return result;
        }

        public bool UpdateGradeItem(GradeItem item)
        {
            var result = false;

            if(DbConnection.IsOnline())
            {
                try
                {
                    result = this.gradeItemDAL.UpdateGradeItem(item, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            var holder = this.gradeItemDAL.UpdateGradeItem(item, this.offlineConnection);
            if(!DbConnection.IsOnline())
            {
                result = holder;
            }

            return result;
        }

        public bool InsertGradeItem(GradeItem item)
        {
            var result = false;

            if(DbConnection.IsOnline())
            {
                try
                {
                    result = this.gradeItemDAL.insertGradeItem(item, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            var holder = this.gradeItemDAL.insertGradeItem(item, this.offlineConnection);
            if(!DbConnection.IsOnline())
            {
                result = holder;
            }

            return result;
        }

        public bool DeleteGradeItemByGradeItem(GradeItem item)
        {
            var result = false;

            if (DbConnection.IsOnline())
            {
                try
                {
                    result = this.gradeItemDAL.DeleteGradeItemByGradeItem(item, this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            var holder = this.gradeItemDAL.DeleteGradeItemByGradeItem(item, this.offlineConnection);
            if (!DbConnection.IsOnline())
            {
                result = holder;
            }

            return result;
        }

        public Student GetGradeItemsForStudentInClass(Student student, int courseId)
        {
            if (DbConnection.IsOnline())
            {
                try
                {
                    student = this.gradeItemDAL.GetGradeItemsForStudentInClass(student, courseId,
                        this.onlineConnection);
                }
                catch (Exception e)
                {
                    DbConnection.SwitchToOffline();
                }
            }

            if (!DbConnection.IsOnline())
            {
                student = this.gradeItemDAL.GetGradeItemsForStudentInClass(student, courseId, this.offlineConnection);
            }

            return student;
        }
    }
}
