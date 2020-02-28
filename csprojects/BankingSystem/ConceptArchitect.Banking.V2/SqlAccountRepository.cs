using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace ConceptArchitect.Banking
{
    public class SqlAccountRepository : IAccountRepository
    {
        String connectionString;

        public SqlAccountRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["bankConnectionString"].ConnectionString;
        }

        public int AddAccount(BankAccount account)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();
                var command = new SqlCommand() { Connection = connection };
                command.CommandText =
                    "INSERT INTO BankAccounts(Name,Password,Balance,AccountType,OdLimit) " +
                    "OUTPUT INSERTED.ID " +
                    "VALUES(@name, @password,@balance,@type,@odLimit)";
                command.Parameters.AddWithValue("@name", account.Name);
                command.Parameters.AddWithValue("@password", account.password);
                command.Parameters.AddWithValue("@balance", account.Balance);
                command.Parameters.AddWithValue("@type", account.GetType().Name);

                double odLimit = 0;
                if (account is OverdraftAccount)
                    odLimit = (account as OverdraftAccount).OdLimit;

                command.Parameters.AddWithValue("@type", odLimit);

                return (int)command.ExecuteScalar();
            }catch(SqlException ex)
            {
                Console.WriteLine("Error Inserting Record:"+ex.Message);
                throw ex;
            }
            finally
            {
                connection.Close();
            }


        }

        public BankAccount GetAccount(int accountNumber)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();
                var command = new SqlCommand() { Connection = connection };
                command.CommandText = "select * from BankAccounts where AccountNumber=" + accountNumber;
                var reader=command.ExecuteReader();
                if (reader.Read())
                {
                    return GetBankAccount(reader);
                }
                else
                    throw new InvalidAccountException(accountNumber);
                    
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Inserting Record:" + ex.Message);
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        private BankAccount GetBankAccount(SqlDataReader reader)
        {
            var accountNumber =(int) reader["AccountNumber"];
            var name = (string)reader["Name"];
            var password = (string)reader["Password"];
            var type = (string)reader["AccountType"];
            var balance = (float)reader["Balance"];

            switch (type)
            {
                case "SavingsAccount": return new SavingsAccount(accountNumber, name, password, balance);
                case "OverdraftAccount": return new OverdraftAccount(accountNumber, name, password, balance)
                {
                    OdLimit = (float)reader["OdLimit"]
                };
                case "CurrentAccount": return new CurrentAccount(accountNumber, name, password, balance);
            }
            throw new InvalidAccountException(0, "InvalidAccountType");
        }

        public List<BankAccount> GetActiveAccounts()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();
                var command = new SqlCommand() { Connection = connection };

                command.CommandText = "select * from BankAccounts";

                var reader = command.ExecuteReader();
                List<BankAccount> accounts = new List<BankAccount>();
                while (reader.Read())
                {
                    var account= GetBankAccount(reader);
                    accounts.Add(account);
                }
                return accounts;

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Inserting Record:" + ex.Message);
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void RemoveAccount(BankAccount account)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();
                var command = new SqlCommand() { Connection = connection };
                command.CommandText = "delete * from BankAccounts where AccountNumber=" + account.AccountNumber;
                command.ExecuteNonQuery();
                

            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Deleting Record:" + ex.Message);
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }

        public void UpdateAccount(BankAccount account)
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection() { ConnectionString = connectionString };
                connection.Open();
                var command = new SqlCommand() { Connection = connection };
                command.CommandText = "update BankAccounts set balance=@balance, OdLimit=@odLimit password=@password, name=@name where acountNumber=" + account.AccountNumber;
                command.Parameters.AddWithValue("@name", account.Name);
                command.Parameters.AddWithValue("@balance", account.Balance);
                command.Parameters.AddWithValue("@password", account.password);
                double odLimit = 0;
                if(account is OverdraftAccount)
                {
                    odLimit = (account as OverdraftAccount).OdLimit;
                }

                command.Parameters.AddWithValue("@odLimit", odLimit);
                var reader = command.ExecuteNonQuery();


            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error Update Record:" + ex.Message);
                throw ex;
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
