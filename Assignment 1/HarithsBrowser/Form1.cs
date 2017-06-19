using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HarithsBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text); //goes to the entered URL
        }

        private void encrypt_button_Click(object sender, EventArgs e)
        {
            EncryptService.ServiceClient myClient = new EncryptService.ServiceClient();

            try
            {
                if (!String.IsNullOrWhiteSpace(textBox1.Text)) //checks if the text box has data
                {
                    lblencrypted.Text = myClient.Encrypt(textBox1.Text); //calls encrypt method and sets label to the output
                    lblconfirmation.Text = "Encrypted message: "; //sets label 

                    lbldecrypted.Text = myClient.Decrypt(lblencrypted.Text); //calls decrypted method and sets label to the output
                }
                else
                {
                    lblconfirmation.Text = ""; //clears label
                    lbldecrypted.Text = ""; //clears label
                    lblencrypted.Text = "Please enter a message."; //error message if the text box is empty 
                }
            }
            catch (Exception ec)
            {
                lblencrypted.Text = ec.Message.ToString(); //prints exception in case something bad happens
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_stock_Click(object sender, EventArgs e)
        {
            StockService.ServiceClient myClient = new StockService.ServiceClient();

            try
            {
                if (!String.IsNullOrWhiteSpace(textBox2.Text)) //checks if the text box has data
                {
                    lblstockInfo.Text = textBox2.Text.ToUpper() + "     " + myClient.getStockquote(textBox2.Text); //prints the stock symbol followed by the stockQuote data from the service          
                }
                else
                {
                    lblstockInfo.Text = "Please enter a valid stock symbol."; //asks user to enter a valid stock symbol
                }
            }
            catch (Exception ec)
            {
                lblstockInfo.Text = ec.Message.ToString(); //prints exception in case something bad happens
            }
        }
    }
}
