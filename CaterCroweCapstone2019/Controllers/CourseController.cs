using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019.Controllers
{
    public class CourseController : Controller
    {
        private CourseDAL CourseDAL;
        private RubricDAL RubricDAL;

        public CourseController()
        {
            this.CourseDAL = new CourseDAL();
            this.RubricDAL = new RubricDAL();
        }

        // GET: Course
        public ActionResult Index()
        {
            //TODO This will show all avalible courses and details will take the functionality that is here.
            var course = this.CourseDAL.getCourseById(1);

            return View(course);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(Course course)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult RubricViewer(int courseID)
        {
            var rubric = this.RubricDAL.getRubricByCourseId(courseID);

            return View("RubricViewer", rubric);
        }

        public ActionResult RubricEdit(int courseID)
        {
            ViewBag.courseID = courseID;

            var rubric = this.RubricDAL.getRubricByCourseId(courseID);

            return View("RubricEdit", rubric);
        }

        [HttpPost]
        public ActionResult RubricEdit(Rubric rubric)
        {
            //Apply the edits

            //If edit works;

            return RedirectToAction("RubricEdit", new { viewRubric = rubric });
        }

        [HttpGet]
        public JsonResult GetRubricTypes()
        {
            //Get the types from the database

            var rubric = this.RubricDAL.getRubricByCourseId(Convert.ToInt32(ViewBag.courseID));

            var types = this.RubricDAL.getRemainingWeightTypes(rubric);

            return Json(types, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddRubricType()
        {
            //Adds a type to the database

        }
    }
}
