using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManager.Model
{
    [Serializable]
    class University
    {
        public List<Department> DepartmentModels = new List<Department>();
    }
}
