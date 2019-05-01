using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels.Users
{
    public class Teacher : User
    {
        private int teacherId;
        public int TeacherId
        {
            get
            {
                return this.teacherId;
            }
            set
            {
                if (value > 0)
                {
                    this.teacherId = value;
                }
            }
        }
    }
}