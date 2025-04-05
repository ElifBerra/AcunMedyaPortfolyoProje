using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;

namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class ContactController : Controller
    {
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        // GET: Contact
        public ActionResult Index()
        {
            var values = db.Tbl_Contact.ToList();

            return View(values);
        }
        public ActionResult RemoveContact(int id)
        {
            var values = db.Tbl_Contact.Find(id);
            db.Tbl_Contact.Remove(values);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateContact()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateContact(Tbl_Contact _Contact) //contact ıd, contact name 
        {
            db.Tbl_Contact.Add(_Contact);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateContact(int id)
        {
            var values = db.Tbl_Contact.Find(id);
            return View(values);

        }
        [HttpPost]
        public ActionResult UpdateContact(Tbl_Contact model)
        {
            var value = db.Tbl_Contact.Find(model.ContactID);
            value.Description = model.Description;
            value.Adress = model.Adress;
            value.Email = model.Email;
            value.Phone = model.Phone;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}