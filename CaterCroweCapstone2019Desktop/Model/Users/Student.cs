using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model.Users
{
    public class Student : User
    {
        private int studentId;
        private List<GradeItem> gradesItems;

        public int StudentId
        {
            get
            {
                return this.studentId;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Student ID");
                }

                this.studentId = value;
            }
        }

        public List<GradeItem> GradeItems
        {
            get
            {
                if (this.gradesItems == null)
                {
                    this.gradesItems = new List<GradeItem>();
                }

                return this.gradesItems;
            }

            set { if (value != null) {this.gradesItems = value;} }
        }
    }
}
