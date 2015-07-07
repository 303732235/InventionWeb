<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsImageEdit.aspx.cs"
    Inherits="InventionWeb.Background.NewImageAdmin.NewsImageEdit"  ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改图片新闻</title>
    <link href="../../Styles/SendArticle.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../Mydatepicker/DataTime.js"></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/editor/ckeditor/ckeditor.js")%>"></script>
            <script type="text/javascript">
                function notnull() {
                    var title = document.getElementById("TxtTitle").value;
                    if (title == "") {
                        alert("请填写标题！");
                        document.getElementById('TxtTitle').focus();
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
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <table width="100%">
            <tr>
                <td class="EditPicleft">
                    图片标题：
                </td>
                <td class="EditPicMiddle">
                    <asp:TextBox ID="TxtTitle" Width="300px" runat="server"></asp:TextBox>
                </td>
                <td  class="EditPicright"  rowspan="3">
                   <asp:Image ID="Image1" runat="server"  Height="169px" Width="187px" />
                </td>
            </tr>
            <tr>
                <td class="EditPicleft">
                    发布时间：
                </td>
                <td class="EditPicMiddle">
                    <asp:TextBox ID="TxtDate" runat="server" onClick="javascript:ShowCalendar(this.id)"></asp:TextBox>
                </td>

            </tr>
            <tr>
                <td class="EditPicleft">
                    图片：
                </td>
                <td class="EditPicMiddle">
                    <asp:FileUpload ID="FileUp" runat="server" Width="220px" />
                </td>
            </tr>
            
            <tr>
                <td class="EditPicleft">
                </td>
                <td class="EditPicMiddle">
                    <asp:Button ID="Add" runat="server" Text="提交" OnClick="Save_Click" OnClientClick="return notnull()" />
                    <asp:Button ID="Cancel" runat="server" Text="取消" OnClick="Cancel_Click" />
                </td>
                <td class="EditPicright">
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
