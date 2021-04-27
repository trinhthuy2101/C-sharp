﻿using StudentManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Blo
{
    class StudentManagement
    {
        public CStudent AddNewStudent(CClass cls, CDepartment dep,DataContext _dataContext)
        {
            CStudent studentModel = new CStudent();
            studentModel._name = InfoInput("Ten");
            string age = InfoInput("Tuoi");
            studentModel._age = int.Parse(age);
            studentModel._id = int.Parse(InfoInput("Id"));
            cls._students.Add(studentModel);
            dep._classes.Add(cls);
            _dataContext.UniversityModel._departmentModels.Add(dep);
            return studentModel;
        }
        public CStudent UpdateStudent(CClass cls, CDepartment dep, DataContext _dataContext)
        {
            CStudent student = RemoveStudent(_dataContext);
            CStudent studentModel = new CStudent();
            studentModel._name = InfoInput("Ten");
            studentModel._age = int.Parse(InfoInput("Tuoi"));
            studentModel._id = student._id;

            cls._students.Add(studentModel);
            dep._classes.Add(cls);
            _dataContext.UniversityModel._departmentModels.Add(dep);
            return studentModel;
        }
        public CStudent RemoveStudent(DataContext dataContext)
        {
            int id;
            Console.WriteLine("Nhap MSSV: ");
            id = int.Parse(Console.ReadLine());
            int i = 0;
            int count = dataContext.UniversityModel._departmentModels.Count();
            //Dictionary<string, string> Student;
            while (i!=count)
            {
                if (dataContext.UniversityModel._departmentModels[i]._classes[0]._students[0]._id == id)
                {
                    CStudent x = dataContext.UniversityModel._departmentModels[i]._classes[0]._students[0];
                    dataContext.UniversityModel._departmentModels[i]._classes[0]._students.Remove(x);
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
