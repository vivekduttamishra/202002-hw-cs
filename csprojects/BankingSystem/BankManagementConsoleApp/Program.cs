using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankManagementConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var manager = new CSVAccountStoreManager();
            var manager = new SerializedAccountStoreManager();
            Bank bank = new Bank("IDFC", 12)
            {
                AccountRepository = new SimpleFileAccountRepository(@"c:\temp\bank.dat",manager)


            };

            var accountType = Input.Read<string>("account type ?");
            if(!string.IsNullOrEmpty(accountType))
            {
                var name = Input.Read<string>("name?");
                var password = Input.Read<string>("password?");
                var balance = Input.Read<int>("balance?");
                var id=bank.OpenAccount(name, password, balance, accountType);
                Console.WriteLine("Account created :"+id);

            }

            bank.PrintAccountList();
        


        }
    }
}
