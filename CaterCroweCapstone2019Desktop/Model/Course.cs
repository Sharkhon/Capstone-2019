﻿using CaterCroweCapstone2019Desktop.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019Desktop.Model
{
    public class Course
    {
        #region Data Memebers
        private int id;
        private string name;
        private int sectionNumber;
        private double creditHours;
        private int maxSeats;
        private int remainingSeats;
        private List<Student> students;
        private Teacher teacher;
        private List<Course> prerequisites;
        private Rubric rubric;
        #endregion

        #region Properties
        public int ID
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Course Id must be greater than zero.");
                }
                this.id = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Course name cannot be empty or null.");
                }
                this.name = value;
            }
        }

        public int SectionNumber
        {
            get
            {
                return this.sectionNumber;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Section number must be greater than negative one.");
                }
                this.sectionNumber = value;
            }
        }

        public double CreditHours
        {
            get
            {
                return this.creditHours;
            }
            set
            {
                if (value <= 0.0)
                {
                    throw new ArgumentException("Credit Hours must be greater than zero.");
                }
                this.creditHours = value;
            }
        }

        public int MaxSeats
        {
            get
            {
                return this.maxSeats;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Max seats must be greater than zero.");
                }
                this.maxSeats = value;
            }
        }

        public int RemainingSeats
        {
            get
            {
                return this.remainingSeats;
            }
            set
            {
                this.remainingSeats = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Students cannot be null.");
                }
                this.students = value;
            }
        }

        public Teacher Teacher
        {
            get
            {
                return this.teacher;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Teacher cannot be null.");
                }
                this.teacher = value;
            }
        }

        public List<Course> Prereequisites
        {
            get
            {
                return this.prerequisites;
            }
            set
            {
                this.prerequisites = value;
            }
        }

        public Rubric Rubric
        {
            get
            {
                return this.rubric;
            }
            set
            {
                this.rubric = value;
            }
        }
        //Grades : Maybe be a dict that has <Student, double>
        #endregion


    }
}
