using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace TryIt
{
    public partial class _Default : Page
    {
        // Author: Harith Neralla
        // ASU CSE 445 Summer 2017
        // 06/10/2017

        // This web application allows users to test out the NearestStore and WeatherConditions service
        
        private void clearLabel(Label lbl)
        {
            // Clears the text of the label in the parameter
            lbl.Text = "";
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WeatherService.Service1Client client = new WeatherService.Service1Client(); // creates service proxy
            string zip = txtBox_ZIP1.Text; // obtains ZIP code from the text box
            string[] data; // to store the data from the service operation
            string end; // to store data

            // Clears the labels
            clearLabel(lbl_info); 
            clearLabel(lbl_first);
            clearLabel(lbl_last);
            HyperLink1.Text = "";
            
            if (!String.IsNullOrWhiteSpace(txtBox_ZIP1.Text) && checkZIP(zip)) // Makes sure both text boxes are full
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

        protected void btn_submit2_Click(object sender, EventArgs e)
        {
            NearestStore.Service1Client client = new NearestStore.Service1Client(); // Makes sure both text boxes are full
            clearLabel(lbl_info2);  // clears label
            IMG2.ImageUrl = ""; // clears image URL

            string zipcode = txtBox_ZIP2.Text; // obtains ZIP code from the text box
            string data = ""; // to store data

            if (!String.IsNullOrWhiteSpace(txtBox_ZIP2.Text) && !String.IsNullOrWhiteSpace(txtBox_storeName.Text)) // checks if both text boxes have data
            {
                if (checkZIP(zipcode)) // checks ZIP code validity 
                {
                    data = client.findNearestStore(zipcode, txtBox_storeName.Text); // finds the nearest store 
                    var output = data.Split(new[] { '|' }); // splits the data using '|'

                    if (output.Length > 1) // If there is only one element, it is an error message
                    {
                        // updates data on the TryIt page
                        IMG2.ImageUrl = output[0]; 
                        lbl_info2.Text += "Store Name: " + output[1] + "<br />";
                        lbl_info2.Text += "Store Rating: " + output[2] + "<br />";
                        lbl_info2.Text += "Store Address: " + output[3];
                    }
                    else
                        lbl_info2.Text = output[0]; // updates label with an error message
                   
                }
                else
                {
                    lbl_info2.Text = "Enter a valid ZIP code."; // prompts user to enter a valid zip code
                }
            }
            else
            {
                lbl_info2.Text = "Please enter data in both boxes."; // prompts user to enter data in both boxes
            }
            
        }

        private Boolean checkZIP(string zipcode)
        {
            // Checks the validity of the ZIP code
            string usZipValid = @"^\d{5}(?:[-\s]\d{4})?$"; // makes sure that the zipcode is a valid US ZIP

            if (Regex.Match(zipcode, usZipValid).Success)
                return true;
            else
                return false;
        } 
    }
}