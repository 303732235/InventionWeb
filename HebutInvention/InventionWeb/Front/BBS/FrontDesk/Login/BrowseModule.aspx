<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BrowseModule.aspx.cs" Inherits="InventionWeb.Front.BBS.FrontDesk.Login.BrowseModule" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>浏览专题</title>
    <style type="text/css">
        .header
        {
            width: 970px;
            color: #fff;
            margin-bottom: 15px;
            background-color: #2e9dc8;
            padding: 10px 15px;
        }
        .item
        {
            margin-bottom: 20px;
            height: 60px;
            padding: 0px 30px;
            border: 1px solid #DDF;
            background-color: #eef7ff;
        }
        .item .left
        {
            width: 120px;
            text-align: left;
            text-indent: 3pt;
            margin-left: 200px;
        }
        .left img
        {
            margin-left: 60px;
            height: 80px;
            width: 80px;
            border-width: 0px;
        }
        .item .middle
        {
            width: 320px;
            text-align: left;
            padding-left: 20px;
            color: #555;
        }
        .item .newtie
        {
            font-size: 13px;
            color: #66B;
            width: 400px;
            list-style-type: none;
            padding: 10px;
        }
        .item .newtie table
        {
            margin-left: 10px;
        }
        .item a
        {
            text-decoration: none;
        }
        .footer
        {
            width: 1000px;
            margin-bottom: 30px;
            background-color: #2e9dc8;
            color: White;
            height: 35px;
        }
        .footer td
        {
            font-size: 9pt;
            float: right;
            margin-top: 10px;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div class="header">
            讨论专题</div>
        <div>
            <table style="width: 1000px;" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <asp:DataList ID="dlModuleList" runat="server" OnItemDataBound="dlModuleList_ItemDataBound">
                            <ItemTemplate>
                                <table class="item" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <%--模块图片显示--%>
                                        <td class="left">
                                            <a href='ModulePartInfo.aspx?ModuleName=<%# DataBinder.Eval(Container.DataItem,"ModuleName") %>'>
                                                <img src='<%#"~/IndexImages/"+ DataBinder.Eval(Container.DataItem, "ModuleImage")%>'
                                                    runat="server" alt="模板图片" />
                                            </a>
                                        </td>
                                        <%--模块名称显示--%>
                                        <td class="middle">
                                            <a href='ModulePartInfo.aspx?ModuleName=<%# DataBinder.Eval(Container.DataItem,"ModuleName") %>'
                                                style="font-size: 12pt; text-decoration: none">
                                                <%# DataBinder.Eval(Container.DataItem,"ModuleName") %></a>
                                            <br />
                                            <span style="color: #999; font-size: 14px; line-height: 30px;" title='<%# DataBinder.Eval(Container.DataItem,"ModuleDescribe") %>'>
                                                <%#CutString( DataBinder.Eval(Container.DataItem, "ModuleDescribe").ToString())%></span>
                                        </td>
                                        <td class="newtie">
                                            <span style="color: #999;">最新发表:</span>
                                            <asp:DataList ID="newtop" runat="server">
                                                <ItemTemplate>
                                                    <table>
                                                        <tr>
                                                            <td>
                                                                <a target="_self" href='CardPartInfo.aspx?CardID=<%#DataBinder.Eval(Container.DataItem,"CardID") %>'>
                                                                    <%#CutString(DataBinder.Eval(Container.DataItem, "CardName").ToString())%>
                                                                </a>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                        <table class="footer" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
