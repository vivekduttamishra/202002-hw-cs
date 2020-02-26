using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Geometry
{
    public class Triangle
    {
        int s1, s2, s3; //has 3 sides called s1,s2,s3

        //TODO: 1. CREATE A SET FUNCTION THAT TAKES
        // X,Y,Z
        //ASSIGNS TO S1,S2,S3 ONLY IF X,Y,Z ARE VALID SIDES OF TRIANGLE


        //SHOULD RETURN -1 IF SIDES ARE NOT VALID
        public int Perimeter()
        {
            return s1 + s2 + s3;
        }

        //SHOULD PRINT INVALID TRIANGLE IF SIDES ARE NOT VALID
        public void Draw()
        {
            Console.WriteLine("Triangle<{0},{1},{2}> drawn", s1, s2, s3);
        }
    }
}
