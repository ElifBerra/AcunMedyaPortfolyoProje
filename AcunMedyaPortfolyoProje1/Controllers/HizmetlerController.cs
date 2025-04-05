using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;
namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class HizmetlerController : Controller
    {
        // GET: Hizmetler
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            var values = db.Tbl_Services.ToList();

            return View(values);
        }
        public ActionResult RemoveServices(int id)
        {
            var values = db.Tbl_Services.Find(id);
            db.Tbl_Services.Remove(values);
            db.SaveChanges();
            return RedirectToAction("Index");
        
        }

        [HttpGet]
        public ActionResult CreateServices()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateServices(Tbl_Services _Services) //Services ıd, Services name 
        {
            db.Tbl_Services.Add(_Services);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateServices(int id)
        {
            var values = db.Tbl_Services.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateServices(Tbl_Services model)
        {
            var value = db.Tbl_Services.Find(model.ServicesID);
            value.Description = model.Description;
            value.Title = model.Title;
            value.IconUrl = model.IconUrl;
            value.Description2 = model.Description2;
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
 
}