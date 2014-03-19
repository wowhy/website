<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="StudyWeb.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>注册新用户</title>
</head>
<body>
    <form runat="server">
    <ext:Viewport runat="server">
        <LayoutConfig>
            <ext:VBoxLayoutConfig Align="Center" Pack="Center" />
        </LayoutConfig>
        <Items>
            <ext:FormPanel
                runat="server"
                Width="400" Height="295"
                Title="注册"
                Frame="true" BodyPadding="13" AutoScroll="true">
                <Tools>
                    <ext:Tool Type="Prev">
                        <Listeners>
                            <Click Handler="window.history.go(-1);" />
                        </Listeners>
                    </ext:Tool>
                </Tools>
                <FieldDefaults LabelAlign="Right" LabelWidth="115" MsgTarget="Side" />
                <Items>
                    <ext:FieldSet runat="server" Title="基础信息" DefaultWidth="300">
                        <Items>
                            <ext:TextField ID="txtLoginName" 
                                runat="server" 
                                AllowBlank="false" BlankText="请输入用户名"
                                FieldLabel="用户名" EmptyText="请输入用户名"
                                Regex="^[a-zA-Z0-9_]*$" RegexText="用户名只能输入字母数字下划线!"
                                 />

                            <ext:TextField 
                                ID="txtPassword" 
                                runat="server"                    
                                FieldLabel="密码" InputType="Password"
                                AllowBlank="false" BlankText="请输入密码" />

                            <ext:TextField ID="txtConfirmPassword" 
                                runat="server" 
                                FieldLabel="确认密码" InputType="Password" 
                                Vtype="password" VtypeText="输入密码不一致"
                                AllowBlank="false" BlankText="请输入确认密码">     
                                <CustomConfig>
                                    <ext:ConfigItem Name="initialPassField" 
                                        Value="txtPassword" Mode="Value" />
                                </CustomConfig>                      
                            </ext:TextField>

                            <ext:TextField ID="txtUserName" 
                                runat="server" 
                                AllowBlank="false" BlankText="请输入用户姓名"
                                FieldLabel="姓名"
                                EmptyText="请输入用户姓名">                                
                            </ext:TextField>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnRegister" 
                        runat="server" 
                        Text="注册" 
                        Disabled="true" 
                        FormBind="true">
                        <Listeners>
                            <Click Handler="App.direct.CreateUser();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:FormPanel>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
