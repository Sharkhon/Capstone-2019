using System;
using System.Web.Mvc;
using CaterCroweCapstone2019.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CaterCroweCapstone2019UnitTest.Controller
{
    [TestClass]
    public class GradeItemControllerTest
    {

        [TestMethod]
        public void TestIndexView()
        {
            var controller = new GradeItemController();
            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new GradeItemController();
            var result = controller.Details(1) as ViewResult;
            Assert.AreEqual("Details", result.ViewName);
        }

        [TestMethod]
        public void TestEditView()
        {
            var controller = new GradeItemController();
            var result = controller.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
        }

    }
}
