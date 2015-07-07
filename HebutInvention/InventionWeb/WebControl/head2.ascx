<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="head2.ascx.cs" Inherits="InventionWeb.WebControl.head2" %>
<link href="../Styles/index2.css" rel="stylesheet" type="text/css" />
<div class="juzhong">
    <div style="display:none">
        <table>
            <tr>
                <td width="530px" align='left'>
                    <%=userloginifo %>
                </td>
                <td width="430px" align="right">
                    您是第<asp:Label ID="tongji" runat="server" Text=""></asp:Label>位访问者
                </td>
            </tr>
        </table>
    </div>
</div>
<div id="header">
    <img alt="" id="Img1" src="<%=ResolveUrl("../images/index2/logo1.gif")%>" />
   
    <!--<div class="clear"></div><-->
   <div id="menu">
            <ul>
                <li class="nav-item"><a href="/Front/index.aspx" target="_parent">首页</a></li>
                <li class="nav-item"><a href="/Front/abstractus/default.aspx" target="_parent">学报简介</a>
                <ul style="display: none;"> 
										<li><a href="/Front/abstractus/default.aspx?id=1">编辑部简介</a></li> 
										<li><a  href="/Front/abstractus/default.aspx?id=2">学报简介</a></li> 
										<li><a href="/Front/abstractus/default.aspx?id=3">社会科学版简介</a></li> 
										</ul> 
                
                </li>

                <li class="nav-item"><a href="/Front/Notice/default.aspx" target="_parent">通知公告</a>
                 <ul style="display: none;"> 
										<li><a href="/Front/Notice/default.aspx?id=1">综合通知公告</a></li> 
										<li><a href="/Front/Notice/default.aspx?id=2">学报通知公告</a></li> 
										<li><a href="/Front/Notice/default.aspx?id=3">社会科学版通知公告</a></li> 
										</ul> </li>
                <li class="nav-item"><a href="/Front/DownAttach/default.aspx?id=1" target="_parent">过刊查询</a>
                <ul style="display: none;"> 
										<li><a href="/Front/DownAttach/default.aspx?id=1">学报过刊</a></li> 
										<li><a href="/Front/DownAttach/default.aspx?id=2">社会科学版过刊</a></li> 
										 </ul> 
                
                </li>
                <li class="nav-item"><a href="/Front/News/default.aspx" target="_parent">投稿指南</a>
                
                 <ul style="display: none;"> 
										<li><a href="/Front/News/default.aspx?id=1">学报投稿指南</a></li> 
										<li><a href="/Front/News/default.aspx?id=2">社会科学版投稿指南</a></li> 
										
										</ul> 
                </li>
                <li class="nav-item"><a href="/Front/ContactUs/default.aspx" target="_parent">联系我们</a></li>
                
                
            </ul>
        </div>
    <!--导航-->
</div>
<!--/header-->







