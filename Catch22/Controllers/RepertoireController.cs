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
    [Authorize(Roles = "EditRepertoire")]
    public class RepertoireController : Controller
    {
        Catch22DataEntities db = new Catch22DataEntities();
        // GET: Repertoire
        public ActionResult Index()
        {
            RepertoireViewModel model = new RepertoireViewModel();
            model.AllRep = db.Repertoires.ToList();
            model.NewRep = new Repertoire();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Repertoire model)
        {
            if (ModelState.IsValid)
            {
                db.Repertoires.Add(model);
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
            var repertoire = db.Repertoires.Where(a => a.RepertoireID == id).First();
            if (repertoire == null)
            {
                return HttpNotFound();
            }

            return View(repertoire);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Repertoire model)
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
            var repertoire = db.Repertoires.Where(a => a.RepertoireID == id).First();
            if (repertoire == null)
            {
                return HttpNotFound();
            }

            db.Repertoires.Remove(repertoire);
            db.SaveChanges();
            return Content(Boolean.TrueString);
        }
    }
}