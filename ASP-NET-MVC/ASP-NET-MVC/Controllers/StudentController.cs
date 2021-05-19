using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP_NET_MVC.Models;

namespace ASP_NET_MVC.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        private webt2289_StudentManager_ThuyEntities1 DB;
        public ActionResult Index()
        {
            return View();
        }
        public StudentController()
        {
            DB = new webt2289_StudentManager_ThuyEntities1();
        }

        public ActionResult AddStudent()
        {
            return View();
        }
        public ActionResult ShowListStudent()
        {
            var StudentList = from s in DB.Students select s;
            return View(StudentList);
        }
        public ActionResult DeleteStudent()
        {
            return View();
        }
        public ActionResult UpdateStudent()
        {
            return View();
        }
    }
}