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
        private UserDAL userDAL;

        public CourseController()
        {
            this.courseDAL = new CourseDAL();
            this.userDAL = new UserDAL();
        }

        public ActionResult Portal()
        {
            var teacherSelectItems = new List<SelectListItem>();

            foreach (var currentTeacher in this.userDAL.GetAllTeachers())
            {
                teacherSelectItems.Add(new SelectListItem(){ Value = currentTeacher.TeacherId.ToString(), Text = currentTeacher.Username });
            }

            var coursesSelectItems = new List<SelectListItem>();

            foreach (var course in this.courseDAL.GetAllCourses())
            {
                coursesSelectItems.Add(new SelectListItem()
                {
                    Text = course.Name,
                    Value = course.Id.ToString()
                });
            }

            ViewBag.Teachers = new SelectList(teacherSelectItems, "Value", "Text");
            ViewBag.Courses = new SelectList(coursesSelectItems, "Value", "Text");

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
