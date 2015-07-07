<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="adminmidContent.aspx.cs"
    Inherits="InventionWeb.Background.adminmidContent" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <base target="rightframe" />
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>后台管理</title>
    <style type="text/css">
        body
        {
            margin: 0 0 0 0;
        }
        .navPoint
        {
            color: white;
            cursor: hand;
            font-family: Webdings;
            font-size: 9pt;
        }
        .bar
        {
            height: 100%;
            background: url(../images/background/topbar.gif) 5px -2px no-repeat;
        }
        .treeview
        {
            padding-left: -5px;
            padding-top: -5px;
        }
        .titlestyle
        {
            font-size: 10pt;
            color: White;
            padding-top: 5px;
        }
        .style1
        {
            width: 240px;
        }
        .style2
        {
            padding-left: -5px;
            padding-top: -5px;
            width: 300px;
        }
    </style>
</head>
<body style="overflow: hidden">
    <form id="form1" runat="server">
    <table width="100%" border="0" cellpadding="0" cellspacing="0" style="table-layout: fixed;vertical-align: top; height: 100%">
        <tr>
            <td width="266" id="frmTitle">
                <table width="266" border="0" cellpadding="0" cellspacing="0" style="height: 100%;table-layout: fixed;vertical-align: top;">
                    <tr>
                        <td bgcolor="#1873aa" style="width: 6px;">
                        </td>
                        <td width="260">
                            <table border="0" align="center" cellpadding="0" cellspacing="0" 
                                style="width: 260px; height: 100%;vertical-align: top; margin-top: 0px">
                                <tr>
                                    <td height="26" style="background: url(../images/background/bar.gif)" 
                                        class="style1">
                                        <div class="bar">
                                            <div align="center" class="titlestyle">
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" class="style2">
                                        <iframe id="menu" name="menu" height="100%" width="100%" border="0" frameborder="0"
                                            src="/Background/leftmenu/TreeMenu.aspx" runat="server" scrolling="auto"></iframe>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="18">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="6" style="width: 6px;" valign="middle" bgcolor="1873aa">
            </td>
            <td width="100%" align="center" valign="top">
                <iframe id="rightframe" name="rightframe" height="100%" width="100%" border="0" frameborder="0"
                    src="adminRight.aspx" runat="server" scrolling="auto"></iframe>
            </td>
            <td width="6" bgcolor="#1873aa" style="width: 6px;">
                &nbsp;
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
