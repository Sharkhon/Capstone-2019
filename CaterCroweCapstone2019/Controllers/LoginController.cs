using CaterCroweCapstone2019.Models.DAL;
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
        public ActionResult LogIn(string username, string password)
        {
            var result = DAL.AuthenticateLogin(username, password);

            if(result == "student")
            {
                this.setSuccessfulLogin(result);
            } else if(result == "teacher")
            {
                this.setSuccessfulLogin(result);
            } else
            {
                HttpContext.Session.Add("loginStatus", false);
            }

            return RedirectToAction("Index", "Home");
        }

        private void setSuccessfulLogin(string result)
        {
            HttpContext.Session.Add("role", result);
            HttpContext.Session.Add("loginStatus", true);
        }
    }
}