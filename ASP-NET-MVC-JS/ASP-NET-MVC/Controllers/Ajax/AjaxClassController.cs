using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxClassController : AjaxController
    {
        // GET: AjaxClass
        public ActionResult Index()
        {
            List<Class> classList = DB.Classes.ToList();
            return View(classList);
        }
        public JsonResult Details(string id)
        {
            Class c = DB.Classes.Find(id);
            ClassModel c1 = new ClassModel();
            c1.C_id = c.C_id;
            c1.dep = c.dep;
            return Json(c1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            Class c = DB.Classes.Find(id);
            DB.Classes.Remove(c);
            DB.SaveChanges();
            return Json(c, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string C_id, string dep)
        {
            var c1 = DB.Classes.Find(C_id);
            if (c1 != null) return Json(false, JsonRequestBehavior.AllowGet);

            Class c = new Class();
            c.C_id = C_id;
            c.dep = dep;
            if (ModelState.IsValid)
            {
                DB.Classes.Add(c);
                DB.SaveChanges();
            }
            return Json(c, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string C_id, string dep)
        {
            var c1 = DB.Classes.Find(C_id);
            c1.dep = dep;
            DB.Entry(c1).State = EntityState.Modified;
            DB.SaveChanges();
            ClassModel c = new ClassModel();
            c.C_id = c1.C_id;
            c.dep = c1.dep;
            return Json(c, JsonRequestBehavior.AllowGet);
        }
    }
}