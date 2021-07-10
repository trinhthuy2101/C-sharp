using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxUniversityController : AjaxController
    {
        // GET: AjaxUniversity
        public ActionResult Index()
        {
            List<University > UniversityList = DB.Universities.ToList();
            return View(UniversityList);
        }
        public JsonResult Details(string id)
        {
            University u = DB.Universities.Find(id);
            UniversityModel u1 = new UniversityModel();
            u1.U_id = u.U_id;
            u1.name = u.name;
            return Json(u1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            University u = DB.Universities.Find(id);
            DB.Universities.Remove(u);
            DB.SaveChanges();
            UniversityModel u1 = new UniversityModel();
            u1.U_id = u.U_id;
            u1.name = u.name;
            return Json(u1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string U_id, string name)
        {
            var u1 = DB.Universities.Find(U_id);
            if (u1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            University u = new University();
            u.U_id =U_id;
            u.name = name;
            if (ModelState.IsValid)
            {
                DB.Universities.Add(u);
                DB.SaveChanges();
            }
            return Json(u, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string U_id, string name)
        {
            var u1 = DB.Universities.Find(U_id);
            u1.name = name;
            DB.Entry(u1).State = EntityState.Modified;
            DB.SaveChanges();
            UniversityModel u = new UniversityModel();
            u.U_id = u1.U_id;
            u.name = u1.name;
            return Json(u, JsonRequestBehavior.AllowGet);
        }
    }
}