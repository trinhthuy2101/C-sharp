using System;
using System.Collections.Generic;
using System.Text;

namespace Inheritance
{
    class person
    {
        protected string name;
        protected int age;
        protected double weight;
        protected double height;

        public person()
        {
            name = "Nguyen Van A";
            age = 20;
            weight = 70;
            height = 1.88;
        }
        public void BMI()
        {
            Console.WriteLine("BMI index:");
            Console.WriteLine(weight / (height * height));
        }
    }
}
