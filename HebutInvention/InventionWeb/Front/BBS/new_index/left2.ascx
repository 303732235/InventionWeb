<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="left2.ascx.cs" Inherits="InventionWeb.Front.BBS.new_index.left21" %>
     <link href="css/admin.css" type="text/css" rel="stylesheet"/>
    <table style="background-image: url(images/menu_bg.jpg);padding-left:7px" height="100%" cellspacing="0" cellpadding="0" width="150" border="0">
        <tr>
            <td valign="top" align="middle">
                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                    <tr>
                        <td height="10">
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr height="22">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" target="mainFrame" href="/Front/BBS/FrontDesk/Login/BrowseModule.aspx">
                                讨论专题</a>
                        </td>
                    </tr>
                    <tr height="4">
                        <td>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr height="22">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" target="mainFrame" href="../FrontDesk/Login/BrowseCard.aspx">浏览问题</a>
                        </td>
                    </tr>
                    <tr height="4">
                        <td>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr height="22">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" id="deliver" runat="server" target="mainFrame" href="../FrontDesk/Login/DeliverCard.aspx">
                                发布问题</a>
                        </td>
                    </tr>
                    <tr height="4">
                        <td>
                        </td>
                    </tr>
                </table>
                 <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr height="22">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" id="A1" runat="server" target="mainFrame" href="../FrontDesk/Login/uploadindex.aspx">
                                共享资料</a>
                        </td>
                    </tr>
                    <tr height="4">
                        <td>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr height="22">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" target="mainFrame" href="../FrontDesk/Login/ModifyInfo.aspx">修改信息</a>
                        </td>
                    </tr>
                    <tr height="4">
                        <td>
                        </td>
                    </tr>
                </table>
              <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr height="22">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" href="../../loginout.aspx?comefrom=bbs"  onclick="if (confirm('确定要退出吗？')) return true; else return false;" target="_parent">退出系统</a>
                        </td>
                    </tr>
                    <tr height="4">
                        <td>
                        </td>
                    </tr>
                </table>
                <table cellspacing="0" cellpadding="0" width="150" border="0">
                    <tr height="22">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" href="../FrontDesk/Login/Help.aspx" target="mainFrame">帮助</a>
                        </td>
                    </tr>
                    <tr height="4">
                        <td>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="1" bgcolor="#d1e6f7">
            </td>
        </tr>
    </table>