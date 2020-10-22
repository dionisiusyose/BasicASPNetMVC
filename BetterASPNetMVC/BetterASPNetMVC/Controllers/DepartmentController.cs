using BetterASPNetMVC.Context;
using BetterASPNetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BetterASPNetMVC.Controllers
{
    public class DepartmentController : Controller
    {
        MyContext myContext = new MyContext();
        // GET: Department
        public ActionResult Index()
        {
            return View(myContext.Departments.ToList());
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = myContext.Departments.Find(id);
            if(department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }
        // To create View of this Action result 
        public ActionResult Create()
        {
            return View();
        }
        // Specify the type of attribute i.e. 
        // it will add the record to the database 
        [HttpPost]
        public ActionResult Create(Department department)
        {
            myContext.Departments.Add(department);
            myContext.SaveChanges();
            return RedirectToAction("index");               // Mengembalikan ke Index
        }

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = myContext.Departments.Where(a => a.Id == id).SingleOrDefault();
            if(department == null)
            {
                return HttpNotFound();
            }
            
            return View(department);
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, Department department)
        {
            Department updateDepartment = myContext.Departments.Where(a => a.Id == id).FirstOrDefault();

            if (updateDepartment != null)
            {
                updateDepartment.Name = department.Name;
                myContext.SaveChanges();
                return RedirectToAction("index");
            }
            else return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = myContext.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        [HttpPost] [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Department deleteDepartment = myContext.Departments.Where(x => x.Id == id).FirstOrDefault();
            if (deleteDepartment != null)
            {
                myContext.Departments.Remove(deleteDepartment);
                myContext.SaveChanges();
                return RedirectToAction("index");
            }
            else return View();
        }
    }
}