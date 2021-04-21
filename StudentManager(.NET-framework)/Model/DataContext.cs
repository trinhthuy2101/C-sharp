using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Model
{
    class DataContext
    {
            public string Version { set; get; }
            public CUniversity UniversityModel = new CUniversity();
    }
}
