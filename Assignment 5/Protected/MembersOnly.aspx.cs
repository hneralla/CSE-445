using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Linq;
using System.Net;
using Cryption;
using System.Xml;

public partial class Protected_MembersOnly : System.Web.UI.Page
{
    public class Util
    {
        public Boolean checkZIP(string zipcode)
        {
            // Checks the validity of the ZIP code
            string usZipValid = @"^\d{5}(?:[-\s]\d{4})?$"; // makes sure that the zipcode is a valid US ZIP

            if (Regex.Match(zipcode, usZipValid).Success)
                return true;
            else
                return false;
        }

        public void clearLabel(Label lbl)
        {
            // Clears the text of the label in the parameter
            lbl.Text = "";
        }
    }

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

    protected void btn_submit3_Click(object sender, EventArgs e)
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        lbl_encrypted.Text = CryptLib.Encrypt(txt_encr.Text);
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        lbl_decrypted.Text = CryptLib.Decrypt(txt_decr.Text);
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        string xml;
        string xmlUrl = "http://neptune.fulton.ad.asu.edu/WSRepository/Services/RandomString/Service.svc/GetRandomString";

        using (var wc = new System.Net.WebClient())
        {
            xml = wc.DownloadString(xmlUrl); // Downloads the XML document using the URL
        }

        Label7.Text = xml;
    }
}
