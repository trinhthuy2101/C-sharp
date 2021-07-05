using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP_NET_MVC.Models
{
    public class StudentModel
    {
        public string S_id { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public Nullable<System.DateTime> dob { get; set; }
        public string Class { get; set; }
    }
}