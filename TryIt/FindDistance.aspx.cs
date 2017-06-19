using System;
using System.Net;
using Newtonsoft.Json.Linq;

namespace TryIt
{
    public partial class FindDistance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Radio buttons for the origin section
        protected void rdio_btn_address_CheckedChanged(object sender, EventArgs e)
        {
            if (rdio_btn_address.Checked) // makes sure the button was checked
            {
                rdio_btn_ZIP.Checked = false; // disables the other button
                txtBox_1.Visible = true; 
                txtBox_2.Visible = true;
                lbl_1.Text = "Street Address: ";
                lbl_2.Text = "City: ";
            }
        }

        protected void rdio_btn_ZIP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdio_btn_ZIP.Checked) // makes sure the button was checked
            {
                rdio_btn_address.Checked = false; // disables the other button
                txtBox_1.Visible = true;
                txtBox_2.Visible = false; // disables the second textbox
                lbl_1.Text = "Enter ZIP code: ";
                lbl_2.Text = ""; // clears the label
            }
        }

        // Radio buttons for the destination section
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton1.Checked)
            {
                RadioButton2.Checked = false;
                TextBox1.Visible = true;
                TextBox2.Visible = true;
                Label1.Text = "Street Address: ";
                Label2.Text = "City: ";
            }
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioButton2.Checked)
            {
                RadioButton1.Checked = false;
                TextBox1.Visible = true;
                TextBox2.Visible = false;
                Label1.Text = "Enter ZIP code: ";
                Label2.Text = "";
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            Util util = new Util(); // utility object to access utility operations defined in the TryIt namespace
            JArray arr; // To load the service data into
            string origin = ""; 
            string dest = "";

            util.clearLabel(lbl_info);
            util.clearLabel(Label3);

            // Checks if the origin address/ZIP are valid
            if (rdio_btn_address.Checked)
            {
                origin += "ADD:"; // lets the service know the parameter is an address
                if (String.IsNullOrWhiteSpace(txtBox_1.Text) || String.IsNullOrWhiteSpace(txtBox_2.Text)) // checks if either text box is empty
                {
                    lbl_info.Text = "Please enter text in both fields."; // prompts user to enter valid data
                    return;
                }
                else
                {
                    origin += txtBox_1.Text + ":"; // Obtains the address and adds a ':' for the service to split
                    origin += txtBox_2.Text; // 
                }
            }
            else if (rdio_btn_ZIP.Checked)
            {
                origin += "ZIP:"; // lets the service know the parameter is a ZIP code
                if (String.IsNullOrWhiteSpace(txtBox_1.Text)) // checks if the text box is empty
                {
                    lbl_info.Text = "Please enter a valid ZIP code."; // prompts user to enter valid data
                    return;
                }
                else
                {
                    if (!util.checkZIP(txtBox_1.Text)) // checks if the ZIP code is not valid
                    {
                        lbl_info.Text = "Please enter a valid ZIP code."; // prompts user to enter valid data
                        return;
                    }
                    else
                    {
                        origin += txtBox_1.Text; // stores the ZIP code in variable to be used as parameter
                    }
                }
            }

            // Checks if the destination address/ZIP are valid
            if (RadioButton1.Checked)
            {
                dest += "ADD:"; // lets the service know the parameter is an address
                if (String.IsNullOrWhiteSpace(TextBox1.Text) || String.IsNullOrWhiteSpace(TextBox2.Text)) // checks if either text box is empty
                {
                    Label3.Text = "Please enter text in both fields."; // prompts user to enter valid data
                    return;
                }
                else
                {
                    dest += TextBox1.Text + ":"; // Obtains the address and adds a ':' for the service to split
                    dest += TextBox2.Text;
                }
            }
            else if (RadioButton2.Checked)
            {
                dest += "ZIP:";  // lets the service know the parameter is a ZIP code
                if (String.IsNullOrWhiteSpace(TextBox1.Text)) // checks if the text box is empty
                {
                    Label3.Text = "Please enter a valid ZIP code."; // prompts user to enter valid data
                    return;
                }
                else
                {
                    if (!util.checkZIP(TextBox1.Text)) // checks if the ZIP code is not valid
                    {
                        Label3.Text = "Please enter a valid ZIP code."; // prompts user to enter valid data
                        return;
                    }
                    else
                    {
                        dest += TextBox1.Text; // stores the ZIP code in variable to be used as parameter
                    }
                }
            }

            // Parses the service output
            using (var webClient = new WebClient())
            {
                string json = webClient.DownloadString("http://webstrar53.fulton.asu.edu/page4/Service1.svc/findDistance?origin=" + origin + "&dest=" + dest); // loads the JSON string from the url
                arr = JArray.Parse(json);// loads the JSON string into the PlaceIdObject
                
                if (arr[0].ToString() == "OK") // makes sure the service was successful 
                {
                    lbl_result.Text = arr[1].ToString() + "<br />" + arr[2].ToString(); // displays the distance and travel duration 
                }
                else
                {
                    lbl_result.Text = arr[0].ToString(); // displays the error message
                }
            }
        }

        protected void txtBox_2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}