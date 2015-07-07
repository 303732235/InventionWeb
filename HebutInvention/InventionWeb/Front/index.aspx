
<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="index.aspx.cs"
    Inherits="InventionWeb.Front.index2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset=gb2312" />
    <meta name="renderer" content="webkit"/>
    <title>河北工业大学学报编辑部</title>
    <link href="/Styles/index2.css" rel="stylesheet" type="text/css" />
 
    <script src="../Scripts/index.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.js"></script>
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
   <script type="text/javascript" language="javascript">
     
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

</head>
<body>
<div style="display:none">
    
                        <%=userloginifo %>
                    
                   <asp:Label ID="tongji" runat="server" Text=""></asp:Label>
                   </div>
    <form id="form1" runat="server">
    <div id="header">
        <img alt="" id="logo" src="../images/index2/logo1.gif" />

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
    <div id="content">
        <div id="left">
            <div class="left-block1">
                <h3>
                    通知通告 <span style="display: block; _margin-top: -25px; *margin-top: -25px; position: relative;
                        float: right"><a href="/Front/Notice/default.aspx" class="rf" target="_blank">
                            <img src="../images/index2/more.gif" style="border: none;" /></a></span>
                </h3>
                <ul>
                    <asp:DataList ID="DatalistNotice" runat="server" Width="250px">
                        <ItemTemplate>
                            <li><a href='/Front/Notice/NoticeDetails.aspx?id=<%#Eval("id")%>' title='<%#Eval("title")%>' target="_blank">
                                <%#CutString(Eval("title").ToString())%></a>&nbsp;&nbsp;&nbsp;<img id="Img1" src="../images/newpic/new4.gif"
                                    runat="server" visible='<%#display(Eval("addDate").ToString())%>' />
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
                </ul>
            </div>
           
            <div class="left-block">
                <h3>
                    友情连接 <span style="display: block; position: relative; _margin-top: -25px; *margin-top: -25px;
                        float: right;"><a href="/Front/Alliance/default.aspx" class="rf" target="_blank">
                            </a></span>
                </h3>
                 <ul>
                <li><a href="http://www.gapp.gov.cn/" target="_blank">
                    国家新闻出版广电总局</a>
                </li>
                <li><a href="http://www.hee.cn/" target="_blank">
                   河北省教育厅</a>
                </li>
                <li><a href="http://www.hbcbgd.gov.cn/" target="_blank">
                    河北省新闻出版广电局</a>
                </li>
                <li><a href="http://www.hebut.edu.cn/" target="_blank">
                   河北工业大学</a>
                </li>
                <li><a href="http://lib.hebut.edu.cn/" target="_blank">
                    河北工业大学图书馆</a>
                </li>
                <li><a href="http://www.cnki.net/" target="_blank">
                    中国知网</a>
                </li>
                 <li><a href="http://www.wanfangdata.com.cn/" target="_blank">
                    万方数据知识服务平台</a>
                </li>
            </ul>
            </div>
             <div class="left-block2">
                <h3>
                    联系我们 <span style="display: block; position: relative; _margin-top: -25px; *margin-top: -25px;
                        float: right"><a href="ContactUs/default.aspx" class="rf" target="_blank">
                         <img alt="" src="../images/index2/more.gif" style="border: none" />
                           </a></span>
                            
                          <p style="font-weight:normal;">
                电话:<asp:Label ID="tel" runat="server" Text="Label"></asp:Label></p>
            <p style="font-weight:normal;">
                邮箱:<asp:Label ID="email" runat="server" Text="Label"></asp:Label></p>
            <p style="font-weight:normal;">
                地址:<asp:Label ID="address" runat="server" Text="Label"></asp:Label> </p>
                </h3>
                <ul>
                   
                </ul>
            </div>
        </div>
        <!--左部分结束-->
        <div id="right">
            <div class="con">
                <div class="pic-news">
                    <h3>简介</h3>
                    <ul>
                        <script type="text/javascript">
				         var focus_width = 320;
				         var focus_height = 320;
				         var text_height = 20;
				         var swf_height = focus_height + text_height;
                         var pics = "<%=showMsgUrl%>";
                         var links='<%=showMsgId %>'
                         var texts=' '
				         document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
				         document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="../images/index2/slide.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
				         document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
				         document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
				         document.write('<embed src="../images/index2/slide.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '" menu="false" bgcolor="#FFFFFF" quality="high" width="' + focus_width + '" height="' + swf_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');
				         document.write('</object>');
                         
                        </script>
                    </ul>
                    <div style="text-align:center">
                        自然科学版
                    </div>
                </div>
                <div class="right-block">
                    <h3>
                        <a href="/Front/abstractus/default.aspx" class="rf" target="_blank">
                            <img alt="" src="../images/index2/more.gif" style="border: none" /></a>
                    </h3>
                    <ul>
                      <script type="text/javascript">
                  
				     var focus_width = 320;
				     var focus_height =320;
				     var text_height = 20;
				     var swf_height = focus_height + text_height;
                     var pics = "<%=showMsgUrl1%>";
			     
                     var links='<%=showMsgId1%>'
				    
                     var texts=' '

				     document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="' + focus_width + '" height="' + swf_height + '">');
				     document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="../images/index2/slide.swf"><param name="quality" value="high"><param name="bgcolor" value="#ffffff">');
				     document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
				     document.write('<param name="FlashVars" value="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '">');
				     document.write('<embed src="../images/index2/slide.swf" wmode="opaque" FlashVars="pics=' + pics + '&links=' + links + '&texts=' + texts + '&borderwidth=' + focus_width + '&borderheight=' + focus_height + '&textheight=' + text_height + '" menu="false" bgcolor="#FFFFFF" quality="high" width="' + focus_width + '" height="' + swf_height + '" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');
				     document.write('</object>');
                      
                    </script>  
                    </ul>
                    <div style="text-align:center">
                        自然科学版
                    </div>
                </div>
            </div>
            
                <asp:DataList ID="DatalistNewsImages" runat="server" RepeatDirection="Horizontal">
                    
                   
                </asp:DataList>
           
            <div style="margin-top:10px" class="con2 ">
                <div class="right-block2">
                    <h3>
                        河北工业大学学报 <span style="display: block; _margin-top: -25px; *margin-top: -25px; position: relative;
                            z-index: 9; float: right"><a href="/Front/DownAttach/default.aspx?type=1"class="rf" target="_blank">
                                <img alt="" src="../images/index2/more.gif" style="border: none" /></a></span>
                    </h3>
                    <ul>
                    <asp:DataList ID="Datalist1" runat="server" Width="340px">
                        <ItemTemplate>
                            <li><a href='/Front/DownAttach/default.aspx?id=a<%#Eval("id")%>'>
                                <%#CutString1(Eval("title").ToString())%></a><span style="float:right"> <%#CutString(Eval("adddate").ToString())%>年第<%#CutString(Eval("type").ToString().Substring(2))%>期</span>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
                    </ul>
                   
                </div>
                <div class="right-block2 rf" style="border-right: 0px;">
                    <h3>
                        河北工业大学学报（社会科学版） <span style="display: block; _margin-top: -25px; *margin-top: -25px; position: relative;
                            float: right"><a href="/Front/DownAttach/default.aspx?type=2" class="rf" target="_blank">
                                <img alt="" src="../images/index2/more.gif" style="border: none" /></a></span>
                    </h3>
                   <ul>
                    <asp:DataList ID="Datalist2" runat="server" Width="340px">
                        <ItemTemplate>
                            <li><a href='/Front/DownAttach/default.aspx?id=a<%#Eval("id")%>'>
                                <%#CutString1(Eval("title").ToString())%> </a><span style="float:right"> <%#CutString(Eval("adddate").ToString())%>年第<%#CutString(Eval("type").ToString().Substring(2))%>期</span>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
                    </ul>
                </div>
            </div>
           
            <asp:DataList ID="DatalistExamplepic" runat="server" RepeatDirection="Horizontal">
           
            </asp:DataList>
             <asp:DataList ID="DatalistNews" runat="server" Width="248px">
                        
                    </asp:DataList>
                    
                        <asp:DataList ID="DatalistPoliy" runat="server" Width="340px">
                           
                        </asp:DataList>
                        
                        <asp:DataList ID="DatalistConn" runat="server" Width="340px">
                           
                        </asp:DataList>
                        <asp:DataList ID="DatalistAlliance" runat="server" Width="250px">
                    </asp:DataList>
                    <asp:DataList ID="DatalistWorkdt" runat="server" Width="320px">
                           
                        </asp:DataList>
                

                   
            
        </div>
        <!--右边部分结束-->
      
    </div>
    <div class="clear">
    </div>
    <div id="footer_up">
        <table>
            <tr>
                <td style="width: 960px;" align="center">
                    <a style="cursor: pointer;" onclick="SetHome(this,location.href)">设为首页</a>| <a href="ContactUs/default.aspx" target="_blank">
                        联系我们</a>|<a style="cursor: pointer;" onclick="AddFavorite(location.href,'河北工业大学学报编辑部')">
                            加入收藏</a> |<a href="../Background/Login.aspx" target="_blank">后台管理</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    <div class="footerWRAP">
        <div id="footer">
            <br />
           河北工业大学学报编辑部版权所有 Copyright@ 2014-2016 ALL Rights Reserved<br>
            <br />
          业务咨询：河北工业大学学报编辑部 技术支持：河北工业大学计算机科学与软件学院214<br>
            <br />
        </div>
        <!--/footer-->
    </div>
    </form>
</body>
</html>
