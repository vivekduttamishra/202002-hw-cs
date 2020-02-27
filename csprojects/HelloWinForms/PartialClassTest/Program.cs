using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClassTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new Person();
            p1.Name = "Vivek";
            p1.Phone = "0010101";
            p1.Email = "vivek@conceptarchitect.in";

            var p2 = new Person() { Name = "Prabhat", TwitterHandle="@pprabhat" };
        }
    }
}
