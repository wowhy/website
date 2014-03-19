<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="StudyWeb.FramePage.RoomList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <ext:Viewport runat="server" 
        Layout="FitLayout">
        <Items>
            <ext:GridPanel
                Id="GridPanel1"
                runat="server" 
                Region="Center"
                Frame="true">
                <Store>
                    <ext:Store ID="Store1" runat="server">
                        <Proxy>
                            <ext:AjaxProxy Url="/Ajax/MeetingRoom.ashx">
                                <Reader>
                                    <ext:JsonReader Root="data" SuccessProperty="success" MessageProperty="message" />
                                </Reader>
                                <Writer>
                                    <ext:JsonWriter Encode="true" Root="data">
                                        <FilterField Handler="if(name == 'CreationTime') return false;" />
                                    </ext:JsonWriter>
                                </Writer>
                            </ext:AjaxProxy>
                        </Proxy>         
                        <SyncParameters>
                            <ext:StoreParameter Name="action" Value="operation.action" Mode="Raw" />
                        </SyncParameters>               
                        <Model>
                            <ext:Model runat="server" IDProperty="Id">
                                <Fields>
                                    <ext:ModelField Name="Id" />
                                    <ext:ModelField Name="RoomName" />
                                    <ext:ModelField Name="Location" />
                                    <ext:ModelField Name="CreationTime" Type="Date" />
<%--                                    <ext:ModelField Name="State" />                                    --%>
                                </Fields>
                            </ext:Model>
                        </Model>
                        <Sorters>
                            <ext:DataSorter Property="Id" Direction="ASC" />
                        </Sorters>
                        <Listeners>                            
                            <Write Handler="Ext.Msg.alert('提示', '保存成功!');" />
                        </Listeners>                        
                    </ext:Store>
                </Store>

                <ColumnModel runat="server">
                    <Columns>
                        <ext:Column runat="server" DataIndex="RoomName" Text="会议室名称"
                            Width="200">
                            <Editor>
                                <ext:TextField ID="txtRoomName" runat="server" />
                            </Editor>
                        </ext:Column>
                        <ext:Column runat="server" DataIndex="Location" Text="所在位置"  Flex="1"
                            Width="200">
                            <Editor>
                                <ext:TextField ID="txtLocation" runat="server" />
                            </Editor>
                        </ext:Column>
                        <ext:DateColumn runat="server" DataIndex="CreationTime" Text="创建时间"
                            Width="200" Format="yyyy年MM月dd日">
                        </ext:DateColumn>
<%--                    <ext:Column runat="server" DataIndex="State" Text="状态"
                            Width="100">
                        </ext:Column>--%>
                    </Columns>
                </ColumnModel>
    
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" Mode="Multi">
                        <Listeners>
                            <Select Handler="#{btnDelete}.enable();" />
                            <Deselect Handler="if (!#{GridPanel1}.selModel.hasSelection()) {
                                                   #{btnDelete}.disable();
                                               }" />
                        </Listeners>
                    </ext:RowSelectionModel>
                </SelectionModel>

                <Plugins>
                    <ext:CellEditing runat="server" />
                </Plugins>
                        
                <Buttons>
                    <ext:Button ID="btnAdd" runat="server" Text="添加" Icon="Add">
                        <Listeners>
                            <Click Handler="#{Store1}.insert(0, {}); #{GridPanel1}.editingPlugin.startEditByPosition({row:0, column:0});" />
                        </Listeners>
                    </ext:Button>
                            
                    <ext:Button ID="btnDelete" runat="server" Text="删除" Icon="Delete" 
                        Disabled="true">
                        <Listeners>
                            <Click Handler="#{GridPanel1}.deleteSelected();
                                            if (!#{GridPanel1}.hasSelection()) {
                                                #{btnDelete}.disable();
                                            }" />
                        </Listeners>
                    </ext:Button>
                            
                    <ext:Button ID="btnSave" runat="server" Text="保存" Icon="Disk">
                        <Listeners>
                            <Click Handler="#{Store1}.sync();" />
                        </Listeners>
                    </ext:Button>
                            
                    <ext:Button ID="btnClear" runat="server" Text="取消" Icon="Cancel">
                        <Listeners>
                            <Click Handler="#{GridPanel1}.getSelectionModel().deselectAll();;
                                            if (!#{GridPanel1}.hasSelection()) {
                                                #{btnDelete}.disable();
                                            }" />
                        </Listeners>
                    </ext:Button>
                            
                    <ext:Button ID="btnRefresh" runat="server" Text="刷新" Icon="ArrowRefresh">
                        <Listeners>
                            <Click Handler="#{Store1}.load();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>                
            </ext:GridPanel>
        </Items>        
    </ext:Viewport>
</body>
</html>
