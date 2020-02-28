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
        public double OdLimit { get; private set; }
        public OverdraftAccount(int accountNumber, string name, string password, int balance) : base(accountNumber, name, password, balance)
        {
            AdjustOdLimit();
        }

        private void AdjustOdLimit()
        {
            if(OdLimit*10<Balance)
                OdLimit = Balance / 10;
        }

        public override void CreditInterest(double rate)
        {
            base.CreditInterest(rate);
            AdjustOdLimit();
        }

        public override double WithdrawableLimit
        {
            get { return Balance + OdLimit; }
        }

        public override void Withdraw(double amount, string password)
        {
            base.Withdraw(amount, password); //will allow the withdraw
            //if (amount < 0)
            //    return false;
            //if (amount > Balance + OdLimit)
            //    return false;
            //if (!Authenticate(password))
            //    return false;
            //balance -= amount;

            if (Balance < 0)
                balance -= (-balance / 100); //1% od fee

            
        }

        public override void Deposit(double amount)
        {
            base.Deposit(amount);
            AdjustOdLimit();
            
        }
    }
}
