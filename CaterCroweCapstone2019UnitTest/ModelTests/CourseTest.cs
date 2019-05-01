using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019UnitTest.ModelTests
{
    [TestClass]
    public class CourseTest
    {

        #region ID
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Course Id must be greater than zero.")]
        public void testSetCourseIdZeroFails()
        {
            Course course = new Course();
            course.ID = 0;
        }

        [TestMethod]
        public void testIDGetSet()
        {
            Course course = new Course();
            course.ID = 1;
            Assert.AreEqual(1, course.ID);
        }
        #endregion

        #region Name 
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Course name cannot be empty or null.")]
        public void testCoruseNameSetNull()
        {
            Course course = new Course();
            course.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Course name cannot be empty or null.")]
        public void testCoruseNameSetEmpty()
        {
            Course course = new Course();
            course.Name = string.Empty;
        }

        [TestMethod]
        public void testCourseNameGetSet()
        {
            Course course = new Course();
            course.Name = "Test";
            Assert.AreEqual("Test", course.Name);
        }
        #endregion

        #region Section Number
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Section number must be greater than negative one.")]
        public void testSetSectionNumberAtNegativeOneFails()
        {
            Course course = new Course();
            course.SectionNumber = -1;
        }

        [TestMethod]
        public void testGetSetSectionNumber()
        {
            Course course = new Course();
            course.SectionNumber = 0;
            Assert.AreEqual(0, course.SectionNumber);
        }
        #endregion

        #region Credit Hours
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Credit Hours must be greater than zero.")]
        public void testSetCreditHoursAtZeroFails()
        {
            Course course = new Course();
            course.CreditHours = 0.0;
        }

        [TestMethod]
        public void testCreditHoursGetSet()
        {
            Course course = new Course();
            course.CreditHours = 0.01;
            Assert.AreEqual(0.01, course.CreditHours);
        }
        #endregion

        #region Max Seats
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Max seats must be greater than zero.")]
        public void testSetMaxSeatsAtZeroFails()
        {
            Course course = new Course();
            course.MaxSeats = 0;
        }

        [TestMethod]
        public void testMaxSeatsGetSet()
        {
            Course course = new Course();
            course.MaxSeats = 1;
            Assert.AreEqual(1, course.MaxSeats);
        }
        #endregion

        #region Remaining Seats
        [TestMethod]
        public void testRemainingSeatsGetSet()
        {
            Course course = new Course();
            course.RemainingSeats = 0;
            Assert.AreEqual(0, course.RemainingSeats);
        }
        #endregion

        #region Students
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Students cannot be null.")]
        public void testSetStudentsNullFails()
        {
            Course course = new Course();
            course.Students = null;
        }

        [TestMethod]
        public void testStudentsGetSet()
        {
            List<Student> students = new List<Student>();
            Course course = new Course();
            course.Students = students;
            Assert.IsNotNull(course.Students);
        }
        #endregion

        #region Teacher
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Teacher cannot be null.")]
        public void testSetTeacherNullFails()
        {
            Course course = new Course();
            course.Teacher = null;
        }

        [TestMethod]
        public void testTeacherGetSet()
        {
            Course course = new Course();
            course.Teacher = new Teacher();
            Assert.IsNotNull(course.Teacher);
        }
        #endregion

        #region Prerequisites
        [TestMethod]
        public void testPrerequisitesGetSet()
        {
            Course course = new Course();
            course.Prerequisites = new Dictionary<int, double>();
            Assert.IsNotNull(course.Prerequisites);
        }
        #endregion

        #region Rubric
        [TestMethod]
        public void testRubricGetSet()
        {
            Course course = new Course();
            course.Rubric = new Rubric();
            Assert.IsNotNull(course.Rubric);
        }
        #endregion

    }
}
