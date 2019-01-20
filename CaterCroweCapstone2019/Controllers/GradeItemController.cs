using CaterCroweCapstone2019.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CaterCroweCapstone2019.Controllers
{
    public class GradeItemController : Controller
    {
        private GradeItemDAL DAL = new GradeItemDAL();

        // GET: GradeItem
        public ActionResult Index()
        {

            var gradeItems = this.DAL.GetAllGradeItems();

            return View(gradeItems);
        }

        // GET: GradeItem/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: GradeItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GradeItem/Create
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

        // GET: GradeItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: GradeItem/Edit/5
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

        // GET: GradeItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GradeItem/Delete/5
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
