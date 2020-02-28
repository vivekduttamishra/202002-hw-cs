
using BankAccountManagementConsole.WcfProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var bank = new Bank("ICICI", 12)
            //{
            //    AccountRepository = new BasicAccountRepository(@"c:\temp\accounts.db")
            //};

            var bank = new BankingServiceClient();
            AddAccount(bank);
            CustomerTransaction(bank);
            bank.PrintAccountList();


        }

        private static void CustomerTransaction(BankingServiceClient bank)
        {
            int from = Input.Read<int>("from account?", -1);
            if (from == -1)
                return;
            string pass = Input.Read<string>("password?");
            int amount = Input.Read<int>("amount?");
            int to = Input.Read<int>("to?");

            try
            {
                bank.Transfer(from, amount, pass, to);
                Console.WriteLine("Transfer success");
            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                //Console.WriteLine(ex.Message);
            }

        }

        private static void AddAccount(BankingServiceClient bank)
        {
            string type = Input.Read<string>("new account type?");
            if (!string.IsNullOrEmpty(type))
            {
                var name = Input.Read<string>("name?");
                var password = Input.Read<string>("password?");
                var balance = Input.Read<int>("amount?", 0);

                var id = bank.OpenAccount(type, name, password, balance);
                Console.WriteLine("New Account Created :" + id);
            }
        }
    }
}
