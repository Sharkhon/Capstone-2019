using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels.Assignments
{
    public class Question
    {
        public string QuestionText { get; set; }
        public List<string> Questions { get; set; }
        public int CorrectAnswerIndex { get; set; }
    }
}