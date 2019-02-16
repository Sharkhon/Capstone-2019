using CaterCroweCapstone2019.Models.DAL;
using CaterCroweCapstone2019.Models.DAL.DALModels;
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
        private RubricDAL RubricDAL = new RubricDAL();
        private WeightTypeDAL WeightTypeDAL = new WeightTypeDAL();

        // GET: GradeItem
        public ActionResult Index()
        {
            //var gradeItems = this.DAL.GetAllGradeItems();

            //var rubric = this.RubricDAL.getRubricByCourseId(1);

            //var gradeAmounts = new Dictionary<int, double>();
            //var gradeCounts = new Dictionary<int, int>();
            //var weightTypes = this.WeightTypeDAL.getWeightTypes();

            //var maxPoints = 0.0;

            //foreach (var current in rubric.RubricValues)
            //{
            //    maxPoints += current.Value;
            //}

            //foreach (var item in gradeItems)
            //{
            //    if (!gradeAmounts.Keys.Contains(item.WeightType))
            //    {
            //        gradeAmounts.Add(item.WeightType, item.Grade);
            //        gradeCounts.Add(item.WeightType, 1);
            //    }
            //    else
            //    {
            //        gradeAmounts[item.WeightType] += item.Grade;
            //        gradeCounts[item.WeightType]++;
            //    }
            //}

            //var total = 0.0;

            //foreach (var index in gradeAmounts.Keys)
            //{
            //    total += gradeAmounts[index] / Convert.ToDouble(gradeCounts[index]) * (rubric.RubricValues[weightTypes[index]] / maxPoints);
            //}

            //ViewBag.totalGrade = total;

            //return View("Index", gradeItems);
            return View("Index");
        }

        // GET: GradeItem/Details/5
        public ActionResult Details(int id)
        {
            var gradeItem = this.DAL.GetGradeItemByID(id);

            return View("Details", gradeItem);
        }

        // GET: GradeItem/Create
        public ActionResult Create()
        {
            ViewBag.weightTypes = new SelectList(this.WeightTypeDAL.getWeightTypes(), "key", "value");

            return View("Create");
        }

        // POST: GradeItem/Create
        [HttpPost]
        public ActionResult Create(GradeItem gradeItem)
        {
            try
            { 
                var result = this.DAL.insertGradeItem(gradeItem);

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View("Create");
            }
        }

        // GET: GradeItem/Edit/5
        public ActionResult Edit(int id)
        {
            var gradeItem = this.DAL.GetGradeItemByID(id);
            ViewBag.weightTypes = new SelectList(this.WeightTypeDAL.getWeightTypes(), "key", "value", gradeItem.WeightType);

            return View("Edit", gradeItem);
        }

        // POST: GradeItem/Edit/5
        [HttpPost]
        public ActionResult Edit(GradeItem gradeItem)
        {
            try
            {
                var result = this.DAL.UpdateGradeItem(gradeItem);

                return RedirectToAction("Index");
            }
            catch
            {
                return View("Edit");
            }
        }

        // GET: GradeItem/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Delete");
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
                return View("Delete");
            }
        }
    }
}
