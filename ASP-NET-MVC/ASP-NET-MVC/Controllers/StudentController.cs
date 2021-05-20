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
        private webt2289_StudentManager_ThuyEntities2 DB;
        
        public StudentController()
        {
            DB = new webt2289_StudentManager_ThuyEntities2();
        }
        public ActionResult AddStudent()
        {
            return View();
        }
        public ActionResult Index()
        {
            List<Student> students = DB.Students.ToList();
            return View(students);
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
       
        public ActionResult RemoveStudent()
        {
            return View();
        }
        public ActionResult UpdateStudent()
        {
            return View();
        }
        public ActionResult Notification()
        {
            return View();
        }
    }
}