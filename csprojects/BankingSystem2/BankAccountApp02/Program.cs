using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountApp01
{
    class Program
    {
        static void Main(string[] args)
        {

           
            var account = new BankAccount(1, "Vivek Dutta Mishra", "p@ss", 20000, 12);   //BankAcc() //AccTemplate()//AccountInformation()
            var account2 = new BankAccount(2, "Sanjay", "p@ss", 20000, 12);

            Console.WriteLine(account.GetName());
            account.SetName("Vivek Singh");
            Console.WriteLine(account.GetName());
            account.SetName("Shivanshi Mishra");
            Console.WriteLine(account.GetName());

            Console.WriteLine(account.GetBalance());

        }

        public static void Transfer(BankAccount src, int amount, String password, BankAccount target)
        {
            if(src.Withdraw(amount, password))
                target.Deposit(amount);
        }
    }
}
