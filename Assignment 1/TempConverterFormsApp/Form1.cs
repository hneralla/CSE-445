using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TempConverterFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Convert_Click(object sender, EventArgs e)
        {
            //lblDefault shows an error message when both text boxes are empty

            TempService.Service1Client tempService = new TempService.Service1Client();
            lblDefault.Text = ""; //clears the text of a label

            if (String.IsNullOrWhiteSpace(textBox1.Text) && String.IsNullOrWhiteSpace(textBox2.Text)) //checks if both text boxes are empty
            {
                lblFahren.Text = ""; //clears the label where the Fahrenheit answer will be printed
                lblCelsius.Text = ""; //clears the label where the Celsius answer will be printed
                lblDefault.Text = "Please enter a number."; //shows error message
                return;
            }

            if (!String.IsNullOrWhiteSpace(textBox1.Text)) //checks if the text box is empty
            {
                int f = tempService.c2f(Convert.ToInt32(Math.Round(Double.Parse(textBox1.Text), MidpointRounding.AwayFromZero))); //obtains the fahrenheit value by invoking the c2f service
                lblFahren.Text = f.ToString() + "° F"; //sets the label to the answer
            }
            else
            {
                lblFahren.Text = "Please enter a number."; //error message if the c2f text box is empty
            }

            if (!String.IsNullOrWhiteSpace(textBox2.Text)) //checks if the text box is empty
            {
                int c = tempService.f2c(Convert.ToInt32(Math.Round(Double.Parse(textBox2.Text), MidpointRounding.AwayFromZero))); //obtains the celsius value by invoking the f2c service
                lblCelsius.Text = c.ToString() + "° C"; //sets the label to the answer
            }
            else
            {
                lblCelsius.Text = "Please enter a number."; //error message if the f2c text box is empty
            }
        }
    }
}
