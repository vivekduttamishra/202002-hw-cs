using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Banking
{
    public class BankingException : Exception
    {
        public int AccountNumber { get; set; }
        public BankingException(int accountNumber, string message="Banking Exception"):base(message)
        {
            AccountNumber = accountNumber;
        }
    }

    public class InvalidCredentialsException : BankingException
    {
        public InvalidCredentialsException(int accountNubmer, string message = "Invalid Credentials") : base(accountNubmer, message)
        {
        }
    }


    public class InvalidDenominationException : BankingException
    {
        public InvalidDenominationException(int accountNubmer, string message = "Invalid Denomination") : base(accountNubmer, message)
        {
        }
    }

    public class InvalidAccountException : BankingException
    {
        public InvalidAccountException(int accountNubmer, string message = "Invalid Account") : base(accountNubmer, message)
        {
        }
    }

    public class InsufficientBalanceException : BankingException
    {
        public double Deficit { get; set; }
        public InsufficientBalanceException(int accountNubmer, string message = "Insufficient Balance") : base(accountNubmer, message)
        {
        }
    }

}
