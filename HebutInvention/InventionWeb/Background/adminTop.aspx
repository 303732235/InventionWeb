<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminTop.aspx.cs" Inherits="InventionWeb.Background.adminTop" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>河北工业大学学报编辑部头部</title>
    <style type="text/css">
        body
        {
            margin-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
        }
    </style>
</head>
<body>
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
            <td height="70" width="100%">
                <div style="float: left;margin-left: 10px;font-size: 42px; color: #70A4CF;  font-weight: bold;">

河北工业大学学报编辑部后台管理
                </div>
                <div style="color: #70A4CF; float: right; font-weight: bolder; margin-right: 30px;
                    padding-top: 30px;">
                    管理员：<asp:Label ID="admin" runat="server"></asp:Label>
                    <a target="_blank" style="color: #70A4CF" href="../Front/index.aspx">前台</a> <a target="_top"
                        style="color: #70A4CF" href="loginout.aspx">退出</a>
                </div>
            </td>
        </tr>
        <tr>
            <td height="28" background="../images/background/main_36.gif">
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td width="276" height="28" style="background: url(../images/background/main_32.gif) no-repeat">
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>
