using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019.Controllers
{
    public class StudentController : Controller
    {
        private CourseDAL courseDAL;
        private GradeItemDAL gradesDAL;
        private RubricDAL rubricDAL;

        public StudentController()
        {
            this.courseDAL = new CourseDAL();
            this.gradesDAL = new GradeItemDAL();
            this.rubricDAL = new RubricDAL();
        }

        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Sets up the data for the course home
        /// </summary>
        /// <returns>CourseHome view with the lis tof courses.</returns>
        public ActionResult CoursesHome()
        {
            //TODO: This will pull the courses that the student is in.
            //Maybe store the student in the session data.

            var studentID = Convert.ToInt32(Session["LoginID"]);

            var courses = this.courseDAL.GetCoursesByStudent(studentID);

            return View("CoursesHome", courses);
        }

        public ActionResult Course(int courseID)
        {
            var course = this.courseDAL.getCourseById(courseID);

            return View("Course", course);
        }

        public ActionResult CourseGrades(int studentID)
        {
            var courses = this.courseDAL.GetCoursesByStudent(studentID);
            var grades = new Dictionary<int, double>();
            var model = new CourseGradesViewModel(courses, grades);

            return View("CourseGrades", model);
        }

        public ActionResult Grades(int courseID)
        {
            //Get grades from the courseID given and the "LoginID" from the session

            var grades = new List<GradeItem>();

            return View("Grades", grades);
        }

        public ActionResult Rubric(int courseID)
        {
            //Get Rubric based on course ID
            var rubric = this.rubricDAL.getRubricByCourseId(courseID);

            return View("Rubric", rubric);
        }

        public ActionResult Assignment (int assignmentID)
        {
            return View("Assignment");
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
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

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Student/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Student/Delete/5
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
    }
}
