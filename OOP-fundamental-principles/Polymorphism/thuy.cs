using System;
using System.Collections.Generic;
using System.Text;

namespace Polymorphism
{
    class thuy:person
    {
        public override void eat()
        {
            Console.WriteLine("Thuy is eating\n");
        }
        public override void learn()
        {
            Console.WriteLine("Thuy is learning\n");
        }
        public override void sleep()
        {
            Console.WriteLine("Thuy is sleeping\n");
        }
    }
}
