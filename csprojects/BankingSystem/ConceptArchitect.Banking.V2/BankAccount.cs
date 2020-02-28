using System;

namespace ConceptArchitect.Banking
{
    //internal  by default
    [Serializable]
    public abstract  class BankAccount
    {

        
        internal string password;       
        
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

        int accountNumber;
        public int AccountNumber
        {
            get { return accountNumber; }
            //no set
            internal set { accountNumber = value; }
        }

        protected double balance;

        public double Balance
        {
            get { return balance; }
            private set { balance = value; }
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
            if (password != newPassword)
                throw new InvalidCredentialsException(AccountNumber);
           
        }

        public void ChangePassword(string oldPassword, string newPassword)
        {
            Authenticate(oldPassword);
            password = newPassword;
            
        }

        //static int lastId=0
        public BankAccount(int accountNumber, string name, string password, int balance)
        {
            //lastId++;
            this.accountNumber = accountNumber; //lastId
            this.name = name;
            this.password = password;
            this.Balance = balance;
            //this.Rate = rate;
        }

        public virtual void CreditInterest(double rate)
        {
            Balance += Balance * rate / 1200;
        }

        public abstract double WithdrawableLimit { get; }

        public virtual void Withdraw(double amount, string password)
        {
            ValidatedDenomination(amount);

            if (amount > WithdrawableLimit)
                throw new InsufficientBalanceException(accountNumber) { Deficit = amount - WithdrawableLimit }; //return false;// Console.WriteLine("Insufficient balance");
            Authenticate(password);                
            Balance -= amount;
                

        }

        private void ValidatedDenomination(double amount)
        {
            if (amount <= 0)
                throw new InvalidDenominationException(AccountNumber);
        }

        public virtual void Deposit(double amount)
        {
            ValidatedDenomination(amount);
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