<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddModule.aspx.cs" Inherits="InventionWeb.Background.BBSAdmin.ModuleAdmin.AddModule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>添加专题</title>
        <script type="text/javascript">
            function modulenull() {
                var title = document.getElementById("txtModuleName").value;
                var describe = document.getElementById("Describe").value;
                var fileup = document.getElementById("UpImage").value;
                if (title == "") {
                    alert("请填写标题！");
                    document.getElementById('txtModuleName').focus();
                    return false;
                }
                 if (fileup == "") {
                    alert("专题图片不为空！");
                    document.getElementById('UpImage').focus();
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
<body style="background-color:#d6e4ef">
    <form id="form1" runat="server">
        <div >
        <br />
        <br />
        <table cellspacing="20" cellpadding="10">
            <tr height="50">
                <td>
                    专题名称：
                </td>
                <td>
                    <asp:TextBox ID="txtModuleName"  Width="200px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr height="50">
                <td>
                    专题图片：
                </td>
                <td>
                    <asp:FileUpload ID="UpImage" runat="server"  Width="220px" />
                    (图片长宽比例接近1:1)
                </td>
            </tr>


            <tr height="60">
                <td>
                    专题描述：
                </td>
                <td>
                    <asp:TextBox ID="Describe" runat="server" Width="250px" Height="80px" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr height="50">
                <td style="margin-left:150">
                   
                </td>
                <td> <asp:Button ID="btnAdd" runat="server" Text="添加" OnClick="btnAdd_Click" OnClientClick="return modulenull()" />
                 &nbsp; &nbsp; &nbsp; &nbsp;
                    <asp:Button ID="btnBack" runat="server" Text="取消" OnClick="btnBack_Click" />
                </td>
            </tr>
        </table>
        <img src="/images/right-1.gif" style="width: 500px; height: 400px; position: absolute;
            top: 50px; left: 450px;" />
    </div>
    </form>
</body>
</html>




