using CaterCroweCapstone2019.Controllers;
using CaterCroweCapstone2019UnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019UnitTest.Controller
{
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void TestIndexViewWhenFirstSession()
        {
            var controller = new HomeController();
            var context = HttpContextMock.GenerateMockHttpContext();

            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsFalse(Convert.ToBoolean(result.ViewData["loggedIn"]));
        }

        [TestMethod]
        public void TestIndexViewWhenLoggedIn()
        {
            var controller = new HomeController();

            var keys = new Dictionary<string, object>()
            {
                { "loginStatus", true }
            };
            var context = HttpContextMock.GenerateMockHttpContext(keys);

            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsTrue(Convert.ToBoolean(result.ViewData["loggedIn"]));
        }

        [TestMethod]
        public void TestIndexViewWhenNotLoggedIn()
        {
            var controller = new HomeController();

            var keys = new Dictionary<string, object>()
            {
                { "loginStatus", false }
            };
            var context = HttpContextMock.GenerateMockHttpContext(keys);

            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
            Assert.IsFalse(Convert.ToBoolean(result.ViewData["loggedIn"]));
        }
    }
}
