﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Abstraction
{
    class person
    {
        private string name;
        private int age;
        private double weight;
        private double height;

        public person()
        {
            name = "Nguyen Van A";
            age = 20;
            weight = 60;
            height = 1.78;
        }
        public void BMI()
        {
            Console.WriteLine("BMI index:");
            Console.WriteLine(weight / (height * height));
        }
    }
}
