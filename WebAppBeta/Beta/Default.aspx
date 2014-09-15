<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppBeta.Beta.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <p>Current App: <%=SampleLibrary.WebHelper.CurrentApp %></p>
    <p>Current SessionId: <%=this.Session.SessionID %></p>
    <p>Current User: <%=this.Session["user"] %></p>
</body>
</html>
