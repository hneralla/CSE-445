using System;
using System.Web.UI;
using System.IO;
using System.Web;

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
            StreamWriter file; // to write the html into a file
            Uri myUri; // To valid the HTTP URLs
            lbl_output.Text = ""; // Clears the label

            if (!String.IsNullOrWhiteSpace(txt_xml.Text) && !String.IsNullOrWhiteSpace(txt_xsl.Text)) // Makes sure that the text boxes have data
            {
                // Makes sure the URLs are valid
                if (Uri.TryCreate(txt_xml.Text, UriKind.RelativeOrAbsolute, out myUri) && Uri.TryCreate(txt_xsl.Text, UriKind.RelativeOrAbsolute, out myUri))
                {
                    string html = client.transformation(txt_xml.Text, txt_xsl.Text);
                    lbl_output.Text = html;
                    file = new StreamWriter(HttpRuntime.AppDomainAppPath + @"\App_Data\Output.html");
                    file.WriteLine(html);
                    file.Close();
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