using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{

    //In Memory Info
    [Serializable]
    public class AccountStore
    {
        public int LastId { get; set; }
        public Dictionary<int, BankAccount> Accounts { get; set; } = new Dictionary<int, BankAccount>();
    }


    //Processing Info in Memory
    public class SimpleFileAccountRepository : IAccountRepository
    {
        AccountStore store = new AccountStore();
        public IAccountStoreManager StoreManager { get; set; }

        public int AddAccount(BankAccount account)
        {
            int id=++store.LastId;
            account.AccountNumber = id;
            store.Accounts[id] = account;
            Save();
            return id;
        }

        

        public BankAccount GetAccount(int accountNumber)
        {
            if (store.Accounts.ContainsKey(accountNumber))
                return store.Accounts[accountNumber];
            else
                throw new InvalidAccountException(accountNumber);
        }

        public List<BankAccount> GetActiveAccounts()
        {
            return store.Accounts.Values.ToList();
        }

        public void RemoveAccount(BankAccount account)
        {
            GetAccount(account.AccountNumber);
            store.Accounts.Remove(account.AccountNumber);
            Save();
        }

        public void UpdateAccount(BankAccount account)
        {
            Save();
        }


        string path;
        private string v;

        public SimpleFileAccountRepository(string path,IAccountStoreManager manager)
        {
            this.path = path;
            this.StoreManager = manager;
            this.store=StoreManager.Load(path);
        }

        public void Save()
        {
            StoreManager.Save(path, store);
        }



       
    }
}
