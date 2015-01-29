<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="BTSmanagementInfo.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>欢迎使用竞赛系统后台</title>
    <link href="<%=PageBase.Url %>lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet"
        type="text/css" />
    <link href="<%=PageBase.Url %>lib/ligerUI/skins/Gray/css/all.css" rel="stylesheet"
        type="text/css" />
    <script src="<%=PageBase.Url %>lib/jquery/jquery-1.7.2.min.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/ligerui.all.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/plugins/ligerTab.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/plugins/ligerLayout.js" type="text/javascript"></script>
    <link href="<%=PageBase.Url %>lib/css/common.css" rel="stylesheet" type="text/css" />
    <link href="<%=PageBase.Url %>lib/css/index.css" rel="stylesheet" type="text/css" />
    <script src="<%=PageBase.Url %>lib/js/common.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/js/LG.js" type="text/javascript"></script>
    <script type="text/javascript">
        rootUrl = "<%=PageBase.Url %>" + "handler";
    </script>
    <script src="<%=PageBase.Url %>lib/js/login.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/jquery-validation/jquery.validate.min.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/jquery-validation/jquery.metadata.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/jquery-validation/messages_cn.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/js/changepassword.js" type="text/javascript"></script>
    <script src="<%=PageBase.Url %>lib/ligerUI/js/plugins/ligerForm.js" type="text/javascript"></script>
    <script type="text/javascript">
        function GetIsShow(hidValue, ArrIndex) {
            var getValue = hidValue.split(',');
            try {
                if (getValue[ArrIndex] == "True")
                    return true;
                else
                    return false;
            }
            catch (e) 
            {
                return false;
            }
        }

    </script>
