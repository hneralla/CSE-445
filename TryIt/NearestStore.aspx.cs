using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class NearestStore : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_submit2_Click(object sender, EventArgs e)
        {
            NearestStoreService.Service1Client client = new NearestStoreService.Service1Client(); // Makes sure both text boxes are full
            Util util = new Util();
            util.clearLabel(lbl_info2);  // clears label
            IMG2.ImageUrl = ""; // clears image URL

            string zipcode = txtBox_ZIP2.Text; // obtains ZIP code from the text box
            string data = ""; // to store data

            if (!String.IsNullOrWhiteSpace(txtBox_ZIP2.Text) && !String.IsNullOrWhiteSpace(txtBox_storeName.Text)) // checks if both text boxes have data
            {
                if (util.checkZIP(zipcode)) // checks ZIP code validity 
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
    }
}