using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
    public partial class Form1 : Form
    {
        Bank bank;
        public Form1()
        {
            InitializeComponent();
            var name = ConfigurationManager.AppSettings["bankName"];
            var rate = double.Parse(ConfigurationManager.AppSettings["rate"]);
            bank = new Bank(name, rate)
            {
                AccountRepository = new BasicAccountRepository(@"c:\temp\accounts.db")
            };
            //DummyAccountSource source = new DummyAccountSource();
            //source.AddAccounts(bank);

            headerLabel.Text = "Welcome to " + bank.Name;
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(accountNumberTextBox.Text))
            {
                SetErrorStatus("Enter Account Number");
                return;
            }
            if(string.IsNullOrEmpty(passwordTextBox.Text))
            {
                SetErrorStatus("Enter Password");
                return;
            }

            var accountNumber = int.Parse(accountNumberTextBox.Text);
            var password = passwordTextBox.Text;

            var account = bank.GetAccount(accountNumber, password);
            if (account == null)
            {
                SetErrorStatus("Invalid Credentials");
                return;
            }

            //all is well
            SetStatus("Login Successfull");
            //MessageBox.Show("Welcome " + account.Name,"Login Success");
            var customerForm = new CustomerForm(this.bank,accountNumber, password, account.Name);
            customerForm.Show();
            this.Hide();


        }

        private void SetStatus(string message)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = Color.Blue;
        }

        private void SetErrorStatus(string message)
        {
            statusLabel.Text = message;
            statusLabel.ForeColor = Color.Maroon;
            Console.Beep();
        }
    }
}
