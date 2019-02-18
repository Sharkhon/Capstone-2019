using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels
{
    public class Rubric
    {

        public int ID { get; set; }
        public int CourseID { get; set; }
        public Dictionary<string, double> RubricValues { get; set; }

        public Rubric()
        {
            this.RubricValues = new Dictionary<string, double>();
        }

        public Rubric(Dictionary<string, double> rubric)
        {
            if (rubric == null)
            {
                throw new ArgumentException("Rubric cannot be null.");
            }
            this.RubricValues = rubric;
        }
    }
}