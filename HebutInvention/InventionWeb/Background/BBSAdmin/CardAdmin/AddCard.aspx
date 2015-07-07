<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeBehind="AddCard.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.CardAdmin.AddCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发布问题</title>
    <link href="../../../Styles/SendArticle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%=ResolveUrl("~/editor/ckeditor/ckeditor.js")%>"></script>
    <script type="text/javascript">
        function cardnull() {
            var title = document.getElementById("txtCardTitle").value;
            if (title == "") {
                alert("请填写标题！");
                document.getElementById('txtCardTitle').focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <table width="100%">
            <tr>
                <td class="Publishleft">
                    <asp:Label ID="labCardTitle" runat="server" Text="标  题" Font-Size="9pt"></asp:Label>
                </td>
                <td class="Publishright">
                    <asp:TextBox ID="txtCardTitle" runat="server" Width="300px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                    <asp:Label ID="labModuleID" runat="server" Text="所属专题" Font-Size="9pt"></asp:Label>
                </td>
                <td class="Publishright">
                    <asp:DropDownList ID="ddlModuleName" runat="server" Width="80px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Publishleft" style="vertical-align: top;">
                    <asp:Label ID="labCardContent" runat="server" Text="内容"></asp:Label>
                </td>
                <td class="Publishright">
                    <asp:TextBox ID="txtCardContent" CssClass="ckeditor"  TextMode="MultiLine" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                </td>
                <td class="Publishright">
                    <asp:Button ID="btnDeliver" runat="server" Text="发布" OnClick="btnDeliver_Click" Font-Size="9pt" OnClientClick="return cardnull()" />
                    &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="返回" OnClick="btnCancel_Click" Font-Size="9pt" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
