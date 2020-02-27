using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp01
{
    class Program
    {

        static void Main()
        {

            BankAccount a1 = new BankAccount( "V", "P", 1000);
            BankAccount a2 = new BankAccount( "S", "X", 1000);

            //looks like changing rate only for a1
            //actually changing for everyone
            //a1.Rate = 20;
            
            //where is this change applied?
            BankAccount.Rate = 20;

            a1.Show();
            Console.WriteLine();
            a2.Show();

            BankAccount.Transfer(a1, 500, "P", a2);

            Console.WriteLine("After transfer");
            a1.Show();
            a2.Show();

        }

      
    }
}
