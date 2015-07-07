<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FindPwd.aspx.cs" Inherits="InventionWeb.Front.BBS.FrontDesk.FindPwd.FindPwd" %>
<%@ Register Src="~/WebControl/footer2.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>找回密码--找到密码</title>
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
            width: 400px;
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
            font-size: 12px;
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
            <table style="width: 810px" border="0" cellspacing="15" align="center">
                <tr>
                    <td colspan="3" align="center">
                        <label>
                            重置密码</label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="linediv">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table class="logininfo" cellpadding="10">
                            <tr>
                                <td style="font-size: 12px; font-weight: bold; text-align: right;">
                                    用户名：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtUserID" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td  style="font-size: 12px; font-weight: bold; text-align: right;">
                                    新密码：
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" CssClass="inputbox"></asp:TextBox>
                                   
                                </td>
                            </tr>
                            <tr>
                                <td  style="font-size: 12px; font-weight: bold; text-align: right;">
                                
                                </td>
                                <td>
                                   <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="txtPwd"
                                        ErrorMessage="(密码应是字母、数字组合)" ForeColor="Red" ValidationExpression="^[A-Za-z0-9]+$"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                 
                                </td>
                                <td>
                                    <asp:Button ID="xiugai" runat="server" CssClass="loginbtn" Width="70px" Text="提交"
                                        Height="30px" BorderColor="Transparent" OnClick="xiugai_Click" />
                                    <asp:Button ID="Btn_Login" runat="server" OnClick="btnBack_Click" CssClass="loginbtn"
                                        Width="70px" Text="取消" Height="30px" BorderColor="Transparent" />
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                        </table>
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
<uc1:footer ID="top2" runat="server" />
    </div>
    </form>
</body>
</html>
