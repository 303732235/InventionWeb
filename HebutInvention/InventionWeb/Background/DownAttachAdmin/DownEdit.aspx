<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownEdit.aspx.cs" Inherits="InventionWeb.Background.DownAttachAdmin.DownEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑下载资料</title>
    <style type="text/css">
        body
        {
            font-size: 12px;
        }
    </style>
</head>
 <script type="text/javascript" src="../../Mydatepicker/DataTime.js"></script>
<script language="javascript" type="text/javascript">
    function Hidden() {
        document.getElementById("flag").style.display = "none";
        document.getElementById("tag").style.display = "block";
    }
    function notnull() {
        var title = document.getElementById("TxtTitle").value;
        var writer = document.getElementById("TxtWriter").value;
        if (title == "") {
            alert("请填写标题！");
            document.getElementById('TxtTitle').focus();
            return false;
        }
        if (writer == "") {
            alert("请填写作者！");
            document.getElementById("TxtWriter").focus();
            return false;
        }
        var time = document.getElementById("TxtDate").value;
        var r = time.match(/^(\d{1,4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
        if (r == null) {
            alert("时间填写有误或为空！");
            document.getElementById("TxtDate").focus();
            return false;
        }
        var d = new Date(r[1], r[3] - 1, r[4]);
        if (!(d.getFullYear() == r[1] && (d.getMonth() + 1) == r[3] && d.getDate() == r[4])) {
            alert("时间填写有误或为空！");
            document.getElementById("TxtDate").focus();
            return false;
        }
        return true;
    }

</script>
<body style="background-color: #d6e4ef">
    <form runat="server">
    <div style="margin-top: 40px; margin-left: 40px">
        <table cellpadding="10" cellspacing="10">
            <tr>
                <td colspan="2">
                    资料分类：
                </td>
                <td>
                    <asp:DropDownList ID="classification" runat="server">
                        <asp:ListItem Value="1">自然版过刊</asp:ListItem>
                        <asp:ListItem Value="2">社科版过刊</asp:ListItem>
                        <%--<asp:ListItem Value="3">TRIZ书籍</asp:ListItem>
                        <asp:ListItem Value="4">BBS资料</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    资料标题：
                </td>
                <td>
                    <asp:TextBox ID="TxtTitle" runat="server" Width="200"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    资料作者：
                </td>
                <td>
                    <asp:TextBox ID="TxtWriter" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    发布时间：
                </td>
                <td>
                    <asp:TextBox ID="TxtDate" runat="server" Height="18px" onClick="javascript:ShowCalendar(this.id)"
                        Width="148px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                    <div id="flag">
                        原资料名：<asp:Label ID="TxtFileName" Width="200" runat="server"></asp:Label>
                        &nbsp;&nbsp;<input id="Button1" type="button" value="重新上传" onclick="Hidden()" /></div>
                    <div id="tag" style="display: none">
                        选择文件：<asp:FileUpload ID="FileUp" runat="server" Width="220px" Visible="True" /></div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                </td>
                <td>
                    <asp:Button ID="Add" runat="server" OnClick="Save_Click" Text="修改" OnClientClick="return notnull()" />
                    <asp:Button ID="Cancel" runat="server" Text="取消" OnClick="Cancel_Click" Style="margin-left: 0px" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
