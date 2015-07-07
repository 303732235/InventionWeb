<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownAdd.aspx.cs" Inherits="InventionWeb.Background.DownAttachAdmin.DownAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>上传资料</title>
    <style type="text/css">
        body
        {
            font-size: 12px;
        }
    </style>
    <script type="text/javascript" src="../../Mydatepicker/DataTime.js"></script>
            <script type="text/javascript">
                function notnull() {
                    var title = document.getElementById("TxtTitle").value;
                    var writer = document.getElementById("TxtWriter").value;
                    var file = document.getElementById("FileUp").value;

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
                    if (file == "") {
                        alert("上传资料不能为空！");
                        document.getElementById('FileUp').focus();
                        return false;
                    }
                    var time = document.getElementById("TxtDate").value;
                   
                    if (time == "") {
                        alert("时间填写为空！");
                        document.getElementById("TxtDate").focus();
                        return false;
                    }
                    
                    return true;
                }
    </script>
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div style="margin-top: 40px; margin-left: 40px">
        <table>
            <tr>
                <td height="50px" colspan="2">
                    资料分类：
                </td>
                <td>
                    <asp:DropDownList ID="classification" runat="server" onchange="change(this);">
                        <asp:ListItem>自然版过刊</asp:ListItem>
                        <asp:ListItem>社科版过刊</asp:ListItem>
                       <%-- <asp:ListItem>TRIZ书籍</asp:ListItem>
                        <asp:ListItem>BBS资料</asp:ListItem>--%>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td height="50px" colspan="2">
                    填写年份:
                </td>
                <td>
                    <asp:TextBox ID="TxtDate" runat="server" ></asp:TextBox>请填写正确年份格式格式，如：2014
                </td>
            </tr>
             <tr>
                <td height="50px" colspan="2">
                    资料分期：
                </td>
                <td>
                 <script type="text/javascript">

                     function change() {

                         var ddl = document.getElementById("classification")
                         var index = ddl.selectedIndex;


                         var Text = ddl.options[index].text;
                         
                         if (Text == "社科版过刊") {
                             document.getElementById('classfenqi').getElementsByTagName('option')[4].style.display = "none";
                             document.getElementById('classfenqi').getElementsByTagName('option')[5].style.display = "none";


                         }
                         
                     }
                     
                     
                 </script>
                    <asp:DropDownList ID="classfenqi" runat="server">
                        <asp:ListItem>第一期</asp:ListItem>
                        <asp:ListItem>第二期</asp:ListItem>
                        <asp:ListItem>第三期</asp:ListItem>
                        <asp:ListItem>第四期</asp:ListItem>
                        <asp:ListItem>第五期</asp:ListItem>
                        <asp:ListItem>第六期</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td height="50px" colspan="2">
                    资料名称：
                </td>
                <td>
                    <asp:TextBox ID="TxtTitle"  Width="200px" runat="server"></asp:TextBox>
                </td>
            </tr>
          
                <td height="50px" colspan="2">
                    资料编号：
                </td>
                <td>
                    <asp:TextBox ID="TextBox1"  Width="200px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td height="50px" colspan="2">
                    资料作者：
                </td>
                <td>
                    <asp:TextBox ID="TxtWriter" runat="server"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td height="50px" colspan="2">
                    选择文件：
                </td>
                <td>
                    <asp:FileUpload ID="FileUp" runat="server" Width="220px" />
                </td>
            </tr>
            <tr>
                <td height="50px" colspan="2">
                </td>
                <td>
                    <asp:Button ID="Add" runat="server" OnClick="Add_Click" Text="提交" OnClientClick="return notnull()" />
                    <asp:Button ID="Cancel" runat="server" Text="取消" OnClick="Cancel_Click" />
                </td>
            </tr>
        </table>
        <img src="/images/right-1.gif" style="width: 500px; height: 400px; position: absolute;
            top: 50px; left: 400px;" />
    </div>
    </form>
</body>
</html>
