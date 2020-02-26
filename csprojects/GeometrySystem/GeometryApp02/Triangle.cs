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
        
        //replaces default constructor!
        public Triangle(int x,int y, int z)
        {
            Set(x, y, z);
        }

        //can have a second constructor
        public Triangle(int side)
        {
            Set(side, side, side);
        }

        public Triangle()
        {
            Set(1, 1, 1);
        }

        public void Set(int x, int y, int z)
        {
            if(x>0 && y>0 && z>0 && x+y>z && x+z>y && y+z>x)
            {
                s1 = x;
                s2 = y;
                s3 = z;
                       
            }
            else
            {
                s1 = -1;
                //Console.WriteLine("Not a valid Triangle");
            }
        }

        public bool IsValid()
        {
            return s1 != -1;
        }

        //TODO: 1. CREATE A SET FUNCTION THAT TAKES
        // X,Y,Z
        //ASSIGNS TO S1,S2,S3 ONLY IF X,Y,Z ARE VALID SIDES OF TRIANGLE

        //SHOULD RETURN -1 IF SIDES ARE NOT VALID
        public int Perimeter()
        {
            if (IsValid())
                return s1 + s2 + s3;
            else
                return -1;
        }

        //SHOULD PRINT INVALID TRIANGLE IF SIDES ARE NOT VALID
        public void Draw()
        {
            if(IsValid())
                Console.WriteLine("Triangle<{0},{1},{2}> drawn", s1, s2, s3);
            else
                Console.WriteLine("Not a Valid Triangle");
        }
    }
}
