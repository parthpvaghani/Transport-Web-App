Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

Partial Class Client_orderhistory
    Inherits System.Web.UI.Page
    Dim cons As String = "Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\vagha\Downloads\Transport_Latest\Transport\Client\App_Data\Database.mdf;Integrated Security=True;Connect Timeout=30"
    Dim qry As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            display()
        End If
    End Sub
    Sub display()
        Dim query As String = "SELECT * FROM booking_master WHERE username='" & Session("cuname") & "'"
        Dim con As SqlConnection = New SqlConnection(cons)
        Dim sda As SqlDataAdapter = New SqlDataAdapter(query, con)
        Dim ds As DataSet = New DataSet()
        sda.Fill(ds)
        GridView1.DataSource = ds
        GridView1.DataBind()

    End Sub
End Class


