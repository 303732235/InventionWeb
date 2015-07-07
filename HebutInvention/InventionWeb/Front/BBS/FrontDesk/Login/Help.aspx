<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="InventionWeb.Front.BBS.FrontDesk.Login.Help" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>在线交流帮助</title>
    <style type="text/css">
        .content
        {
            width: 1000px;
        }
        .title
        {
            height: 30px;
            color: White;
            font-weight: bold;
            font-size: 20px;
            padding-left: 300px;
            padding-top: 10px;
            background-color: #2E9DC8;
            margin-top: 15px;
        }
        .neirong
        {
            padding: 10px;
            width: 980px;
        }
        .neirong p
        {
            text-indent: 24px;
            line-height: 24px;
            font-size: 12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="content">
        <div class="title">
            河北工业大学学报编辑部在线交流
        </div>
        <hr style="width: 1000px" />
        <div class="neirong">
            <p>
                <asp:Label ID="bbshelp" runat="server" Text="Label"></asp:Label>
               </p>
        </div>
        <hr style="width: 1000px" />
    </div>
    </form>
</body>
</html>
