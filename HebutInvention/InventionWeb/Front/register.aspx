<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="InventionWeb.Front.register" %>
<%@ Register Src="~/WebControl/footer2.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>注册页面</title>
    <style type="text/css">
        .tdstyle
        {
            text-align: right;
            font-size: 14px;
            width: 240px;
            vertical-align: middle;
        }
        .warninfo
        {
            font-size: 12px;
        }
        .toptd
        {
            font-size: 15px;
            height: 25px;
        }
        .inputbox
        {
            border: 1px solid #cacaca;
            padding: 5px;
            line-height: 15px;
            width: 250px;
            display: inline;
            background: #fff;
            color: #333;
            vertical-align: middle;
            margin-right: 5px;
        }
        #topnav A
        {
            color: Black;
            font-size: 12px;
            text-decoration: none;
        }
        #topnav A:hover
        {
            color: Blue;
            text-decoration: underline;
        }
        #topnav .topnav_left A
        {
            margin: 0px 5px;
        }
        .btm_p
        {
            font-size: 12px;
        }
        .linediv
        {
            height: 5px;
            background: #84c1ff;
        }
        
        .loginbtn
        {
            background: url(/images/loginbtn.jpg) repeat-x center;
            font-size: 14px;
            font-weight: bold;
            color: White;
        }
        .clear
        {
            clear: both;
        }
        #footer
        {
            color: #757575;
            font-size: 13px;
            text-align: center;
            padding-top: 10px;
            padding-bottom: 10px;
        }
        .bitian
        {
            color:Red;
            font-size:15px;
            vertical-align:middle;
            }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="clear">
        </div>
        <%--清除浮动--%>
        <div>
            <table style="width: 810px;" align="center" border="0" cellspacing="15">
                <tr>
                    <td colspan="2" style="height: 60px">
                        <img src="../images/TitleLogoRegist.gif" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="toptd">
                        <b>登录信息：</b>
                        <div class="linediv">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                        <span class="bitian">*</span>用户名：
                        <br />
                        <br />
                    </td>
                    <td>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:TextBox ID="UserLoginName" runat="server" CssClass="inputbox"></asp:TextBox>
                                <asp:Button ID="Detect" runat="server" OnClick="Detect_Click" Style="margin-bottom: 0px"
                                    Text="检测是否可用" />
                                <asp:Label ID="lblmessage" runat="server" ForeColor="Red"></asp:Label>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="UserLoginName"
                            ErrorMessage="(5-16位字母、数字或下划线组合)" ForeColor="Red" ValidationExpression="^[a-zA-Z][a-zA-Z0-9_]{4,15}$"></asp:RegularExpressionValidator>
                        <div class="warninfo">
                            (5-16位字母、数字或下划线组合，首字符必须为字母)
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                       <span class="bitian">*</span>密码：
                        <br />
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" CssClass="inputbox" TextMode="Password"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="Password"
                            ErrorMessage="(密码应是字母、数字组合)" ForeColor="Red" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                        <div class="warninfo">
                            (建议您的密码使用字符+数字等多种不同类型的组合，并且密码长度大于5位)</div>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                       <span class="bitian">*</span>确认密码：
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="AffrimPassword" runat="server" CssClass="inputbox" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="CVPassword" runat="server" ControlToCompare="Password"
                            ControlToValidate="AffrimPassword" Operator="Equal" ErrorMessage="两次输入密码不一致"
                            ForeColor="#FF3300"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                       <span class="bitian">*</span>密码问题：<br />
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtQuePwd" runat="server" CssClass="inputbox" Style="margin-right: 0"
                            Width="250px"></asp:TextBox>
                             <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="txtQuePwd"
                        ValidationExpression="[a-zA-Z0-9_\u4e00-\u9fa5]+" Font-Size="9pt" Width="134px">地址有汉字、字母、下划线或数字组成</asp:RegularExpressionValidator>
                        <div class="warninfo">
                            (密码问题，以防忘记密码)</div>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                       <span class="bitian">*</span>密码提示答案：<br />
                        <br />
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnsPwd" runat="server" CssClass="inputbox" Style="margin-right: 0"
                            Width="249px"></asp:TextBox>
<asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="txtAnsPwd"
                        ValidationExpression="[a-zA-Z0-9_\u4e00-\u9fa5]+" Font-Size="9pt" Width="134px">地址由汉字、字母、下划线或数字组成</asp:RegularExpressionValidator>
                        <div class="warninfo">
                            (用于重置密码时回答密码问题)</div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" class="toptd">
                        <b>用户信息：</b>
                        <div class="linediv">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                        性别：
                    </td>
                    <td>
                        <asp:RadioButton ID="RadioButton_Male" GroupName="UserSex" runat="server" Text="男"
                            Checked="true" />
                        <asp:RadioButton ID="RadioButton_Female" GroupName="UserSex" runat="server" Text="女" />
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                        联系电话：
                    </td>
                    <td>
                        <asp:TextBox ID="TelephoneNum" runat="server" CssClass="inputbox"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TelephoneNum"
                            ErrorMessage="须区号—电话号码或输入11手机号位" ForeColor="Red" ValidationExpression="\d{3}-\d{8}|\d{4}-\d{8}|\d{4}-\d{7}|\d{11}"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                       <span class="bitian">*</span>Email：
                    </td>
                    <td>
                        <asp:TextBox ID="EmailAddress" runat="server" CssClass="inputbox"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="REVEmail" runat="server" ControlToValidate="EmailAddress"
                            ErrorMessage="格式不正确!输入形如“123@126.com”" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                        住址：
                    </td>
                    <td>
                        <asp:TextBox ID="Address" runat="server" CssClass="inputbox"></asp:TextBox>
                          <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="Address"
                        ValidationExpression="[a-zA-Z0-9_\u4e00-\u9fa5]+" Font-Size="9pt" Width="134px">地址有汉字、字母、下划线或数字组成</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td class="tdstyle">
                       <span class="bitian">*</span>验证码：
                    </td>
                    <td>
                        <asp:TextBox ID="identify" runat="server" CssClass="inputbox" Style="vertical-align: top;
                            margin-right: 0" Width="147px"></asp:TextBox>
                        <asp:Image ID="Image1" runat="server" Height="25px" onclick="this.src='../Front/picture2.aspx?'+Math.random()"
                            title="看不清？点击更换验证码" Width="100px" ImageUrl="/front/picture2.aspx" />
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="identify"
                        ValidationExpression="[a-zA-Z0-9]+" Font-Size="9pt" Width="134px">验证码由字母和数字组成</asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Button1" runat="server" OnClick="Btn_Login_Click" Text="注 册" CssClass="loginbtn"
                            Width="70px" Height="30px" BorderColor="Transparent" />
                        &nbsp;&nbsp;
                        <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Btn_Cancel_Click" CssClass="loginbtn"
                            Width="70px" Height="30px" BorderColor="Transparent" />
                        &nbsp;&nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div class="linediv">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
<uc1:footer ID="top2" runat="server" />
    </div>
    </form>
</body>
</html>
