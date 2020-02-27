using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dem01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            byeButton.Click += ExitApplication;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Console.WriteLine("Hello World");
            var name = nameTextBox.Text;
            if (string.IsNullOrEmpty(name))
                MessageBox.Show("May I know your name please", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                MessageBox.Show("Hello "+name+"\nWelcome to \nWin Forms World!", "Greeting",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void ByeButton_Click(object sender, EventArgs e)
        {
            var name = nameTextBox.Text;
            if (string.IsNullOrEmpty(name))
                MessageBox.Show("May I know your name please", "Missing Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
            else
                MessageBox.Show("Good Bye " + name + "\nThanks for using the app");
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
