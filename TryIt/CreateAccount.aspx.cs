using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class CreateAccount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            CreateAccountService.CreateAccountServiceClient client = new CreateAccountService.CreateAccountServiceClient();
            if (!String.IsNullOrWhiteSpace(txtBox_username.Text) && !String.IsNullOrWhiteSpace(txtBox_password.Text))
            {
                Boolean created = client.createAccount(txtBox_username.Text, txtBox_password.Text);

                if(created)
                {
                    lbl_confirmation.Text = "Account created.";
                }
                else
                {
                    lbl_confirmation.Text = "Username already exists. Enter a different username.";
                }
            }

        }
    }
}