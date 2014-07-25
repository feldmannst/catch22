using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Catch22.Models;

namespace Catch22.Controllers
{
    public class HomeController : Controller
    {
        private readonly Catch22DataEntities db;

        public HomeController()
        {
            db = new Catch22DataEntities();
        }
        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();
            model.MainBlurb = db.SiteContents.Where(a => a.SiteContentID == 1).Select(b => b.ContentText).Single().ToString();
            model.Performances = db.Performances.Where(a => a.PerformanceDate >= DateTime.Now).OrderBy(b => b.PerformanceDate).ToList();
            model.Repertoire = db.Repertoires.Where(a => a.Retired == false).ToList();
            model.MemberBios = db.MemberBios.Where(a => a.User.ActiveGroupMember == true).OrderBy(a => a.User.FirstName).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult SendContactEmail(MailModel model)
        {
            if (ModelState.IsValid)
            {
                MailMessage mail = new MailMessage();

                mail.To.Add("feldmannst@gmail.com");
                mail.From = new MailAddress("website@catch22nc.org");
                mail.Subject = model.Subject;
                string body = "<h3>" + model.ContactName + "<br /> Email Address:" + model.ReturnEmail + "<br /><small>via www.catch22nc.org</small></h3>" + model.Body;
                mail.Body = body;
                mail.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Send(mail);
                RedirectToAction("Index", "Home");
                return View();
            }
            else
            {
                return View();
            }
        }
    }
}