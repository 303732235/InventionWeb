<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminIndex.aspx.cs" Inherits="InventionWeb.Background.AdminIndex" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>河北工业大学学报编辑部后台管理</title>
</head>
<frameset rows="98,*,8" frameborder="no" border="0" framespacing="0">
  <frame src="adminTop.aspx" name="topFrame" scrolling="No" noresize="noresize" id="topFrame" />
  <frame src="adminmidContent.aspx" name="mainFrame" scrolling="yes" id="mainFrame" />
  <frame src="adminDown.aspx" name="bottomFrame" scrolling="No" noresize="noresize" id="bottomFrame" />
</frameset>
<noframes>
    <body>
    </body>
</noframes>
</html>
