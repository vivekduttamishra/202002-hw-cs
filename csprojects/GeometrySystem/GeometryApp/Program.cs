using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConceptArchitect.Geometry;

namespace GeometryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //step1 : create triangle
            Triangle t1 = new Triangle();
            
            //step 2: set sides
            t1.s1 = 3;
            t1.s2 = 4;
            t1.s3 = 5;

            

            var t2 = new Triangle();

            t2.s1 = 1;
            t2.s2 = 1;
            t2.s3 = 1;


            t1.Draw();
            Console.WriteLine("Perimeter is {0}",t1.Perimeter());

            t2.Draw();
            Console.WriteLine("Perimeter is {0}", t2.Perimeter());


            var t3 = new Triangle();
            t3.s1 = 3;
            t3.s2 = 6;
            t3.s3 = 12;
            t3.Draw();
            Console.WriteLine("Perimeter is {0}", t3.Perimeter());






        }
    }
}
