using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        public int lastId;
        List<BankAccount> accounts = new List<BankAccount>();
        public List<BankAccount> GetActiveAccounts()
        {
            return accounts;
        }
        public int AddAccount(BankAccount account)
        {
            ++lastId;
            account.AccountNumber = lastId;
            accounts.Add(account);
            return account.AccountNumber;

        }

        public void RemoveAccount(BankAccount account)
        {
            accounts.Remove(account);
        }

        public BankAccount GetAccount(int accountNumber)
        {
            foreach (var account in accounts)
                if (account.AccountNumber == accountNumber)
                    return account;

            //return null; //null means no account
            throw new InvalidAccountException(accountNumber);
        }

        public void UpdateAccount(BankAccount account)
        {
            
        }
    }
}
