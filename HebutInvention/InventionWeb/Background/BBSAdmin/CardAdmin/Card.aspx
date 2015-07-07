<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Card.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.CardAdmin.Card" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>查看问题详细信息</title>
    <link href="../../../Styles/SendArticle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ResolveUrl("~/editor/ckeditor/ckeditor.js")%>"></script>
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <table width="100%">
            <tr>
                <td class="Publishleft">
                问题标题：
                </td>
                <td>
                    <asp:Label ID="labCardTitle" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                发布日期：
                </td>
                <td>
                    <asp:Label ID="labCardMod" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                所属专题：
                </td>
                <td>
                    <asp:Label ID="labCardDate" runat="server" Font-Size="12px"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="Publishleft" style="vertical-align: top;">
                内容：
                </td>
                <td>
                    <asp:TextBox ID="labCardContent" CssClass="ckeditor" ReadOnly="true" TextMode="MultiLine"
                        runat="server"></asp:TextBox>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
