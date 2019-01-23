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

            ViewBag.loggedIn = Convert.ToBoolean(HttpContext.Session["loginStatus"]);

            return View("Index");
        }
    }
}