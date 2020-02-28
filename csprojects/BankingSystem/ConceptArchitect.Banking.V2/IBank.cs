using System.Collections.Generic;
using System.ServiceModel;

namespace ConceptArchitect.Banking
{
    [ServiceContract]
    public interface IBankingCustomer
    {

        [OperationContract]
        string Authenticate(int accountNumber, string password);
        [OperationContract]
        double CloseAccount(int accountNumber, string password);
        [OperationContract]
        void Transfer(int source, int amount, string password, int target);
        [OperationContract]
        void Withdraw(int accountNumber, double amount, string password);
        [OperationContract]
        void Deposit(int accountNumber, int amount);
        
        
    }

    [ServiceContract]
    public interface IBankingManager 
    {
        [OperationContract]
        BankAccount GetAccount(int accountNumber, string password);
        [OperationContract]
        void CreditInterest();
        [OperationContract]
        int OpenAccount(string customerName, string password, int amount, string accountType = "SavingsAccount");
        [OperationContract]
        List<BankAccount> GetAccountList();
    }
}