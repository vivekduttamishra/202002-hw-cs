using ConceptArchitect.Geometry;
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
            //when is Triangle t1 created?
            //here?
            var t1 = new Triangle(3,4,5);
            //or here?
            //t1.Set(3, 4, 5);
            TestTriangle(t1);

            var t2 = new Triangle(3,6,12);
            t2.Set(3, 6, 12);
            TestTriangle(t2); //should print error message for invalid triangle


            Triangle t3 = new Triangle();
            //t3.Set() not called.
            TestTriangle(t3);

            var t4 = new Triangle(5);
            TestTriangle(t4);

        }
        static  void TestTriangle(Triangle t)
        {
            t.Draw();
            Console.WriteLine("Perimeter is :"+t.Perimeter());
            Console.WriteLine();
        }
    }
}
