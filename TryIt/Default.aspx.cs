using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace TryIt
{
    public partial class _Default : Page
    {
        private void clearLabel(Label lbl)
        {
            lbl.Text = "";
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WeatherService.Service1Client client = new WeatherService.Service1Client();
            string zip = txtBox_ZIP1.Text;
            clearLabel(lbl_info);
            clearLabel(lbl_first);
            clearLabel(lbl_last);
            HyperLink1.Text = "";
            
            if (!String.IsNullOrWhiteSpace(txtBox_ZIP1.Text) && checkZIP(zip))
            {
                string[] data = client.getLocationDetails(zip);
                if (data.Length > 1)
                {
                    string end = data[data.Length - 1];
                    foreach (string str in data)
                    {
                        if (str != end)
                            lbl_info.Text += str + "<br />";
                        else
                        {
                            lbl_first.Text = "Click ";
                            HyperLink1.Text = "here";
                            HyperLink1.NavigateUrl = end;
                            lbl_last.Text = " for more information on the current weather.";
                        }
                    }
                }
                else
                {
                    lbl_info.Text = data[0];
                }
                
            }
            else
            {
                lbl_info.Text = "Please enter a valid zip code.";
            }
        }

        protected void btn_submit2_Click(object sender, EventArgs e)
        {
            NearestStore.Service1Client client = new NearestStore.Service1Client();
            clearLabel(lbl_info2);
            IMG2.ImageUrl = "";
            string zipcode = txtBox_ZIP2.Text;
            string data = "";
            if (!String.IsNullOrWhiteSpace(txtBox_ZIP2.Text) && !String.IsNullOrWhiteSpace(txtBox_storeName.Text))
            {
                if (checkZIP(zipcode))
                {
                    data = client.findNearestStore(zipcode, txtBox_storeName.Text);
                    var output = data.Split(new[] { '|' });
                    if (output.Length > 1)
                    {
                        IMG2.ImageUrl = output[0];
                        lbl_info2.Text += "Store Name: " + output[1] + "<br />";
                        lbl_info2.Text += "Store Rating: " + output[2] + "<br />";
                        lbl_info2.Text += "Store Address: " + output[3];
                    }
                    else
                        lbl_info2.Text = output[0];
                   
                }
                else
                {
                    lbl_info2.Text = "Enter a valid ZIP code.";
                }
            }
            else
            {
                lbl_info2.Text = "Please enter data in both boxes.";
            }
            
        }

        private Boolean checkZIP(string zipcode)
        {
            string usZipValid = @"^\d{5}(?:[-\s]\d{4})?$";
            if (Regex.Match(zipcode, usZipValid).Success)
                return true;
            else
                return false;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}