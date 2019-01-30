using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels
{
    public class Course
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SectionNumber { get; set; }
        public double CreditHours { get; set; }
        public int MaxSeats { get; set; }
        public int RemainingSeats { get; set; }
        public List<Student> Students { get; set; }
        public Teacher Teacher { get; set; }
        public List<Course> Prereequisites { get; set; }
        public Rubric Rubric { get; set; }
        //Grades : Maybe be a dict that has <Student, double>
    }
}