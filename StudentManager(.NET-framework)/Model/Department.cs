using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManager.Model
{
    [Serializable]
    class Department:University
    {
        public List<Class> Classes = new List<Class>();
    }
}
