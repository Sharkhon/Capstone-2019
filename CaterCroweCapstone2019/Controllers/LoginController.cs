using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019.Controllers
{
    public class LoginController : Controller
    {
        private AuthenticateDAL DAL = new AuthenticateDAL();

        /// <summary>
        /// Logs the user in
        /// </summary>
        /// <param name="username">Username to authenticate to</param>
        /// <param name="password">Password to autheticate by</param>
        /// <returns>Sets the session to be logged in. Reloads page.</returns>
        [HttpPost]
        [AllowAnonymous]
        public JsonResult LogIn(string username, string password)
        {
            var result = DAL.AuthenticateLogin(username, password);
            var user = new User();

            if(user != null)
            {
                this.setSuccessfulLogin(user);
            }

            return this.IsLoggedIn();
        }

        private void setSuccessfulLogin(User user)
        {
            HttpContext.Session.Add("user", user);
            HttpContext.Session.Add("loginStatus", true);
        }

        [HttpGet]
        [AllowAnonymous]
        public JsonResult IsLoggedIn()
        {
            var loginStatus = HttpContext.Session["loginStatus"] != null && Convert.ToBoolean(HttpContext.Session["loginStatus"]);

            return Json(loginStatus, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [AllowAnonymous]
        public void LogoutUser()
        {
            HttpContext.Session["user"] = null;
            HttpContext.Session["loginStatus"] = null;
        }
    }
}