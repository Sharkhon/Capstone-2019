using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CaterCroweCapstone2019.Controllers;
using CaterCroweCapstone2019.Models.DAL.DALModels;
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
            Assert.AreNotEqual(null, result.Model as List<GradeItem>);
        }

        [TestMethod]
        public void TestDetailsView()
        {
            var controller = new GradeItemController();
            var result = controller.Details(1) as ViewResult;
            var model = result.Model as GradeItem;
            Assert.AreEqual("Details", result.ViewName);
            Assert.AreEqual(1, model.ID);
        }

        [TestMethod]
        public void TestEditView()
        {
            var controller = new GradeItemController();
            var result = controller.Edit(1) as ViewResult;
            Assert.AreEqual("Edit", result.ViewName);
            var model = result.Model as GradeItem;
            Assert.AreEqual(1, model.ID);
        }

        [TestMethod]
        public void TestDeleteView()
        {
            var controller = new GradeItemController();
            var result = controller.Delete(1) as ViewResult;
            Assert.AreEqual("Delete", result.ViewName);
        }

        [TestMethod]
        public void TestCreateView()
        {
            var controller = new GradeItemController();
            var result = controller.Create() as ViewResult;
            Assert.AreEqual("Create", result.ViewName);
        }

    }
}
