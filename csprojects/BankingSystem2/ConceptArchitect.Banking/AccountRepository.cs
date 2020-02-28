using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public interface AccountRepository
    {
        int AddAccount(BankAccount account);
        List<BankAccount> GetActiveAccounts();
        BankAccount GetAccount(int id);
        void UpdateAccount(BankAccount account);
        void DeleteAccount(BankAccount account);
    }
}
