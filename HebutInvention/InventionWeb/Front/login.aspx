<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="InventionWeb.Front.login" %>
<%@ Register Src="~/WebControl/footer2.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>登录页面</title>
    <style type="text/css">
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
        .linediv
        {
            height: 5px;
            background: #84c1ff;
        }
        .btm_p
        {
            font-size: 12px;
        }
        .inputbox
        {
            border-bottom: #cacaca 1px solid;
            border-left: #cacaca 1px solid;
            padding-bottom: 5px;
            line-height: 15px;
            width: 180px;
            padding-right: 5px;
            display: inline;
            background: #fff;
            color: #333;
            vertical-align: middle;
            border-top: #cacaca 1px solid;
            border-right: #cacaca 1px solid;
            padding-top: 5px;
        }
        .logininfo
        {
            margin-left: 100px;
            margin-top: 40px;
            border: 1px dashed #84c1ff;
            width: 300px;
        }
        a.btn_login
        {
            background: url(/images/pic_button01.gif) left top no-repeat;
            width: auto;
            height: 42px;
            line-height: 42px;
            padding-left: 20px;
            display: inline-block;
            text-decoration: none;
            margin-right: 10px;
            cursor: pointer;
        }
        a.btn_login span
        {
            background: url(/images/regeter.jpg) right top repeat-x;
            height: 42px;
            line-height: 42px;
            color: #fff;
            font-weight: normal;
            padding-right: 20px;
            display: inline-block;
            font-size: 20px;
            font-family: 黑体;
        }
        a.btn_loginr
        {
            background: url(/images/regeter.jpg) left top repeat-x;
            width: auto;
            height: 48px;
            line-height: 48px;
            padding-left: 40px;
            display: inline-block;
            text-decoration: none;
            margin-right: 10px;
            cursor: pointer;
        }
        a.btn_loginr span
        {
            background: url(/images/regeter.jpg) right top repeat-x;
            height: 48px;
            line-height: 48px;
            color: #444;
            font-weight: normal;
            padding-right: 40px;
            display: inline-block;
            font-size: 20px;
            font-family: 黑体;
        }
        
        .regdiv
        {
            margin-left: 50px;
            margin-top: 50px;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="clear">
        </div>
        <%--清除浮动--%>
        <div>
            <table style="width: 810px; margin:0 auto;" border="0" cellspacing="15" align="center">
                <tr>
                    <td colspan="3">
                        <img src="../images/TitleLogo1.gif" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="linediv">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <table class="logininfo" cellpadding="10">
                            <tr>
                                <td align="right" style="font-size: 14px; font-weight: bold; text-align: right;">
                                    用户名：
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtUserName" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; font-weight: bold; text-align: right;">
                                    密 码：
                                </td>
                                <td>
                                    <asp:TextBox ID="TxtPwd" runat="server" CssClass="inputbox" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; font-weight: bold; text-align: right;">
                                    验证码：
                                </td>
                                <td>
                                    <asp:TextBox ID="identify" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Image ID="Image1" runat="server" Height="29px" ImageUrl="/front/picture2.aspx"
                                        onclick="this.src='/Front/picture2.aspx?'+Math.random()" title="看不清？点击更换验证码" Width="120px" />
                                <asp:HyperLink ID="hpLinkInfo" runat="server" Font-Size="9pt" ForeColor="Red" NavigateUrl="BBS/FrontDesk/FindPwd/FillUserID.aspx">忘记密码？</asp:HyperLink>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="Btn_Login" runat="server" OnClick="Btn_Login_Click" CssClass="loginbtn"
                                        Width="70px" Text="登   录" Height="30px" BorderColor="Transparent" />
                                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="loginbtn" Width="70px"
                                        Text="取   消" Height="30px" BorderColor="Transparent" OnClick="Button1_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1%;">
                        <img alt="" src="/images/index_new.jpg" style="height: 350px" />
                    </td>
                    <td style="width: 39%">
                        <div>
                            <img src="../images/welcome.gif" />
                        </div>
                        <div class="regdiv">
                            <a class="btn_loginr" href="register.aspx"><span>立即注册</span></a></div>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="linediv">
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
    </div>
    <uc1:footer ID="top2" runat="server" />
    </form>
</body>
</html>
