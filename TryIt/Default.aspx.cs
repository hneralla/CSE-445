using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace TryIt
{
    public partial class _Default : Page
    {
        // Author: Harith Neralla
        // ASU CSE 445 Summer 2017
        // 06/10/2017

        // This web application allows users to test out the NearestStore and WeatherConditions service
        
        

        

        
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }

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
}