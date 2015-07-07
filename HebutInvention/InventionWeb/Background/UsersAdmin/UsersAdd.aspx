<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersAdd.aspx.cs" Inherits="InventionWeb.Background.UsersAdmin.UsersAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加用户</title>
    <link href="../../Styles/backmokuai.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            height: 40px;
        }
    </style>
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="content">
        <table>
            <tr class="style1">
                <td>
                    用户名：
                </td>
                <td>
                    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>(5-16位字母、数字或下划线组合)
                    <asp:RequiredFieldValidator ID="RFVUserName" runat="server" ControlToValidate="TxtName"
                        ErrorMessage="用户名不能为空" ForeColor="Red"></asp:RequiredFieldValidator>
                         <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtName"
                            ErrorMessage="(5-16位字母、数字或下划线组合)" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z0-9_]{4,15}$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr class="style1">
                <td>
                    密码：&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>(密码应是字母、数字组合)
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtPassword"
                        ForeColor="Red" ErrorMessage="密码不为空"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TxtPassword"
                            ErrorMessage="(密码应是字母、数字组合)" ForeColor="Red" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr class="style1">
                <td>
                    密码问题：&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="question" runat="server"></asp:TextBox>不能为空
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="question"
                        ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="style1">
                <td>
                    问题答案：&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="answer" TextMode="Password" runat="server"></asp:TextBox>不能为空
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="answer"
                        ForeColor="Red" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr class="style1">
                <td>
                    性别：&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:RadioButton ID="RadioButton_Male" GroupName="UserSex" runat="server" Text="男"
                        Checked="true" />
                    <asp:RadioButton ID="RadioButton_Female" GroupName="UserSex" runat="server" Text="女" />
                </td>
            </tr>
            <tr class="style1">
                <td>
                    地址：&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="style1">
                <td>
                    电话：&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtPhone" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr class="style1">
                <td>
                    邮箱：&nbsp;&nbsp;&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>邮箱不能为空
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TxtEmail"
                        ForeColor="Red" ErrorMessage="邮箱不能为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REVEmail" runat="server" ControlToValidate="TxtEmail"
                        ErrorMessage="格式不正确!" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr class="style1" style="display:none;">
                <td>
                    积分：&nbsp;
                </td>
                <td>
                    <asp:TextBox ID="mark" runat="server"></asp:TextBox>（5000以内数字）
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ValidationExpression="[0-9]*"  ControlToValidate="mark" ErrorMessage="只能输入数字"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr class="style1" >
                <td>
                    用户角色：&nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        
                        <asp:ListItem Value="1">管理员</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr class="style1">
                <td>
                    <asp:Button ID="Save" runat="server" Text="添加" OnClick="Add_Click" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <img src="/images/right-1.gif" style="width: 600px; height: 400px; position: absolute;
            top: 80px; left: 400px;" />
    </div>
    </form>
</body>
</html>
