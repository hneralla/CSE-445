using System;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class FindDistance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void rdio_btn_address_CheckedChanged(object sender, EventArgs e)
        {
            if (rdio_btn_address.Checked)
            {
                rdio_btn_ZIP.Checked = false;
                txtBox_1.Visible = true;
                txtBox_2.Visible = true;
                lbl_1.Text = "Street Address: ";
                lbl_2.Text = "City: ";
            }
        }

        protected void rdio_btn_ZIP_CheckedChanged(object sender, EventArgs e)
        {
            if (rdio_btn_ZIP.Checked)
            {
                rdio_btn_address.Checked = false;
                txtBox_1.Visible = true;
                txtBox_2.Visible = false;
                lbl_1.Text = "Enter ZIP code: ";
                lbl_2.Text = "";
            }
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            JSONObj obj = new JSONObj();
            Util util = new Util();
            string[] result;
            string origin = "";
            string dest = "";

            util.clearLabel(lbl_info);
            util.clearLabel(Label3);
            // Checks if the origin address/ZIP are valid
            if (rdio_btn_address.Checked)
            {
                origin += "ADD:";
                if (String.IsNullOrWhiteSpace(txtBox_1.Text) || String.IsNullOrWhiteSpace(txtBox_2.Text))
                {
                    lbl_info.Text = "Please enter text in both fields.";
                    return;
                }
                else
                {
                    origin += txtBox_1.Text + ":";
                    origin += txtBox_2.Text;
                }
            }
            else if (rdio_btn_ZIP.Checked)
            {
                origin += "ZIP:";
                if (String.IsNullOrWhiteSpace(txtBox_1.Text))
                {
                    lbl_info.Text = "Please enter a valid ZIP code.";
                    return;
                }
                else
                {
                    if (!util.checkZIP(txtBox_1.Text))
                    {
                        lbl_info.Text = "Please enter a valid ZIP code.";
                        return;
                    }
                    else
                    {
                        origin += txtBox_1.Text;
                    }
                }
            }

            // Checks if the destination address/ZIP are valid
            if (RadioButton1.Checked)
            {
                dest += "ADD:";
                if (String.IsNullOrWhiteSpace(TextBox1.Text) || String.IsNullOrWhiteSpace(TextBox2.Text))
                {
                    Label3.Text = "Please enter text in both fields.";
                    return;
                }
                else
                {
                    dest += TextBox1.Text + ":";
                    dest += TextBox2.Text;
                }
            }
            else if (RadioButton2.Checked)
            {
                dest += "ZIP:";
                if (String.IsNullOrWhiteSpace(TextBox1.Text))
                {
                    Label3.Text = "Please enter a valid ZIP code.";
                    return;
                }
                else
                {
                    if (!util.checkZIP(TextBox1.Text))
                    {
                        Label3.Text = "Please enter a valid ZIP code.";
                        return;
                    }
                    else
                    {
                        dest += TextBox1.Text;
                    }
                }
            }

            using (var webClient = new WebClient())
            {
                string json = webClient.DownloadString("http://webstrar53.fulton.asu.edu/page4/Service1.svc/findDistance?origin=" + origin+"&dest="+dest); // loads the JSON string from the url
                JArray arr = JArray.Parse(json);// loads the JSON string into the PlaceIdObject
                
                if (arr[0].ToString() == "OK")
                {
                    lbl_result.Text = arr[1].ToString() + "<br />" + arr[2].ToString();
                }
                else
                {
                    lbl_result.Text = arr[0].ToString();
                }
            }
        }

        protected void txtBox_2_TextChanged(object sender, EventArgs e)
        {

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
        public class JSONObj
        {
            public string[] Property1 { get; set; }
        }

    }
}