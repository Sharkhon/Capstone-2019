using CaterCroweCapstone2019.Models.DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.ViewModels
{
    public class CourseGradesViewModel
    { 
        public Dictionary<Course, double> CourseGrades { get; private set; }

        public CourseGradesViewModel(List<Course> courses, Dictionary<Course, double> courseGrades)
        {
            this.CourseGrades = courseGrades;
        }
    }
}