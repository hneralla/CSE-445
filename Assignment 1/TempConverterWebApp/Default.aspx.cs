using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void button1_Click(object sender, EventArgs e)
        {
            TempService.Service1Client tempService = new TempService.Service1Client();

            if (!String.IsNullOrWhiteSpace(textBox1.Text)) //checks if the text box is empty
            {
                int f = tempService.c2f(Int32.Parse(textBox1.Text)); //obtains the fahrenheit value by invoking the c2f service
                label1.Text = f.ToString() + "° F"; //sets the label to the answer
            }
            else
            {
                label1.Text = "Please enter a number."; //error message if the text box is empty
            }

            if (!String.IsNullOrWhiteSpace(textBox2.Text)) //checks if the text box is empty
            {
                int c = tempService.f2c(Int32.Parse(textBox2.Text)); //obtains the celsius value by invoking the f2c service
                label2.Text = c.ToString() + "° C"; //sets the label to the answer
            }
            else
            {
                label2.Text = "Please enter a number."; //error message if the text box is empty
            }
        }
    }
}