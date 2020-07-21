using paytm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Transport
{
public partial class biio : System.Web.UI.Page
{

        protected void Page_Load(object sender, EventArgs e)
        {


            //Page Lastpage = (Page)Context.Handler;
            //Order_Id = (((Label)Lastpage.FindControl("lblAmount")).Text);
            string merchantKey = "aAH_BAQQzlg1bLwp";
            Int32 value = (Int32)HttpContext.Current.Session["tamount"];
            string finalvalue = value.ToString();

            int length = 25;
            // creating a StringBuilder object()
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();

            char letter;

            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            string randomorderstring = str_build.ToString();
        


        Dictionary<string, string> parameters = new Dictionary<string, string>
            {
                { "MID", "gAtnKo86089875089192" },
                { "CHANNEL_ID", "WEB" },
                { "INDUSTRY_TYPE_ID", "Retail" },
                { "WEBSITE", "WEBSTAGING" },
                { "EMAIL", "vaghani98@gmail.com" },
                { "MOBILE_NO", "7777777777" },
                { "CUST_ID", "cust_id_001" },
                { "ORDER_ID", randomorderstring },
                { "TXN_AMOUNT", finalvalue },
                { "CALLBACK_URL", "http://localhost:53715/Client/Payment_confirmation.aspx" } //This parameter is not mandatory. Use this to pass the callback url dynamically.
            };

            string checksum = CheckSum.generateCheckSum(merchantKey, parameters);
            string paytmURL = "https://securegw-stage.paytm.in/order/process?orderid" + randomorderstring ;
            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";
            Response.Write(outputHTML);
            }
}
}