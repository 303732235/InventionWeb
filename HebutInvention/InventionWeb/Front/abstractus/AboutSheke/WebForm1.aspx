<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="InventionWeb.Front.abstractus.AboutSheke.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>关于我们</title>
     <link href="../../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .neirong
        {
            padding: 0px 0;
            margin: 0px 0;
            font-size:14px;
            text-indent: 24px;
            line-height: 24px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <br /><br />
    <span class="ModuleName">河北工业大学学报（社科版）简介</span>
     <hr class="RightHR"/>
    <div class="neirong">
    <p>
        <asp:Label ID="about" runat="server" Text="Label"></asp:Label></p>
    </div>
        <div style="clear: both;"></div>
  <br/>
    </div>
    </form>
</body>
</html>
