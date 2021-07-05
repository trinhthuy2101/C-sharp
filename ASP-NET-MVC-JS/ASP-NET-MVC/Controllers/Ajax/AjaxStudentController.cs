using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers.Ajax
{
    public class AjaxStudentController : AjaxController
    {
        // GET: Student
        public ActionResult Index()
        {
            List<Student> students = DB.Students.ToList();
            return View(students);
        }
        public JsonResult Details(string id)
        {
            Student s = DB.Students.Find(id);
            StudentModel s1 = new StudentModel();
            s1.S_id = s.S_id;
            s1.name = s.name;
            s1.dob = s.dob;
            s1.gender = s.gender;
            s1.Class = s.Class;
            return Json(s1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(string id)
        {
            Student s = DB.Students.Find(id);
            DB.Students.Remove(s);
            DB.SaveChanges();
            return Json(s, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateNew(string S_id, string name, string gender, string Class)
        {
            var s1 = DB.Students.Find(S_id);
            if (s1!=null) return Json(false,JsonRequestBehavior.AllowGet);
            
            Student s = new Student();
            s.S_id = S_id;
            s.name = name;
            s.gender = gender;
            s.Class = Class;
            if (ModelState.IsValid)
            {
                DB.Students.Add(s);
                DB.SaveChanges();
            }
            return Json(s,JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(string S_id, string name, string gender, string Class)
        {
            var s1 = DB.Students.Find(S_id);
            s1.name = name;
            s1.gender = gender;
            s1.Class = Class;
            DB.Entry(s1).State = EntityState.Modified;
            DB.SaveChanges();
            StudentModel s = new StudentModel();
            s.S_id = s1.S_id;
            s.name = s1.name;
            s.dob = s1.dob;
            s.gender = s1.gender;
            s.Class = s1.Class;
            return Json(s,JsonRequestBehavior.AllowGet);
        }
    }
}