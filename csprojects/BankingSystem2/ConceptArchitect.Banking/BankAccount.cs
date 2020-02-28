using System;
using System.Runtime.Serialization;

namespace ConceptArchitect.Banking
{
    //internal  by default
    [Serializable]
    [DataContract]
    public abstract class BankAccount
    {

        [DataMember]
        string password;       
        [DataMember]
        string name;
        
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (LastName(name) == LastName(value))
                    this.name = value;
            }
        }
        [DataMember]
        int accountNumber;
        
        public int AccountNumber
        {
            get { return accountNumber; }
            //no set
            internal set { accountNumber = value; }
        }
        
        [DataMember]
        public double Balance { get; protected set; }

        public BankAccount(int accountNumber, string name, string password, int balance)
        {
            this.accountNumber = accountNumber; //lastId
            this.name = name;
            this.password = password;
            this.Balance = balance;
            //this.Rate = rate;
        }


        private string LastName(string name)
        {
            var ndx = name.LastIndexOf(" ");
            if (ndx == -1) //no blank space
                return ""; //no last name
            else
                return name.Substring(ndx + 1);
        }

      
        public void Authenticate(string newPassword)
        {
            if(password != newPassword)
                throw new InvalidCredentialsException(AccountNumber,"Invalid Credentials");
        }



        public void ChangePassword(string oldPassword, string newPassword)
        {
            Authenticate(oldPassword);
            password = newPassword;
            
        }

        
        

        public virtual void CreditInterest(double rate)
        {
            Balance += Balance * rate / 1200;
        }
        public abstract double MaxWithdrawableAmount { get; }
        public virtual void Withdraw(double amount, string password)
        {
            ValidateDenomination(amount);
            Authenticate(password);

            if (amount > MaxWithdrawableAmount)
                throw new InsufficientBalanceException(AccountNumber, "Insufficient Balance")
                {
                    Deficit = amount - MaxWithdrawableAmount
                };

            Balance -= amount;

        }

        private void ValidateDenomination(double amount)
        {
            if (amount <= 0)
                throw new InvalidDenominationException(AccountNumber, "Amount Can't be Negative");

        }

        public virtual void Deposit(double amount)
        {
            ValidateDenomination(amount);
            Balance += amount;            
        }

       

      
        [Obsolete("Prefer ToString() over Show()")]
        public void Show()
        {
            Console.WriteLine("Account Number "+accountNumber);
            Console.WriteLine("Name " + name);
            Console.WriteLine("Balance " + Balance);
            //Console.WriteLine("Password " + password);
            //Console.WriteLine("Rate " + Rate);
        }




    }
}