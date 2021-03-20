using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class person
    {
        protected string name;
        protected int age;
        public virtual void eat()
        {
            Console.WriteLine("This person is eating\n");
        }
        public virtual void learn()
        {
            Console.WriteLine("This person is learning\n");
        }
        public virtual void sleep()
        {
            Console.WriteLine("This person is sleeping\n");
        }
    }
}
