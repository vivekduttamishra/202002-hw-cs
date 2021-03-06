﻿using System;
using System.Collections.Generic;

namespace ConceptArchitect.Banking
{
    public class Bank
    {
        public string Name { get; private set; }
        private double rate;
        
        public Bank(string name, double rate)
        {
            this.Name = name;
            this.rate = rate;

        }



        private int lastId;
        List<BankAccount> accounts = new List<BankAccount>();
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

            //return null; //null means no account
            throw new InvalidAccountException(accountNumber);
        }

       

        public int OpenAccount(string customerName, string password, int amount,string accountType="SavingsAccount")
        {
            //TODO: step 1. create BankAccount object
            int accountNumber = ++lastId;  //generate new account number
            BankAccount account = null;

            switch(accountType)
            {
                case "SavingsAccount":
                    account = new SavingsAccount(accountNumber, customerName, password, amount); break;

                case "CurrentAccount":
                    account = new CurrentAccount(accountNumber, customerName, password, amount); break;

                case "OverdraftAccount":
                    account = new OverdraftAccount(accountNumber, customerName, password, amount); break;
            }
            

            //TODO: step 2.  store the account object in Bank Object
            AddAccount(account);

            //TODO: step 3.  return the account number
            return accountNumber;
        }
        public BankAccount GetAccount(int accountNumber, string password)
        {
            var account = GetAccount(accountNumber);
            account.Authenticate(password);
            return account;

            //if (account == null || !account.Authenticate(password))
            //    return null;
            //else
            //    return account;
        }
        public void Authenticate(int accountNumber, string password)
        {
            var account = GetAccount(accountNumber);
            account.Authenticate(password);
        }
        public double CloseAccount(int accountNumber,string password)
        {
            var account = GetAccount(accountNumber);
            account.Authenticate(password);

            if (account.Balance < 0)
                throw new InsufficientBalanceException(accountNumber, "You need to clear your dues to close the account");

            //ok to close
            RemoveAccount(account);

            return account.Balance;

        }
        public void PrintAccountList()
        {
            //TODO: print info about all accounts
            foreach (var account in accounts)
                account.Show();
            
        }

        public void CreditInterest()
        {
            //TODO: credit interest to all accounts
            foreach (var account in GetActiveAccounts())
                account.CreditInterest(rate);
        }
        public void Deposit(int accountNumber, int amount)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = GetAccount(accountNumber);

            account.Deposit(amount);
            

         
        }
        public void Transfer(int source, int amount, string password, int target)
        {
            //step1 Locate source account
            BankAccount s = GetAccount(source);
            
            BankAccount t = GetAccount(target);


            s.Withdraw(amount, password);
            t.Deposit(amount);
            
        }
        public void Withdraw(int accountNumber  , double amount, string password)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = GetAccount(accountNumber);
           account.Withdraw(amount,password);
           

        }

        
    }
}