using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
using CaterCroweCapstone2019Admin.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019Admin.Controllers
{
    public class UserController : Controller   
    {
        private UserDAL userDal;
        private CourseDAL courseDAL;

        public UserController()
        {
            this.userDal = new UserDAL();
            this.courseDAL = new CourseDAL();
        }

        // GET: User
        public ActionResult Portal()
        {
            ViewBag.AccessLevels = new SelectList(new List<SelectListItem>()
            {
                new SelectListItem() { Text = "Student", Value = "1"},
                new SelectListItem() { Text = "Teacher", Value = "2" }
            }, "Value", "Text");

            return View("Portal", new User());
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                this.userDal.MakeUser(user);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }

            return RedirectToAction("Portal");
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                this.userDal.UpdateUser(user);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }

            return RedirectToAction("Portal");
        }

        [HttpPost]
        public ActionResult AssignTeacherToCourse(int teacerID, int courseID)
        {
            try
            {
                
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }

            return RedirectToAction("Portal");
        }

        #region Request Handling

        [HttpGet]
        public JsonResult GetUser(string username)
        {
            return Json("", JsonRequestBehavior.AllowGet);

        }

        #endregion
    }
}
