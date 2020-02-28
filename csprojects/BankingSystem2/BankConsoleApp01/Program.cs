using ConceptArchitect.Banking;
//using BankConsoleApp01.WcfProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp01
{
    class Program
    {
        static void Main(string[] args)
        {
            var icici = new Bank("ICICI", 12);
            //var icici = new BankingServiceClient();

            //creates an account. stores it internally. returns the account number
            int a1 = icici.OpenAccount("SavingsAccount","Vivek Dutta Mishra", "p@ss", 20000);
            int a2 = icici.OpenAccount("SavingsAccount","Prabhat Singh", "p@ss", 30000);

            //bank (employee) can
            icici.PrintAccountList(); //see a list of all accounts
            icici.CreditInterest();   //credit interest to all accounts

            //bank (customers) can
            icici.Deposit(a1, 20000); //icici locates BankAccount object for a1 and add money
            icici.Withdraw(a2, 5000, "p@ss"); //locate BankAccount for a1 and call its Withdraw
            icici.Transfer(a1, 1000, "p@ss", a2); //transfer from a1 to a2 Rs 1000 using password



        }
    }
}
