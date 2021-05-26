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
    public class UniversityController : Controller
    {
        // GET: University
        private webt2289_StudentManager_ThuyEntities6 DB;
        public UniversityController()
        {
            DB = new webt2289_StudentManager_ThuyEntities6();
        }
        //SHOW
        public ActionResult Index()
        {
            List<University> UniList = DB.Universities.ToList();
            return View(UniList);
        }
        //ADD 
        public ActionResult AddUniversity()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SaveUniversity(University uni)
        {
            var cl = DB.Universities.Find(uni.U_id);
            if (cl != null)
            {
                return RedirectToAction("Notification", "University");
            }
            if (ModelState.IsValid)
            {
                DB.Universities.Add(uni);
                uni.create_date = DateTime.Now;
                DB.SaveChanges();
            }
            return RedirectToAction("Index", "University");
        }
        public ActionResult Notification()
        {
            return View();
        }
        //REMOVE                    
        public ActionResult RemoveUniversity(string s)
        {
            var uni_model = DB.Universities.Find( s);
            DB.Universities.Remove(uni_model);
            DB.SaveChanges();
            return RedirectToAction("Index", "University");
        }
    }
}