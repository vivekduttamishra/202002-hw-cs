﻿using System;
using System.Collections.Generic;

namespace ConceptArchitect.Banking
{
    public class Bank
    {
        private string name;
        private double rate;
        private int lastId;
        
        List<BankAccount> accounts = new List<BankAccount>();

        public Bank(string name, double rate)
        {
            this.name = name;
            this.rate = rate;
            
        }

        public int OpenAccount(string customerName, string password, int amount)
        {
            //TODO: step 1. create BankAccount object
            int accountNumber = ++lastId;  //generate new account number
            var account = new BankAccount(accountNumber, customerName, password, amount);

            //TODO: step 2.  store the account object in Bank Object
            accounts.Add(account);

            //TODO: step 3.  return the account number
            return accountNumber;
        }

        public double CloseAccount(int accountNumber,string password)
        {
            var account = GetAccount(accountNumber);
            if (account == null) //no such account
                return double.NaN; //failed to close

            if (!account.Authenticate(password))
                return double.NaN; //fail to close because of authentication failure

            if (account.Balance < 0)
                return double.NaN; //can't runaway without paying the due

            //ok to close
            accounts.Remove(account);

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
            foreach(var account in accounts)
                account.CreditInterest(rate);
        }

        public bool Deposit(int accountNumber, int amount)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = GetAccount(accountNumber);

            //TODO: step 2. if there is a acccount with this account number deposit money
            if (account!=null)
                return account.Deposit(amount);
            else //no such account
                return false;

         
        }

        public bool Transfer(int source, int amount, string password, int target)
        {
            //step1 Locate source account
            BankAccount s = GetAccount(source);
            if (s == null)
                return false;
            BankAccount t = GetAccount(target);
            if (t == null)
                return false;

            if (s.Withdraw(amount, password))
                return t.Deposit(amount);
            else
                return false;
        }

        public bool Withdraw(int accountNumber  , double amount, string password)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = GetAccount(accountNumber);

            //TODO: step 2. if there is a acccount with this account number deposit money
            if (account!=null)
                return account.Withdraw(amount,password);
            else //no such account
                return false;

        }

        private BankAccount GetAccount(int accountNumber)
        {
            foreach (var account in accounts)
                if (account.AccountNumber == accountNumber)
                    return account;

            return null; //null means no account
        }
    }
}