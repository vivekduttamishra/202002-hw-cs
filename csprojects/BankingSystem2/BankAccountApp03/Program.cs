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
            BankAccount a1 = new BankAccount(1, "V", "P", 1000, 12);
            BankAccount a2 = new BankAccount(1, "S", "X", 1000, 14);

            a1.Rate = 20;

            a1.Show();
            Console.WriteLine();
            a2.Show();

        }

        static void Test1()
        {

           
            var account = new BankAccount(1, "Vivek Dutta Mishra", "p@ss", 20000, 12);   //BankAcc() //AccTemplate()//AccountInformation()
            var account2 = new BankAccount(2, "Sanjay", "p@ss", 20000, 12);

            Console.WriteLine(account.Name);
            //account.SetName("Vivek Singh");

            account.Name = "Vivek Singh";

            Console.WriteLine(account.Name);

            account.Name = "Shivanshi Mishra";

            Console.WriteLine(account.Name);

            Console.WriteLine(account.GetBalance());

            Console.WriteLine(account.AccountNumber);
            //account.AccountNumber = 20;

        }

        public static void Transfer(BankAccount src, int amount, String password, BankAccount target)
        {
            if(src.Withdraw(amount, password))
                target.Deposit(amount);
        }
    }
}
