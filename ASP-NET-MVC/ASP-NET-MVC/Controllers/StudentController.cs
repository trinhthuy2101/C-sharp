using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;
using System.Data.SqlClient;
using System.Data;

namespace ASP_NET_MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private webt2289_StudentManager_ThuyEntities4 DB;
        public StudentController()
        {
            DB = new webt2289_StudentManager_ThuyEntities4();
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
            List<Student> students = DB.Students.ToList();
            for(int i = 0; i < students.Count; i++)
            {
                if (student.S_id == students[i].S_id) return RedirectToAction("Notification");
            }
            if (ModelState.IsValid)
            {
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
            if (s.Class != null) s1.Class = s.Class;
            var student = DB.Students.FirstOrDefault(st => st.S_id == s.S_id);
            DB.Students.Remove(student);
            DB.SaveChanges();
            DB.Students.Add(s1);
            DB.SaveChanges();
            return RedirectToAction("Index", "Student");
        }
    }
}