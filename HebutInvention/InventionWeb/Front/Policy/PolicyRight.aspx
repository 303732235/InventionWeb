<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PolicyRight.aspx.cs" Inherits="InventionWeb.Front.Policy.PolicyRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>创新理论2</title>
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
     <br /><br />
    <span class="ModuleName">创新理论：</span>
    <span class="Search">
          <asp:TextBox ID="txtKwords" runat="server"></asp:TextBox>
        <asp:Button ID="btnsearch" runat="server" Text="搜索" onclick="btnsearch_Click" />
        </span>
        <div style="clear: both;"></div>
    <hr class="RightHR" />
        <asp:Repeater ID="rightlist" runat="server">
            <ItemTemplate>
                <table class="RightTable" cellspacing="7px" cellpadding="0">
                    <tr>
                        <td width="5" align="left">
                            <img alt="" src="/images/fuhao_08.gif"/>
                        </td>
                        <td>
                            <a href="./PolicyDetails.aspx?id=<%#Eval("id")%>" target="_parent">
                                <%#Eval("title")%></a>
                        </td>
                        <td style="text-align: right">
                             [<%#Eval("addDate","{0:yyyy-MM-dd}")%>]
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:Repeater>
        <br />
        <table class="RightSort" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="当前页码为："></asp:Label>[
                    <asp:Label ID="labPage" runat="server" Text="1"></asp:Label> &nbsp;]
                    <asp:Label ID="Label6" runat="server" Text="总页码为："></asp:Label>[
                    <asp:Label ID="labBackPage" runat="server"></asp:Label> &nbsp;]
                    <asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton>&nbsp;&nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
