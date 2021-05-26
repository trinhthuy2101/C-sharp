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
    public class ClassController : Controller
    {
        // GET: Class
        private webt2289_StudentManager_ThuyEntities6 DB;

        public EntityState EntryState { get; private set; }

        public ClassController()
        {
            DB = new webt2289_StudentManager_ThuyEntities6();
        }
        //SHOW
        public ActionResult Index()
        {
            List<Class> classList = DB.Classes.ToList();
            return View(classList);
        }
        //ADD CLASS
        public ActionResult AddClass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveClass(Class class_model)
        {
            var cl = DB.Classes.Find(class_model.C_id);
            if (cl != null)
            {
                return RedirectToAction("Notification", "Class");
            }
            if (ModelState.IsValid)
            {
                DB.Classes.Add(class_model);
                class_model.create_date = DateTime.Now;
                DB.SaveChanges();
            }
            return RedirectToAction("Index", "Class");
        }
        public ActionResult Notification()
        {
            return View();
        }
        //REMOVE
        public ActionResult RemoveClass(string id)
        {
            var class_model = DB.Classes.FirstOrDefault(cl => cl.C_id == id);
            DB.Classes.Remove(class_model);
            DB.SaveChanges();
            return RedirectToAction("Index", "Class");
        }
        //UPDATE
        public ActionResult UpdateClass(string id)
        {
            var class_model = DB.Classes.FirstOrDefault(cl => cl.C_id == id);
            return View(class_model);
        }
        public ActionResult SaveUpdateClass(Class c)
        {
            var c1 = DB.Classes.Find(c.C_id);
            if(c.dep!=null) c1.dep = c.dep;
            DB.Entry(c1).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index", "Class");
        }
    }
}