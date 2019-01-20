using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels
{
    public class GradeItem
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Grade { get; set; }
        public string WeightType { get; set; }
    }
}