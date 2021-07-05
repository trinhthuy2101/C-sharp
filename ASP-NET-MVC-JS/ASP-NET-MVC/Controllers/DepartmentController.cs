using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;
using System.Data.SqlClient;
using System.Data;
using System.Data.Entity;

namespace ASP_NET_MVC.Controllers
{
    public class DepartmentController : BaseController
    {
        //SHOW
        public ActionResult Index()
        {
            List<Department> depList = DB.Departments.ToList();
            return View(depList);
        }
        //ADD CLASS
        public ActionResult AddDepartment()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveDepartment(Department dep)
        {
            var cl = DB.Departments.Find(dep.D_id);
            if (cl != null)
            {
                return RedirectToAction("Notification", "Department");
            }
            if (ModelState.IsValid)
            {
                DB.Departments.Add(dep);
                dep.create_date= DateTime.Now;
                DB.SaveChanges();
            }
            return RedirectToAction("Index", "Department");
        }
        public ActionResult Notification()
        {
            return View();
        }
        //REMOVE
        public ActionResult RemoveDepartment(string id)
        {
            var dep = DB.Departments.FirstOrDefault(de => de.D_id == id);
            DB.Departments.Remove(dep);
            DB.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
        //UPDATE
        public ActionResult UpdateDepartment(string id)
        {
            var dep = DB.Departments.FirstOrDefault(de => de.D_id == id);
            return View(dep);
        }
        public ActionResult SaveUpdateDepartment(Department d)
        {
            var d1 = DB.Departments.Find(d.D_id);
            if (d.uni != null) d1.uni = d.uni;
            if (d.name != null) d1.name = d.name;
            DB.Entry(d1).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index", "Department");
        }
    }
}