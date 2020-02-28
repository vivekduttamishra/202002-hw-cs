//using ConceptArchitect.Banking;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankApp
{
    public partial class CustomerForm : Form
    {
        int accountNumber;
        string password;
        string userName;

        public Form1 ParentWindow { get; internal set; }

        public CustomerForm(int accountNumber, string password, string userName)
        {
            InitializeComponent();
            this.accountNumber = accountNumber;
            this.password = password;
            this.userName = userName;

            headerLabel.Text = "Welcome " + userName;
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void CustomerForm_FormClosing(object sender, FormClosingEventArgs e)
        {

            ParentWindow.Dispose();
            new Form1().Show();
        }
    }
}
