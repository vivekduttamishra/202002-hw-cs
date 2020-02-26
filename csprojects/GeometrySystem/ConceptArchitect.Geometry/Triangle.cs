using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Geometry
{
    public class Triangle
    {
       public int s1, s2, s3; //has 3 sides called s1,s2,s3

        public int Perimeter()
        {
            return s1 + s2 + s3;
        }

        public void Draw()
        {
            Console.WriteLine("Triangle<{0},{1},{2}> drawn",s1,s2,s3);
        }
    }
}
