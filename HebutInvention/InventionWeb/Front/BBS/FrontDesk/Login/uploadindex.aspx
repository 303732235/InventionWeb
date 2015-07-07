<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="uploadindex.aspx.cs" Inherits="InventionWeb.Front.BBS.FrontDesk.Login.uploadindex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BBS共享资料</title>
    <script type="text/javascript">
        function timemgr() {
            var t = setTimeout("parent.location.href='/Front/BBS/new_index/index2.aspx?comefrom=Uploadindex';", 2000);
        }
    </script>
    <style type="text/css">
        body
        {
           font-size:12px; 
           }
        .title
        {
            font-size: 12pt;
            color: #fff;
            background-color: #2e9dc8;
            height: 30px;
            padding-top:10px;
            padding-left:10px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 1000px;">
        <div class="title">
            共享资料
        </div>
        <div style="margin-top: 20px;">
            <asp:GridView ID="uploadifo" runat="server" AutoGenerateColumns="False" Width="1000px"
                CellPadding="3" GridLines="Horizontal" BorderColor="#E7E7FF" BorderStyle="None"
                HorizontalAlign="Center" Font-Size="9pt" BackColor="White" BorderWidth="1px"
                AllowPaging="True" CssClass="dgTable" AllowSorting="True" OnRowCommand="GridViewArticle_onRowCommand"
                OnRowCreated="GridViewArticle_RowCreated" OnPageIndexChanging="GridViewArticle_PageIndexChanging"
                PageSize="10" OnRowDataBound="GridViewArticle_RowDataBound">
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" Height="30px" />
                <Columns>
                    <asp:BoundField HeaderText="编号">
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="id" HeaderText="文献编号" SortExpression="id" Visible="False">
                        <HeaderStyle ForeColor="Black" BackColor="#84c1ff" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="文献名称">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#CutString(Eval("title").ToString())%>'></asp:Label>&nbsp;
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="writer" HeaderText="文献作者">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="addDate" DataFormatString="{0:yyyy-MM-dd hh:mm}" HeaderText="发表时间">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="文献下载">
                        <ItemTemplate>
                            <asp:Button ID="downloadbtn" runat="server" Text="下载" OnClientClick="timemgr();return confirm('注：游客不能下载；会员扣10分，确定要下载吗？');"
                                CommandName="download" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "filesavename") %> ' />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页"
                    Mode="NextPreviousFirstLast" />
                <HeaderStyle BackColor="#a3cfea" Font-Bold="True" Height="30px" ForeColor="#555555" />
                <FooterStyle BackColor="#a3cfea" Font-Bold="True" Height="30px" ForeColor="#555555" />
                <AlternatingRowStyle BackColor="#F7F7F7" />
            </asp:GridView>
            <div style="background-color: #a3cfea; height: 25px;">
                <asp:Button ID="up" runat="server" Text="上传" OnClick="up_Click" />
            </div>
        </div>
        <div>
            <asp:Panel ID="uppanel" Style="display: none; margin-top: 15px;" runat="server" Height="75px">
                <table>
                    <tr height="25px">
                        <td>
                            资料名称：
                        </td>
                        <td>
                            <asp:TextBox ID="TxtTitle" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr height="25px">
                        <td>
                            选择文件：
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" /> <span style="color:Red;">*限制大小为4M</span>
                        </td>
                    </tr>
                    <tr height="25px">
                        <td>
                            
                        </td>
                        <td>
                        <asp:Button ID="uploadbtn" runat="server" Text="上传" OnClick="uploadbtn_Click" />
                            <asp:Button ID="Cancel" runat="server" Text="取消" onclick="Cancel_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
    </form>
</body>
</html>
