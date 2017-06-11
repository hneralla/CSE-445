using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /*protected void btn_getOps_Click(object sender, EventArgs e)
        {

            WsOps.Service1Client client = new WsOps.Service1Client();
            string url = textBox1.Text;
            url = ReplaceLastOccurrence(url, "?wsdl", "?singlewsdl");
            string[] input = client.getWsOperations(url);

            clearLabel(lbl_opNameDefault);
            clearLabel(lbl_paramDefault);
            clearLabel(lbl_retTypeDefault);

            lbl_opNameDefault.Text = "Operation Name";
            lbl_paramDefault.Text = "Parameter types";
            lbl_retTypeDefault.Text = "Return type";

            for (int index = 0; index < input.Length; index++)
            {
                var data = input[index].Split(new[] { ':' });
                lbl_opName.Text += data[0] + "\r\n";
                var inputParams = data[1].Split(new[] { '/' });
                var outputParams = data[2].Split(new[] { '/' });

                foreach(string str in inputParams)
                {
                    lbl_paramType.Text += str + " ";
                }

                foreach (string str in outputParams)
                {
                    lbl_retType.Text += str + " ";
                }

                lbl_paramType.Text += "\r\n";
                lbl_retType.Text += "\r\n";
            }
        }*/

        private void clearLabel(Label lbl)
        {
            lbl.Text = "";
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            WeatherService.Service1Client client = new WeatherService.Service1Client();
            string zip = textBox_zipcode.Text;
            clearLabel(lbl_info);
            clearLabel(lbl_first);
            clearLabel(lbl_last);
            HyperLink1.Text = "";
            string usZipValid = @"^\d{5}(?:[-\s]\d{4})?$";
            if (!String.IsNullOrWhiteSpace(textBox_zipcode.Text) && Regex.Match(zip, usZipValid).Success)
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

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}