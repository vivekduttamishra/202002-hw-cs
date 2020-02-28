using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{

    [Serializable]
    public class AccountStore
    {
        public Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        public int LastId { get; set; }
    }
    public class BasicAccountRepository : AccountRepository
    {
        String path;
        AccountStore store=new AccountStore();

        public BasicAccountRepository(string path)
        {
            this.path = path;
            try
            {
                using (var reader = new StreamReader(path))
                {
                    var formatter = new BinaryFormatter();
                    store = (AccountStore)formatter.Deserialize(reader.BaseStream);
                }
            }
            catch(Exception ex)
            {
                store = new AccountStore();
            }
            
        }

        public int AddAccount(BankAccount account)
        {
            int id = ++store.LastId;
            account.AccountNumber = id;
            store.accounts[id] = account;
            Save();
            return id;
        }

        private void Save()
        {
            using(var stream=new StreamWriter(path))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream.BaseStream, store);
            }
        }

        public void DeleteAccount(BankAccount account)
        {
            store.accounts.Remove(account.AccountNumber);
            Save();
        }

        public BankAccount GetAccount(int id)
        {
            if (store.accounts.ContainsKey(id))
                return store.accounts[id];
            else
                throw new InvalidAccountException(id, "No Such Account :" + id);
        }

        public List<BankAccount> GetActiveAccounts()
        {
            return store.accounts.Values.ToList();
        }

        public void UpdateAccount(BankAccount account)
        {
            Save();
        }

        
    }
}
