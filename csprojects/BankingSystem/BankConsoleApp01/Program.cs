using ConceptArchitect.Banking;
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
            //TestSavingsAccountAsBankAccount();

            BankAccount[] accounts =
            {
                new SavingsAccount(1,"S Kumar", "p@ss",20000),
                new CurrentAccount(1,"C Singh", "p@ss",20000),
                new OverdraftAccount(1,"O Deshmukh", "p@ss",20000),

            };

            //now onward they are all BankAccounts

            //TestCreditInterest(accounts);

            //TestTryWithdraw(accounts, 18000);

            TestTryWithdraw(accounts, 21000);

        }

        private static void TestTryWithdraw(BankAccount[] accounts, int amount)
        {
            Console.WriteLine("Trying to withdraw {0} from each account", amount);
            foreach (var account in accounts)
            {
                Console.WriteLine("status:" + account.Withdraw(amount, "p@ss"));
                account.Show();
                Console.WriteLine();
            }
        }

        private static void TestCreditInterest(BankAccount[] accounts)
        {
            Console.WriteLine("Crediting Interest and Printing there details");
            foreach (var account in accounts)
            {
                account.CreditInterest(12);
                account.Show();
                Console.WriteLine();
            }
        }

        private static void TestSavingsAccountAsBankAccount()
        {
            //TestBankOpeningAccounts();

            //TestSavingsAccountIndependently();

            SavingsAccount sa = new SavingsAccount(1, "Vivek", "p@ss", 20000);

            Console.WriteLine(sa.Withdraw(18000, "p@ss"));
            Console.WriteLine(sa.Balance);


            BankAccount ba = sa; //sa is a type of BankAccount. so this assignment is a bank account to bank account
            Console.WriteLine(ba.Withdraw(18000, "p@ss"));
            Console.WriteLine(sa.Balance);
        }

        private static void TestSavingsAccountIndependently()
        {
            Console.WriteLine("Testing Savings Account");
            SavingsAccount s = new SavingsAccount(25, "Sanjay", "san", 25000);

            s.Show();
            s.Deposit(10000);
            s.Show();
            Console.WriteLine(s.MinBalance);

            Console.WriteLine(s.Withdraw(33000, "san"));
            s.Show();

            Console.WriteLine(s.Withdraw(29000, "san"));
            s.Show();
        }

        private static void TestBankOpeningAccounts()
        {
            var icici = new Bank("ICICI", 12);

            //creates an account. stores it internally. returns the account number
            int a1 = icici.OpenAccount("Vivek Dutta Mishra", "p@ss", 20000);
            int a2 = icici.OpenAccount("Prabhat Singh", "p@ss", 30000);

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
