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
using System.Media;

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
        double totalBurgerPrice;
        double totalFriePrice;
        double totalDrinkPrice;



        public Form1()
        {
            InitializeComponent();
        }

        private void TotalButton_Click(object sender, EventArgs e)
        {
            try
            {
                errorLabel.Text = "";
                
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
                errorLabel.Text = $"Please input whole number choices";
            }
        }

        private void ChangeButton_Click(object sender, EventArgs e)
        {
            try
            {
                errorLabel.Text = "";

                tendered = Convert.ToInt32(tenderedInput.Text);

                change = tendered - totalPrice;
                changeOutputLabel.Text = $"{change.ToString("c")}";
            }
            catch
            {
                errorLabel.Text = $"Please input a correct amount for tendered";
            }
                
        }

        private void ReciptButton_Click(object sender, EventArgs e)
        {

            SoundPlayer reciptSound = new SoundPlayer(Properties.Resources._345056__azumarill__epson_receipt_printer3__1_);
            reciptSound.Play();

            reciptOutputLabel.Text = "";
            itemNumberOutputLabel.Text = "";
            reciptPriceOutputLabel.Text = "";
            errorLabel.Text = "";

            totalBurgerPrice = burgerNumber * burgerPrice;
            totalFriePrice = frieNumber * friePrice;
            totalDrinkPrice = drinkNumber * drinkPrice;

            errorLabel.Text = $"";

            nameLabel.Visible = true;

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"Order Number 1024";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\nFebuary 11, 2021";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\n\nBurgers";
            itemNumberOutputLabel.Text += $"\n\n\nx{burgerNumber}";
            reciptPriceOutputLabel.Text += $"\n\n\n{totalBurgerPrice.ToString("c")}";


            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\nFries";
            itemNumberOutputLabel.Text += $"\nx{frieNumber}";
            reciptPriceOutputLabel.Text += $"\n{totalFriePrice.ToString("c")}";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\nDrinks";
            itemNumberOutputLabel.Text += $"\nx{drinkNumber}";
            reciptPriceOutputLabel.Text += $"\n{totalDrinkPrice.ToString("c")}";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\n\nsubtotal:";
            reciptPriceOutputLabel.Text += $"\n\n{subTotalPrice.ToString("c")}";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\nTax:";
            reciptPriceOutputLabel.Text += $"\n  {taxAmount.ToString("c")}";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\nTotal:";
            reciptPriceOutputLabel.Text += $"\n{totalPrice.ToString("c")}";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\n\nTendered";
            reciptPriceOutputLabel.Text += $"\n\n{tendered.ToString("c")}";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\nChange";
            reciptPriceOutputLabel.Text += $"\n{change.ToString("c")}";

            Refresh();
            Thread.Sleep(500);

            reciptOutputLabel.Text += $"\n\nSee You Soon!";



        }

        private void NewOrderButton_Click(object sender, EventArgs e)
        {
            reciptOutputLabel.Text = "";
            itemNumberOutputLabel.Text = "";
            reciptPriceOutputLabel.Text = "";
            errorLabel.Text = "";
            nameLabel.Visible = false;

            burgerInput.Text = "";
            frieInput.Text = "";
            drinkInput.Text = "";

            subTotalOutputLabel.Text = "";
            taxOutputLabel.Text = "";
            totalOutputLabel.Text = "";

            tenderedInput.Text = "";
            changeOutputLabel.Text = "";

            burgerNumber = 0;
            frieNumber = 0;
            drinkNumber = 0;

            subTotalPrice = 0;
            taxAmount = 0;
            totalPrice = 0;

            tendered = 0;
            change = 0;

        }
    }
}

