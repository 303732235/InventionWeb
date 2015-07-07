<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditModule.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.ModuleAdmin.EditModule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改专题</title>
    <link href="../../../Styles/backmokuai.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function modulenull() {
            var title = document.getElementById("txtModTitle").value;
            var describe = document.getElementById("Describe").value;
            if (title == "") {
                alert("请填写标题！");
                document.getElementById('txtModTitle').focus();
                return false;
            }
            if (describe == "") {
                alert("请专题描述！");
                document.getElementById('Describe').focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <table cellspacing="20" cellpadding="10">
            <tr>
                <td>
                    <asp:Label ID="labModTitle" runat="server" Font-Size="9pt" Text="专题名称"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtModTitle" runat="server" Width="300px" Font-Size="9pt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Font-Size="9pt" Text="专题描述"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="Describe" runat="server" TextMode="MultiLine" Width="300px" Height="60px"
                        Font-Size="9pt"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Font-Size="9pt" Text="原有专题图片"></asp:Label>
                </td>
                <td>
                    <asp:Image ID="Image1" ImageUrl="" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Font-Size="9pt" Text="上传专题图片"></asp:Label>
                </td>
                <td>
                    <asp:FileUpload ID="UpImage" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnModify" runat="server" Text="修改" Font-Size="9pt" OnClick="btnModify_Click" OnClientClick="return modulenull()" />
                    &nbsp;&nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnCancel" runat="server" Text="返回" Font-Size="9pt" OnClick="btnCancel_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
