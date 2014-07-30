using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Catch22.Models;

namespace Catch22.Controllers
{
    [Authorize]
    public class CMSController : Controller
    {
        Catch22DataEntities db = new Catch22DataEntities();
        // GET: CMS
        public ActionResult Index()
        {
            CMSHomeViewModel model = new CMSHomeViewModel();
            model.NewsItems = db.News.Where(a => a.ExpirationDate > DateTime.Now).ToList();
            return View(model);
        }

        public ActionResult Calendar()
        {
            return View();
        }

        public ActionResult MemberBioEdit(int? id)
        {
            MemberBio memberBio;
            List<SelectListItem> allUsers = new List<SelectListItem>();
            if (id == null)
            {
                memberBio = db.MemberBios.Where(a => a.User.UserName == User.Identity.Name).Single();
            }
            else
            {
                if (!User.IsInRole("EditMemberBios"))
                {
                    memberBio = db.MemberBios.Where(a => a.User.UserName == User.Identity.Name).Single();
                }
                else
                {
                    memberBio = db.MemberBios.Where(a => a.UserID == id).Single();
                }
            }
            if (memberBio == null)
            {
                return HttpNotFound();
            }
            foreach (var user in db.Users)
            {
                var name = user.FirstName + " " + user.LastName;
                var item = new SelectListItem() { Text = name, Value = user.Id.ToString() };
                allUsers.Add(item);
            }
            ViewBag.AllUsers = allUsers;
            return View(memberBio);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult MemberBioEdit(MemberBio model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("MemberBioEdit");
            }
            return View(model);
        }
    }
}