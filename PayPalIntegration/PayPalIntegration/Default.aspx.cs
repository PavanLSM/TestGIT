using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace PayPalIntegration
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["status"] != null)
            {
                lblStatus.Text = Request.QueryString["status"];
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            PayWithPayPal(txtAmount.Text, "Contribution", txtFirstName.Text, txtLastName.Text, txtMiddleName.Text, txtPhone.Text, txtEmailId.Text, txtAddress.Text, txtCity.Text, txtState.Text, txtZipCode.Text);
        }

        //FirstName, MiddleName, LastName, Email, HomePhoneNumber, Home Address - City, State, ZipCode, Mobile Phone, Contribution Amount
        protected void PayWithPayPal(string amount, string itemInfo, string firstname, string lastName, string middleName, string homePhone, string email, string homeAddress, string city, string state, string zipCode)
        {
            string redirecturl = "";

            //Mention URL to redirect content to paypal site
            redirecturl += "https://www.sandbox.paypal.com/cgi-bin/webscr?cmd=_donations&business=" +
                           ConfigurationManager.AppSettings["paypalemail"].ToString();

            //First name i assign static based on login details assign this value
            redirecturl += "&first_name=" + firstname;

            //First name i assign static based on login details assign this value
            redirecturl += "&last_name=" + lastName;

            //City i assign static based on login user detail you change this value
            redirecturl += "&city=" + city;

            //State i assign static based on login user detail you change this value
            redirecturl += "&state=" + state;

            //State i assign static based on login user detail you change this value
            redirecturl += "&zipcode=" + zipCode;

            //Amount
            redirecturl += "&amount=" + amount;

            //Email
            redirecturl += "&email=" + email;

            //Phone No
            redirecturl += "&night_phone_a=" + homePhone;


            //Product Name
            redirecturl += "&item_name=" + itemInfo;

            //Address 
            redirecturl += "&address1=" + homeAddress;

            //Business contact id
            // redirecturl += "&business=k.tapankumar@gmail.com";

            //Shipping charges if any
            redirecturl += "&shipping=0";

            //Handling charges if any
            redirecturl += "&handling=0";

            //Tax amount if any
            redirecturl += "&tax=0";

            //Add quatity i added one only statically 
            redirecturl += "&quantity=1";

            //Currency code 
            redirecturl += "&currency=" + "USD";

            //Success return page url
            redirecturl += "&return=" +
              ConfigurationManager.AppSettings["SuccessURL"].ToString();

            //Failed return page url
            redirecturl += "&cancel_return=" +
              ConfigurationManager.AppSettings["FailedURL"].ToString();

            Response.Redirect(redirecturl);
        }
    }
}
