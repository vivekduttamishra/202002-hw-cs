using System;
using System.Collections.Generic;

namespace ConceptArchitect.Banking
{
    public class Bank
    {
        public string Name { get; private set; }
        private double rate;
        public IAccountRepository AccountRepository { get; set; }

        public Bank(string name, double rate)
        {
            this.Name = name;
            this.rate = rate;

        }



        public int OpenAccount(string customerName, string password, int amount,string accountType="SavingsAccount")
        {
            //TODO: step 1. create BankAccount object
           
            BankAccount account = null;

            switch(accountType)
            {
                case "SavingsAccount":
                    account = new SavingsAccount(0, customerName, password, amount); break;

                case "CurrentAccount":
                    account = new CurrentAccount(0, customerName, password, amount); break;

                case "OverdraftAccount":
                    account = new OverdraftAccount(0, customerName, password, amount); break;
            }
            

            //TODO: step 2.  store the account object in Bank Object
            return AccountRepository.AddAccount(account);

            
        }
        public BankAccount GetAccount(int accountNumber, string password)
        {
            var account =AccountRepository.GetAccount(accountNumber);
            account.Authenticate(password);
            return account;

            //if (account == null || !account.Authenticate(password))
            //    return null;
            //else
            //    return account;
        }
        public void Authenticate(int accountNumber, string password)
        {
            var account = AccountRepository.GetAccount(accountNumber);
            account.Authenticate(password);
        }
        public double CloseAccount(int accountNumber,string password)
        {
            var account = AccountRepository.GetAccount(accountNumber);
            account.Authenticate(password);

            if (account.Balance < 0)
                throw new InsufficientBalanceException(accountNumber, "You need to clear your dues to close the account");

            //ok to close
            AccountRepository.RemoveAccount(account);

            return account.Balance;

        }
        public void PrintAccountList()
        {
            //TODO: print info about all accounts
            foreach (var account in AccountRepository.GetActiveAccounts())
                Console.WriteLine("{0}#{1}\t{2}\t{3}",account.GetType().Name, account.AccountNumber,account.Name, account.Balance);
            
        }

        public void CreditInterest()
        {
            //TODO: credit interest to all accounts
            foreach (var account in AccountRepository.GetActiveAccounts())
                account.CreditInterest(rate);
        }
        public void Deposit(int accountNumber, int amount)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = AccountRepository.GetAccount(accountNumber);

            account.Deposit(amount);
            AccountRepository.UpdateAccount(account);
            

         
        }
        public void Transfer(int source, int amount, string password, int target)
        {
            //step1 Locate source account
            BankAccount s = AccountRepository.GetAccount(source);
            
            BankAccount t = AccountRepository.GetAccount(target);


            s.Withdraw(amount, password);
            t.Deposit(amount);

            AccountRepository.UpdateAccount(s);
            AccountRepository.UpdateAccount(t);

        }
        public void Withdraw(int accountNumber  , double amount, string password)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = AccountRepository.GetAccount(accountNumber);
           account.Withdraw(amount,password);
            AccountRepository.UpdateAccount(account);

        }

        
    }
}