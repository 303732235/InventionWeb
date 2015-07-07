<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsImageRight.aspx.cs"
    Inherits="InventionWeb.Front.NewImage.NewImageRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>新闻快递2</title>
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <span class="ModuleName">图片新闻：</span><br />
        <hr class="RightHR"/>
        <asp:DataList ID="rightlist" runat="server" RepeatColumns="5">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <a href="./NewsImageDetails.aspx?id=<%#Eval("id")%>" target="_parent">
                                <asp:Image ID="CommodityImage" runat="server" Width="120px" Height="110px" ImageUrl='<%#"~/IndexImages/"+ DataBinder.Eval(Container.DataItem, "url")%>' />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                          <a href="./NewsImageDetails.aspx?id=<%#Eval("id")%>" target="_parent">
                            <asp:Label ID="Label1" runat="server" Text='<%#CutString(Eval("content").ToString()) %>'></asp:Label>
                            </a>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        <br />
        <table class="RightSort" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="当前页码为："></asp:Label>[
                    <asp:Label ID="labPage" runat="server" Text="1"></asp:Label>
                    &nbsp;]
                    <asp:Label ID="Label6" runat="server" Text="总页码为："></asp:Label>[
                    <asp:Label ID="labBackPage" runat="server"></asp:Label>
                    &nbsp;]
                    <asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>
                    <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
                    <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="Red"
                        OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton>&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
