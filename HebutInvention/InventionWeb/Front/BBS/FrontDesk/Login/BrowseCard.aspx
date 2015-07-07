<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowseCard.aspx.cs" Inherits="InventionWeb.Front.BBS.FrontDesk.Login.BrowseCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>浏览问题</title>
    <style type="text/css">
        .header
        {
            width: 1000px;
            color: #fff;
            margin-bottom: 5px;
            background-color: #2e9dc8;
            height: 35px;
        }
        .search
        {
            float: right;
            margin-top: 5px;
            margin-bottom: 5px;
        }
        .btn
        {
            cursor: pointer;
            font-size: 12px;
            color: #138;
        }
        #unsolved:hover
        {
            background: #A3CFEA;
            color: #fff;
        }
        #resolved:hover
        {
            background: #A3CFEA;
            color: #fff;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px;">
        <div class="header"><asp:Label ID="labModTitle" runat="server" Text="在线问题" Style="color: White; float: left;
                margin-top: 10px; margin-left: 10px" Font-Size="12pt"></asp:Label></div>
        <div style="float: left">
            <asp:Button ID="unsolved" CssClass="btn" runat="server" Text="未解决问题" OnClick="unsolved_Click" />
            <asp:Button ID="resolved" CssClass="btn" runat="server" Text="已解决问题" OnClick="resolved_Click" />
        </div>
        <div class="search">
            <asp:TextBox ID="txtKeyWord" runat="server"></asp:TextBox>
            <asp:Button ID="btnSelect" runat="server" Text="搜索" OnClick="btnSelect_Click1" />
        </div>
    </div>
    <div style="width: 1000px; clear: both;">
        <asp:GridView ID="CardInfo" runat="server" AllowPaging="True" CellPadding="3" GridLines="Horizontal"
            Width="1000px" BorderColor="#E7E7FF" BorderStyle="None" HorizontalAlign="Center"
            AutoGenerateColumns="False" Font-Size="9pt" OnPageIndexChanging="gvModuleInfo_PageIndexChanging"
            PageSize="12" BackColor="White" BorderWidth="1px" OnRowDataBound="CardInfo_RowDataBound">
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Height="30px" />
            <Columns>
                <asp:BoundField HeaderText="编号">
                    <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="CardID" HeaderText="标号" Visible="False">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="ModuleName" DataTextField="ModuleName"
                    DataNavigateUrlFormatString="ModulePartInfo.aspx?ModuleName={0}" HeaderText="所属专题">
                    <ControlStyle Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataNavigateUrlFields="CardID" DataTextField="CardName" DataNavigateUrlFormatString="CardPartInfo.aspx?CardID={0}"
                    HeaderText="标题">
                    <ControlStyle Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="UserName" HeaderText="发布人">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="CardDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="创建日期">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
            </Columns>
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页"
                Mode="NextPreviousFirstLast" />
            <HeaderStyle BackColor="#a3cfea" Font-Bold="True" Height="30px" ForeColor="#555555" />
            <FooterStyle BackColor="#a3cfea" Font-Bold="True" Height="30px" ForeColor="#555555" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
        <div style="background-color: #a3cfea; height: 30px;">
        </div>
    </div>
    </form>
</body>
</html>
