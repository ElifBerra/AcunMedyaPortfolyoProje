using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;
namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
        public ActionResult Index()
        {
            var values = db.Tbl_Message.ToList();

            return View(values);
        }
        public ActionResult RemoveMessage(int id)
        {
            var values = db.Tbl_Message.Find(id);
            db.Tbl_Message.Remove(values);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult CreateMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMessage(Tbl_Message _Message) //Message ıd, Message name 
        {
            db.Tbl_Message.Add(_Message);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateMessage(int id)
        {
            var values = db.Tbl_Message.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateMessage(Tbl_Message model)
        {
            var value = db.Tbl_Message.Find(model.MessageID);
            value.NameSurname = model.NameSurname;
            value.Mail = model.Mail;
            value.Subject = model.Subject;
            value.MessageContent = model.MessageContent;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}