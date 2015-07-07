<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyInfo.aspx.cs" Inherits="InventionWeb.Front.BBS.FrontDesk.Login.ModifyInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改个人信息</title>
    <style type="text/css">
        .header
        {
            width: 970px;
            color: #fff;
            background-color: #2e9dc8;
            padding: 10px 15px;
            font-size: 16px;
        }
        
        .content
        {
            width: 1000px;
            height: 400px;
            padding-top: 5px;
            font-size: 12px;
        }
        .left
        {
            margin-left: 150px;
            _margin-left: 80px;
            overflow: hidden;
            float: left;
        }
        .tdleft
        {
            width: 80px;
            vertical-align: top;
        }
        .tdright
        {
            width: 270px;
            float: left;
        }
        .right
        {
            overflow: hidden;
            float: left;
        }
        table tr
        {
            height: 40px;
        }
    </style>
    <script language="javascript" type="text/javascript">
        function Hidden() {
            document.getElementById("flag").style.display = "none";
            document.getElementById("tag").style.display = "block";
            document.getElementById("tag2").style.display = "block";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="header">
            修改个人信息</div>
        <hr style="width: 1000px" />
        <br />
        <br />
        <br />
        <table class="left">
            <tr>
                <td class="tdleft">
                    用户名
                </td>
                <td class="tdright">
                    <asp:TextBox ID="txtLoginName" Enabled="false" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    性 别
                </td>
                <td class="tdright">
                    <asp:DropDownList ID="ddlSex" runat="server" Font-Size="9pt">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="flag">
                        <input id="Button1" type="button" value="重新设密码" onclick="Hidden()" /></div>
                    <div id="tag" style="display: none">
                        新密码： &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="newpwd1" TextMode="Password"
                            runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="newpwd1"
                            ErrorMessage="(密码应是字母、数字组合)" ForeColor="Red" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                    </div>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <div id="tag2" style="display: none">
                        重复新密码: &nbsp;&nbsp;&nbsp;
                        <asp:TextBox ID="newpwd2" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="CVPassword" runat="server" ControlToCompare="newpwd1" ControlToValidate="newpwd2"
                            Operator="Equal" ErrorMessage="两次输入密码不一致" ForeColor="#FF3300"></asp:CompareValidator>
                    </div>
                </td>
            </tr>
        </table>
        <table class="right">
            <tr>
                <td class="tdleft">
                    Email
                </td>
                <td class="tdright">
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail"
                        ForeColor="Red" ErrorMessage="密码不为空"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REVEmail" runat="server" ControlToValidate="txtEmail"
                        ErrorMessage="格式不正确!输入形如“123@126.com”" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    住 址
                </td>
                <td class="tdright">
                    <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtAddress"
                        ValidationExpression="[a-zA-Z0-9_\u4e00-\u9fa5]+" Font-Size="9pt" Width="134px">地址有汉字、字母、下划线或数字组成</asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="tdleft">
                    电 话
                </td>
                <td class="tdright">
                    <asp:TextBox ID="txtTel" runat="server"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtTel"
                        ErrorMessage="格式不正确!例：区号—电话号码或输入11手机号为" ForeColor="Red" ValidationExpression="\d{3}-\d{8}|\d{4}-\d{8}|\d{4}-\d{7}|\d{11}"></asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
        <div style="clear: both">
        </div>
        <div style="padding-top: 30px; _margin-top: -130px;*margin-top:30px; margin-left: 400px; margin-bottom: 10px;">
            <asp:Button ID="btnModify" runat="server" OnClick="btnModify_Click" Text="提交" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" OnClick="btnCancel_Click" Text="返回" />
        </div>
        <hr style="width: 1000px" />
    </div>
    </form>
</body>
</html>
