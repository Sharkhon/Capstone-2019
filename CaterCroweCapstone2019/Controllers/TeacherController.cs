﻿using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels;
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

        public TeacherController()
        {
            this.courseDAL = new CourseDAL();
            this.gradeItemDAL = new GradeItemDAL();
            this.rubricDAL = new RubricDAL();
        }

        // GET: Teacher
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CoursesHome()
        {
            //TODO: This will pull the courses that the student is in.
            //Maybe store the student in the session data.

            var teacherID = Convert.ToInt32(Session["LoginID"]);

            var courses = this.courseDAL.GetCoursesByStudent(teacherID);

            return View("CourseHome", courses);
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

        public ActionResult CreateGradeItem()
        {
            return View("CreateGradeItem");
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult CreateGradeItem(GradeItem gradeItem)
        {
            //Do the creation

            return RedirectToAction("Course", new { courseID = gradeItem.CourseID });
        }

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
