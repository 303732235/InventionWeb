<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConfigMgr2.aspx.cs" Inherits="InventionWeb.Front.DBConn.ConfigMgr2" %>

<%@ Register Src="~/WebControl/footer2.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改连接字符串</title>
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
            margin-left: 25px;
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
            <table style="width: 810px; margin: 0 auto;" border="0" cellspacing="15" align="center">
                <tr>
                    <td colspan="3">
                        <img src="../../images/TitleLogo2.gif" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <div class="linediv">
                        </div>
                    </td>
                </tr>
                <tr>
                    <td style="width: 60%;">
                        <table class="logininfo" cellpadding="10">
                            <tr>
                                <td style="font-size: 14px; font-weight: bold;">
                                    数据库IP：
                                </td>
                                <td>
                                    <asp:TextBox ID="SQLIP" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; font-weight: bold;">
                                    数据库名：
                                </td>
                                <td>
                                    <asp:TextBox ID="SQLName" runat="server" CssClass="inputbox" ></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; font-weight: bold;">
                                    用&nbsp;户&nbsp;名：
                                </td>
                                <td>
                                    <asp:TextBox ID="SQLUser" runat="server" CssClass="inputbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="font-size: 14px; font-weight: bold;">
                                    密&nbsp;&nbsp;&nbsp;码：
                                </td>
                                <td>
                                    <asp:TextBox ID="SQLPwd" runat="server" CssClass="inputbox" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:Button ID="Btn_Login" runat="server" CssClass="loginbtn" Width="70px" Text="提   交"
                                        Height="30px" BorderColor="Transparent" onclick="Btn_Login_Click1" />
                                    &nbsp;&nbsp;<asp:Button ID="Button1" runat="server" CssClass="loginbtn" Width="70px"
                                        Text="清   空" Height="30px" BorderColor="Transparent" 
                                        onclick="Button1_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 1%;">
                        <img alt="" src="/images/index_new.jpg" style="height: 350px" />
                    </td>
                    <td style="width: 39%">
                        <div>
                         <asp:Panel ID="welcome" runat="server" style= "display:Block;background-color:#F0F5F5;font-size:12px;padding:15px;width:180px;" >
                           此页面实现河北工业大学学报编辑部动态修改数据库连接字符串
                        </asp:Panel>
                           <asp:Panel ID="Panel1" runat="server" style= "display:none;" >
                            <table style="width: 100%;">
                                <tr>
                                    <td height="30px" style="font-size: 14px; font-weight: bold;">
                                        用户名：
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TxtNewname" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-size: 14px; font-weight: bold;">
                                        新密码：
                                    </td>
                                    <td colspan="2" >
                                        <asp:TextBox ID="TxtNewpwd" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="font-size: 14px; font-weight: bold;">
                                        确认密码：
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="TextBox1" runat="server"  TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="submit" runat="server" Text="提交" OnClick="submit_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="quit" runat="server" Text="取消" OnClick="quit_Click" />
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                        </div>
                        <div class="regdiv">
   <asp:Button ID="Button2" runat="server" CssClass="loginbtn" Width="90px" Text="重设用户"
                                        Height="30px" BorderColor="Transparent" onclick="Button2_Click" />
     <asp:Button ID="Button3" runat="server" CssClass="loginbtn" Width="90px" Text="返回首页"
                                        Height="30px" BorderColor="Transparent" onclick="Button3_Click" />
                         
                            </div>
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
