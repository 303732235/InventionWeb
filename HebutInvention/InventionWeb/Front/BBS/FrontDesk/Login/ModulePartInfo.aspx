<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModulePartInfo.aspx.cs"
    Inherits="InventionWeb.Front.BBS.FrontDesk.Login.ModulePartInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>专题详细信息</title>
    <style type="text/css">
        .header
        {
            width: 1000px;
            color: #fff;
            margin-bottom: 15px;
            background-color: #2e9dc8;
            height: 40px;
        }
        .title
        {
            float: left;
            margin-top: 10px;
            margin-left: 10px;
            font-size: 12pt;
        }
        .search
        {
            float: right;
            margin-top: 8px;
        }
        .footer
        {
            background-color: #a3cfea;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="header" style="width: 1000px;">
            <div class="title">
                <asp:Label ID="labModTitle" runat="server"></asp:Label>
            </div>
            <div class="search">
                <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
                <asp:Button ID="Button" runat="server" Text="搜索" OnClick="Button_Click" />
            </div>
        </div>
        <div style="width: 1000px;">
            <asp:GridView ID="gvModuleInfo" runat="server" AllowPaging="True" CellPadding="3"
                GridLines="Horizontal" Width="1000px" BorderColor="#E7E7FF" BorderStyle="None"
                HorizontalAlign="Center" AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvModuleInfo_PageIndexChanging"
                PageSize="10" BackColor="White" BorderWidth="1px" 
                onrowdatabound="gvModuleInfo_RowDataBound">
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Height="30px" />
                <Columns>
                <asp:BoundField HeaderText="编号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                    <asp:BoundField DataField="CardID" HeaderText="标号" Visible="false">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:HyperLinkField DataNavigateUrlFields="CardID" DataTextField="CardName" DataNavigateUrlFormatString="CardPartInfo.aspx?CardID={0}"
                        HeaderText="问题">
                        <ControlStyle Font-Underline="False" />
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:HyperLinkField>
                    <asp:BoundField DataField="UserName" HeaderText="发布人">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                    <asp:BoundField DataField="CardDate" HeaderText="发布日期">
                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    </asp:BoundField>
                </Columns>
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页"
                    Mode="NextPreviousFirstLast" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <HeaderStyle BackColor="#a3cfea" Font-Bold="True" Height="30px" ForeColor="#555555" />
                <FooterStyle BackColor="#a3cfea" Font-Bold="True" Height="30px" ForeColor="#555555" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:GridView>
            <div class="footer">
            </div>
        </div>
    </div>
    </form>
</body>
</html>
