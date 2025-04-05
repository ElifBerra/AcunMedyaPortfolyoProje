using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;
namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            var values = db.Tbl_Education.ToList();

            return View(values);
            
        }
        public ActionResult RemoveEducation(int id)
        {
            var values = db.Tbl_Education.Find(id);
            db.Tbl_Education.Remove(values);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateEducation()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateEducation(Tbl_Education _Education) //Education ıd, Education name 
        {
            db.Tbl_Education.Add(_Education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var values = db.Tbl_Education.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateEducation(Tbl_Education model)
        {
            var value = db.Tbl_Education.Find(model.EducationID);
            value.StartYear = model.StartYear;
            value.EndYear = model.EndYear;
            value.Name = model.Name;
            value.Description = model.Description;
            value.Section = model.Section;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}