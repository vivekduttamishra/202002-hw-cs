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
            var bank = new Bank("ICICI", 12)
            {
                AccountRepository = new BasicAccountRepository(@"c:\temp\accounts.db")
            };

            var host = new ServiceHost(bank,
                        //new Uri("net.tcp://localhost:9000"),
                        new Uri("http://localhost:8000")
                                );

            host.AddDefaultEndpoints();
            host.Open();
            
            
            foreach(var ep in host.Description.Endpoints)
            {
                Console.WriteLine(ep.Name);
                Console.WriteLine(ep.Address.Uri);
                Console.WriteLine(ep.Contract.ContractType);
                Console.WriteLine(ep.Binding);
                Console.WriteLine();
            }
            Console.WriteLine("Hit Enter to Exit");
            Console.ReadLine();
            Console.WriteLine("Service Shutdown!");
        }
    }
}
