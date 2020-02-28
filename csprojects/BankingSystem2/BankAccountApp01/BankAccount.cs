using System;

namespace BankAccountApp01
{
    //internal  by default
    public class BankAccount
    {

        //private by default
        int accountNumber;
        string name;
        string password;
        double balance;
        double rate;

        public BankAccount(int accountNumber, string name, string password, int balance, int rate)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.password = password;
            this.balance = balance;
            this.rate = rate;
        }

        public bool Withdraw(double amount, string password)
        {


            if (amount <= 0)
                return false;//Console.WriteLine("Amount should be positive");
            else if (amount > balance)
                return false;// Console.WriteLine("Insufficient balance");
            else if (password != this.password)
                return false;// Console.WriteLine("Invalid credentials");
            else
            {
                //Console.WriteLine("Please collect your cash");
                balance -= amount;
                return true;
            }

        }

        public bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;
            else
            {
                balance += amount;
                return true;
            }
        }

        public void CreditInterest()
        {
            balance += balance * rate / 1200;
        }

      

        public void Show()
        {
            Console.WriteLine("Account Number "+accountNumber);
            Console.WriteLine("Name " + name);
            Console.WriteLine("Balance " + balance);
            //Console.WriteLine("Password " + password);
            Console.WriteLine("Rate " + rate);
        }
    }
}