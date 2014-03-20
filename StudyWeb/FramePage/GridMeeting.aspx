<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GridMeeting.aspx.cs" Inherits="StudyWeb.FramePage.GridMeeting" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:Viewport runat="server" Layout="FitLayout">
            <Items>
                <ext:GridPanel ID="grid" runat="server"></ext:GridPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
