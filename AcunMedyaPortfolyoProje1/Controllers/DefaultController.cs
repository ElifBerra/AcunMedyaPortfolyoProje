using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;

namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class DefaultController : Controller
    {
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.Tbl_Testimonial.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialHero()
        {
            var values = db.Tbl_Slider.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAbout()
        {
            var values = db.Tbl_About.ToList();
            return PartialView(values);  
        }
        public PartialViewResult PartialSkills()
        {
            var values = db.Tbl_Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialEducation()
        {
            var values = db.Tbl_Education.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialJob()
        {
            var values = db.Tbl_Job.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialServices()
        {
            var values = db.Tbl_Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialPortfolio()
        {
            var values = db.Tbl_Project.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialContact()
        {
            var values = db.Tbl_Contact.ToList();
            return PartialView(values);
        }
        public ActionResult PartialMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult PartialMessage(Tbl_Message message)
        {
            db.Tbl_Message.Add(message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}