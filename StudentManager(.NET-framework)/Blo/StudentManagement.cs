using StudentManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Blo
{
    class StudentManagement
    {
        public static CStudent AddNewStudent()
        {
            CStudent studentModel = new CStudent();
            studentModel._name = InfoInput("Ten");
            studentModel._age = int.Parse(InfoInput("Tuoi"));
            studentModel._id = int.Parse(InfoInput("Id"));
            return studentModel;
        }
        public static CStudent UpdateStudent()
        {
            int id = RemoveStudent();
            CStudent studentModel = new CStudent();
            studentModel._name = InfoInput("Ten");
            studentModel._age = int.Parse(InfoInput("Tuoi"));
            studentModel._id = id;
            return studentModel;
        }
        public static int RemoveStudent()
        {
            int id;
            DataContext dataContext = ObjectInOut.ReadData();
            Console.WriteLine("Nhap MSSV: ");
            id = int.Parse(Console.ReadLine());
            int i = 0;
            int count = dataContext.UniversityModel._departmentModels.Count();
            while (i!=count)
            {
                if (dataContext.UniversityModel._departmentModels[i]._classes[0]._students[0]._id == id)
                {
                    CStudent x = dataContext.UniversityModel._departmentModels[i]._classes[0]._students[0];
                    dataContext.UniversityModel._departmentModels[i]._classes[0]._students.Remove(x);
                    break;
                }
                i++;
            }
            ObjectInOut.Save(dataContext);
            return id;
        }
       
        private static string InfoInput(string field)
        {
            Console.WriteLine("Xin nhap " + field);
            return Console.ReadLine();
        }
    }
}
