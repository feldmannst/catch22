using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Catch22.Models;

namespace Catch22.Controllers
{
    [Authorize(Roles = "EditPerformances")]
    public class PerformanceController : Controller
    {
        Catch22DataEntities db = new Catch22DataEntities();
        // GET: Performance
        public ActionResult Index()
        {
            PerformancesViewModel model = new PerformancesViewModel();
            model.AllPerformances = db.Performances.ToList();
            model.NewPerformance = new Performance();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Performance model)
        {
            if (ModelState.IsValid)
            {
                db.Performances.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var performance = db.Performances.Where(a => a.PerformanceID == id).First();
            if (performance == null)
            {
                return HttpNotFound();
            }

            return View(performance);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Performance model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var performance = db.Performances.Where(a => a.PerformanceID == id).First();
            if (performance == null)
            {
                return HttpNotFound();
            }

            db.Performances.Remove(performance);
            db.SaveChanges();
            return Content(Boolean.TrueString);
        }
    }
}