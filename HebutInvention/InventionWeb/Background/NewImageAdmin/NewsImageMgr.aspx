﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsImageMgr.aspx.cs" Inherits="InventionWeb.Background.NewImageAdmin.NewsImageMgr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>图片新闻管理</title>
    <link href="../../Styles/backmokuai.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function SelectAll(tempControl, tempSpan) {
            //将除头模板中的其它所有的CheckBox取反 
            var theBox = tempControl;
            var xState = theBox.checked;
            var strTemp = tempSpan;
            elem = theBox.form.elements;
            for (i = 0; i < elem.length; i++) {
                if (elem[i].type == "checkbox" && elem[i].id != theBox.id) {
                    if (elem[i].checked != xState) {
                        elem[i].click();
                    }
                }
            }
        } 
    </script>
</head>
<body style="background-color:#d6e4ef">
    <form id="form1" runat="server">
    <asp:DataList ID="DataList1" runat="server"  CellPadding="0" CellSpacing="0"  
        OnDeleteCommand="DataList1_DeleteCommand" 
        onselectedindexchanged="DataList1_SelectedIndexChanged">
        <HeaderTemplate>
            <table  cellpadding="0" cellspacing="0" width="950px" class="tabtitle">
                <tr>
                    <td width="60">
                        选择框
                    </td>
                    <td width="100">
                        id
                    </td>
                    <td width="250">
                        名称
                    </td>
                    <td width="140">
                        图片
                    </td>
                    <td width="200">
                        发布时间
                    </td>
                    <td width="100">
                        
                    </td>
                </tr>
            </table>
        </HeaderTemplate>
        <ItemTemplate>
            <table cellspacing="0" cellpadding="0" width="950px" class="tabcenter">
                <tr>
                    <td width="60" class="tabtd">
                        <asp:CheckBox ID="selected" runat="server" />
                    </td>
                    <td width="100" class="tabtd">
                        <asp:HyperLink ID="Hyperlink3" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "id") %>' />
                    </td>
                    <td width="250" class="tabtd">
                        <font style="cursor: hand" title='<%#Eval("title")%>'>
                            <%#CutString(Eval("title").ToString())%></font>
                    </td>
                    <td width="140" class="tabtd">
                        <asp:Image ID="CommodityImage" runat="server" Width="140px" Height="100px" ImageUrl='<%#"~/IndexImages/"+ DataBinder.Eval(Container.DataItem, "url")%>' />
                        <asp:Image ID="basicImage" runat="server"  Width="1" Height="1" ImageUrl='<%#"~/NewsImages/"+ DataBinder.Eval(Container.DataItem, "url")%>' Visible="False" />
                    </td>
                    <td width="200" class="tabtd">
                     [<%#Eval("addDate","{0:yyyy-MM-dd}")%>]
                    </td>
                    <td width="100" class="tabtd">
                       <a href='NewsImageEdit.aspx?id=<%# Eval("id")%>'>修改</a>
                     <asp:LinkButton ID="del" CommandName="Delete" OnClientClick="return confirm('确定要删除？')"
                            CommandArgument='<%# DataBinder.Eval(Container.DataItem,"id")%>' runat="server">删除</asp:LinkButton> 
                    </td>
                     </tr>
            </table>
        </ItemTemplate>
        <FooterTemplate>
        </FooterTemplate>
    </asp:DataList>
    <table cellspacing="0" cellpadding="0" width="950px" class="tabtitle">
        <tr>
            <td width="100px">
                <asp:CheckBox ID="chkHeader" onclick="javascript:SelectAll(this,'DataList1');" runat="server"
                    AutoPostBack="False"></asp:CheckBox>全选&nbsp;<asp:Button ID="Delete" runat="server" Text="删除" OnClientClick="return confirm('确定要删除？')" OnClick="Delete_Click" />
            </td>
            <td width="850px" align="right">
                <asp:Label ID="Label7" runat="server" Text="当前页码为："></asp:Label>[
                <asp:Label ID="labPage" runat="server" Text="1"></asp:Label>
                ]
                <asp:Label ID="Label6" runat="server" Text="总页码为："></asp:Label>
                <asp:Label ID="labBackPage" runat="server"></asp:Label>
                &nbsp;<asp:LinkButton ID="lnkbtnOne" runat="server" Font-Underline="False" OnClick="lnkbtnOne_Click">第一页</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkbtnUp" runat="server" Font-Underline="False" OnClick="lnkbtnUp_Click">上一页</asp:LinkButton>
                &nbsp;
                <asp:LinkButton ID="lnkbtnNext" runat="server" Font-Underline="False" OnClick="lnkbtnNext_Click">下一页</asp:LinkButton>&nbsp;
                <asp:LinkButton ID="lnkbtnBack" runat="server" Font-Underline="False" OnClick="lnkbtnBack_Click">最后一页</asp:LinkButton>&nbsp;&nbsp;
            </td>
        </tr>
    </table>
</form>
</body>
</html>
