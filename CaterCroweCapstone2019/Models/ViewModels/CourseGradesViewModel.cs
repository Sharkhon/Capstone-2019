using CaterCroweCapstone2019.Models.DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.ViewModels
{
    public class CourseGradesViewModel
    {
        public List<Course> Courses { get; private set; }
        public Dictionary<int, double> CourseGrades { get; private set; }

        public CourseGradesViewModel(List<Course> courses, Dictionary<int, double> courseGrades)
        {
            this.Courses = courses;
            this.CourseGrades = courseGrades;
        }
    }
}