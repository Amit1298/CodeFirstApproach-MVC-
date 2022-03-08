using CodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        StudentContaxt db = new StudentContaxt();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid == true)
            {
                db.Students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.InsertMessage = "<script>alert('Data is created successfully')</script>";
                    TempData["InsertMessage"] = "<script>alert('Data is created successfully')</script>";
                    return RedirectToAction("Index");
                   // ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data is not created')</script>";
                }
            }
            
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            db.Entry(s).State = EntityState.Modified;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.UpdateMessage = "<script>alert('Data Updated')</script>";
                ModelState.Clear();
            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('Data not Updated')</script>";
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var StudentIdRow = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(StudentIdRow);
        }
        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                TempData["DeleteMessage"] = "<script>alert('Data Deleted !!')</script>";
            }
            else
            {
                TempData["DeleteMessage"] = "<script>alert('Data not Deleted !!')</script>";
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var DetailsById = db.Students.Where(model => model.Id == id).FirstOrDefault();
            return View(DetailsById);
        }
    }
}