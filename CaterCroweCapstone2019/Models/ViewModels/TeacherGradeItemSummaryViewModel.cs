using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;

namespace CaterCroweCapstone2019.Models.ViewModels
{
    public class TeacherGradeItemSummaryViewModel
    {
        public Student Student { get; set; }
        public List<GradeItem> Grades { get; set; }
        public double OverallGrade { get; set; }

        public TeacherGradeItemSummaryViewModel()
        {
            this.Grades = new List<GradeItem>();
        }
    }
}