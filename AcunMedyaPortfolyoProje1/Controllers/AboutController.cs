using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;

namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class AboutController : Controller
    {
        // GET: About
        //public ActionResult Index()
        //{
        //    return View();
        //}
        // GET: Categories
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            var deger = db.Tbl_About.ToList();

            return View(deger);
        }

        public ActionResult RemoveAbout(int id)
        {
            var deger = db.Tbl_About.Find(id);
            db.Tbl_About.Remove(deger);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }
        //[httpget] [httppost]

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(Tbl_About _About) //About ıd, About name 
        {
            db.Tbl_About.Add(_About);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var values = db.Tbl_About.Find(id);
            return View(values);

        }

        public ActionResult UpdateAbout(Tbl_About model)
        {
            var value = db.Tbl_About.Find(model.AboutID);

            value.ImageUrl = model.ImageUrl;
            value.Title = model.Title;
            value.BirthDay = model.BirthDay;
            value.WebSite = model.WebSite;
            value.Phone = model.Phone;
            value.City = model.City;
            value.Age = model.Age;
            value.Email = model.Email;
            value.Freelance = model.Freelance;            
            value.Description1 = model.Description1;
            value.Desciption2 = model.Desciption2;
            value.Degree = model.Degree ;  
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}