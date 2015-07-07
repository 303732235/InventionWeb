<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.CardAdmin.ManageCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>各专题下问题管理</title>
    <link href="../../../Styles/backmokuai.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <div style="width: 950px; text-align: center; vertical-align: top;">
            <asp:Label ID="Label1" runat="server" Text="问题管理" Font-Size="15pt"></asp:Label></div>
        <div style="float: right; margin-right: 40px; margin-top: -30px;">
            <asp:TextBox ID="search" runat="server"></asp:TextBox>
            <asp:Button ID="searchbtn" runat="server" Text="搜索" OnClick="searchbtn_Click" />
        </div>
        <asp:GridView ID="gvCardInfo" runat="server" CellPadding="8" GridLines="Horizontal"
            Width="950px" BorderColor="#E7E7FF" BorderStyle="None" HorizontalAlign="Center"
            OnRowDeleting="gvCardInfo_RowDeleting" AutoGenerateColumns="False" Font-Size="12px"
            OnRowDataBound="gvCardInfo_RowDataBound" OnPageIndexChanging="gvCardInfo_PageIndexChanging"
            PageSize="10" AllowPaging="True" BackColor="White" BorderWidth="1px">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" Height="30px" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="CardID" HeaderText="问题ID">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ModuleName" HeaderText="问题所属模块">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="CardName" HeaderText="标题">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="CardDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="发布日期">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="CardID" DataNavigateUrlFormatString="EditCard.aspx?CardID={0}"
                    HeaderText="修改" Text="修改">
                    <ControlStyle Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
                <asp:HyperLinkField DataNavigateUrlFields="CardID" DataNavigateUrlFormatString="Card.aspx?CardID={0}"
                    HeaderText="详细信息" Text="详细信息">
                    <ControlStyle Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ControlStyle Font-Underline="False" />
                </asp:CommandField>
            </Columns>
            <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页"
                Mode="NextPreviousFirstLast" />
            <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" Height="30px" ForeColor="#F7F7F7" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
