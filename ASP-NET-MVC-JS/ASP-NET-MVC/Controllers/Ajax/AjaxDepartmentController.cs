using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxDepartmentController : AjaxController
    {
        // GET: AjaxDepartment
        public ActionResult Index()
        {
            List<Department> DepartmentList = DB.Departments.ToList();
            return View(DepartmentList);
        }
        public JsonResult Details(string id)
        {
            Department d = DB.Departments.Find(id);
            DepartmentModel d1 = new DepartmentModel();
            d1.D_id = d.D_id;
            d1.uni = d.uni;
            d1.name = d.name;
            return Json(d1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            Department d = DB.Departments.Find(id);
            DB.Departments.Remove(d);
            DB.SaveChanges();
            return Json(d, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string D_id, string uni,string name)
        {
            var d1 = DB.Departments.Find(D_id);
            if (d1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Department d = new Department();
            d.D_id = D_id;
            d.uni= uni;
            d.name = name;
            if (ModelState.IsValid)
            {
                DB.Departments.Add(d);
                DB.SaveChanges();
            }
            return Json(d, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string D_id, string uni,string name)
        {
            var d1 = DB.Departments.Find(D_id);
            d1.uni = uni;
            d1.name = name;
            DB.Entry(d1).State = EntityState.Modified;
            DB.SaveChanges();
            DepartmentModel d = new DepartmentModel();
            d.D_id = d1.D_id;
            d.uni = d1.uni;
            d.name = d1.name;
            return Json(d, JsonRequestBehavior.AllowGet);
        }
    }
}