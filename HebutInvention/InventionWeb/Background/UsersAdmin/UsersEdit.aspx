<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersEdit.aspx.cs" Inherits="InventionWeb.Background.UsersAdmin.UsersEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑用户</title>
    <link href="../../Styles/backmokuai.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 40px;
        }
    </style>
    <script type="text/javascript" src="../../Mydatepicker/DataTime.js"></script>
    <script language="javascript" type="text/javascript">
        function Hidden() {
            document.getElementById("flag").style.display = "none";
            document.getElementById("tag").style.display = "block";
        }
    </script>
</head>
<body class="Addpage" style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <table>
            <tr>
                <td class="style1">
                    用户名：
                    </td><td>
                    <asp:TextBox ID="TxtName" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1" colspan="2">
                    <asp:Label ID="yuanmima" runat="server" style="display:none" Text="Label"></asp:Label>
                    <div id="flag">
                        <input id="Button1" type="button" value="重新设密码" onclick="Hidden()" />使用此项会重设用户名的密码，谨慎使用！
                    </div>
                    <div id="tag" style="display: none">
                        新密码：<asp:TextBox ID="TxtPassword" TextMode="Password" runat="server" Width="200px"></asp:TextBox>
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    性别：&nbsp;
                   </td><td> <asp:RadioButton ID="RadioButton_Male" GroupName="UserSex" runat="server" Text="男"
                        Checked="true" />
                    <asp:RadioButton ID="RadioButton_Female" GroupName="UserSex" runat="server" Text="女" />
                </td>
            </tr>
            <tr>
                <td class="style1">
                    地址：&nbsp;
                   </td><td> <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    电话：&nbsp;
                   </td><td> <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style1">
                    邮箱：&nbsp;
                   </td><td> <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="REVEmail" runat="server" ControlToValidate="TxtEmail"
                        ErrorMessage="格式不正确!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            
            <tr>
                <td class="style1">
                    用户角色：
                   </td><td> <asp:DropDownList ID="DropDownList1" runat="server">
                        
                        <asp:ListItem Value="1">管理员</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style1">
                  </td><td>  <asp:Button ID="Save" runat="server" Text="保存" OnClick="Save_Click" />
                   &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Button ID="Cancel" runat="server" Text="取消" OnClick="Cancel_Click" />
                </td>
            </tr>
        </table>
        <img src="/images/right-1.gif" style="width: 600px; height: 400px; position: absolute;
            top: 50px; left: 300px;" />
    </div>
    </form>
</body>
</html>
