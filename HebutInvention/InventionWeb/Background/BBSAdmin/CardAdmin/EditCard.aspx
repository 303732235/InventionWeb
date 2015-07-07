<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeBehind="EditCard.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.CardAdmin.EditCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>编辑问题</title>
    <link href="../../../Styles/SendArticle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../../Mydatepicker/DataTime.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/editor/ckeditor/ckeditor.js")%>"></script>
        <script type="text/javascript">
            function cardnull() {
                var title = document.getElementById("labCardTitle").value;
                if (title == "") {
                    alert("请填写标题！");
                    document.getElementById('labCardTitle').focus();
                    return false;
                }
                var time = document.getElementById("labCardDate").value;
                var r = time.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
                if (r == null) {
                    alert("时间填写有误或为空！");
                    document.getElementById("labCardDate").focus();
                    return false;
                }
                var d = new Date(r[1], r[3] - 1, r[4]);
                if (!(d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4])) {
                    alert("时间填写有误或为空！");
                    document.getElementById("labCardDate").focus();
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
                    标题：
                </td>
                <td class="Publishright">
                    <asp:TextBox ID="labCardTitle" Width="300px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                    所属专题：
                </td>
                <td class="Publishright">
                    <asp:DropDownList ID="hpLinkCardMod" runat="server" Width="80px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                    发布日期：
                </td>
                <td class="Publishright">
                    <asp:TextBox ID="labCardDate" runat="server" onClick="javascript:ShowCalendar(this.id)"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Publishleft" style="vertical-align: top;">
                    内容：
                </td>
                <td class="Publishright">
                    <asp:TextBox ID="txtCardContent" CssClass="ckeditor" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="Publishleft">
                </td>
                <td class="Publishright">
                    <asp:Button ID="btnSubmit" runat="server" Text="提交" Font-Size="9pt" CommandName="update"
                        OnClick="btnSubmit_Click" OnClientClick="return cardnull()" />
                    <asp:Button ID="btnCancel" runat="server" Text="返回" Font-Size="9pt" CommandName="cancel"
                        OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
