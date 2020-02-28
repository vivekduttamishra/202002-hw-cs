using System.ServiceModel;

namespace ConceptArchitect.Banking
{
    [ServiceContract]
    public interface IBankingService
    {

        string Name { get; }

        [OperationContract]
        void Authenticate(int accountNumber, string password);
        [OperationContract]
        double CloseAccount(int accountNumber, string password);
        [OperationContract]
        void CreditInterest();
        [OperationContract]
        void Deposit(int accountNumber, int amount);

        [OperationContract]
        BankAccount GetAccount(int accountNumber, string password);
        [OperationContract]
        int OpenAccount(string type, string customerName, string password, int amount);
        [OperationContract]
        void PrintAccountList();
        [OperationContract]
        void Transfer(int source, int amount, string password, int target);
        [OperationContract]
        void Withdraw(int accountNumber, double amount, string password);
    }
}