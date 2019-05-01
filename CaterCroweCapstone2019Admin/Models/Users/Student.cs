using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels.Users
{
    public class Student : User
    {
        private int studentId;
        private Dictionary<int, double> completedCourses;

        public int StudentId
        {
            get
            {
                return this.studentId;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Invalid Student ID");
                }

                this.studentId = value;
            }
        }

        public Dictionary<int, double> CompletedCourses
        {
            get
            {
                return this.completedCourses;
            }

            set
            {
                this.completedCourses = value;
            }
        }

        public Student()
        {
            this.completedCourses = new Dictionary<int, double>();
        }

        public void AddCompleted(int courseID, double grade)
        {
            this.completedCourses.Add(courseID, grade);
        }
    }
}