using CaterCroweCapstone2019Admin.Models;
using CaterCroweCapstone2019Admin.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019Admin.Controllers
{
    public class CourseController : Controller
    {
        private CourseDAL courseDAL;

        public CourseController()
        {
            this.courseDAL = new CourseDAL();
        }

        public ActionResult Portal()
        {
            return View("Portal");
        }

        [HttpPost]
        public ActionResult Create(Course course)
        {
            try
            {
                this.courseDAL.CreateCourse(course);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }

            return RedirectToAction("Portal");
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
                this.courseDAL.EditCourse(course);
            }
            catch (Exception e)
            {
                TempData["error"] = e.Message;
            }

            return RedirectToAction("Portal");
        }

        #region Request Handling 

        [HttpGet]
        public JsonResult GetCourseByID(int courseID)
        {
            return Json(this.courseDAL.GetCourseById(courseID), JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
