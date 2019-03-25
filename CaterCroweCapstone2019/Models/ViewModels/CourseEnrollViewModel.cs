using CaterCroweCapstone2019.Models.DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.ViewModels
{
    public class CourseEnrollViewModel
    {
        private List<Course> enrolledCourses;
        private List<Course> enrollableCourses;

        public List<Course> EnrolledCourses {
            get
            {
                return this.enrolledCourses;
            }

            set
            {
                if(value == null)
                {
                    throw new ArgumentException("Cannot have a null list for enrolled courses");
                }

                this.enrolledCourses = value;
            }
        }

        public List<Course> EnrollableCourses
        {
            get
            {
                return this.enrollableCourses;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Cannot have a null list for enrollable courses");
                }

                this.enrollableCourses = value;
            }
        }

        public CourseEnrollViewModel()
        {
            this.enrollableCourses = new List<Course>();
            this.enrolledCourses = new List<Course>();
        }
    }
}