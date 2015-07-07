<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="remark.aspx.cs" Inherits="InventionWeb.Background.Remark.remark" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>备注</title>
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
    .connus, .about, .help
    {
        margin-left: 40px;
        margin-top: 10px;
        font-size: 9pt;
        width:80%;
    }
    .about p,.help p
        {
            text-indent: 24px;
            line-height: 24px;
            font-size:13px;
        }
</style>
</head>
<body style="background-color: #d6e4ef">
    <form id="form1" runat="server">
    <div class="connus">
    <br /><br />
        联系我们：
        <ul>
            <li>电话:<asp:Label ID="tel" runat="server" Text="Label"></asp:Label></li>
            <li>邮箱:<asp:Label ID="email" runat="server" Text="Label"></asp:Label></li>
            <li>地址:<asp:Label ID="address" runat="server" Text="Label"></asp:Label></li>
        </ul>
    </div><br />
    <div class="about">
        关于我们：<br />
        <div style="border:1px solid #fff">
           <p> <asp:Label ID="aboutus" runat="server" Text="Label"></asp:Label></p>
        </div>
    </div><br />
    <div class="help">
       学报简介：<br />
        <div style="border:1px solid #fff">
          <p>  <asp:Label ID="bbshelp" runat="server" Text="Label"></asp:Label></p>
        </div>
    </div>
    <div class="help">
       自然版简洁：<br />
        <div style="border:1px solid #fff">
          <p>  <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></p>
        </div>
    </div>
    <div class="help">
       社科版简介：<br />
        <div style="border:1px solid #fff">
          <p>  <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></p>
        </div>
    </div>
    </form>
</body>
</html>
