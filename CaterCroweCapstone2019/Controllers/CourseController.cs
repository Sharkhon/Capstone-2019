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
        private WeightTypeDAL WeightTypeDAL;

        public CourseController()
        {
            this.CourseDAL = new CourseDAL();
            this.RubricDAL = new RubricDAL();
            this.WeightTypeDAL = new WeightTypeDAL();
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
            this.RubricDAL.updateRubricByRubric(rubric);

            //return RedirectToAction("RubricEdit", new { viewRubric = rubric });
            return RedirectToAction("RubricViewer", new { rubric.CourseID });
        }

        [HttpGet]
        public JsonResult GetRubricTypes(List<string> usedTypes)
        {
            //Get the types from the database

            //var rubric = this.RubricDAL.getRubricByCourseId(Convert.ToInt32(courseID));

            var types = this.WeightTypeDAL.getWeightTypeList();

            if (usedTypes == null)
            {
                return Json(types, JsonRequestBehavior.AllowGet);
            }

            foreach(var type in usedTypes)//((Rubric)rubric).RubricValues.Keys)
            {
                types.Remove(type);
            }

            return Json(types, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void AddRubricType()
        {
            //Adds a type to the database

        }
    }
}
