using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    //Savings Account is a type of BankAccount
    [Serializable]
    public class SavingsAccount : BankAccount
    {
        public SavingsAccount(int accountNumber, string name, string password, int balance)
            : base(accountNumber, name, password, balance)
        {

        }

        public int MinBalance
        {
            get { return 5000; }
        }

        public override double WithdrawableLimit
        {
            get { return Balance - MinBalance; }
        }


        //public override bool Withdraw(double amount, string password)
        //{
        //    if (amount > Balance - MinBalance)
        //        return false;

        //    //if (amount <= 0)
        //    //    return false;
        //    //if (!Authenticate(password))
        //    //    return false;

        //    //balance -= amount;
        //    //return true;

        //    return base.Withdraw(amount, password);
        //}
    }
}
