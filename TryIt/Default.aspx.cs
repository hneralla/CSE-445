using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_getOps_Click(object sender, EventArgs e)
        {
            WsOps.Service1Client client = new WsOps.Service1Client();

            string[] input = client.getWsOperations(textBox1.Text);

            for (int index = 0; index < input.Length; index++)
            {
                var data = input[0].Split(new[] { '|' });
                lbl_retType.Text += data[0] + "\r\n";
                lbl_opName.Text += data[1] + "\r\n";

                var parameters = data[3].Split(new[] { '-' });

                foreach(string paramType in parameters)
                {
                    lbl_paramType.Text += paramType + " ";
                }

                lbl_paramType.Text += "\r\n";
            }
        }
    }
}