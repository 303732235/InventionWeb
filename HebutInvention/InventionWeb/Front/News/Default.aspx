<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventionWeb.Front.News.Default" %>
<%@ Register Src="~/WebControl/head2.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>投稿指南</title>
    <link href="../../Styles/index2.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
      <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top1" runat="server" />
    <div class="second-mid">
         <table cellpadding="0" cellspacing="0"  >
            <tr>
                <td style="width: 16.7%;" valign="top" class="left-mid1">
                <table cellspacing="0" cellpadding="0"  border="0" style="width:150px;margin-top:0;padding-top:0;border-width:0">
                    <%--<tr style="height:10px">
                        <td style="padding-left: 20px;height:2px; background: url(/Front/BBS/new_index/images/menu_bt.jpg) no-repeat">
                            <a class="menuParent" target="mainFrame"style="font-size:14px;" href="NewsRight.aspx" >
                                投稿指南</a>
                        </td>
                    </tr>--%>
                
                    <tr style="height:inherit">
                        <td style="padding-left: 0px; ">
                                <h3 style="text-align:center;" ><img src="../../images/2.gif" align="absMiddle" />
             <a id="xa" target="mainFrame" style="font-size:14px;color:#FFFFFF;font-weight:bold;"href="NewsRight.aspx">
                                河北工业大学学报投稿指南</a></h3>
                        </td>
                    </tr>
                    
             
                 
                    <tr style="height:inherit">
                        <td style="padding-left: 0px;">
                          
                                <h3 style="text-align:center;" ><img src="../../images/2.gif" align="absMiddle" />
             <a id="xb" target="mainFrame" style="font-size:14px;color:#FFFFFF;font-weight:bold;"href="../Alliance/AllianceRight.aspx">
                                河北工业大学学报（社会科学版）<br>投稿指南</a></h3>
                        </td>
                    </tr>
                    
                </table>
               
                </td>
                <td class="right-mid">
                    <iframe id="mainFrame" name="mainFrame" marginwidth="0" marginheight="3" frameborder="0"
                        width="95%" src="NewsRight.aspx" scrolling="yes" height="440px" runat="server">
                    </iframe>
                </td>
            </tr>
            </table>
    </div>
<uc1:footer ID="top2" runat="server" />
    </form>
</body>
<script type="text/javascript">
    $(function () {
        var url = document.location.href;
        if (url.indexOf("=") > 0) {
            var id = url.substring(url.indexOf("=") + 1, url.length)
        }
       
        if (id == 2) document.getElementById("xb").click();
        else document.getElementById("xa").click();
        $("#menu ul>li:has(ul)").hover(
    function () {
        $(this).children('a').end().find('ul').fadeIn(400);
    },
    function () {
        $(this).children('a').end().find('ul').fadeOut(400);
    }
    );
    });
</script>
</html>