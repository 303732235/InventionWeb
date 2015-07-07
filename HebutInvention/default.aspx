<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="InventionWeb.Front.AboutUs._default" %>

<%@ Register Src="~/WebControl/head2.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>学报简介</title>
    <link href="../../Styles/index2.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
     <link href="../../Front/BBS/new_index/css/admin.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top1" runat="server" />
    <div class="second-mid">
        <table cellpadding="0" cellspacing="0">
            <tr>
                <td style="width: 15%;background-color:#0066FF" valign="top">
                <table cellspacing="0" cellpadding="0"  border="0" style="width:150px;margin-top:0;padding-top:0;border-width:0">
                    <tr style="height:10px">
                        <td style="padding-left: 20px;height:2px; background: url(/Front/BBS/new_index/images/menu_bt.jpg) no-repeat">
                            <a class="menuParent" target="mainFrame"style="font-size:14px;" href="AboutUsRight.aspx" >
                                学报简介</a>
                        </td>
                    </tr>
                
                    <tr style="height:inherit">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent" target="mainFrame" style="font-size:14px;" href="HTMLPage1.htm">
                               自然版简介</a>
                        </td>
                    </tr>
                    
             
                 
                    <tr style="height:inherit">
                        <td style="padding-left: 20px; background: url(/Front/BBS/new_index/images/menu_bt.jpg)">
                            <a class="menuParent"  target="mainFrame" style="font-size:14px;" href="HTMLPage2.htm">
                                社科版简介</a>
                        </td>
                    </tr>
                    
                </table>
               
                </td>
                <td class="right-mid">
                    <iframe id="mainFrame" name="mainFrame" marginwidth="0" marginheight="3" frameborder="0"
                        width="95%" src="AboutUsRight.aspx" scrolling="yes" height="440px"></iframe>
                </td>
            </tr>
        </table>
    </div>
    <uc1:footer ID="top2" runat="server" />
    </form>
</body>
</html>
