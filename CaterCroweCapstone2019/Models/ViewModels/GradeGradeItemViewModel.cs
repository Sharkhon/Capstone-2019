using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.ViewModels
{
    public class GradeGradeItemViewModel
    {
        public Dictionary<int, GradeItem> GradeItemsByStudentID { get; set; }
        public Dictionary<int, Student> StudentsByStudentID { get; set; }

        public Dictionary<int, double> GradeByStudentID { get; set; }

        public int CourseID { get; set; }
        public int GradeItemID { get; set; }

        public double MaxGrade { get; set; }
        public string ItemName { get; set; }

        public GradeGradeItemViewModel()
        {
            if (this.GradeItemsByStudentID == null)
            {
                this.GradeItemsByStudentID = new Dictionary<int, GradeItem>();
            }
            this.StudentsByStudentID = new Dictionary<int, Student>();

            if (this.GradeByStudentID == null)
            {
                this.GradeByStudentID = new Dictionary<int, double>();
            }
        }
    }
}