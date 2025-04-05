using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;
namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            var values = db.Tbl_Skills.ToList();

            return View(values);
        }
        public ActionResult RemoveSkills(int id)
        {
            var values = db.Tbl_Skills.Find(id);
            db.Tbl_Skills.Remove(values);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateSkills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSkills(Tbl_Skills _Skills) //Skills ıd, Skills name 
        {
            db.Tbl_Skills.Add(_Skills);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSkills(int id)
        {
            var values = db.Tbl_Skills.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateSkills(Tbl_Skills model)
        {
            var value = db.Tbl_Skills.Find(model.SkillID);
            value.SkillName = model.SkillName;
            value.Derece = model.Derece;
            value.Description = model.Description;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}