using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ConceptArchitect.Banking
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class Bank : IBankingService
    {
        public string Name { get; private set; }
        private double rate;

        public AccountRepository AccountRepository { get; set; }

        /*
        List<BankAccount> accounts = new List<BankAccount>();
        private int lastId;
        private List<BankAccount> GetActiveAccounts()
        {
            return accounts;
        }
        private void AddAccount(BankAccount account)
        {
            accounts.Add(account);
        }

        private void RemoveAccount(BankAccount account)
        {
            accounts.Remove(account);
        }

        private BankAccount GetAccount(int accountNumber)
        {
            foreach (var account in accounts)
                if (account.AccountNumber == accountNumber)
                    return account;

            return null; //null means no account
        }
        */
        public Bank(string name, double rate)
        {
            this.Name = name;
            this.rate = rate;

        }

        public int OpenAccount(string type, string customerName, string password, int amount)
        {
            //TODO: step 1. create BankAccount object
            //int accountNumber = ++lastId;  //generate new account number

            BankAccount account = null;

            switch (type)
            {
                case "SavingsAccount":
                    account = new SavingsAccount(0, customerName, password, amount);
                    break;
                case "CurrentAccount":
                    account = new CurrentAccount(0, customerName, password, amount);
                    break;

                case "OverdraftAccount":
                    account = new OverdraftAccount(0, customerName, password, amount);
                    break;
            }

            //TODO: step 2.  store the account object in Bank Object
            return AccountRepository.AddAccount(account);

            //TODO: step 3.  return the account number
            //return account.AccountNumber;
        }

        public BankAccount GetAccount(int accountNumber, string password)
        {
            var account = AccountRepository.GetAccount(accountNumber);
            account.Authenticate(password);
            return account;
        }

        public void Authenticate(int accountNumber, string password)
        {
            var account = AccountRepository.GetAccount(accountNumber);
            account.Authenticate(password);
        }

        public double CloseAccount(int accountNumber, string password)
        {
            var account = AccountRepository.GetAccount(accountNumber);
            account.Authenticate(password);
            if (account.Balance < 0)
                throw new InsufficientBalanceException(accountNumber, "Please clear your dues before closing account")
                {
                    Deficit = -account.Balance
                };

            //ok to close
            AccountRepository.DeleteAccount(account);

            return account.Balance;

        }



        public void PrintAccountList()
        {
            //TODO: print info about all accounts
            foreach (var account in AccountRepository.GetActiveAccounts())
                account.Show();

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
        }

        public void Transfer(int source, int amount, string password, int target)
        {
            //step1 Locate source account
            BankAccount s = AccountRepository.GetAccount(source);
            BankAccount t = AccountRepository.GetAccount(target);

            s.Withdraw(amount, password);
            t.Deposit(amount);

        }

        public void Withdraw(int accountNumber, double amount, string password)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = AccountRepository.GetAccount(accountNumber);
            account.Withdraw(amount, password);
        }


    }
}