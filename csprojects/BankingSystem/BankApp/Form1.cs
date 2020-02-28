using BankApp.BankServiceProxy;
//using ConceptArchitect.Banking;
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
        //Bank bank;
        BankingCustomerClient bank;
        public Form1()
        {
            InitializeComponent();
            var name = ConfigurationManager.AppSettings["bankName"];
            var rate =double.Parse( ConfigurationManager.AppSettings["rate"]);
            //bank = new Bank(name,rate);
            bank = new BankingCustomerClient();

            
            headerLabel.Text = "Welcome";
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
            try
            {
                SetStatus("connecting...");
                string name = bank.Authenticate(accountNumber, password);
                SetStatus("Login Successfull");
                var customerForm = new CustomerForm(accountNumber, password, name)
                {
                    ParentWindow = this
                };
                customerForm.Show();
                this.Hide();
            }catch(Exception ex)
            {
                SetErrorStatus(ex.Message);
                MessageBox.Show(ex.Message, ex.GetType().Name, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


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
