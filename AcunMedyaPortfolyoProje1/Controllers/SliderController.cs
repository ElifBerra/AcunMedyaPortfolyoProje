using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;
namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class SliderController : Controller
    {
        // GET: Slider
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            var values = db.Tbl_Slider.ToList();

            return View(values);
        }
        public ActionResult RemoveSlider(int id)
        {
            var values = db.Tbl_Slider.Find(id);
            db.Tbl_Slider.Remove(values);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateSlider()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateSlider(Tbl_Slider _Slider) //Slider ıd, Slider name 
        {
            db.Tbl_Slider.Add(_Slider);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateSlider(int id)
        {
            var values = db.Tbl_Slider.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateSlider(Tbl_Slider model)
        {
            var value = db.Tbl_Slider.Find(model.SliderID);
            value.NameSurname = model.NameSurname;
            value.Description = model.Description;
            value.ImageUrl = model.ImageUrl;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}