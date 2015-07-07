<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardPartInfo.aspx.cs" ValidateRequest="false"
    Inherits="InventionWeb.Front.BBS.FrontDesk.Login.CardPartInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript" src="<%=ResolveUrl("~/editor2/ckeditor/ckeditor.js")%>"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>详细问题页</title>
    <style type="text/css">
        body
        {
            color: #66B;
        }
        .maxdiv
        {
            width: 1000px;
            text-align: left;
            vertical-align: top;
        }
        .problem
        {
            width: 1000px;
            word-break: break-all;
            border: 1px solid #2E9DC8;
            align: center;
        }
        .problemtitle
        {
            padding: 10px 15px;
            background-color: #2e9dc8;
            color: #fff;
            height: 26px;
            text-indent: 3pt;
            font-size: 9pt;
        }
        .content
        {
            padding: 0 15px;
            vertical-align: top;
            direction: ltr;
            text-indent: 6pt;
            height: 54px;
            text-align: left;
        }
        .time
        {
            color: #999;
            height: 22px;
            text-align: right;
        }
        .sort
        {
            margin-top: 5px;
            font-size: 9pt;
            float: right;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="maxdiv">
        <div>
            <table class="problem" cellpadding="0" cellspacing="0">
                <tr>
                    <td class="problemtitle">
                        <asp:Label ID="Label3" Visible="false" runat="server">问题：</asp:Label>
                        <asp:Label ID="labCardID" Visible="false" runat="server"></asp:Label>
                        <asp:Label ID="labCardTitle" runat="server"></asp:Label>
                        &nbsp; &nbsp;
                        <asp:Label ID="username" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 5px; height: 5px;">
                    </td>
                </tr>
                <tr>
                    <td class="content">
                        <asp:Label ID="labCardContent" runat="server" Font-Size="9pt"></asp:Label>
                        <br />
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="time">
                        <asp:Label ID="labCardDate" runat="server" Width="180px" Font-Size="9pt"></asp:Label>&nbsp;
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:DataList ID="dlRevertCard" runat="server">
                <ItemTemplate>
                    <table class="problem" cellpadding="0" cellspacing="0">
                        <tr>
                            <td class="problemtitle" style="background-color: #EEF7FF; color: Black;">
                                留言人：
                                <asp:Label ID="RevrtUser" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"RevertCardUserName") %>'></asp:Label>&nbsp;
                                身份：
                                <asp:Label ID="status" runat="server" Text='<%# DataBinder.Eval(Container.DataItem,"RevertRole") %>'></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="content" style="padding: 2px 15px 0 50px;">
                                &nbsp;&nbsp;<asp:Label ID="labRevert" runat="server" Font-Size="9pt" Text='<%# DataBinder.Eval(Container.DataItem,"RevertCardContent") %>'></asp:Label>
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="time">
                                <asp:Label ID="Label8" runat="server" Font-Size="9pt" Text="回复日期："></asp:Label><asp:Label
                                    ID="labRevertCardDate" runat="server" Font-Size="9pt" Text='<%# DataBinder.Eval(Container.DataItem,"RevertCardDate") %>'></asp:Label>&nbsp;
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>
        </div>
        <div class="sort">
            <asp:Label ID="Label7" runat="server" Text="当前页码为："></asp:Label>
            [
            <asp:Label ID="labPage" runat="server" Text="1"></asp:Label>
            &nbsp;]
            <asp:Label ID="Label6" runat="server" Text="总页码为："></asp:Label>
            [
            <asp:Label ID="labBackPage" runat="server"></asp:Label>
            &nbsp;]<asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" ForeColor="Red"
                OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" ForeColor="Red"
                OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>
            <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" ForeColor="Red"
                OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
            <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" ForeColor="Red"
                OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton>
        </div>
        <asp:Panel ID="editor" Style="display: none;" runat="server">
            <div id="Revert" runat="server" style="margin-top: 20px;">
                <div style="font-size: 12pt; color: Red">
                    快速回复</div>


                 <asp:TextBox ID="txtContent" runat="server"
                        TextMode="MultiLine"></asp:TextBox>
                                        <script type="text/javascript">
                                            CKEDITOR.replace('txtContent', { height: 150 });
                </script>
                <div style="float: left">
                    <asp:Button ID="btnRevert" runat="server" Font-Size="9pt" OnClick="btnRevert_Click"
                        Text="回复" />
                    <asp:Button ID="btnCancel" runat="server" Font-Size="9pt" OnClick="btnCancel_Click"
                        Text="取消" />
                </div>
            </div>
        </asp:Panel>
        <div id="tishi" runat="server" style="border: 1px solid #2E9DC8; clear: both; display: block;
            text-align: center; color: Red; font-size: 12px; padding-top: 50px; padding-bottom: 50px;">
            您未登录，回复需<span style="font-weight: bold; text-decoration: none;"><a href="../../../login.aspx?type=bbs"
                target="_top">登录</a>或<a href="../../../register.aspx" target="_top">注册</a></span></div>
    </div>
    </form>
</body>
</html>
