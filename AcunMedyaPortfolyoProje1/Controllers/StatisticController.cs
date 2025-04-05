using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;
namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class StatisticController : Controller
    {
        // GET: Statistic
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            ViewBag.CategoryCount = db.Tbl_Category.Count();
            ViewBag.testimonialCount = db.Tbl_Testimonial.Count();
            //ViewBag.projectCount = db.Tbl_Project.Count();
            ViewBag.jobCount = db.Tbl_Job.Count();
            ViewBag.serviceCount = db.Tbl_Services.Count();
            ViewBag.skillCount = db.Tbl_Skills.Count();
            ViewBag.testimonialCount = db.Tbl_Testimonial.Count();
            ViewBag.messageCount = db.Tbl_Message.Count();
            ViewBag.lastCategory = db.Tbl_Category.OrderByDescending(x => x.CategoryID).Select(x => x.CategoryName).FirstOrDefault();
            ViewBag.lastTestimonial = db.Tbl_Testimonial.OrderByDescending(x => x.TestimonialID).Select(x => x.TestimonialName).FirstOrDefault();
            //ViewBag.lastProject = db.Tbl_Project.OrderByDescending(x => x.ProjectID).Select(x => x.ProjectName).FirstOrDefault();
            ViewBag.lastJob = db.Tbl_Job.OrderByDescending(x => x.JobID).Select(x => x.Title).FirstOrDefault();
            ViewBag.lastService = db.Tbl_Services.OrderByDescending(x => x.ServicesID).Select(x => x.Title).FirstOrDefault();
            ViewBag.lastSkill = db.Tbl_Skills.OrderByDescending(x => x.SkillID).Select(x => x.SkillName).FirstOrDefault();
            ViewBag.lastMessage = db.Tbl_Message.OrderByDescending(x => x.MessageID).Select(x => x.MessageContent).FirstOrDefault();

            return View();
        }
    }
}