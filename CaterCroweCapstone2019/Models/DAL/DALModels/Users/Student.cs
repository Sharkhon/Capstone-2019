using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels.Users
{
    public class Student : User
    {
        private int studentId;

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
    }
}