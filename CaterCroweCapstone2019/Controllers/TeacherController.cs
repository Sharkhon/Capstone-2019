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
        private StudentDAL studentDAL;

        public TeacherController()
        {
            this.courseDAL = new CourseDAL();
            this.gradeItemDAL = new GradeItemDAL();
            this.rubricDAL = new RubricDAL();
            this.weightTypeDAL = new WeightTypeDAL();
            this.studentDAL = new StudentDAL();
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

        #region Final Grade

        public ActionResult FinalGrade(int courseID)
        {
            var students = this.courseDAL.GetAllStudentsInCourse(courseID);
            var model = new List<TeacherFinalGradeViewModel>();

            foreach (var student in students)
            {
                model.Add(new TeacherFinalGradeViewModel()
                {
                    CourseID = courseID,
                    GradeEarned = this.studentDAL.GetFinalGrade(student.StudentId, courseID),
                    StudentID = student.StudentId,
                    StudentName = student.Username
                });
            }

            return View("FinalGrade", model);
        }

        [HttpGet]
        public ActionResult FinalGradeEdit(int courseID)
        {
            var students = this.courseDAL.GetAllStudentsInCourse(courseID);
            var model = new List<TeacherFinalGradeViewModel>();

            foreach (var student in students)
            {
                model.Add(new TeacherFinalGradeViewModel()
                {
                    CourseID = courseID,
                    GradeEarned = this.studentDAL.GetFinalGrade(student.StudentId, courseID),
                    StudentID = student.StudentId,
                    StudentName = student.Username
                });
            }

            ViewBag.courseID = courseID;

            return View("FinalGradeEdit", model);
        }

        [HttpPost]
        public ActionResult FinalGradeEdit(List<TeacherFinalGradeViewModel> model)
        {
            try
            {
                foreach (var finalGrade in model)
                {
                    this.studentDAL.AssignFinalGradeByStudentIdAndCourseID(finalGrade.StudentID, finalGrade.CourseID, finalGrade.GradeEarned);
                }
            }
            catch (Exception e)
            {
                TempData["error"] = "Could not push final grades. Please try again later.";
                return View("FinalGradeEdit", model);
            }

            return RedirectToAction("FinalGrade", new { courseID = model[0].CourseID });
        }

        #endregion

        #region GradeItem

        public ActionResult GradeItemHome(int courseID)
        {
            var model = new Dictionary<GradeItem, List<GradeItem>>();
            var grades = this.gradeItemDAL.GetGradeItemsForCourse(courseID);
            var students = this.courseDAL.GetAllStudentsInCourse(courseID);

            foreach(var item in grades)
            {
                if(!model.Keys.Contains(item))
                {
                    model.Add(item, new List<GradeItem>());
                }
                foreach (var student in students)
                {
                    model[item].Add(this.gradeItemDAL.GetGradeItemForStudent(student.StudentId, item.ID));
                }
            }

            ViewBag.courseID = courseID;

            return View("GradeItemHome", model);
        }

        public ActionResult GradeItemGrades(int gradeItemID, int courseID)
        {
            var viewModel = new GradeGradeItemViewModel()
            {
                CourseID = courseID
            };

            var studentsInCourse = this.courseDAL.GetAllStudentsInCourse(courseID);

            foreach (var student in studentsInCourse)
            {
                var gradeItemForStudent = this.gradeItemDAL.GetGradeItemForStudent(student.StudentId, gradeItemID);

                viewModel.GradeItemsByStudentID.Add(student.StudentId, gradeItemForStudent);
                viewModel.StudentsByStudentID.Add(student.StudentId, student);
                viewModel.GradeByStudentID.Add(student.StudentId, gradeItemForStudent.Grade);
            }

            return View("GradeItemGrades", viewModel);
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
