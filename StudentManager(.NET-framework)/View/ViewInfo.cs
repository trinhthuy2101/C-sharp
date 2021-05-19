using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManager.Controller;
using StudentManager.Model;

namespace StudentManager.View
{
    class ViewInfo
    {
        Student S=new Student();
        public void MessageForm(string action, string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(action + ": " + msg);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any key to continue");
        }

        public string Show(Student student)
        {
            return Convert.ToString(student.Id)+"\n"+student.Name+"\n" + Convert.ToString(student.Age)+"\n";
        }
        public string ShowListStudent(DataContext dataContext)
        {
            int i = 0;
            int count = dataContext.UniversityModel.DepartmentModels[0].Classes[0].Students.Count();
            if (count == 0) return "Student is empty\n";
            string buf="";
            while (i != count)
            {
                Student a = dataContext.UniversityModel.DepartmentModels[0].Classes[0].Students[i];
                buf+="Name: " + a.Name + "\t" + "ID: " + a.Id + "\t" + "Age: " + a.Age + "\n";
                i++;
            }
            return buf;
        }
        public string GenerateInfoBoard()
        {
            List<string> actions = new List<string>()
            {
                "Add",
                "Update",
                "Remove",
                ">Show",
                ">SAVE",
                ">Exit without saving"
            };
            int i = 1;
            string textInfoAll = string.Empty;
            foreach (var action in actions)
            {
                textInfoAll += string.Format("\n{0} -> {1}", i++, action);
            }
            return textInfoAll + "\n -------------------- \n";
        }
    }
}
