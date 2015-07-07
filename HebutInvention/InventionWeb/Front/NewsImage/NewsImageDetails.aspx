<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsImageDetails.aspx.cs"
    Inherits="InventionWeb.Front.NewsImage.NewsImageDetails" %>

<%@ Register Src="~/WebControl/head2.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>图片新闻</title>
    <link href="../../Styles/index2.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/fron-third.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function size() {
            if (document.images["img1"].width >= 700) {
                document.images["img1"].width = 700;
            }
        }
    </script>
</head>
<body onload="size()">
    <form id="form1" runat="server">
    <uc1:top ID="top1" runat="server" />
    <div class="content">
        <br />
        <span class="title">当前位置：<a href="default.aspx" target="_self">图片新闻</a>>正文</span>
        <br />
        <br />
        <asp:ListView ID="ListView1" runat="server">
            <ItemTemplate>
                <table>
                    <tr>
                        <td align="center" class="title">
                            <%#Eval("title")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <hr class="RightHR" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            发表时间：
                            <%#Eval("addDate","{0:yyyy-MM-dd}")%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div align="center">
                                <img name="img1" src='<%#"~/NewsImages/"+ DataBinder.Eval(Container.DataItem, "url")%>'
                                    alt="" runat="server" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="neirong">
                                <p>
                                    <%#Eval("content")%>
                                </p>
                            </div>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <uc1:footer ID="top2" runat="server" />
    </form>
</body>
</html>
