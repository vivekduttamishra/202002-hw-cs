using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo02
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            SetupUI();
        }

        
        void hiButtonClick(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            if (string.IsNullOrEmpty(name))
                MessageBox.Show("Please Enter your Name", "Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                MessageBox.Show("Welcome to Handcoded Win Form", "Hello " + name);
        }

        void byeButtonClickAction1(object sender, EventArgs e)
        {
            string name = nameTextBox.Text;
            if (string.IsNullOrEmpty(name))
                MessageBox.Show("Please Enter your Name", "Name Missing", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                MessageBox.Show("Thanks for using our App", "Good Bye " + name);

        }

        void byeButtonClickAction2(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
