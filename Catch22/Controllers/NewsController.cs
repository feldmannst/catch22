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
    [Authorize(Roles="EditNews")]
    public class NewsController : Controller
    {
        Catch22DataEntities db = new Catch22DataEntities();
        // GET: News
        public ActionResult Index()
        {
            var dataSet = db.News.ToList();
            return View(dataSet);
        }

        [HttpPost]
        public ActionResult Create(string news_text, string expdate)
        {
            var userentered = db.Users.Where(a => a.UserName == User.Identity.Name).First();
            DateTime date = Convert.ToDateTime(expdate);
            var newsitem = new News()
            {
                NewsText = news_text,
                ExpirationDate = date,
                User = userentered,
                UserID = userentered.Id
            };

            db.News.Add(newsitem);
            db.SaveChanges();
            return RedirectToAction("Index", "News");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsitem = db.News.Where(a => a.NewsID == id).First();
            if (newsitem == null)
            {
                return HttpNotFound();
            }

            return View(newsitem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
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
            var newsitem = db.News.Where(a => a.NewsID == id).First();
            if (newsitem == null)
            {
                return HttpNotFound();
            }

            db.News.Remove(newsitem);
            db.SaveChanges();
            return Content(Boolean.TrueString);
        }
    }
}