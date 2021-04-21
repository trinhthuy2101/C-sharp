using StudentManager.Blo;
using StudentManager.Model;
using StudentManager.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManager.Controller
{
    class ControllerCenter
    {
        static string optionSelect = "";
        static DataContext _dataContext;
        static List<CUniversity> Universities { set; get; }

        public static void InfoManagerment()
        {
            var dep = new CDepartment();
            var cls = new CClass();
            cls._students = new List<CStudent>();
            dep._classes = new List<CClass>();
          
            do
            {
                Console.WriteLine("Type to select:" + ViewInfo.GenerateInfoBoard());
                optionSelect = Console.ReadLine();
                switch (optionSelect)
                {
                    case "1"://add new
                       
                        if (_dataContext == null)
                        {
                            _dataContext = new DataContext();
                        }
                        CStudent studentModel = StudentManagement.AddNewStudent();
                        cls._students.Add(studentModel);
                        dep._classes.Add(cls);
                        _dataContext.UniversityModel._departmentModels.Add(dep);
                        Console.WriteLine(ViewInfo.AddingSuccess(studentModel._name));
                        break;
                    case "2":
                        CStudent student = StudentManagement.UpdateStudent();
                        cls._students.Add(student);
                        dep._classes.Add(cls);
                        _dataContext.UniversityModel._departmentModels.Add(dep);
                        Console.WriteLine(ViewInfo.UpdatingSuccess(student._id));
                        break;
                    case "3"://remove
                        int id=StudentManagement.RemoveStudent();
                        Console.WriteLine(ViewInfo.RemovingSuccess(id));
                        break;
                    case "4"://show
                        ViewInfo.ShowStudents(_dataContext);
                        break;
                    case "5"://save
                        ObjectInOut.Save(_dataContext);
                        Console.WriteLine(ViewInfo.SavingSuccess());
                        break;
                    case "6"://exit without saving
                        return;
                    default:
                        return;
                }
                Console.ReadKey();
                Console.Clear();
            } while (optionSelect != "6");
        }
    }
}