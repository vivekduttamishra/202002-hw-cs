﻿using ConceptArchitect.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryApp02
{
    class Program
    {
        static void Main(string[] args)
        {
            var t1 = new Triangle();
            t1.Set(3, 4, 5);
            TestTriangle(t1);

            var t2 = new Triangle();
            t2.Set(3, 6, 12);
            TestTriangle(t2); //should print error message for invalid triangle
        }
        static  void TestTriangle(Triangle t)
        {
            t.Draw();
            Console.WriteLine("Perimeter is :"+t.Perimeter());
        }
    }
}
