<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Sample.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>Current App: <%=SampleLibrary.WebHelper.CurrentApp %></p>
        <p>Current SessionId: <%=this.Session.SessionID %></p>
        <p>Current User: <%=this.Session["user"] %></p>
        <p>Current AppDomainId: <%=System.Web.HttpRuntime.AppDomainId %></p>
        <p>Current AppDomainAppId: <%=System.Web.HttpRuntime.AppDomainAppId %></p>
        <p><a href="/Alpha/Default.aspx" target="_blank">Alpha</a></p>
        <p><a href="/Beta/Default.aspx" target="_blank">Beta</a></p>
    </form>
</body>
</html>
