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
        CStudent s=new CStudent();
        
        public static string AddingSuccess(string name)
        {
            return "Added:" + name;
        }
        public static string UpdatingSuccess(int id)
        {
            return "Updated" + id;
        }
        public static string SavingSuccess()
        {
            return "Saved\n";
        }
        public static string RemovingSuccess(int id)
        {
            return "Removed\n"+id;
        }

        public static string Show(CStudent student)
        {
            return Convert.ToString(student._id)+"\n"+student._name+"\n" + Convert.ToString(student._age)+"\n";
        }
        public static void ShowStudents(DataContext dataContext)
        {
            int i = 0;
            int count = dataContext.UniversityModel._departmentModels[0]._classes[0]._students.Count();
            while (i != count)
            {
                CStudent a = dataContext.UniversityModel._departmentModels[i]._classes[0]._students[0];
                Console.WriteLine("Name: " + a._name + "\n");
                Console.WriteLine("ID: " + a._id + "\n");
                Console.WriteLine("Age: " + a._age + "\n");
                i++;
            }

        }
        public static string GenerateInfoBoard()
        {
            List<string> actions = new List<string>()
            {
                "Add new",
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
