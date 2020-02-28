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

           
            var account = new BankAccount(1, "Vivek", "p@ss", 20000, 12);   //BankAcc() //AccTemplate()//AccountInformation()
            var account2 = new BankAccount(2, "Sanjay", "p@ss", 20000, 12);
            //Console.Write("How Much? ");
            //double amount = double.Parse(Console.ReadLine());
            //Console.Write("Password?");
            //string password = Console.ReadLine();
            //account.Withdraw(amount, password);
            //account.Show();

            //Transfer(account, 1000, "wrong", account2);
            //account.TransferTo(account2, 1000, "wrong");

            account.Show();
            account2.Show();
        }

        public static void Transfer(BankAccount src, int amount, String password, BankAccount target)
        {
            if(src.Withdraw(amount, password))
                target.Deposit(amount);
        }
    }
}
