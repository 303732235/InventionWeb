<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InventionWeb.Front.DownAttach.Default" %>
<%@ Register Src="~/WebControl/head2.ascx" TagName="top" TagPrefix="uc1" %>
<%@ Register Src="~/WebControl/footer.ascx" TagName="footer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>过刊查询</title>
    <link href="../../Styles/index2.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/fro-2ceng.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../../Scripts/jquery-1.4.1.js"></script>
      <script src="../../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    
</head>
<body>
    <form id="form1" runat="server">
    <uc1:top ID="top1" runat="server" />
    <div class="second-mid">
         <table cellpadding="0" cellspacing="0">
            <tr>
               
                <td style="width: 16.7%;" valign="top" class="left-mid1">
                  <li ><a href="javascript:c(m02);" id="m02">
                <h3 <%--style="text-align:left;"--%> style="color:#FFFFFF;font-weight:bold;font-size:14px;"><img src="../../images/2.gif"  />
              河北工业大学学报过刊</h3></a></li>
              
              
               <ul id="m02d" style="display: none; width:70px;" >
                <asp:DataList ID="DatalistNotice" runat="server" Width="100px">
                        <ItemTemplate>
                           <li> <a href="javascript:c(m<%#CutString1(Eval("adddate").ToString())%>);" id="m<%#CutString1(Eval("adddate").ToString())%>" style="color:#FFFFFF;">
                                <%#CutString1(Eval("adddate").ToString())%></a>
                                <%--<tbody id="t<%#CutString1(Eval("adddate").ToString())%>">
                             
                                                    </tbody>--%>
             <ul id="m<%#CutString1(Eval("adddate").ToString())%>d" style="display: none; padding-left:30px;"> 
                <li style="list-style-type:none;"> <a id="z<%#CutString1(Eval("adddate").ToString())%>a" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getziran(this,<%#CutString1(Eval("adddate").ToString())%>)"; >
                                第一期</a></li>
                <li style="list-style-type:none;"> <a id="z<%#CutString1(Eval("adddate").ToString())%>b" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getziran(this,<%#CutString1(Eval("adddate").ToString())%>)"; >
                                第二期</a></li>
                <li style="list-style-type:none;"> <a  id="z<%#CutString1(Eval("adddate").ToString())%>c" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getziran(this,<%#CutString1(Eval("adddate").ToString())%>)"; >
                                第三期</a></li>
                 <li style="list-style-type:none;"> <a  id="z<%#CutString1(Eval("adddate").ToString())%>d" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getziran(this,<%#CutString1(Eval("adddate").ToString())%>)"; >
                                第四期</a></li>
                  <li style="list-style-type:none;"> <a id="z<%#CutString1(Eval("adddate").ToString())%>e"  target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getziran(this,<%#CutString1(Eval("adddate").ToString())%>)"; >
                                第五期</a></li>
                  <li style="list-style-type:none;"> <a  id="z<%#CutString1(Eval("adddate").ToString())%>f"target="mainFrame"style="font-size:12px;color:#FFFFFF;"  onclick="getziran(this,<%#CutString1(Eval("adddate").ToString())%>)"; >
                                第六期</a></li>
             </ul>
                                </li>
                        </ItemTemplate>
                    </asp:DataList>
            </ul>
        
         
             <li ><a href="javascript:c(m03);" id="m03"><span>
                <h3 <%--style="text-align:left;"--%>style="color:#FFFFFF;font-weight:bold;font-size:14px;"><img src="../../images/2.gif" align="absMiddle" />
               河北工业大学学报(社会科学版)过刊</h3></span></a></li>
               <ul id="m03d" style="display: none;" >
                <asp:DataList ID="Datalist1" runat="server" Width="100px">
                        <ItemTemplate>
                            <li id="ziran"><a href="javascript:c(n<%#CutString1(Eval("adddate").ToString())%>);" id="n<%#CutString1(Eval("adddate").ToString())%>" style="color:#FFFFFF;">
                                <%#CutString1(Eval("adddate").ToString())%></a>
                                <ul id="n<%#CutString1(Eval("adddate").ToString())%>d" style="display: none; padding-left:30px;" >
             <li style="list-style-type:none;"><a id="s<%#CutString1(Eval("adddate").ToString())%>a" class="menuParent" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getsheke(this,<%#CutString1(Eval("adddate").ToString())%>)";  >
                                第一期</a></li>
                <li style="list-style-type:none;"><a id="s<%#CutString1(Eval("adddate").ToString())%>b" class="menuParent" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getsheke(this,<%#CutString1(Eval("adddate").ToString())%>)";  >
                                第二期</a></li>
                <li style="list-style-type:none;"><a id="s<%#CutString1(Eval("adddate").ToString())%>c" class="menuParent" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getsheke(this,<%#CutString1(Eval("adddate").ToString())%>)";  >
                                第三期</a></li>
                <li style="list-style-type:none;"><a id="s<%#CutString1(Eval("adddate").ToString())%>d" class="menuParent" target="mainFrame"style="font-size:12px;color:#FFFFFF;" onclick="getsheke(this,<%#CutString1(Eval("adddate").ToString())%>)";  >
                                第四期</a></li>
             </ul>
                            </li>
                        </ItemTemplate>
                    </asp:DataList>
            </ul>
             
                </td>
                <td class="right-mid">
                    <iframe id="mainFrame" name="mainFrame" marginwidth="0" marginheight="3" frameborder="0"
                        width="95%" src="filedownload.aspx?type=0"   scrolling="yes" height="440px" >
                    </iframe>
                </td>
            </tr>
            </table>
    </div>
     <uc1:footer ID="top2" runat="server" />
    </form>
     <script type="text/javascript">

         $(function () {
             var url = document.location.href;
             if (url.indexOf("=") > 0) {
                 var id = url.substring(url.indexOf("=") + 1, url.length)
             }

             if (id =="1") window.parent.mainFrame.location.href = "filedownload.aspx?type=1";
             else if (id =="2") window.parent.mainFrame.location.href = "filedownload.aspx?type=2";
             else window.parent.mainFrame.location.href = "filedownload.aspx?type=" + id + "";

             $("#menu ul>li:has(ul)").hover(
    function () {
        $(this).children('a').end().find('ul').fadeIn(400);
    },
    function () {
        $(this).children('a').end().find('ul').fadeOut(400);
    }
    );
         });
         var cur_id = "";
         var flag = 0, sflag = 0;
         var year;

         //-------- 菜单点击事件 -------
         var axc01 = "";
         axc01 = "<li class=\"L22\"> <a class=\"menuParent\" target=\"mainFrame\"style=\"font-size:14px;\" onclick=\"getziran(1)\"; >";
         var axc02 = "";
         axc02 = "第一期";
         axc03 = "";
         axc03 = "</a></li>";


         function get(year) {
             alert("m" + year);
             var a = "m" + year;
             c(a);

         }
         function get1(y) {
             year = y;
            
             
             c(m12);
            

         }
         function getziran(obj, id) {

         
             if (obj.id == "z" + id + "a") {
                 document.getElementById("z" + id + "a").href = "filedownload.aspx?type=" + id + "1.1";
                 document.getElementById("z" + id + "a").style.color = "blue";
                 document.getElementById("z" + id + "b").style.color = "white";
                 document.getElementById("z" + id + "c").style.color = "white";
                 document.getElementById("z" + id + "d").style.color = "white";
                 document.getElementById("z" + id + "e").style.color = "white";
                 document.getElementById("z" + id + "f").style.color = "white";
                 
              }
             else if (obj.id == "z" + id + "b") {
                 document.getElementById("z" + id + "b").href = "filedownload.aspx?type=" + id + "1.2";
                 document.getElementById("z" + id + "a").style.color = "white";
                 document.getElementById("z" + id + "b").style.color = "blue";
                 document.getElementById("z" + id + "c").style.color = "white";
                 document.getElementById("z" + id + "d").style.color = "white";
                 document.getElementById("z" + id + "e").style.color = "white";
                 document.getElementById("z" + id + "f").style.color = "white";
             }
             else if (obj.id == "z" + id + "c") {
                 document.getElementById("z" + id + "c").href = "filedownload.aspx?type=" + id + "1.3";
                 document.getElementById("z" + id + "a").style.color = "white";
                 document.getElementById("z" + id + "b").style.color = "white";
                 document.getElementById("z" + id + "c").style.color = "blue";
                 document.getElementById("z" + id + "d").style.color = "white";
                 document.getElementById("z" + id + "e").style.color = "white";
                 document.getElementById("z" + id + "f").style.color = "white";
             }
             else if (obj.id == "z" + id + "d") {
                 document.getElementById("z" + id + "d").href = "filedownload.aspx?type=" + id + "1.4";
                 document.getElementById("z" + id + "a").style.color = "white";
                 document.getElementById("z" + id + "b").style.color = "white";
                 document.getElementById("z" + id + "c").style.color = "white";
                 document.getElementById("z" + id + "d").style.color = "blue";
                 document.getElementById("z" + id + "e").style.color = "white";
                 document.getElementById("z" + id + "f").style.color = "white";
             }
             else if (obj.id == "z" + id + "e") {
                 document.getElementById("z" + id + "e").href = "filedownload.aspx?type=" + id + "1.5";
                 document.getElementById("z" + id + "a").style.color = "white";
                 document.getElementById("z" + id + "b").style.color = "white";
                 document.getElementById("z" + id + "c").style.color = "white";
                 document.getElementById("z" + id + "d").style.color = "v";
                 document.getElementById("z" + id + "e").style.color = "blue";
                 document.getElementById("z" + id + "f").style.color = "white";
             }
             else if (obj.id == "z" + id + "f") {

                 document.getElementById("z" + id + "f").href = "filedownload.aspx?type=" + id + "1.6";
                 document.getElementById("z" + id + "a").style.color = "white";
                 document.getElementById("z" + id + "b").style.color = "white";
                 document.getElementById("z" + id + "c").style.color = "white";
                 document.getElementById("z" + id + "d").style.color = "white";
                 document.getElementById("z" + id + "e").style.color = "white";
                 document.getElementById("z" + id + "f").style.color = "blue";
             }

         }
         function getsheke(obj, id) {

             if (obj.id == "s" + id + "a") {

                 document.getElementById("s" + id + "a").href = "filedownload.aspx?type=" + id + "2.1";
             }
             else if (obj.id == "s" + id + "b")
             { document.getElementById("s" + id + "b").href = "filedownload.aspx?type=" + id + "2.2"; }
             else if (obj.id == "s" + id + "c")
             { document.getElementById("s" + id + "c").href = "filedownload.aspx?type=" + id + "2.3"; }
             else if (obj.id == "s" + id + "d")
             { document.getElementById("s" + id + "d").href = "filedownload.aspx?type=" + id + "2.4"; }
           

         }
         function c(srcelement) {

             var targetid, srcelement, targetelement;
             var strbuf;
           
             //-------- 如果点击了展开或收缩按钮---------
             targetid = srcelement.id + "d";
             targetelement = document.getElementById(targetid);
            
             if (targetid == "m02d") window.parent.mainFrame.location.href = "filedownload.aspx?type=1";
             if (targetid == "m03d") window.parent.mainFrame.location.href = "filedownload.aspx?type=2";
             if (targetelement.style.display == "none") {
                 srcelement.className = "active";
                 targetelement.style.display = '';

                 menu_flag = 0;
                 expand_text.innerHTML = "收缩";
             }
             else {
                 srcelement.className = "";
                 targetelement.style.display = "none";

                 menu_flag = 1;
                 expand_text.innerHTML = "展开";
                 var links = document.getElementsByTagName("A");
                 for (i = 0; i < links.length; i++) {
                     srcelement = links[i];
                     if (srcelement.parentNode.className.toUpperCase() == "L1" && srcelement.className == "active" && srcelement.id.substr(0, 1) == "m") {
                         menu_flag = 0;
                         expand_text.innerHTML = "收缩";
                         break;
                     }
                 }
             }
         }
         //-------- 菜单全部展开/收缩 -------
         var menu_flag = 1;
         function menu_expand() {
             if (menu_flag == 1)
                 expand_text.innerHTML = "收缩";
             else
                 expand_text.innerHTML = "展开";

             menu_flag = 1 - menu_flag;

             var links = document.getElementsByTagName("A");
             for (i = 0; i < links.length; i++) {
                 srcelement = links[i];
                 if (srcelement.parentNode.className.toUpperCase() == "L1" || srcelement.parentNode.className.toUpperCase() == "L21") {
                     targetelement = document.getElementById(srcelement.id + "d");
                     if (menu_flag == 0) {
                         targetelement.style.display = '';
                         srcelement.className = "active";
                     }
                     else {
                         targetelement.style.display = "none";
                         srcelement.className = "";
                     }
                 }
             }
         }
    </script>
</body>
</html>