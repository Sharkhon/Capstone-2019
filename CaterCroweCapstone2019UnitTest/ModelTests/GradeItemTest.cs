using CaterCroweCapstone2019.Models.DAL.DALModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaterCroweCapstone2019UnitTest.ModelTests
{
    [TestClass]
    public class GradeItemTest
    {
        #region Id
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Id cannot be less than zero.")]
        public void testIdLessThanZeroFails()
        {
            GradeItem item = new GradeItem();
            item.ID = -1;
        }

        [TestMethod]
        public void testIdSetGetAt0()
        {
            GradeItem item = new GradeItem();
            item.ID = 0;
            Assert.AreEqual(0, item.ID);
        }

        [TestMethod]
        public void testIdSetGetAt10()
        {
            GradeItem item = new GradeItem();
            item.ID = 10;
            Assert.AreEqual(10, item.ID);
        }
        #endregion

        #region Course Id
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Course Id cannot be less than zero.")]
        public void testCourseIDLessThanZeroFails()
        {
            GradeItem item = new GradeItem();
            item.CourseID = -1;
        }

        [TestMethod]
        public void testCourseIDSetGetAt0()
        {
            GradeItem item = new GradeItem();
            item.CourseID = 0;
            Assert.AreEqual(0, item.CourseID);
        }

        [TestMethod]
        public void testCourseIDSetGetAt5()
        {
            GradeItem item = new GradeItem();
            item.CourseID = 5;
            Assert.AreEqual(5, item.CourseID);
        }
        #endregion

        #region Student Id
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Student Id cannot be less than zero.")]
        public void testStudentIdLessThanZeroFails()
        {
            GradeItem item = new GradeItem();
            item.StudentID = -1;
        }

        [TestMethod]
        public void testStudentIDSetGetAt0()
        {
            GradeItem item = new GradeItem();
            item.StudentID = 0;
            Assert.AreEqual(0, item.StudentID);
        }

        [TestMethod]
        public void testStudentIDSetGetAt123()
        {
            GradeItem item = new GradeItem();
            item.StudentID = 123;
            Assert.AreEqual(123, item.StudentID);
        }
        #endregion

        #region Name
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Name cannot be null or empty.")]
        public void testNameSetGetNullFails()
        {
            GradeItem item = new GradeItem();
            item.Name = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Name cannot be null or empty.")]
        public void testNameSetGetEmptyFails()
        {
            GradeItem item = new GradeItem();
            item.Name = "";
        }

        [TestMethod]
        public void testNameSetGetOneCharacter()
        {
            GradeItem item = new GradeItem();
            item.Name = "A";
            Assert.AreEqual("A", item.Name);
        }

        [TestMethod]
        public void testNameSetGetMultipleCharacters()
        {
            GradeItem item = new GradeItem();
            item.Name = "Jackson";
            Assert.AreEqual("Jackson", item.Name);
        }
        #endregion

        #region Description
        [TestMethod]
        public void testDescriptionNull()
        {
            GradeItem item = new GradeItem();
            item.Description = null;
            Assert.AreEqual(null, item.Description);
        }

        [TestMethod]
        public void testDescriptionEmpty()
        {
            GradeItem item = new GradeItem();
            item.Description = "";
            Assert.AreEqual("", item.Description);
        }

        [TestMethod]
        public void testDescriptionOneCharacter()
        {
            GradeItem item = new GradeItem();
            item.Description = "R";
            Assert.AreEqual("R", item.Description);
        }

        [TestMethod]
        public void testDescriptionMultipleCharacters()
        {
            GradeItem item = new GradeItem();
            item.Description = "This is a test description";
            Assert.AreEqual("This is a test description", item.Description);
        }
        #endregion

        #region Grade
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Grade cannot be less than zero.")]
        public void testGradeLessThanZeroFails()
        {
            GradeItem item = new GradeItem();
            item.Grade = -.01;
        }

        [TestMethod]
        public void testGradeSetGetAt0()
        {
            GradeItem item = new GradeItem();
            item.Grade = 0.0;
            Assert.AreEqual(0.0, item.Grade);
        }

        [TestMethod]
        public void testGradeSetGetHigherThan0()
        {
            GradeItem item = new GradeItem();
            item.Grade = 0.01;
            Assert.AreEqual(0.01, item.Grade);
        }
        #endregion

        #region Weight Type
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Weight type cannot be less than zero.")]
        public void testWeightTypeLessThan0()
        {
            GradeItem item = new GradeItem();
            item.WeightType = -1;
        }

        [TestMethod]
        public void testWeightTypeSetGetAt0()
        {
            GradeItem item = new GradeItem();
            item.WeightType = 0;
            Assert.AreEqual(0, item.WeightType);
        }

        [TestMethod]
        public void testWeightTypeSetGetAt3()
        {
            GradeItem item = new GradeItem();
            item.WeightType = 3;
            Assert.AreEqual(3, item.WeightType);
        }
        #endregion
    }
}
