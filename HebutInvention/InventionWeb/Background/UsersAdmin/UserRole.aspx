<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRole.aspx.cs" Inherits="InventionWeb.Background.UsersAdmin.UserRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分配CAI权限</title>
    <link href="../../Styles/backmokuai.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content" style="margin-left: 80px; margin-top: 80px">
        注：授予操作：只针对未分配CAI权限的用户与未分配CAI用户（1:1操作）； 移除操作：只针对一个已分配CAI权限的用户（1:0操作）。<br />
        <br />
        <table>
            <tr>
                <td>
                    <asp:DataList ID="DataList1" runat="server">
                        <HeaderTemplate>
                            <table width="450px" cellpadding="0" cellspacing="0" class="tabtitle">
                                <tr>
                                    <td width="50">
                                        选择
                                    </td>
                                    <td width="150">
                                        用户名
                                    </td>
                                    <td width="150">
                                        CAI用户名
                                    </td>
                                    <td width="100">
                                        是否CAI用户
                                    </td>
                                </tr>
                            </table>
                            <table cellpadding="0" width="450px" cellspacing="0" class="tabcenter">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td width="50" class="tabtd">
                                    <asp:CheckBox ID="selected" runat="server" />
                                </td>
                                <td width="150" class="tabtd">
                                    <font title='<%#Eval("UserName")%>'>
                                        <%#Eval("UserName").ToString()%></font>
                                </td>
                                <td width="150" class="tabtd">
                                    &nbsp;
                                    <%#Eval("CAIUser").ToString()%>
                                    <asp:Label ID="Label1" Visible="false" runat="server" Text='<%#Eval("CAIUser").ToString()%> '></asp:Label>
                                </td>
                                <td width="100" class="tabtd">
                                    <%# Eval("CAIflag").Equals(1)? "是" : "否"%>
                                    <asp:HyperLink ID="Hyperlink1" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "UserID") %>'
                                        Visible="False" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:DataList>
                    <table cellspacing="0" cellpadding="0" width="450px" class="tabtitle">
                        <tr>
                            <td width="450px" align="right">
                                当前页码为:
                                <asp:Label ID="labPage" runat="server" Text="1"></asp:Label>
                                总页码为:
                                <asp:Label ID="labBackPage" runat="server"></asp:Label>
                                &nbsp;<asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>
                                &nbsp;
                                <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
                                <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton>&nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 100px;">
                    <asp:Button ID="warranty" runat="server" Text="授予" Width="67px" OnClick="warranty_Click" />
                    <br />
                    <br />
                    <asp:Button ID="remove" runat="server" Text="移除" Width="69px" OnClick="remove_Click" />
                </td>
                <td>
                    <asp:DataList ID="DataList2" runat="server">
                        <HeaderTemplate>
                            <table width="200px" class="tabtitle">
                                <tr>
                                    <td width="50">
                                        选择
                                    </td>
                                    <td width="150">
                                        未分配用户
                                    </td>
                                </tr>
                            </table>
                            <table cellspacing="0" width="200px" cellpadding="0" class="tabcenter">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr class="tabtr">
                                <td width="50" class="tabtd">
                                    <asp:CheckBox ID="selected" runat="server" />
                                </td>
                                <td width="150" class="tabtd">
                                    <font title='<%#Eval("CAIUser")%>'>
                                        <%#Eval("CAIUser").ToString()%></font>
                                    <asp:HyperLink ID="Hyperlink2" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ID") %>'
                                        Visible="False" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:DataList>
                    <table width="200px" class="tabtitle">
                        <tr>
                            <td>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
