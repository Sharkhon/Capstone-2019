using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CaterCroweCapstone2019.Models.DAL.DALModels
{
    public class GradeItem
    {
        #region Data Members
        private int id;
        private string name;
        private string description;
        private int maxGrade;
        private int weightType;
        private DateTime dueDate;
        private int courseID;
        private int studentID;
        private double grade;
        #endregion

        #region Properties
        /// <summary>
        /// Gets and sets the Id for the GradeItem.
        /// </summary>
        /// <exception cref="System.ArgumentException">Id must be >= 0</exception>
        /// <return>Returns the value of id.</return>
        public int ID {
            get
            {
                return this.id;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Id cannot be less than zero.");
                }
                this.id = value;
            }
        }

        /// <summary>
        /// Gets and sets the Name for the GradeItem.
        /// </summary>
        /// <exception cref="System.ArgumentException">Name cannot be null or empty string.</exception>
        /// <return>Returns the value of Name.</return>
        public string Name {
            get
            {
                return this.name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        /// <summary>
        /// Gets and sets the Description for the GradeItem.
        /// </summary>
        /// <return>Returns the value of Description.</return>
        public string Description {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        /// <summary>
        /// Gets and sets the Max Grade for the GradeItem.
        /// </summary>
        /// <exception cref="System.ArgumentException">Max Grade must be >= 0.0</exception>
        /// <return>Returns the value of the Max Grade.</return>
        public int MaxGrade {
            get
            {
                return this.maxGrade;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException("Max Grade cannot be less than zero.");
                }
                this.maxGrade = value;
            }
        }

        /// <summary>
        /// Gets and sets the Weight Type for the GradeItem.
        /// </summary>
        /// <exception cref="System.ArgumentException">Weight Type must be >= 0</exception>
        /// <return>Returns the value of the Weight Type.</return>
        public int WeightType {
            get
            {
                return this.weightType;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Weight type cannot be less than zero.");
                }
                this.weightType = value;
            }
        }

        /// <summary>
        /// Get and sets the due date for the grade item.
        /// </summary>
        /// <exception cref="System.ArgumentException">Due Date cannot be null.</exception>
        /// <return>Returns the date and time the grade item is due.</return>
        public DateTime DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Due date cannot be null.");
                }
                this.dueDate = value;
            }
        }

        /// <summary>
        /// Gets and set the Course Id for the GradeItem.
        /// </summary>
        /// <exception cref="System.ArgumentException">CourseId must be >= 0</exception>
        /// <return>Returns the value of Course Id.</return>
        public int CourseID
        {
            get
            {
                return this.courseID;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Course Id cannot be less than zero.");
                }
                this.courseID = value;
            }

        }

        /// <summary>
        /// Gets and sets the Student Id for the GradeItem.
        /// </summary>
        /// <exception cref="System.ArgumentException">Student Id must be >= 0</exception>
        /// <return>Returns the value of Student Id.</return>
        public int StudentID
        {
            get
            {
                return this.studentID;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Student Id cannot be less than zero.");
                }
                this.studentID = value;
            }
        }

        /// <summary>
        /// Gets and sets the grade for the grade item.
        /// </summary>
        /// <exception cref="System.ArgumentException">Grade must be >= 0</exception>
        /// <return>Returns the grade achieved for the grade item.</return>
        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Grade cannot be less than zero.");
                }
                this.grade = value;
            }
        }
        #endregion
    }
}