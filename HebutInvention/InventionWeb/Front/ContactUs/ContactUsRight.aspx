<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ContactUsRight.aspx.cs"
    Inherits="InventionWeb.Front.ContactUs.ContactUsRight" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>联系我们2</title>
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .neirong
        {
            padding: 0px 0;
            margin: 0px 0;
            font-size: 15px;
            text-indent: 48px;
            line-height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <br />
        <span class="ModuleName">联系我们</span>
        <hr  class="RightHR"/>
        <div class="neirong">
            <br />
            <br />
            <p>
                电话:<asp:Label ID="tel" runat="server" Text="Label"></asp:Label></p>
            <p>
                邮箱:<asp:Label ID="email" runat="server" Text="Label"></asp:Label></p>
            <p>
                地址:<asp:Label ID="address" runat="server" Text="Label"></asp:Label> </p>
        </div>
        <div style="clear: both;">
        </div>
        <br />
    </div>
    </form>
</body>
</html>
