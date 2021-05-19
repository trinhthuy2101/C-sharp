using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManager.Model
{
    [Serializable]
    class Student : Class
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Age;
    }
}
