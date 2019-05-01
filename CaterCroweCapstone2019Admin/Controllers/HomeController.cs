using CaterCroweCapstone2019Admin.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019Admin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(string username, string password)
        {
            var login = new AuthenticateDAL();
            Session["User"] = login.AuthenticateLogin(username, password);            

            return RedirectToAction("Index");
        }
    }
}