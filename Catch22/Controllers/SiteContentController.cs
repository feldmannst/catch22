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
    [Authorize(Roles = "EditSiteContent")]
    public class SiteContentController : Controller
    {
        Catch22DataEntities db = new Catch22DataEntities();
        // GET: SiteContent
        public ActionResult Index(bool successMessage = false)
        {
            ViewBag.Success = successMessage;
            var model = db.SiteContents.Where(a => a.SiteContentID == 1).Single();
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(SiteContent model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { successMessage = true });
            }
            return View(model);
        }
    }
}