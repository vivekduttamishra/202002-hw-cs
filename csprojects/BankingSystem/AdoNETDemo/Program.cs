using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoNETDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //step 1- create a connection
            var connection = new SqlConnection();

            //step 1.1 - set connection string
            connection.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\MyWorks\Corporate\202002-honeywell-cs\hwbanking.mdf;Integrated Security=True;Connect Timeout=30";

            //step 1.2 - open the conenction
            connection.Open();
            Console.WriteLine("Conenction Success!");

            //step 2 - create a command
            var command = new SqlCommand();

            //step 2.1 - connect command to connection
            command.Connection = connection;

            //step 2.2 - define your query
            command.CommandText = "select * from BankAccounts"; //select everything from the given table


            //step 2.3 - execute command to get a set of results

            var results = command.ExecuteReader();
            int count = 0;

            while(results.Read()) //as long as there is something to read
            {
                var accountNumber =(int) results["AccountNumber"];
                var name = (string)results["Name"];
                var password = (string)results["Password"];
                var accountType = (string)results["AccountType"];
                var balance =(float) results["Balance"];
                var odLimit =(float) results["OdLimit"];

                

                Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}",accountNumber,balance,odLimit,name,accountType,password);
                count++;
            }

            Console.WriteLine("Total {0} records founds",count);
            

            // step Last
            connection.Close();

        }
    }
}
