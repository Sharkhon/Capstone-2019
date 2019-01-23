using CaterCroweCapstone2019.Controllers;
using CaterCroweCapstone2019UnitTest.MockObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class LoginControllerTest
    {
        [TestMethod]
        public void TestNullLogin()
        {
            var controller = new LoginController();
            controller.ControllerContext = new ControllerContext(HttpContextMock.GenerateMockHttpContext().Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.LogIn(null, null);
            Assert.IsFalse(Convert.ToBoolean(result.Data));
        }

        [TestMethod]
        public void TestNotAUserLogin()
        {
            var controller = new LoginController();
            controller.ControllerContext = new ControllerContext(HttpContextMock.GenerateMockHttpContext().Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.LogIn("akdshfalkdjshf", "dsajhflkdsafhl");
            Assert.IsFalse(Convert.ToBoolean(result.Data));
        }

        [TestMethod]
        public void TestTeacherUserLogin()
        {
            var controller = new LoginController();
            controller.ControllerContext = new ControllerContext(HttpContextMock.GenerateMockHttpContext().Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.LogIn("teacher", "password");
            Assert.IsTrue(Convert.ToBoolean(result.Data));
        }

        [TestMethod]
        public void TestStudentUserLogin()
        {
            var controller = new LoginController();
            controller.ControllerContext = new ControllerContext(HttpContextMock.GenerateMockHttpContext().Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.LogIn("student", "password");
            Assert.IsTrue(Convert.ToBoolean(result.Data));
        }

        [TestMethod]
        public void TestIsLoggedIn()
        {
            var controller = new LoginController();

            var sessionData = new Dictionary<string, object>()
            {
                { "loginStatus", true }
            };

            var context = HttpContextMock.GenerateMockHttpContext(sessionData);
            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.IsLoggedIn();
            Assert.IsTrue(Convert.ToBoolean(result.Data));
        }

        [TestMethod]
        public void TestIsNotLoggedIn()
        {
            var controller = new LoginController();

            var sessionData = new Dictionary<string, object>()
            {
                { "loginStatus", false }
            };

            var context = HttpContextMock.GenerateMockHttpContext(sessionData);
            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.IsLoggedIn();
            Assert.IsFalse(Convert.ToBoolean(result.Data));
        }

        [TestMethod]
        public void TestIsLoggedInNewSession()
        {
            var controller = new LoginController();

            var context = HttpContextMock.GenerateMockHttpContext();
            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            var result = controller.IsLoggedIn();
            Assert.IsFalse(Convert.ToBoolean(result.Data));
        }

        [TestMethod]
        public void TestLogout()
        {
            var controller = new LoginController();

            var sessionData = new Dictionary<string, object>()
            {
                { "loginStatus", true },
                { "role", "student" }
            };

            var context = HttpContextMock.GenerateMockHttpContext(sessionData);
            controller.ControllerContext = new ControllerContext(context.Object, new System.Web.Routing.RouteData(), controller);

            controller.LogoutUser();

            Assert.AreEqual(context.Object.Session["loginStatus"], null);
            Assert.AreEqual(context.Object.Session["role"], null);
        }
    }
}