</head>
<body style="text-align: center; background: #F0F0F0; overflow: hidden;">
    <form runat="server">
    <input type="hidden" id="hid_Pre" runat="server" />
    <input type="hidden" id="hid_InSite" runat="server" />
    <input type="hidden" id="hid_Optimization" runat="server" />
    <input type="hidden" id="hid_RecordFinsh" runat="server" />
    <input type="hidden" id="hid_RecordManage" runat="server" />
    <input type="hidden" id="hid_UserConfig" runat="server" />
    <div id="pageloading" style="display: block;">
    </div>
    <div id="topmenu" class="l-topmenu">
        <div class="l-topmenu-logo">
            竞赛系统后台</div>
        <div class="l-topmenu-welcome">
            <span class="l-topmenu-username"></span>欢迎您
            <%= Eastcom.BLL.SessionConfig.GetUserRealName()%>
            [<a href="javascript:f_changepassword()">修改密码</a>] &nbsp; [<a href="javascript:f_login()">切换用户</a>]
            [<a href="login.html?Action=out">退出</a>]
        </div>
    </div>
    <div id="mainbody" class="l-mainbody" style="width: 99.2%; margin: 0 auto; margin-top: 3px;">
        <div position="left" title="主要菜单" id="mainmenu">
        </div>
        <div position="center" id="framecenter">
            <div tabid="home" title="我的主页">
                <iframe frameborder="0" name="home" id="home" src="./MyWelcome.aspx"></iframe>
            </div>
        </div>
    </div>
    </form>
    <script type="text/javascript">
        //几个布局的对象
        var layout, tab, accordion;
        //tabid计数器，保证tabid不会重复
        var tabidcounter = 0;
        //窗口改变时的处理函数
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        //增加tab项的函数
        function f_addTab(tabid, text, url) {
            if (!tab) return;

            if (!tabid) {
                tabidcounter++;
                tabid = "tabid" + tabidcounter;
            }
            tab.addTabItem({ tabid: tabid, text: text, url: url });
        }
        //登录
        function f_login() {
            LG.login();
        }
        //修改密码
        function f_changepassword() {
            LG.changepassword();
        }
        $(document).ready(function () {
            //菜单初始化
            $("ul.menulist li").live('click', function () {
                var jitem = $(this);
                var tabid = jitem.attr("tabid");
                var url = jitem.attr("url");
                if (!url) return;
                if (!tabid) {
                    tabidcounter++;
                    tabid = "tabid" + tabidcounter;
                    jitem.attr("tabid", tabid);

                    //给url附加menuno
                    if (url.indexOf('?') > -1) url += "&";
                    else url += "?";
                    url += "MenuNo=" + jitem.attr("menuno");
                    jitem.attr("url", url);
                }
                f_addTab(tabid, $("span:first", jitem).html(), url);
            }).live('mouseover', function () {
                var jitem = $(this);
                jitem.addClass("over");
            }).live('mouseout', function () {
                var jitem = $(this);
                jitem.removeClass("over");
            });

            //布局初始化 
            //layout
            layout = $("#mainbody").ligerLayout({ height: '100%', heightDiff: -3, leftWidth: 140, onHeightChanged: f_heightChanged, minLeftWidth: 120 });
            var bodyHeight = $(".l-layout-center:first").height();
            //Tab
            tab = $("#framecenter").ligerTab({ height: bodyHeight, contextmenu: true });

            //预加载dialog的背景图片
            LG.prevDialogImage();

            var mainmenu = $("#mainmenu");

            var item1 = "";

            /*RNP数据 (基站数据)*/
        
            item1 += '<div title="考题管理"><ul class="menulist">';  //lib/icons/silkicons/application.png

            item1 += '<li tabid="AdminIndex"  url="/Admin/ExamMng/QuestionBankList.aspx" ><img src="<%=PageBase.Url%>lib/icons/32X32/basket.gif" /><span>考题管理</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
            item1 += '<li tabid="AdminIndex"  url="/Admin/ExamMng/ExaminationList.aspx" ><img src="<%=PageBase.Url%>lib/icons/32X32/basket.gif" /><span>考务管理</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
            item1 += '<li tabid="AdminIndex"  url="/Admin/ExamMng/ExaminationList.aspx" ><img src="<%=PageBase.Url%>lib/icons/32X32/basket.gif" /><span>答题情况</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
           

            item1 += '</ul></div>';

           
            item1 += '<div title="系统配置"><ul class="menulist">'; //lib/icons/silkicons/application.png
               
                item1 += '<li tabid="UserList" url="System_Config/Sys_User/UserList.aspx"><img src="lib/icons/32X32/basket.gif" /><span>用户信息管理</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
                item1 += '<li tabid="RoleList" url="System_Config/Sys_Power/RoleList.aspx"><img src="lib/icons/32X32/suppliers.gif" /><span>角色信息管理</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
                item1 += '<li tabid="RightList" url="System_Config/Sys_Power/RightList.aspx"><img src="lib/icons/32X32/address.gif" /><span>权限信息管理</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
                item1 += '<li tabid="Sys_MSM_Config_List" url="System_Config/Sys_Config/Msm_Number_Config_List.aspx"><img src="lib/icons/32X32/milestone.gif" /><span>短信接收人配置</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
                item1 += '<li tabid="Sys_Log_List" url="System_Config/Sys_Log/Sys_Log_List.aspx"><img src="lib/icons/32X32/milestone.gif" /><span>系统日志管理</span><div class="menuitem-l"></div><div class="menuitem-r"></div></li>';
              
            item1 += '</ul></div>';

            mainmenu.append(item1);
            accordion = $("#mainmenu").ligerAccordion({ height: bodyHeight - 24, speed: null });
            $("#pageloading").hide();

            //            LG.ajax({
            //                type: 'AjaxMemberManage',
            //                method: 'GetCurrentUser',
            //                success: function (user) {
            //                    $(".l-topmenu-username").html(user.Title + "，");
            //                },
            //                error: function () {
            //                    LG.tip('用户信息加载失败');
            //                }
            //            });
        });
    </script>
</body>
</html>
