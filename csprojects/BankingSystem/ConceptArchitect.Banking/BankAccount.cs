using System;

namespace ConceptArchitect.Banking
{
    //internal  by default
    public abstract  class BankAccount
    {

        
        string password;       
        
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

      
        public bool Authenticate(string newPassword)
        {
            return password == newPassword;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            if (Authenticate(oldPassword))
            {
                password = newPassword;
                return true;
            }
            else
                return false;
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

        public virtual bool Withdraw(double amount, string password)
        {
            if (amount <= 0)
                return false;//Console.WriteLine("Amount should be positive");
            else if (amount > WithdrawableLimit)
                return false;// Console.WriteLine("Insufficient balance");
            else if (!Authenticate(password))
                return false;// Console.WriteLine("Invalid credentials");
            else
            {
                //Console.WriteLine("Please collect your cash");
                Balance -= amount;
                return true;
            }

        }

        public virtual bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
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