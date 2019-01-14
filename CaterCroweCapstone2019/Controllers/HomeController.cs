using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019.Controllers
{
    public class HomeController : Controller
    {

        /// <summary>
        /// Returns the Index for the home
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            if (HttpContext.Session["loginStatus"] == null)
            {
                HttpContext.Session.Add("loginStatus", false);
            }

            ViewBag.loggedIn = (bool)HttpContext.Session["loginStatus"];

            return View();
        }

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
            HttpContext.Session.Add("loginStatus", true);

            return RedirectToAction("Index");
        }
    }
}