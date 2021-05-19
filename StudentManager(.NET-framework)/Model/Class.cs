using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManager.Model
{
    [Serializable]
    class Class:Department
    {
        public List<Student> Students = new List<Student>();
    }
}
