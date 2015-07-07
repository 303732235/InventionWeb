<%@ Page Language="C#" AutoEventWireup="true" validateRequest="false" CodeBehind="connus.aspx.cs" Inherits="InventionWeb.Background.Remark.connus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>联系我们</title>
     <script type="text/javascript" src="<%=ResolveUrl("~/editor/ckeditor/ckeditor.js")%>"></script>
    <style type="text/css">
        ul
        {
            list-style-type: none;
            border: 1px solid #fff;
            padding-left: 2px;
        }
        ul li
        {
            height: 30px;
        }
        .connus, .about,.help,.sub
        {
            margin-left: 40px;
            margin-top: 10px;
            font-size: 9pt;
        }
    </style>
</head>
<body style="background-color: #d6e4ef">

    <form id="form1" runat="server">
    <div class="connus">
        联系我们：
        <ul>
            <li>电话:<asp:TextBox ID="tel" Width="250px" runat="server"></asp:TextBox></li>
            <li>邮箱:<asp:TextBox ID="email" Width="250px" runat="server"></asp:TextBox></li>
            <li>地址:<asp:TextBox ID="address" Width="250px" runat="server"></asp:TextBox></li>
        </ul>
    </div>
    <div class="about">
        关于我们：<br />
        <div style="border: 1px solid #fff;">
         <asp:TextBox ID="aboutus" runat="server"  TextMode="MultiLine"></asp:TextBox>
         </div>
    </div>
    <div class="help">
        学报简介：<br />
        <div style="border: 1px solid #fff;">
         <asp:TextBox ID="bbshelp" runat="server"  TextMode="MultiLine"></asp:TextBox>
                        
               

         </div>
    </div>
    <div class="help">
        自然版简介：<br />
        <div style="border: 1px solid #fff;">
         <asp:TextBox ID="TextBox1" runat="server"  TextMode="MultiLine"></asp:TextBox>
            

         </div>
    </div>
    <div class="help">
        社科版简介：<br />
        <div style="border: 1px solid #fff;">
         <asp:TextBox ID="TextBox2" runat="server"  TextMode="MultiLine"></asp:TextBox>
                        
 <script type="text/javascript">
     CKEDITOR.replace('bbshelp', { height: 150 });
     CKEDITOR.replace('aboutus', { height: 150 });
     CKEDITOR.replace('TextBox1', { height: 150 });
     CKEDITOR.replace('TextBox2', { height: 150 });
                </script>
         </div>
    </div>
    <div class="sub">
        <asp:Button ID="submit" runat="server" Text="提交" onclick="submit_Click"/>
    </div>
    </form>
</body>
</html>
