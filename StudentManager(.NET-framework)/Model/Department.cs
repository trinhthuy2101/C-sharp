using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManager.Model
{
    class CDepartment:CUniversity
    {
        public List<CClass> _classes = new List<CClass>();
    }
}
