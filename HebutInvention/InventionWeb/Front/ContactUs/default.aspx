<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="InventionWeb.Front.ContactUs._default" %>
<%@ Register Src="~/WebControl/head2.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>联系我们</title>
    <link href="../../Styles/index2.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
      <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top1" runat="server" />
    <div class="second-mid">
         <table  cellpadding="0" cellspacing="0">
            <tr>
               
                <td class="right-mid">
                    <iframe id="mainFrame" name="mainFrame" marginwidth="0" marginheight="3" frameborder="0"
                        width="95%" src="ContactUsRight.aspx" scrolling="yes" height="440px">
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
