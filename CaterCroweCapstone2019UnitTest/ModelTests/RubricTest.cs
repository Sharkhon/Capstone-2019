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
    public class RubricTest
    {

        #region ID
        [TestMethod]
        public void testIdGetSet()
        {
            Rubric rubric = new Rubric();
            rubric.ID = 1;
            Assert.AreEqual(1, rubric.ID);
        }
        #endregion

        #region Course ID
        [TestMethod]
        public void testCourseIdGetSet()
        {
            Rubric rubric = new Rubric();
            rubric.CourseID = 1;
            Assert.AreEqual(1, rubric.CourseID);
        }
        #endregion

        #region Default Constructor
        [TestMethod]
        public void testDefaultConstructorInitializesRubricValues()
        {
            Rubric rubric = new Rubric();
            Assert.IsNotNull(rubric.RubricValues);
        }
        #endregion

        #region One-Parameter Constructor
        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Rubric cannot be null.")]
        public void testCreateRubricWithNullRubricValuesFails()
        {
            Rubric rubric = new Rubric(null);
        }

        [TestMethod]
        public void testCreateRubricWithEmptyDictionary()
        {
            Dictionary<string, double> values = new Dictionary<string, double>();
            Rubric rubric = new Rubric(values);
            Assert.IsNotNull(rubric.RubricValues);
        }

        [TestMethod]
        public void testCreateRubricWithFilledDictionary()
        {
            Dictionary<string, double> values = new Dictionary<string, double>();
            values.Add("Assignment", 25);
            Rubric rubric = new Rubric(values);
            Assert.IsNotNull(rubric.RubricValues);
            Assert.AreEqual(25, rubric.RubricValues["Assignment"]);
        }
        #endregion
    }
}
