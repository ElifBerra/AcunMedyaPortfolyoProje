using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;

namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            var deger = db.Tbl_Category.ToList();

            return View(deger);
        }

        public ActionResult RemoveCategory(int id)
        {    
            var deger = db.Tbl_Category.Find(id);
            db.Tbl_Category.Remove(deger);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }
        //[httpget] [httppost]

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();  
        }
        [HttpPost]
        public ActionResult CreateCategory(Tbl_Category _Category) //category ıd, category name 
        {
            db.Tbl_Category.Add(_Category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id) 
        {
            var values = db.Tbl_Category.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateCategory(Tbl_Category model)
        {
            var value = db.Tbl_Category.Find(model.CategoryID);
            value.CategoryName = model.CategoryName;
            
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}