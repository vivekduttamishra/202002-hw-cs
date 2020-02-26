using System;

namespace BankAccountApp01
{
    internal class BankAccount
    {
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

        public void Withdraw(double amount, string password)
        {
            

            if (amount <= 0)
                Console.WriteLine("Amount should be positive");
            else if (amount > balance)
                Console.WriteLine("Insufficient balance");
            else if (password != this.password)
                Console.WriteLine("Invalid credentials");
            else
            {
                Console.WriteLine("Please collect your cash");
                balance -= amount;
            }

        }

        public void Deposit(double amount)
        {
            balance += amount;
        }

        public void Show()
        {
            Console.WriteLine("Account Number "+accountNumber);
            Console.WriteLine("Name " + name);
            Console.WriteLine("Balance " + balance);
            Console.WriteLine("Password " + password);
            Console.WriteLine("Rate " + rate);
        }
    }
}