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
                var courseID = this.courseDAL.CreateCourse(course);

                this.courseDAL.InsertPrereqsForCourse(courseID, course.Prereqs);
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

                var dbPrereqs = this.courseDAL.GetCoursePrereqsByCourseId(course.Id);

                var prereqEdits = new List<Prereq>();
                var prereqNews = new List<Prereq>();

                foreach (var dbPrereq in dbPrereqs)
                {
                    var hasCourse = false;
                    foreach (var coursePrereq in course.Prereqs)
                    {
                        if (dbPrereq.PrereqId == coursePrereq.PrereqId)
                        {
                            hasCourse = true;
                            prereqEdits.Add(coursePrereq);
                        }
                    }

                    if (!hasCourse)
                    {
                        this.courseDAL.DropPrereqFromCourse(course.Id, dbPrereq.PrereqId);
                    }
                }

                foreach (var coursePrereq in course.Prereqs)
                {
                    if (!prereqEdits.Contains(coursePrereq))
                    {
                        prereqNews.Add(coursePrereq);
                    }
                }

                this.courseDAL.InsertPrereqsForCourse(course.Id, prereqNews);
                this.courseDAL.UpdatePrereqsForCourseId(course.Id, prereqEdits);
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
            var course = this.courseDAL.GetCourseById(courseID);
            course.Prereqs = this.courseDAL.GetCoursePrereqsByCourseId(courseID);

            return Json(course, JsonRequestBehavior.AllowGet);
        }

        #endregion
    }
}
