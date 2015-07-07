<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index2.aspx.cs" Inherits="InventionWeb.Front.BBS.new_index.index2" %>

<%@ Register Src="~/Front/BBS/new_index/left1.ascx" TagName="left1" TagPrefix="uc1" %>
<%@ Register Src="~/Front/BBS/new_index/left2.ascx" TagName="left2" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线交流首页</title>
    <style type="text/css">
        .header
        {
            width: 100%;
            height: 62px;
            margin: 0;
            padding: 0;
        }
        .header table
        {
            width: 100%;
            background-image: url(images/header_bg1.jpg);
            border: 0;
        }
        .header table tr
        {
            height: 56px;
        }
        .headmiddle
        {
            font-weight: bold;
            color: #2E9DC8;
            padding-top: 10px;
            text-align: center;
        }
    </style>
    <link href="css/admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="header">
            <table cellspacing="0" cellpadding="0">
                <tr>
                    <td style="background-image: url(images/header_left3.jpg); width: 260px">
                    </td>
                    <td class="headmiddle">
                        <asp:Label ID="username" runat="server" Text=""></asp:Label>
                        <%=userloginifo%>
                       &nbsp; &nbsp; <a href="/Front/index.aspx" style="color: #2E9DC8" target="_self">返回首页</a>
                    </td>
                    <td align="right" style="background-image: url(images/header_right1.gif); width: 268px;">
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <table style="width: 100%; height: 100%;">
                <tr>
                    <td style="width: 15%; background: url(images/menu_bg.jpg) repeat-y; vertical-align: top;">
                        <uc1:left1 ID="top1" runat="server" Visible="false" />
                        <uc2:left2 ID="top2" runat="server" Visible="false" />
                    </td>
                    <td style="width: 85%;">
                        <iframe id="mainFrame" runat="server" name="mainFrame" marginwidth="0" frameborder="0"
                            src="/Front/BBS/FrontDesk/Login/BrowseModule.aspx" height="700px" width="100%"
                            noresize scrolling="yes"></iframe>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
