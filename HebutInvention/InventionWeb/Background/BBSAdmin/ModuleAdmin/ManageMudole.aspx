<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageMudole.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.ModuleAdmin.ManageMudole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>专题信息</title>
    <link href="../../../Styles/backmokuai.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <div style="width: 950px; text-align: center; vertical-align: top;">
            <asp:Label ID="Label1" runat="server" Text="管理专题" Font-Size="15pt"></asp:Label></div><br /><br />
        <asp:GridView ID="gvModuleInfo" runat="server" AllowPaging="True" CellPadding="8"
            GridLines="Horizontal" Width="950px" BorderColor="#E7E7FF" BorderStyle="None"
            HorizontalAlign="Center" OnRowDeleting="gvModuleInfo_RowDeleting" AutoGenerateColumns="False"
            Font-Size="12px" OnRowDataBound="gvModuleInfo_RowDataBound" OnPageIndexChanging="gvModuleInfo_PageIndexChanging"
            PageSize="10" BackColor="White" BorderWidth="1px">
            <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
            <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
            <Columns>
                <asp:BoundField DataField="ModuleID" HeaderText="专题ID">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ModuleName" HeaderText="专题名称">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="ModuleDate" DataFormatString="{0:yyyy-MM-dd}" HeaderText="专题创建日期">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:HyperLinkField DataNavigateUrlFields="ModuleID" DataNavigateUrlFormatString="EditModule.aspx?ModuleID={0}"
                    HeaderText="修改" Text="修改">
                    <ControlStyle Font-Underline="False" />
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:HyperLinkField>
                <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                    <ControlStyle Font-Underline="False" />
                </asp:CommandField>
            </Columns>
            <SelectedRowStyle BackColor="#70a4cf" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
            <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
            <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页"
                Mode="NextPreviousFirstLast" />
            <AlternatingRowStyle BackColor="#F7F7F7" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
