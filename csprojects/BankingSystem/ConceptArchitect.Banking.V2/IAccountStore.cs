using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public interface IAccountStoreManager
    {
        void Save(string path, AccountStore store);
        AccountStore Load(string path);
    }

    public class CSVAccountStoreManager : IAccountStoreManager
    {
        public AccountStore Load(string path)
        {
           
            StreamReader reader = null;
            var store = new AccountStore();
            try
            {
                reader = new StreamReader(path);
                store.LastId = int.Parse(reader.ReadLine()); //first line contains last id


                while (true)
                {
                    var str = reader.ReadLine();
                    if (str == null)
                        break;

                    var parts = str.Split(',');
                    var id = int.Parse(parts[0]);
                    var name = parts[1];
                    var pass = parts[2];
                    var balance = double.Parse(parts[3]);
                    var accountType = parts[4];
                    BankAccount account = null;
                    switch (accountType)
                    {
                        case "SavingsAccount": account = new SavingsAccount(id, name, pass, 0); break;
                        case "CurrentAccount": account = new CurrentAccount(id, name, pass, 0); break;
                        case "OverdraftAccount": account = new OverdraftAccount(id, name, pass, 0); break;
                    }
                    account.Deposit(balance);
                    store.Accounts[id] = account;

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                reader.Close();
            }

            return store;
        }

       

        public void Save(string path, AccountStore store)
        {
                StreamWriter file = null;
                try
                {
                    file = new StreamWriter(path); // it opens a file for writing information

                    file.WriteLine(store.LastId); //first line should contain the lastId
                                                  //now for each account 1 line of info
                    foreach (var account in store.Accounts.Values)
                        file.WriteLine("{0},{1},{2},{3},{4}", account.AccountNumber, account.Name, account.password, account.Balance, account.GetType().Name);


                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error Saving Records:" + ex.Message);
                }
                finally
                {
                    if (file != null)
                        file.Close();
                }
            }
        }

    public class SerializedAccountStoreManager : IAccountStoreManager
    {
        public AccountStore Load(string path)
        {
            try
            {
                using(var reader=new StreamReader(path))
                {
                    var formatter = new BinaryFormatter();
                    return (AccountStore) formatter.Deserialize(reader.BaseStream);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new AccountStore();
            }
        }

        public void Save(string path, AccountStore store)
        {
            using( var writer=new StreamWriter(path))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(writer.BaseStream, store);
            }
        }
    }


}
