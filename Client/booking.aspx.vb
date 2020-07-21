Imports System.Data.SqlClient
Imports System.Data
Imports System
Partial Class Client_booking
    Inherits System.Web.UI.Page
    Dim cn As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\Downloads\Transport_Latest\Transport\Client\App_Data\Database.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd As New SqlCommand
    Dim qry As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("cuname") = "" Then
            Response.Redirect("login.aspx")
        End If

        If Session("payment") = 1 Then
            Response.Write("<script>alert('Order Successful...')</script>")
            Session.Remove("payment")

        End If
    End Sub
    Protected Sub btnNext_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If DDLGType.SelectedValue = -1 Then
            Response.Write("<script>alert('Select Goods Type...')</script>")
        ElseIf txtGWeight.Text < 1 Then
            Response.Write("<script>alert('Enter Proper Goods Weight...')</script>")
        Else

            Session("SFName") = txtSFName.Text
            Session("SLName") = txtSLName.Text
            Session("DDLPickupCity") = DDLPickupCity.SelectedItem.Text
            Session("SMobile") = txtSMobile.Text
            Session("SEmail") = txtSEmail.Text
            Session("RFName") = txtRFName.Text
            Session("RLname") = txtRLName.Text
            Session("DDLDropCity") = DDLDropCity.SelectedItem.Text
            Session("RMobile") = txtRMobile.Text
            Session("REmail") = txtREmail.Text
            Session("DDLGType") = DDLGType.SelectedItem.Text
            Session("GWeight") = txtGWeight.Text
            Session("amount") = Val(txtGWeight.Text)
            Response.Redirect("payment.aspx")
            'Response.Redirect("checksession.aspx")'

        End If
    End Sub
End Class


