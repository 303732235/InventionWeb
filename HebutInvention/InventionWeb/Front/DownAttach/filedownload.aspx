<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="filedownload.aspx.cs" Inherits="InventionWeb.Front.DownAttach.filedownload" %>

<%@ Import Namespace="System.Data" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>过刊查询</title>
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            margin-top: 5px;
            margin-left: 5px;
        }
        .dgTable
        {
            border-collapse: collapse;
            border-top: 2px solid #8db1d5;
            width: 100%;
            border-left: 1px solid #d6dee9;
            border-right: 1px solid #d6dee9;
            border-bottom: 2px solid #8db1d5;
        }
    </style>
</head>
<body>
     
    <form   id="form1" runat="server">
    <div>
        <br />
        <span class="ModuleName">下载中心</span>
        <span style="float:right;">
        年份区间：
        <asp:TextBox ID="TextBox1" runat="server" size="4"></asp:TextBox>
        -
        <asp:TextBox ID="TextBox2" runat="server" size="4"></asp:TextBox>
        关键字：
        <asp:TextBox ID="searchtext" runat="server"></asp:TextBox>
        <asp:Button ID="Save" runat="server" Text="搜索" OnClick="Add_Click" />
        </span>
        <br />
        <div style="clear: both;">
        </div>
        <hr class="RightHR" />
        <div id="searchNone" runat="server" style="display:none;text-align:center;width:100%;margin-top:100px;">
             找到 0 条结果 
        </div>
        <div class="style1">
            <asp:RadioButtonList ID="sort2" runat="server" AutoPostBack="true" RepeatColumns="3"
                OnSelectedIndexChanged="sort2_SelectedIndexChanged">
                <%--<asp:ListItem>自然版过刊</asp:ListItem>
                <asp:ListItem>社科版过刊</asp:ListItem>--%>
              <%--  <asp:ListItem>TRIZ书籍</asp:ListItem>--%>
            </asp:RadioButtonList>
            <asp:GridView ID="GridViewArticle" runat="server" AutoGenerateColumns="False" Width="95%"
                AllowPaging="True" CssClass="dgTable" AllowSorting="True" OnRowCommand="GridViewArticle_onRowCommand"
                OnRowCreated="GridViewArticle_RowCreated" OnPageIndexChanging="GridViewArticle_PageIndexChanging"
                PageSize="5" OnRowDataBound="GridViewArticle_RowDataBound">
                <Columns>
                    <asp:BoundField HeaderText="编号">
                        <HeaderStyle ForeColor="Black" Font-Bold="False" BackColor="#84c1ff" Height="25px" width="5%" />
                    </asp:BoundField>
                    <asp:BoundField DataField="fileid" HeaderText="文献编号" >
                   
                        <HeaderStyle ForeColor="Black" Font-Bold="False" BackColor="#84c1ff"  />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="文献名称">
                        <ItemTemplate>
                            <asp:Label ID="Label1" runat="server" Text='<%#CutString(Eval("title").ToString())%>'></asp:Label>&nbsp;
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black" Font-Bold="False" BackColor="#84c1ff"  />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="writer" HeaderText="文献作者">
                        <HeaderStyle ForeColor="Black" Font-Bold="False" BackColor="#84c1ff" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    
                    <asp:TemplateField HeaderText="文献下载">
                        <ItemTemplate>
                            <asp:Button ID="downloadbtn" runat="server" Text="下载" CommandName="download" 
                                CommandArgument='<%# DataBinder.Eval(Container.DataItem, "filesavename") %> ' />
                        </ItemTemplate>
                        <HeaderStyle ForeColor="Black" Font-Bold="False" BackColor="#84c1ff" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField  DataField="count"  HeaderText="下载次数">
                        <HeaderStyle ForeColor="Black" Font-Bold="False" BackColor="#84c1ff" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
                <PagerSettings FirstPageText="第一页" LastPageText="最后一页" NextPageText="下一页" PreviousPageText="上一页"
                    Mode="NextPreviousFirstLast" />
                <PagerStyle HorizontalAlign="right" />
            </asp:GridView>
        </div>
    </div> 
   
   <%-- <asp:HiddenField ID="HiddenField1" runat="server"  value = "1.1" />--%>
    <%--<asp:TextBox  name="canshu" Runat="server" value = "1.1"></asp:TextBox>--%>
    </form>
    
   
    
        <a id="hiddenDown" href="_blank" target="_blank"></a>
    <script type="text/javascript">
//        window.onload=function(){
//            //alert("a");
//            var url = window.location.href;
//            if (url.indexOf("type") != -1) {
//                var mm = url.substring(url.indexOf("?type=") + ("?type=").length);
//                alert(mm);
//                docuent.getElementById('HiddenField1').value = mm;
//               // document.getElementById("HiddenField11").value =mm;
//            
//            }

//        }
       
        

        function download(href) {
           // var a = document.getElementById("hiddenDown");
            //a.href = href;
            //a.click();
            window.open(href);   
        }
        if (window.down) {
            download(window.down);window.down = null;
        }

       

       
       // getbtn(mm);
    
       
    </script>
    <%--<script type="text/javascript">
     $(document).ready(function () {

            var url = window.location.href;
            if (url.indexOf("type") != -1) {
                var mm = url.substring(url.indexOf("?type=") + ("?type=").length);
                alert(mm);
                docuent.getElementById("HiddenField1").value = mm;
            }

        });
        </script>--%>
       
</body>
</html>
