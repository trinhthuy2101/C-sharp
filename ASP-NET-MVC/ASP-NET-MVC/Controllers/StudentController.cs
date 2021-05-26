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
    public class StudentController : Controller
    {
        // GET: Student
        private webt2289_StudentManager_ThuyEntities6 DB;
        public StudentController()
        {
            DB = new webt2289_StudentManager_ThuyEntities6();
        }
        //SHOW
        public ActionResult Index()
        {
            List<Student> students = DB.Students.ToList();
            return View(students);
        }
        public ActionResult Details(string s)
        {
            var student = DB.Students.FirstOrDefault(st => st.S_id == s);
            return View(student);
        }
        //ADD STUDENT
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveStudent(Student student)
        {
            var st = DB.Students.Find(student.S_id);
            if (st!=null){
                return RedirectToAction("Notification", "Student");
            }
            if (ModelState.IsValid)
            {
                student.create_date = DateTime.Now;
                DB.Students.Add(student);
                DB.SaveChanges();
            }
            return RedirectToAction("Index","Student");
        }
        public ActionResult Notification()
        {
            return View();
        }
        //REMOVE
        public ActionResult RemoveStudent(string s)
        {
            var student = DB.Students.FirstOrDefault(st => st.S_id == s);
            DB.Students.Remove(student);
            DB.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
        //UPDATE
        public ActionResult UpdateStudent(string s)
        {
            var student = DB.Students.FirstOrDefault(st => st.S_id == s);
            return View(student);
        }
        public ActionResult SaveUpdateStudent(Student s)
        {
            var s1 = DB.Students.Find(s.S_id);
            if (s.name != null) s1.name = s.name;
            if (s.gender != null) s1.gender = s.gender;
            if (s.dob != null) s1.dob = s.dob;
            DB.Entry(s1).State = EntityState.Modified;
            DB.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}