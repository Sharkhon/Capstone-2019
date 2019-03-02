using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.Users
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
