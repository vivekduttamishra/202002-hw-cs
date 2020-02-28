using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    [Serializable]
    public class OverdraftAccount : BankAccount
    {
        public OverdraftAccount(int accountNumber, string name, string password, int balance) : base(accountNumber, name, password, balance)
        {
            AdjustOdLimit();
        }

        private void AdjustOdLimit()
        {
            if (Balance > OdLimit * 10)
                OdLimit = Balance / 10;
        }

        public override void CreditInterest(double rate)
        {
            base.CreditInterest(rate);
            AdjustOdLimit();
        }

        public override void Withdraw(double amount, string password)
        {
            base.Withdraw(amount, password);
            if (Balance < 0)
            {
                var odfee = -Balance / 100;
                Balance -= odfee;
            }
        }

        public override void Deposit(double amount)
        {
            base.Deposit(amount);
            AdjustOdLimit();
        }

        public override double MaxWithdrawableAmount
        {
            get
            {
                return Balance + OdLimit;
            }
        }

        public double OdLimit { get; private set; }


    }
}
