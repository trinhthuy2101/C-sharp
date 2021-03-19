using System;
using System.Collections.Generic;
using System.Text;

namespace Encapsulation
{
    class person
    {
        private string name;
        private int age;
        public void eat()
        {
            Console.WriteLine("This person is eating\n");
        }
        public void learn()
        {
            Console.WriteLine("This person is learning\n");
        }
        public void sleep() {
            Console.WriteLine("This person is sleeping\n");
        }
       
    }
}