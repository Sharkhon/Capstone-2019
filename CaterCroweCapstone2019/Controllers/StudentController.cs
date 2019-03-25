using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels;
using CaterCroweCapstone2019.Models.DAL.DALModels.Users;
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
        private StudentDAL studentDAL;

        public StudentController()
        {
            this.courseDAL = new CourseDAL();
            this.gradesDAL = new GradeItemDAL();
            this.rubricDAL = new RubricDAL();
            this.studentDAL = new StudentDAL();
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

            var studentID = (Session["user"] as Student).StudentId;

            var courses = this.courseDAL.GetCoursesByStudent(studentID);

            return View("CoursesHome", courses);
        }

        public ActionResult Course(int courseID)
        {
            var course = this.courseDAL.getCourseById(courseID);

            ViewBag.isEnrolled = this.courseDAL.IsStudentEnrolled((Session["user"] as Student).StudentId, courseID);

            return View("Course", course);
        }

        public ActionResult CourseEnroll(int studentID)
        {
            var student = this.studentDAL.GetStudentByID(studentID);

            var model = new CourseEnrollViewModel()
            {
                EnrollableCourses = this.courseDAL.getEnrollableCourses(student),
                EnrolledCourses = this.courseDAL.GetCoursesByStudent(studentID)
            };

            ViewBag.studentID = studentID;

            return View("CourseEnroll", model);
        }

        public ActionResult EnrollIntoCourse(int courseID, int studentID)
        {
            if (this.courseDAL.CanEnroll(studentID, courseID))
            {
                this.studentDAL.EnrollIntoCouse(courseID, studentID);
            }
            else
            {
                TempData["error"] = "Could not enroll.";
            }

            return RedirectToAction("CourseEnroll", new { studentID = studentID });
        }

        public ActionResult DropCourse(int courseID)
        {
            var studentID = (Session["user"] as Student).StudentId;

            this.studentDAL.DropCourse(courseID, studentID);

            return RedirectToAction("CoursesHome");
        }

        public ActionResult GradeItemHome(int courseID)
        {
            //Get grades from the courseID given and the "LoginID" from the session
            var studentID = (Session["user"] as Student).StudentId;
            var grades = this.gradesDAL.GetGradeItemsForStudentInClass(studentID, courseID);
            var course = this.courseDAL.getCourseById(courseID);

            var overallGrade = 0.0;

            var gradeDict = new Dictionary<int, double>();

            foreach(var grade in grades)
            {
                if(!double.IsNaN(grade.Grade))
                {
                    if (gradeDict.ContainsKey(grade.WeightType))
                {
                    gradeDict[grade.WeightType] += (grade.Grade / grade.MaxGrade);
                }
                else
                {
                    gradeDict[grade.WeightType] = (grade.Grade / grade.MaxGrade);
                }
                }
            }

            foreach(var calcGrade in gradeDict)
            {
                var hold = this.rubricDAL.GetWeightTypeById(calcGrade.Key);
                overallGrade += calcGrade.Value * (course.Rubric.RubricValues[this.rubricDAL.GetWeightTypeById(calcGrade.Key)] / 100);
            }

            ViewBag.OverallGrade = overallGrade;

            return View("GradeItemHome", grades);
        }

        public ActionResult GradeItem(int gradeItemID)
        {
            var gradeItem = this.gradesDAL.GetGradeItemByID(gradeItemID);

            return View("GradeItem", gradeItem);
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

        #region default scaffold

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
        #endregion
    }
}
