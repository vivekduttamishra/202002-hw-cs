using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public interface IAccountRepository 
    {
        int AddAccount(BankAccount account);
        BankAccount GetAccount(int accountNumber);
        List<BankAccount> GetActiveAccounts();
        void RemoveAccount(BankAccount account);
        void UpdateAccount(BankAccount account);

    }
}
