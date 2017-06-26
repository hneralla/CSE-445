using System;
using System.Web.UI;

namespace WebApplication
{
    public partial class Verification : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_verify_Click(object sender, EventArgs e)
        {
            XMLServiceReference.Service1Client client = new XMLServiceReference.Service1Client();
            Uri myUri; // To valid the HTTP URLs
            lbl_output.Text = ""; // Clears the label

            if (!String.IsNullOrWhiteSpace(txt_xml.Text) && !String.IsNullOrWhiteSpace(txt_xsd.Text)) // Makes sure that the text boxes have data
            {
                // Makes sure the URLs are valid
                if (Uri.TryCreate(txt_xml.Text, UriKind.RelativeOrAbsolute, out myUri) && Uri.TryCreate(txt_xsd.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = client.verification(txt_xml.Text, txt_xsd.Text);
                }
                else if (!Uri.TryCreate(txt_xml.Text, UriKind.RelativeOrAbsolute, out myUri) && !Uri.TryCreate(txt_xsd.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = "Both URLs are invalid";
                }
                else if (!Uri.TryCreate(txt_xml.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = "The XML URL is invalid";
                }
                else if (!Uri.TryCreate(txt_xsd.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    lbl_output.Text = "The XMLS URL is invalid";
                }
            }
            else
            {
                lbl_output.Text = "Please enter data in both boxes.";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}