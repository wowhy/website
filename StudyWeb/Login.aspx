<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="StudyWeb._Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登录</title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:Viewport runat="server">
            <LayoutConfig>
                <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
            </LayoutConfig>
            <Items>
                <ext:FormPanel ID="FormPanel1" 
                    runat="server" 
                    Title="登录"
                    Width="400" 
                    Frame="true" BodyPadding="13" DefaultAnchor="100%">
                    <Items>
                        <ext:TextField ID="txtLoginName" 
                            runat="server" 
                            AllowBlank="false" BlankText="请输入用户名"
                            FieldLabel="用户名"
                            EmptyText="请输入用户名" />

                        <ext:TextField ID="txtPassword" 
                            runat="server" 
                            AllowBlank="false" BlankText="请输入密码"
                            FieldLabel="密码"
                            InputType="Password" />

<%--                        <ext:Checkbox ID="chkRemember" runat="server" FieldLabel="记住密码" />--%>
                    </Items>
                    <Buttons>
                        <ext:Button ID="btnRegister" runat="server" Text="注册">
                            <Listeners>
                                <Click Handler="window.location='/Register.aspx';" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnLogin" runat="server" Text="登录"
                            FormBind="true">
                            <Listeners>
                                <Click Handler="App.direct.Login();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:FormPanel>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
