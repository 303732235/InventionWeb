<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="InventionWeb.Background.Login2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        *
        {
            overflow: hidden;
            font-size: 9pt;
        }
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            background-image: url(../images/background-login2/bg.gif);
            background-repeat: repeat-x;
        }
    </style>
    <script type="text/javascript">
        function Checklogin() {
            if (myform.username.value == "") {
                alert("请填写登录名");
                myform.id.focus();
                return false;
            }
            if (myform.password.value == "") {
                alert("密码不能为空");
                myform.pw.focus();
                return false;
            }
        }

    </script>
    <script language="javascript" type="text/javascript" for="login" event="onclick">
// <![CDATA[
return login_onclick()
// ]]>
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <table width="100%" height="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td height="561" style="background: url(../images/background-login2/lbg.gif)">
                            <table width="940" border="0" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td height="238" style="background: url(../images/background-login2/login01.jpg)">
                                    <center style="font-size:36px;font-weight:bold;color:#06AEEF;">河北工业大学学报编辑部后台管理</center>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="190">
                                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td width="208" height="190" style="background: url(../images/background-login2/login02.jpg)">
                                                </td>
                                                <td width="518" style="background: url(../images/background-login2/login03.jpg)">
                                                    <table width="320" border="0" align="center" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="40" height="30">
                                                                <img src="../images/background-login2/login_user.gif" width="26" height="26">
                                                            </td>
                                                            <td width="38" height="30">
                                                                用 户
                                                            </td>
                                                            <td width="242" height="30">
                                                                <asp:TextBox ID="txtUserName" runat="server" Style="width: 164px; height: 26px; line-height: 26px;
                                                                    background: url(../images/background-login2/inputbg.gif) repeat-x; border: solid 1px #d1d1d1;
                                                                    font-size: 9pt; font-family: Verdana, Geneva, sans-serif;"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtUserName"
                                                                    runat="server" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="30">
                                                                <img src="../images/background-login2/login_password.gif" width="24" height="26" />
                                                            </td>
                                                            <td height="30">
                                                                密 码
                                                            </td>
                                                            <td height="30">
                                                                <asp:TextBox ID="txtUserPass" runat="server" Style="width: 164px; height: 26px; line-height: 26px;
                                                                    background: url(../images/background-login2/inputbg.gif) repeat-x; border: solid 1px #d1d1d1;
                                                                    font-size: 9pt;" TextMode="Password"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserPass"
                                                                    Display="Dynamic" ErrorMessage="不能为空"></asp:RequiredFieldValidator>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="30">
                                                                <img src="../images/background-login2/login_yzm.jpg" width="26" height="26">
                                                            </td>
                                                            <td height="30">
                                                                验证码
                                                            </td>
                                                            <td height="30">
                                                                <asp:TextBox ID="identify" runat="server" Style="width: 85px; height: 26px; line-height: 26px;
                                                                    background: url(../images/background-login2/inputbg.gif) repeat-x; border: solid 1px #d1d1d1;
                                                                    font-size: 9pt;"></asp:TextBox>
                                                                <img src="../Front/picture2.aspx" id="captchaimg" style="cursor: pointer; margin-left: 5px"
                                                                    onclick="this.src='../Front/picture2.aspx?'+Math.random()" align="absmiddle" title="看不清？点击更换验证码" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td height="30">
                                                            </td>
                                                            <td height="40">
                                                            </td>
                                                            <td height="60">
                                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/background-login2/login.gif"
                                                                    Width="80" Height="30" name="login" OnClick="ImageButton1_Click" />
                                                                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/background-login2/login1.gif"
                                                                    Width="80" Height="30" name="login" OnClick="ImageButton2_Click" />
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td width="214" style="background: url(../images/background-login2/login04.jpg)">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="133" style="background: url(../images/background-login2/login05.jpg)">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
