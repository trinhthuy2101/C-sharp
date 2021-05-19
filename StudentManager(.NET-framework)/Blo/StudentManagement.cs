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
        public Student AddStudent(Class cls, Department dep,DataContext _dataContext)
        {
            Student studentModel = new Student();
            studentModel.Name = InfoInput("Ten");
            string age = InfoInput("Tuoi");
            studentModel.Age = int.Parse(age);
            studentModel.Id = int.Parse(InfoInput("Id"));
            cls.Students.Add(studentModel);
            return studentModel;
        }
        public Student UpdateStudent(Class cls, Department dep, DataContext _dataContext)
        {
            Student student = DeleteStudent(_dataContext);
            if (student == null) return null;
            Student studentModel = new Student();
            studentModel.Name = InfoInput("Ten");
            studentModel.Age = int.Parse(InfoInput("Tuoi"));
            studentModel.Id = student.Id;

            cls.Students.Add(studentModel);
            return studentModel;
        }
        public Student DeleteStudent(DataContext dataContext)
        {
            int id;
            Console.WriteLine("Nhap MSSV: ");
            id = int.Parse(Console.ReadLine());
            int i = 0;
            int count = dataContext.UniversityModel.DepartmentModels[0].Classes[0].Students.Count();
            //Dictionary<string, string> Student;
            while (i!=count)
            {
                if (dataContext.UniversityModel.DepartmentModels[0].Classes[0].Students[i].Id == id)
                {
                    Student x = dataContext.UniversityModel.DepartmentModels[0].Classes[0].Students[i];
                    dataContext.UniversityModel.DepartmentModels[0].Classes[0].Students.Remove(x);
                    return x;
                }
                i++;
            }
            return null;
        }
       
        private string InfoInput(string field)
        {
            Console.WriteLine("Xin nhap " + field);
            return Console.ReadLine();
        }
    }
}
