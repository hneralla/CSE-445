using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class Transformation : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_transform_Click(object sender, EventArgs e)
        {
            XMLServiceReference.Service1Client client = new XMLServiceReference.Service1Client();
            Uri myUri; // To valid the HTTP URLs
            lbl_output.Text = ""; // Clears the label

            if (!String.IsNullOrWhiteSpace(txt_xml.Text) && !String.IsNullOrWhiteSpace(txt_xsl.Text)) // Makes sure that the text boxes have data
            {
                // Makes sure the URLs are valid
                if (Uri.TryCreate(txt_xml.Text, UriKind.RelativeOrAbsolute, out myUri) && Uri.TryCreate(txt_xsl.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = client.transformation(txt_xml.Text, txt_xsl.Text);
                }
                else if (!Uri.TryCreate(txt_xml.Text, UriKind.RelativeOrAbsolute, out myUri) && !Uri.TryCreate(txt_xsl.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = "Both URLs are invalid";
                }
                else if (!Uri.TryCreate(txt_xml.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = "The XML URL is invalid";
                }
                else if (!Uri.TryCreate(txt_xsl.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = "The XSL URL is invalid";
                }
            }
            else
            {
                lbl_output.Text = "Please enter data in both boxes.";
            }
        }
    }
}