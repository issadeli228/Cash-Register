using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Cash_Register
{
    public partial class Form1 : Form
    {
        //Issac Deline - Cash Register
        //Global Integers

        int burgerNumber;
        int frieNumber;
        int drinkNumber;
        double burgerPrice = 8.00;
        double friePrice = 5.00;
        double drinkPrice = 3.00;
        double subTotalPrice;
        double taxRate = 0.13;
        double taxAmount;
        double totalPrice;
        double tendered;
        double change;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void TotalButton_Click(object sender, EventArgs e)
        {
            try
            {
                
                burgerNumber = Convert.ToInt32(burgerInput.Text);
                frieNumber = Convert.ToInt32(frieInput.Text);
                drinkNumber = Convert.ToInt32(drinkInput.Text);

                subTotalPrice = burgerNumber * burgerPrice + frieNumber * friePrice + drinkNumber * drinkPrice;
                subTotalOutputLabel.Text = $"{subTotalPrice.ToString("c")}";

                Refresh();
                Thread.Sleep(500);

                taxAmount = taxRate * subTotalPrice;
                taxOutputLabel.Text = $"{taxAmount.ToString("c")}";

                Refresh();
                Thread.Sleep(500);

                totalPrice = taxAmount + subTotalPrice;
                totalOutputLabel.Text = $"{totalPrice.ToString("c")}";

            }
            catch
            {
                reciptOutputLabel.Text = $"Please input whole number choices";
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {

                tendered = Convert.ToInt32(tenderedInput.Text);

                change = tendered - totalPrice;
                changeOutputLabel.Text = $"{change.ToString("c")}";
            }
            catch
            {
                reciptOutputLabel.Text = $"Please input a correct amount for tendered";
            }
                
        }

        private void ReciptButton_Click(object sender, EventArgs e)
        {
            nameLabel.Visible = true;

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\n\n\nOrder Number 1024";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\nFebuary 11, 2021";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\n\nBurgers x{burgerNumber} @ {burgerNumber * burgerPrice.ToString("c")}";
            

        }
    }
}

