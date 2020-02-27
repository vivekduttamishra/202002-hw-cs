using System;

namespace BankAccountApp01
{
    //internal  by default
    public class BankAccount
    {

        //private by default
        
        
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

        //double rate; //create a private field
        //public double Rate //create a public property
        //{
        //    get { return rate; } //write usual get
        //    set { rate = value; } //write usual set
        //}

        private double rate;

        public double Rate
        {
            get { return rate; }
            set { rate = value; }
        }



        //double balance;
        //public double Balance
        //{
        //    get { return balance; }
        //    //no set
        //}

        public double Balance { get; private set; }





        private string LastName(string name)
        {
            var ndx = name.LastIndexOf(" ");
            if (ndx == -1) //no blank space
                return ""; //no last name
            else
                return name.Substring(ndx + 1);
        }

        public double GetRate() { return Rate; }
        public void SetRate(double newRate) { Rate = newRate; }


        public int GetAccountNumber() { return accountNumber; }

        // accountNumber is immutable --> not modifiable
        //public void SetAccountNumber(int newAccountNumber) { accountNumber = newAccountNumber; }

        public double GetBalance() { return Balance; }

        //No SetBalance

        // no get set password
        //public string GetPassword() { return password; }
        //public void SetPassword(string newPassword) { password = newPassword; }

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

        public BankAccount(int accountNumber, string name, string password, int balance, int rate)
        {
            this.accountNumber = accountNumber;
            this.name = name;
            this.password = password;
            this.Balance = balance;
            this.Rate = rate;
        }

        public bool Withdraw(double amount, string password)
        {


            if (amount <= 0)
                return false;//Console.WriteLine("Amount should be positive");
            else if (amount > Balance)
                return false;// Console.WriteLine("Insufficient balance");
            else if (Authenticate(password))
                return false;// Console.WriteLine("Invalid credentials");
            else
            {
                //Console.WriteLine("Please collect your cash");
                Balance -= amount;
                return true;
            }

        }

        public bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;
            else
            {
                Balance += amount;
                return true;
            }
        }

        public void CreditInterest()
        {
            Balance += Balance * Rate / 1200;
        }

      

        public void Show()
        {
            Console.WriteLine("Account Number "+accountNumber);
            Console.WriteLine("Name " + name);
            Console.WriteLine("Balance " + Balance);
            //Console.WriteLine("Password " + password);
            Console.WriteLine("Rate " + Rate);
        }
    }
}