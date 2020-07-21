using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using Newtonsoft.Json;
using paytm;
using System.Data.SqlClient;

public partial class Client_Payment_confirmation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string connetionString = null;
        string qry;
        SqlConnection cnn;
        connetionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\Downloads\Transport_Latest\Transport\Client\App_Data\Database.mdf;Integrated Security=True;Connect Timeout=30";
        cnn = new SqlConnection(connetionString);

        string username = Session["cuname"].ToString();  


        string merchantKey = "aAH_BAQQzlg1bLwp" ; 

        Dictionary<string, string> parameters = new Dictionary<string, string>();
        string paytmChecksum = "";
        foreach (string key in Request.Form.Keys)
        {
            parameters.Add(key.Trim(), Request.Form[key].Trim());
        }

        if (parameters.ContainsKey("CHECKSUMHASH"))
        {
            paytmChecksum = parameters["CHECKSUMHASH"];
            parameters.Remove("CHECKSUMHASH");
        }

        if (CheckSum.verifyCheckSum(merchantKey, parameters, paytmChecksum))
        {
            string paytmstatus = parameters["STATUS"];
            string txnId = parameters["TXNID"];
            pTxnId.InnerText = "Note This Transaction Id : " + txnId;
        if (paytmstatus=="TXN_SUCCESS")
        {
                    h1Messasge.InnerText = "Courier Pick Up Request has been made Successfully";
                
                    cnn.Open();
                    qry = "insert into booking_master(username,sfname,slname,scity,smobno,semail,rfname,rlname,rcity,rmobno,remail,gtypes,gweight) values(@username,@SFName,@SLName,@DDLPickupCity,@SMobile,@SEmail,@RFName,@RLName,@DDLDropCity,@RMobile,@REmail,@DDLGType,@GWeight)";
                    using (SqlCommand command = new SqlCommand(qry, cnn))
                    {
                    //null hoy to gand marave pela check karie bharine ...ok
                        
                        command.Parameters.AddWithValue("@username",username );
                        command.Parameters.AddWithValue("@SFName", Session["SFName"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SLName", Session["SLName"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DDLPickupCity", Session["DDLPickupCity"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SMobile", Session["SMobile"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@SEmail", Session["SEmail"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RFName", Session["RFName"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RLName", Session["RLname"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DDLDropCity", Session["DDLDropCity"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@RMobile", Session["RMobile"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@REmail", Session["REmail"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@DDLGType", Session["DDLGType"] ?? DBNull.Value);
                        command.Parameters.AddWithValue("@GWeight", Session["GWeight"] ?? DBNull.Value);
                    

                    command.ExecuteNonQuery();
                    cnn.Close();
                        
                    
                }
                
            }
        else if (paytmstatus == "PENDING")
        {
                h1Messasge.InnerText = "Plese Wait Transaction is Process";
        }
        else if (paytmstatus == "TXN_FAILURE")
        {
                h1Messasge.InnerText = "Transaction Failed ! If it is deducted from your bank account it will be get refunded within 5-6 days";
            }
        }

    }
}