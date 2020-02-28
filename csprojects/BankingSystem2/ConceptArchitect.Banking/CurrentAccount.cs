﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    [Serializable]
    public class CurrentAccount : BankAccount
    {
        
        public CurrentAccount(int accountNumber, string name, string password, int balance) : base(accountNumber, name, password, balance)
        {
        }

        public override double MaxWithdrawableAmount
        {
            get { return Balance; }
        }

        public override void CreditInterest(double rate)
        {
            //do nothing!
        }
    }
}