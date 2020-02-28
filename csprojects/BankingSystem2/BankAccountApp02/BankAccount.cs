using System;

namespace BankAccountApp01
{
    //internal  by default
    public class BankAccount
    {

        //private by default
        int accountNumber;
        string name;
        string password;
        double balance;
        double rate;


        public string GetName()
        {
            return name;
        }

        public void SetName(string newName)
        {
            if(LastName(name)==LastName(newName))
                this.name = newName;
        }

        private string LastName(string name)
        {
            var ndx = name.LastIndexOf(" ");
            if (ndx == -1) //no blank space
                return ""; //no last name
            else
                return name.Substring(ndx + 1);
        }

        public double GetRate() { return rate; }
        public void SetRate(double newRate) { rate = newRate; }


        public int GetAccountNumber() { return accountNumber; }

        // accountNumber is immutable --> not modifiable
        //public void SetAccountNumber(int newAccountNumber) { accountNumber = newAccountNumber; }

        public double GetBalance() { return balance; }

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
            this.balance = balance;
            this.rate = rate;
        }

        public bool Withdraw(double amount, string password)
        {


            if (amount <= 0)
                return false;//Console.WriteLine("Amount should be positive");
            else if (amount > balance)
                return false;// Console.WriteLine("Insufficient balance");
            else if (Authenticate(password))
                return false;// Console.WriteLine("Invalid credentials");
            else
            {
                //Console.WriteLine("Please collect your cash");
                balance -= amount;
                return true;
            }

        }

        public bool Deposit(double amount)
        {
            if (amount <= 0)
                return false;
            else
            {
                balance += amount;
                return true;
            }
        }

        public void CreditInterest()
        {
            balance += balance * rate / 1200;
        }

      

        public void Show()
        {
            Console.WriteLine("Account Number "+accountNumber);
            Console.WriteLine("Name " + name);
            Console.WriteLine("Balance " + balance);
            //Console.WriteLine("Password " + password);
            Console.WriteLine("Rate " + rate);
        }
    }
}