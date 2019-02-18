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
    public class TeacherController : Controller
    {
        private CourseDAL courseDAL;
        private GradeItemDAL gradeItemDAL;
        private RubricDAL rubricDAL;
        private WeightTypeDAL weightTypeDAL;

        public TeacherController()
        {
            this.courseDAL = new CourseDAL();
            this.gradeItemDAL = new GradeItemDAL();
            this.rubricDAL = new RubricDAL();
            this.weightTypeDAL = new WeightTypeDAL();
        }

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoursesHome()
        {
            var teacherID = (Session["user"] as Teacher).TeacherId;

            var courses = this.courseDAL.GetCoursesByTeacher(teacherID);

            return View("CoursesHome", courses);
        }

        public ActionResult Course(int courseID)
        {
            var course = this.courseDAL.getCourseById(courseID);

            return View("Course", course);
        }

        public ActionResult Grades(int courseID)
        {
            var grades = new List<GradeItem>();

            return View("Grades", grades);
        }

        #region GradeItem

        public ActionResult GradeItemHome(int courseID)
        {
            var grades = this.gradeItemDAL.GetGradeItemsForCourse(courseID);

            ViewBag.courseID = courseID;

            return View("GradeItemHome", grades);
        }

        public ActionResult EditGradeItem(int gradeItemID)
        {
            var gradeItem = this.gradeItemDAL.GetGradeItemByID(gradeItemID);

            return View("EditGradeItem", gradeItem);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult EditGradeItem(GradeItem gradeItem)
        {

            this.gradeItemDAL.UpdateGradeItem(gradeItem);

            return RedirectToAction("GradeItemHome", new { courseID = gradeItem.CourseID });
        }

        public ActionResult CreateGradeItem(int courseID)
        {
            ViewBag.weightTypes = new SelectList(this.weightTypeDAL.getWeightTypesInCourse(courseID), "Key", "Value");

            var newItem = new GradeItem()
            {
                CourseID = courseID
            };

            return View("CreateGradeItem", newItem);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateGradeItem(GradeItem gradeItem)
        {
            this.gradeItemDAL.insertGradeItem(gradeItem);

            return RedirectToAction("Course", new { courseID = gradeItem.CourseID });
        }

        public ActionResult GradeGradeItem(int gradeItemID, int courseID)
        {
            var viewModel = new GradeGradeItemViewModel()
            {
                CourseID = courseID
            };
            
            var studentsInCourse = this.courseDAL.GetAllStudentsInCourse(courseID);
            
            foreach(var student in studentsInCourse)
            {
                var gradeItemForStudent = this.gradeItemDAL.GetGradeItemForStudent(student.StudentId, gradeItemID);

                viewModel.GradeItemsByStudentID.Add(student.StudentId, gradeItemForStudent);
                viewModel.StudentsByStudentID.Add(student.StudentId, student);
                viewModel.GradeByStudentID.Add(student.StudentId, gradeItemForStudent.Grade);
            }

            return View("GradeGradeItem", viewModel);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult GradeGradeItem(GradeGradeItemViewModel viewModel)
        {
            foreach(var item in viewModel.GradeByStudentID)
            {
                this.gradeItemDAL.GradeGradeItemByParameters(item.Key, viewModel.GradeItemID, item.Value);
            }

            //TODO Maybe show errors?

            return RedirectToAction("GradeItemHome", new { courseID = viewModel.CourseID });
        }

        #endregion

        #region Rubric

        public ActionResult Rubric(int courseID)
        {
            var rubric = this.rubricDAL.getRubricByCourseId(courseID);

            return View("Rubric", rubric);
        }

        public ActionResult RubricEdit(int courseID)
        {
            var rubric = this.rubricDAL.getRubricByCourseId(courseID);

            return View("RubricEdit", rubric);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult RubricEdit(Rubric rubric)
        {
            var result = this.rubricDAL.updateRubricByRubric(rubric);

            if(result > 0)
            {
                return RedirectToAction("Course", new { courseID = rubric.CourseID });
            }
            else
            {
                return View("RubricEdit", rubric.CourseID);
            }
           
        }

        [HttpPost]
        [AllowAnonymous]
        public void AddRubricType(string type)
        {
            try
            {
                this.weightTypeDAL.addWeightType(type);
            }
            catch (Exception e)
            {
                //Throw error to view saying that the weight type is not unique
            }
        }

        #endregion

        public ActionResult Assignment(int assignmentID)
        {
            return View("Assignment");
        }

        // GET: Teacher/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Teacher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Teacher/Create
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

        // GET: Teacher/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Teacher/Edit/5
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

        // GET: Teacher/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Teacher/Delete/5
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
