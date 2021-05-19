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
        string optionSelect = "";
        DataContext _dataContext;
        List<University> Universities { set; get; }
        ViewInfo _viewInfo = new ViewInfo();
        ObjectInOut _objectInOut = new ObjectInOut();
        StudentManagement _studentManagement = new StudentManagement();
         
        public void InfoManagerment()
        {
            var dep = new Department();
            var cls = new Class();
            cls.Students = new List<Student>();
            dep.Classes = new List<Class>();
            _dataContext = _objectInOut.ReadData();
            if (_dataContext.UniversityModel.DepartmentModels.Count == 0)
            {
                dep.Classes.Add(cls);
                _dataContext.UniversityModel.DepartmentModels.Add(dep);
            }
            do
            {
                Console.WriteLine("Type to select:" + _viewInfo.GenerateInfoBoard());
                optionSelect = Console.ReadLine();
                switch (optionSelect)
                {
                    case "1"://add new
                        Student studentModel = _studentManagement.AddStudent(cls, dep, _dataContext);
                        _viewInfo.MessageForm("Added: ",studentModel.Name);
                        break;
                    case "2":
                        Student student = _studentManagement.UpdateStudent(cls, dep, _dataContext);
                        if (student == null) _viewInfo.MessageForm("Update: ", "Failed");
                        else _viewInfo.MessageForm("Updated: ", student.Id + "-" + student.Name);
                        break;
                    case "3"://remove
                        var st=_studentManagement.DeleteStudent(_dataContext);
                        if (st == null) _viewInfo.MessageForm("Remove: ", "Failed");
                       else  _viewInfo.MessageForm("Remove", st.Id+"-"+st.Name);
                        break;
                    case "4"://show
                        Console.WriteLine(_viewInfo.ShowListStudent(_dataContext));
                        break;
                    case "5"://save
                        var msg = _objectInOut.Save(_dataContext);
                        _viewInfo.MessageForm("Saved", msg);
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