using ConceptArchitect.Banking;
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
        public CustomerForm(Bank bank,int accountNumber, string password, string userName)
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
    }
}
