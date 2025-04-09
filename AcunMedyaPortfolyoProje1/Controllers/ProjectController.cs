using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AcunMedyaPortfolyoProje1.Models;

namespace AcunMedyaPortfolyoProje1.Controllers
{
    public class ProjectController : Controller
    {
        // GET: Project
        DbAcunMedyaProject1Entities db = new DbAcunMedyaProject1Entities();
       
        public ActionResult Index()
        {
            var values = db.Tbl_Project.ToList();
            return View(values);
        }
        public ActionResult RemoveProject(int id)
        {
            var values = db.Tbl_Project.Find(id);
            db.Tbl_Project.Remove(values);
            db.SaveChanges(); //ctrl s
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Tbl_Project _Project) //Project ıd, Project name 
        {
            db.Tbl_Project.Add(_Project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var values = db.Tbl_Project.Find(id);
            return View(values);

        }

        [HttpPost]
        public ActionResult UpdateProject(Tbl_Project model)
        {
            var value = db.Tbl_Project.Find(model.ProjectID);
            value.ProjectName = model.ProjectName;
            value.Description = model.Description;
            value.ProjectLink = model.ProjectLink;
            value.Image1 = model.Image1;
            value.Image2 = model.Image2;
            value.Image3 = model.Image3;
            value.Tbl_Category.CategoryName = model.Tbl_Category.CategoryName;

            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}