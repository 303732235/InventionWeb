
<%@ Page Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="index.aspx.cs"
    Inherits="InventionWeb.Front.index2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset=gb2312" />
    <meta name="renderer" content="webkit"/>
    <title>�ӱ���ҵ��ѧѧ���༭��</title>
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
                <li class="nav-item"><a href="/Front/index.aspx" target="_parent">��ҳ</a></li>
                <li class="nav-item"><a href="/Front/abstractus/default.aspx" target="_parent">ѧ�����</a>
                <ul style="display: none;"> 
										<li><a href="/Front/abstractus/default.aspx?id=1">�༭�����</a></li> 
										<li><a  href="/Front/abstractus/default.aspx?id=2">ѧ�����</a></li> 
										<li><a href="/Front/abstractus/default.aspx?id=3">����ѧ����</a></li> 
										</ul> 
                
                </li>

                <li class="nav-item"><a href="/Front/Notice/default.aspx" target="_parent">֪ͨ����</a>
                 <ul style="display: none;"> 
										<li><a href="/Front/Notice/default.aspx?id=1">�ۺ�֪ͨ����</a></li> 
										<li><a href="/Front/Notice/default.aspx?id=2">ѧ��֪ͨ����</a></li> 
										<li><a href="/Front/Notice/default.aspx?id=3">����ѧ��֪ͨ����</a></li> 
										</ul> </li>
                <li class="nav-item"><a href="/Front/DownAttach/default.aspx?id=1" target="_parent">������ѯ</a>
                  <ul style="display: none;"> 
										<li><a href="/Front/DownAttach/default.aspx?id=1">ѧ������</a></li> 
										<li><a href="/Front/DownAttach/default.aspx?id=2">����ѧ�����</a></li> 
										 </ul> 
                </li>

                <li class="nav-item"><a href="/Front/News/default.aspx" target="_parent">Ͷ��ָ��</a>
                
                 <ul style="display: none;"> 
										<li><a href="/Front/News/default.aspx?id=1">ѧ��Ͷ��ָ��</a></li> 
										<li><a href="/Front/News/default.aspx?id=2">����ѧ��Ͷ��ָ��</a></li> 
										
										</ul> 
                </li>
                <li class="nav-item"><a href="/Front/ContactUs/default.aspx" target="_parent">��ϵ����</a></li>
                
                
            </ul>
        </div>
        <!--����-->
    </div>
    <!--/header-->
    <div id="content">
        <div id="left">
            <div class="left-block1">
                <h3>
                    ֪ͨͨ�� <span style="display: block; _margin-top: -25px; *margin-top: -25px; position: relative;
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
                    �������� <span style="display: block; position: relative; _margin-top: -25px; *margin-top: -25px;
                        float: right;"><a href="/Front/Alliance/default.aspx" class="rf" target="_blank">
                            </a></span>
                </h3>
                 <ul>
                <li><a href="http://www.gapp.gov.cn/" target="_blank">
                    �������ų������ܾ�</a>
                </li>
                <li><a href="http://www.hee.cn/" target="_blank">
                   �ӱ�ʡ������</a>
                </li>
                <li><a href="http://www.hbcbgd.gov.cn/" target="_blank">
                    �ӱ�ʡ���ų������</a>
                </li>
                <li><a href="http://www.hebut.edu.cn/" target="_blank">
                   �ӱ���ҵ��ѧ</a>
                </li>
                <li><a href="http://lib.hebut.edu.cn/" target="_blank">
                    �ӱ���ҵ��ѧͼ���</a>
                </li>
                <li><a href="http://www.cnki.net/" target="_blank">
                    �й�֪��</a>
                </li>
                 <li><a href="http://www.wanfangdata.com.cn/" target="_blank">
                    ������֪ʶ����ƽ̨</a>
                </li>
            </ul>
            </div>
             <div class="left-block2">
                <h3>
                    ��ϵ���� <span style="display: block; position: relative; _margin-top: -25px; *margin-top: -25px;
                        float: right"><a href="ContactUs/default.aspx" class="rf" target="_blank">
                         <img alt="" src="../images/index2/more.gif" style="border: none" />
                           </a></span>
                            
                          <p style="font-weight:normal;">
                �绰:<asp:Label ID="tel" runat="server" Text="Label"></asp:Label></p>
            <p style="font-weight:normal;">
                ����:<asp:Label ID="email" runat="server" Text="Label"></asp:Label></p>
            <p style="font-weight:normal;">
                ��ַ:<asp:Label ID="address" runat="server" Text="Label"></asp:Label> </p>
                </h3>
                <ul>
                   
                </ul>
            </div>
        </div>
        <!--�󲿷ֽ���-->
        <div id="right">
            <div class="con">
                <div class="pic-news">
                    <h3>���</h3>
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
                        ��Ȼ��ѧ��
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
                        ��Ȼ��ѧ��
                    </div>
                </div>
            </div>
            
                <asp:DataList ID="DatalistNewsImages" runat="server" RepeatDirection="Horizontal">
                    
                   
                </asp:DataList>
           
            <div style="margin-top:10px" class="con2 ">
                <div class="right-block2">
                    <h3>
                        �ӱ���ҵ��ѧѧ�� <span style="display: block; _margin-top: -25px; *margin-top: -25px; position: relative;
                            z-index: 9; float: right"><a href="/Front/DownAttach/default.aspx?type=1"class="rf" target="_blank">
                                <img alt="" src="../images/index2/more.gif" style="border: none" /></a></span>
                    </h3>
                    <ul>
                    <asp:DataList ID="Datalist1" runat="server" Width="340px">
                        <ItemTemplate>
                            <li><a href='/Front/DownAttach/default.aspx?id=a<%#Eval("id")%>'>
                                <%#CutString1(Eval("title").ToString())%></a><span style="float:right"> <%#CutString(Eval("adddate").ToString())%>���<%#CutString(Eval("type").ToString().Substring(2))%>��</span>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
                    </ul>
                   
                </div>
                <div class="right-block2 rf" style="border-right: 0px;">
                    <h3>
                        �ӱ���ҵ��ѧѧ��������ѧ�棩 <span style="display: block; _margin-top: -25px; *margin-top: -25px; position: relative;
                            float: right"><a href="/Front/DownAttach/default.aspx?type=2" class="rf" target="_blank">
                                <img alt="" src="../images/index2/more.gif" style="border: none" /></a></span>
                    </h3>
                   <ul>
                    <asp:DataList ID="Datalist2" runat="server" Width="340px">
                        <ItemTemplate>
                            <li><a href='/Front/DownAttach/default.aspx?id=a<%#Eval("id")%>'>
                                <%#CutString1(Eval("title").ToString())%> </a><span style="float:right"> <%#CutString(Eval("adddate").ToString())%>���<%#CutString(Eval("type").ToString().Substring(2))%>��</span>
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
        <!--�ұ߲��ֽ���-->
      
    </div>
    <div class="clear">
    </div>
    <div id="footer_up">
        <table>
            <tr>
                <td style="width: 960px;" align="center">
                    <a style="cursor: pointer;" onclick="SetHome(this,location.href)">��Ϊ��ҳ</a>| <a href="ContactUs/default.aspx" target="_blank">
                        ��ϵ����</a>|<a style="cursor: pointer;" onclick="AddFavorite(location.href,'�ӱ���ҵ��ѧѧ���༭��')">
                            �����ղ�</a> |<a href="../Background/Login.aspx" target="_blank">��̨����</a>
                </td>
            </tr>
        </table>
    </div>
    <div class="clear">
    </div>
    <div class="footerWRAP">
        <div id="footer">
            <br />
           �ӱ���ҵ��ѧѧ���༭����Ȩ���� Copyright@ 2014-2016 ALL Rights Reserved<br>
            <br />
          ҵ����ѯ���ӱ���ҵ��ѧѧ���༭�� ����֧�֣��ӱ���ҵ��ѧ�������ѧ�����ѧԺ214<br>
            <br />
        </div>
        <!--/footer-->
    </div>
    </form>
</body>
</html>
