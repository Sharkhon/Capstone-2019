using CaterCroweCapstone2019.Models.DAL.DALModels.Assignments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels
{
    public class Quiz : Assignmnet
    {
        public List<Question> QuestionBank { get; set; }
    }
}