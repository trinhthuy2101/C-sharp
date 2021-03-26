using System;

namespace Console_App_Students
{
    class Program
    {
        static void Main(string[] args)
        {
            CStudent a = new CStudent();
            //a.Add();
            //a.Show();
            //a.Update();
            a.InputClassName();
            a.InputDepartmentName();
            a.InputUniName();
            Console.ReadKey();
            a.Delete();
            a.Show();
            a.OuputClassName();
            a.OuputDepartmentName();
            a.OuputUniName();
        }
    }
}
