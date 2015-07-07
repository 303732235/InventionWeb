<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TreeMenu.aspx.cs" Inherits="InventionWeb.Background.leftmenu.TreeMenu" %>

<html>
<head>
    <title>主菜单</title>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312">
    <link rel="stylesheet" type="text/css" href="css/menu.css">
</head>
<body topmargin="0" leftmargin="0">
    <div id="body">
        <!-- OA树开始-->
        <a id="expand_link" href="javascript:menu_expand();"><u><span id="expand_text">展开</span></u></a>
        <ul id="menu">
        <li class="L1"><a href="javascript:c(m02);" id="m02"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
               首页图片展示管理(左)</span></a></li>
            <ul id="m02d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/NewImageAdmin/NewsImageAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加图片展示</span></a></li>
                <li class="L22"><a href="/BackGround/NewImageAdmin/NewsImageMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        图片展示列表</span></a></li>
            </ul>
             <li class="L1"><a href="javascript:c(m06);" id="m06"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
               首页图片展示管理（右）</span></a></li>
            <ul id="m06d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/ImageRight/RightAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加图片展示</span></a></li>
                <li class="L22"><a href="/BackGround/ImageRight/RightMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        图片展示列表</span></a></li>
            </ul>
            <li class="L1"><a href="javascript:c(m04);" id="m04"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                综合通告管理</span></a></li>
            <ul id="m04d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/NoticeAdmin/NoticeArticleAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加综合通告</span></a></li>
                <li class="L22"><a href="/BackGround/NoticeAdmin/NoticeMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        综合通告列表</span></a></li>
            </ul>
            <li class="L1"><a href="javascript:c(m08);" id="m08"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                自然版通知公告管理</span></a></li>
            <ul id="m08d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/ExampleAdmin/ExampleArticleAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加自然版通知公告</span></a></li>
                <li class="L22"><a href="/BackGround/ExampleAdmin/ExampleMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        自然版通知公告列表</span></a></li>
            </ul>
             <li class="L1"><a href="javascript:c(m05);" id="m05"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                社科版通知公告管理</span></a></li>
            <ul id="m05d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/WorkdtAdmin/WorkdtArticleAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加社科版通知公告</span></a></li>
                <li class="L22"><a href="/BackGround/WorkdtAdmin/WorkdtMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        社科版通知公告列表</span></a></li>
            </ul>
            <li class="L1"><a href="javascript:c(m01);" id="m01"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                自然版投稿指南管理</span></a></li>
            <ul id="m01d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/NewAdmin/NewsArticleAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加自然版投稿指南</span></a></li>
                <li class="L22"><a href="/BackGround/NewAdmin/NewsManager.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        自然版投稿指南列表</span></a></li>
            </ul>
            <li class="L1"><a href="javascript:c(m07);" id="m07"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                社科版投稿指南管理</span></a></li>
            <ul id="m07d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/AllianceAdmin/AllianceArticleAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加社科版投稿指南</span></a></li>
                <li class="L22"><a href="/BackGround/AllianceAdmin/AllianceMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        社科版投稿指南列表</span></a></li>
            </ul>
            <li class="L1"><a href="javascript:c(m03);" id="m03"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                过刊查询管理</span></a></li>
            <ul id="m03d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/DownAttachAdmin/DownAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加下载过刊</span></a></li>
                <li class="L22"><a href="/BackGround/DownAttachAdmin/DownMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        下载资料过刊</span></a></li>
            </ul>
            
           
            <%--<li class="L1"><a href="javascript:c(m06);" id="m06"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                创新理论管理</span></a></li>
            <ul id="m06d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/PolicyAdmin/PolicyArticleAdd.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加创新理论</span></a></li>
                <li class="L22"><a href="/BackGround/PolicyAdmin/PolicyMgr.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        创新理论列表</span></a></li>
            </ul>--%>
            
            
            <li class="L1"><a href="javascript:c(m09);" id="m09"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                用户管理</span></a></li>
            <ul id="m09d" style="display: none;" class="U1">
                <li class="L22"><a href="/BackGround/UsersAdmin/UsersAdd.aspx" target="rightframe"><span>
                    <img src="images/ico/2.gif" align="absMiddle" />
                    添加用户</span></a></li>
                <li class="L22"><a href="/BackGround/UsersAdmin/UsersMgr.aspx" target="rightframe"><span>
                    <img src="images/ico/2.gif" align="absMiddle" />
                    用户列表</span></a></li>
            </ul>
            <%--<li class="L1"><a href="javascript:c(m10);" id="m10"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                BBS专题管理</span></a></li>
            <ul id="m10d" style="display: none;" class="U1">
                <li class="L22"><a href="/background/BBSAdmin/ModuleAdmin/AddModule.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加专题</span></a></li>
                <li class="L22"><a href="/background/BBSAdmin/ModuleAdmin/ManageMudole.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        专题列表</span></a></li>
            </ul>
            <li class="L1"><a href="javascript:c(m11);" id="m11"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                BBS问题管理</span></a></li>
            <ul id="m11d" style="display: none;" class="U1">
                <li class="L22"><a href="/background/BBSAdmin/CardAdmin/AddCard.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        添加问题</span></a></li>
                <li class="L22"><a href="/background/BBSAdmin/CardAdmin/ManageCard.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        问题列表</span></a></li>
                <li class="L22"><a href="/background/BBSAdmin/CardAdmin/RevertCardAdmin.aspx" target="rightframe">
                    <span>
                        <img src="images/ico/2.gif" align="absMiddle" />
                        回复管理</span></a></li>
            </ul>
            <li class="L1"><a href="javascript:c(m12);" id="m12"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                CAI用户管理</span></a></li>
            <ul id="m12d" style="display: none;" class="U1">
                <li class="L22"><a href="/Background/UsersAdmin/UserRole.aspx" target="rightframe"><span>
                    <img src="images/ico/2.gif" align="absMiddle" />
                    权限分配</span></a></li>
            </ul>--%>
            <li class="L1"><a href="javascript:c(m13);" id="m13"><span>
                <img src="images/ico/2.gif" align="absMiddle" />
                简介管理</span></a></li>
            <ul id="m13d" style="display: none;" class="U1">
                <li class="L22"><a href="/Background/Remark/remark.aspx" target="rightframe"><span>
                    <img src="images/ico/2.gif" align="absMiddle" />
                    查看简介</span></a></li>
                <li class="L22"><a href="/Background/Remark/connus.aspx" target="rightframe"><span>
                    <img src="images/ico/2.gif" align="absMiddle" />
                    修改简介</span></a></li>
            </ul>
        </ul>
    </div>
    <script type="text/javascript">
        var cur_id = "";
        var flag = 0, sflag = 0;

        //-------- 菜单点击事件 -------
        function c(srcelement) {
            var targetid, srcelement, targetelement;
            var strbuf;

            //-------- 如果点击了展开或收缩按钮---------
            targetid = srcelement.id + "d";
            targetelement = document.getElementById(targetid);

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
