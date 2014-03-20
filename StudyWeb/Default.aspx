<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="StudyWeb.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" href="/Content/css/main.css" />    
</head>
<body>   
    <ext:Viewport runat="server" Layout="BorderLayout">
        <Items>
            <ext:Panel runat="server" Region="North"
                Height="90" Border="false">
                <Content>
                    <div class="header">
                        <div class="left title">
                            <ext:Label runat="server" Text="会议室预定系统" />
                        </div>
                        
                        <div class="right">
                            <table style="width:210px;">
                                <tr>
                                    <td style="width:30px;">
                                        <ext:Label runat="server" Text="主题"/>
                                    </td>
                                    <td style="padding-top:10px;">
                                        <form runat="server">
                                            <ext:ComboBox ID="cboTheme" runat="server" 
                                                OnDirectSelect="cboTheme_DirectSelect">
                                                <Items>
                                                    <ext:ListItem Text="Default" />
                                                    <ext:ListItem Text="Gray" />
                                                    <ext:ListItem Text="Neptune" />
                                                    <ext:ListItem Text="Access" />
                                                </Items>
                                            </ext:ComboBox>
                                        </form>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                   
                </Content>
            </ext:Panel>

            <ext:Panel runat="server" Region="West" Visible="false"
                Width="240" Border="true" 
                Collapsible="true" TitleCollapse="true" Split="true">
                <Content>
                    <ext:GridPanel ID="gpRooms" runat="server">
                        <Store>
                            <ext:Store ID="store" runat="server">
                                <Model>
                                    <ext:Model runat="server">
                                        <Fields>
                                            <ext:ModelField Name="Id" />
                                            <ext:ModelField Name="RoomName" />
                                        </Fields>
                                    </ext:Model>
                                </Model>
                            </ext:Store>
                        </Store>
                        <ColumnModel>
                            <Columns>
                                <ext:Column runat="server" DataIndex="RoomName" Text="会议室名称"
                                    Flex="1">
<%--                                    
                                    <ToolTips>
                                        <ext:ToolTip runat="server" />
                                    </ToolTips>
--%>
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel />
                        </SelectionModel>
                    </ext:GridPanel>
                </Content>
            </ext:Panel>

            <ext:Panel runat="server" Region="Center"
                Border="true">
                <Loader runat="server"
                    Url="/FramePage/Meeting.aspx"
                    Mode="Frame">
                    <LoadMask ShowMask="true" />
                </Loader>
            </ext:Panel>

            <ext:Panel runat="server" Region="East"
                Width="240" Border="true"
                Collapsible="true" TitleCollapse="true" Split="true">
                <Content>在此处预订会议室</Content>
            </ext:Panel>
        </Items>
    </ext:Viewport>

    <script type="text/javascript">
        /// <reference path="/Scripts/ext-all.js" />
        /// <reference path="/Scripts/extnet-all.js" />

    </script>
</body>
</html>
