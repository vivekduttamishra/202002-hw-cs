using System;

namespace ConceptArchitect.Banking
{
    public class Bank
    {
        private string name;
        private double rate;

        public Bank(string name, double rate)
        {
            this.name = name;
            this.rate = rate;
        }

        public int OpenAccount(string customerName, string password, int amount)
        {
            //TODO: step 1. create BankAccount object

            //TODO: step 2.  store the account object in Bank Object

            //TODO: step 3.  return the account number
            return 0;
        }

        public void PrintAccountList()
        {
            //TODO: print info about all accounts
            
        }

        public void CreditInterest()
        {
            //TODO: credit interest to all accounts
        }

        public bool Deposit(int accountNumber, int amount)
        {
            //TODO: step 1. Locate the BankAccount object with given account number
            BankAccount account = GetAccount(accountNumber);

            //TODO: step 2. if there is a acccount with this account number deposit money
            //if (/* your condition*/)
            //    return account.Deposit(amount);
            //else //no such account
            //    return false;

            return false;
        }

        public bool Transfer(int source, int amount, string password, int target)
        {
            //step1 Locate source account
            BankAccount s = GetAccount(source);
            BankAccount t = GetAccount(target);

            //step2. check if both account exits. return false otherwise
            //if (/*condition*/)
            //    return false;

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
            //if (/* your condition*/)
            //    return account.Withdraw(amount);
            //else //no such account
            //    return false;

            return false;
        }

        private BankAccount GetAccount(int accountNumber)
        {
            throw new NotImplementedException();
        }
    }
}