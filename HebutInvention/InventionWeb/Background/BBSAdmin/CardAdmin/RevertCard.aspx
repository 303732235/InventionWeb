<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RevertCard.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.CardAdmin.RevertCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看回复详细信息</title>
    <link href="../../../Styles/SendArticle.css" rel="stylesheet" type="text/css" />
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <table width="100%">
            <tr>
                <td class="Publishleft">
                    回复人：
                </td>
                <td class="Publishright">
                    <asp:Label ID="labCardTitle" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                    所属问题：
                </td>
                <td class="Publishright">
                    <asp:Label ID="labCardMod" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                    回复日期：
                </td>
                <td class="Publishright">
                    <asp:Label ID="labCardDate" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Publishleft" style="vertical-align: top;">
                    回复内容：
                </td>
                <td class="Publishright">
                    <asp:TextBox ID="labCardContent" Width="810px" ReadOnly="true" height="370px" runat="server" 
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
