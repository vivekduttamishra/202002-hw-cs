using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo02
{
    partial class Form1
    {
        Label nameLabel;
        TextBox nameTextBox;
        Button hiButton;
        Button byeButton;
        private void SetupUI()
        {
            this.Width = 400;

            nameLabel = new Label()
            {
                Text = "What shall I call you?",
                Font = new Font("Forte", 18),
                Location = new Point(50, 50),
                Size = new Size(300, 30)
            };

            this.Controls.Add(nameLabel);

            nameTextBox = new TextBox()
            {
                Size = new Size(200, 80),
                Location = new Point(50, 120)
            };

            this.Controls.Add(nameTextBox);

            hiButton = new Button()
            {
                Text = "Welcome!",
                Location = new Point(60, 150)
            };

            hiButton.Click += hiButtonClick;  //call this method when button is clicked

            this.Controls.Add(hiButton);


            byeButton = new Button()
            {
                Text = "Good Bye",
                Location = new Point(160, 150)
            };

            byeButton.Click += byeButtonClickAction1; //call this method when bye button is clicked
            byeButton.Click += byeButtonClickAction2; //and also do this!

            this.Controls.Add(byeButton);
        }

    }
}
