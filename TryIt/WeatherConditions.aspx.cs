using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class WeatherConditions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WeatherService.Service1Client client = new WeatherService.Service1Client(); // creates service proxy
            string zip = txtBox_ZIP1.Text; // obtains ZIP code from the text box
            string[] data; // to store the data from the service operation
            string end; // to store data
            Util util = new Util();

            // Clears the labels
            util.clearLabel(lbl_info);
            util.clearLabel(lbl_first);
            util.clearLabel(lbl_last);
            HyperLink1.Text = "";

            if (!String.IsNullOrWhiteSpace(txtBox_ZIP1.Text) && util.checkZIP(zip)) // Makes sure both text boxes are full
            {
                data = client.getLocationDetails(zip);  // Calls the service operation
                if (data.Length > 1) // Makes sure that the method returned information
                {
                    end = data[data.Length - 1]; // Obtains the url in data[]
                    foreach (string str in data)
                    {
                        if (str != end)
                            lbl_info.Text += str + "<br />"; // updates the label
                        else
                        {
                            // Updates the hyper link so that users can access more weather information
                            lbl_first.Text = "Click ";
                            HyperLink1.Text = "here";
                            HyperLink1.NavigateUrl = end;
                            lbl_last.Text = " for more information on the current weather.";
                        }
                    }
                }
                else
                {
                    lbl_info.Text = data[0]; // If there is only one element, it is an error message
                }

            }
            else
            {
                lbl_info.Text = "Please enter a valid zip code."; // prompts user to enter a valid zip code
            }
        }
    }
}