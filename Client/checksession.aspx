<%@ Page Language="C#" AutoEventWireup="true" CodeFile="checksession.aspx.cs" Inherits="Client_checksession" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p><%=Session["cuname"]%></p>
            <p><%=Session["SFName"]%></p>
            <p><%=Session["SLName"]%></p>
            <p><%=Session["DDLPickupCity"]%></p>
            <p><%=Session["SMobile"]%></p>
            <p><%=Session["SEmail"]%></p>
            <p><%=Session["RFName"]%></p>
            <p><%=Session["RLname"]%></p>
            <p><%=Session["DDLDropCity"]%></p>
            <p><%=Session["RMobile"]%></p>
            <p><%=Session["REmail"]%></p>
            <p><%=Session["DDLGType"]%></p>
            <p><%=Session["GWeight"]%></p>
            <p><%=Session["amount"]%></p>


        </div>
    </form>
</body>
</html>
