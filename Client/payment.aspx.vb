Imports System.Data.SqlClient
Imports System.Data
Imports System

Partial Class Client_payment
    Inherits System.Web.UI.Page

    Dim cn, cn1 As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\Downloads\Transport_Latest\Transport\Client\App_Data\Database.mdf;Integrated Security=True;Connect Timeout=30")
    Dim cmd, cmd1 As New SqlCommand
    Dim qry, qry1 As String
    Dim no As Integer
    Dim tamount As Integer
    Dim netAmount As Integer

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        netAmount = CType(Session("amount"), Integer)
        If Session("amount") < 10 Then
            Session("tamount") = 100
            lblAmount.Text = "Total Amount: " & Session("tamount")
            Server.Transfer("biio.aspx")
        Else
            Session("tamount") = 10 * netAmount
            lblAmount.Text = "Total Amount: " & Session("tamount")
            Server.Transfer("biio.aspx")
        End If
    End Sub

    Protected Sub btnBookNow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBookNow.Click
        cn1.Open()
        qry1 = "select max(bid) from booking_master"
        cmd = New SqlCommand(qry1, cn1)
        no = cmd.ExecuteScalar
        cn1.Close()

        cn.Open()
        qry = "insert into payment_master(amount,pmethod,bid) values(" & Session("tamount") & ",'" & RadioButtonList1.SelectedItem.Text & "'," & no & ")"
        cmd = New SqlCommand(qry, cn)
        cmd.ExecuteNonQuery()
        cn.Close()
        Response.Redirect("biio.aspx")
    End Sub

End Class