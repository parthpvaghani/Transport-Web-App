﻿
Partial Class Client_logout
    Inherits System.Web.UI.Page


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Session.Remove("cuname")
        Session.Abandon()
        Response.Redirect("login.aspx")
    End Sub

End Class
