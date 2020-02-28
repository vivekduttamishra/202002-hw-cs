using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace BankingServiceHostApp
{
    class Program
    {
        static void Main(string[] args)
        {

            var bank = new Bank("IDFC", 12);
            bank.AccountRepository = new SqlAccountRepository();

            var host = new ServiceHost(bank);
            host.Open();
            Console.WriteLine("Service is running");
            foreach(var ep in host.Description.Endpoints)
            {
                Console.WriteLine("Name:{0}",ep.Name);
                Console.WriteLine("Address:{0}",ep.Address);
                Console.WriteLine("Contract:{0}",ep.Contract.ContractType);
                Console.WriteLine("Binding:{0}",ep.Binding);
                Console.WriteLine();
            }

            Console.WriteLine("Hit Enter to Exit");
            Console.ReadLine();
            host.Close();

        }
    }
}
