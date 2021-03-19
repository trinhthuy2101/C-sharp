using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    class person
    {
        private string name;
        private int age;
        private float weight;
        private float height;

        person()
        {
            name = "Nguyen Van A";
            age = 20;
            weight = 55;
            height = 178;
        }
        public void BMI()
        {
            Console.WriteLine("BMI index:",weight / (height * height));
        }
    }
}
