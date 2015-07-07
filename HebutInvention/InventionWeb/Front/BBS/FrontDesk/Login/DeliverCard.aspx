<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeliverCard.aspx.cs"  validateRequest="false" Inherits="InventionWeb.Front.BBS.FrontDesk.Login.DeliverCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script type="text/javascript" src="<%=ResolveUrl("~/editor2/ckeditor/ckeditor.js")%>"></script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>发布问题</title>
    <style type="text/css">
        body
        {
            padding: 0;
            margin: 0;
            font-size: 12px;
        }
         .header
        {   width:970px;
            color: #fff;
            background-color: #2e9dc8;
            padding: 10px 15px;
            font-size:16px;
        }
        .content
        {
            width: 1000px;
            height: 600px;
            text-align: center;
        }
        .content table
        {
            margin-top: 20px;
        }
        .left
        {
            width: 100px;
            text-align: center;
        }
        .right
        {
            width: 800px;
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="header">发布问题</div>     
    <div class="content">
        <table>
            <tr style="height:40px;">
                <td class="left">
                    问题标题
                </td>
                <td class="right">
                    <asp:TextBox ID="txtCardTitle" runat="server" Height="20px" Width="460px"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:40px;">
                <td class="left">
                    所属专题
                </td>
                <td class="right">
                    <asp:DropDownList ID="ddlModuleName" Font-Size="10pt" Height="25px" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="left" style="vertical-align: top;padding-top:30px;">
                    正文
                </td>
                <td class="right">
                    <asp:TextBox ID="txtCardContent" Style="width: 780px;height:400px;" CssClass="ckeditor" runat="server"
                        TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td class="right">
                    <asp:Button ID="btnDeliver" runat="server" Text="提问" OnClick="btnDeliver_Click" Font-Size="9pt" />
                    <asp:Button ID="btnCancel" runat="server" Text="返回" OnClick="btnCancel_Click" Font-Size="9pt" />
                </td>
            </tr>
        </table>
         <hr style="width: 1000px" />
    </div>
   
    </form>
</body>
</html>
