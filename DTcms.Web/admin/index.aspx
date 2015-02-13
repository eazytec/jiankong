<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DTcms.Web.admin.index" %>

<%@ Import Namespace="DTcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=siteConfig.webname %>
        - 后台管理</title>
    <link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <link href="images/style.css" rel="stylesheet" type="text/css" />
    <script src="../scripts/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../scripts/ui/js/ligerBuild.min.js" type="text/javascript"></script>
    <script src="js/function.js" type="text/javascript"></script>
    <script type="text/javascript">
        var tab = null;
        var accordion = null;
        var tree = null;
        $(function () {
            //页面布局
            $("#global_layout").ligerLayout({ leftWidth: 180, height: '100%', topHeight: 65, bottomHeight: 24, allowTopResize: false, allowBottomResize: false, allowLeftCollapse: true, onHeightChanged: f_heightChanged });

            var height = $(".l-layout-center").height();

            //Tab
            $("#framecenter").ligerTab({ height: height });

            //左边导航面板
            $("#global_left_nav").ligerAccordion({ height: height - 25, speed: null });

            $(".l-link").hover(function () {
                $(this).addClass("l-link-over");
            }, function () {
                $(this).removeClass("l-link-over");
            });

            //设置频道菜单
            //        $("#global_channel_tree").ligerTree({
            //            url: '../tools/admin_ajax.ashx?action=sys_channel_load',
            //            checkbox: false,
            //            nodeWidth: 112,
            //            //attribute: ['nodename', 'url'],
            //            onSelect: function (node) {
            //                if (!node.data.url) return;
            //                var tabid = $(node.target).attr("tabid");
            //                if (!tabid) {
            //                    tabid = new Date().getTime();
            //                    $(node.target).attr("tabid", tabid)
            //                }
            //                f_addTab(tabid, node.data.text, node.data.url);
            //            }
            //        });

            //加载插件菜单
            loadPluginsNav();

            //快捷菜单
            var menu = $.ligerMenu({ width: 120, items:
		[
			{ text: '管理首页', click: itemclick },
			{ text: '修改密码', click: itemclick },
			{ line: true },
			{ text: '关闭菜单', click: itemclick }
		]
            });
            $("#tab-tools-nav").bind("click", function () {
                var offset = $(this).offset(); //取得事件对象的位置
                menu.show({ top: offset.top + 27, left: offset.left - 120 });
                return false;
            });

            tab = $("#framecenter").ligerGetTabManager();
            accordion = $("#global_left_nav").ligerGetAccordionManager();
            //        tree = $("#global_channel_tree").ligerGetTreeManager();
            //tree.expandAll(); //默认展开所有节点
            $("#pageloading_bg,#pageloading").hide();
        });

        //频道菜单异步加载函数，结合ligerMenu.js使用
        function loadChannelTree() {
            if (tree != null) {
                tree.clear();
                tree.loadData(null, "../tools/admin_ajax.ashx?action=sys_channel_load");
            }
        }

        //加载插件管理菜单
        function loadPluginsNav() {
            $.ajax({
                type: "POST",
                url: "../tools/admin_ajax.ashx?action=plugins_nav_load&time=" + Math.random(),
                timeout: 20000,
                beforeSend: function (XMLHttpRequest) {
                    $("#global_plugins").html("<div style=\"line-height:30px; text-align:center;\">正在加载，请稍候...</div>");
                },
                success: function (data, textStatus) {
                    $("#global_plugins").html(data);
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    $("#global_plugins").html("<div style=\"line-height:30px; text-align:center;\">加载插件菜单出错！</div>");
                }
            });
        }

        //快捷菜单回调函数
        function itemclick(item) {
            switch (item.text) {
                case "管理首页":
                    f_addTab('home', '管理中心', 'center.aspx');
                    break;
                case "快捷导航":
                    //调用函数
                    break;
                case "修改密码":
                    f_addTab('manager_pwd', '修改密码', 'manager/manager_pwd.aspx');
                    break;
                default:
                    //关闭窗口
                    break;
            }
        }
        function f_heightChanged(options) {
            if (tab)
                tab.addHeight(options.diff);
            if (accordion && options.middleHeight - 24 > 0)
                accordion.setHeight(options.middleHeight - 24);
        }
        //添加Tab，可传3个参数
        function f_addTab(tabid, text, url, iconcss) {
            if (arguments.length == 4) {
                tab.addTabItem({ tabid: tabid, text: text, url: url, iconcss: iconcss });
            } else {
                tab.addTabItem({ tabid: tabid, text: text, url: url });
            }
        }
        //提示Dialog并关闭Tab
        function f_errorTab(tit, msg) {
            $.ligerDialog.open({
                isDrag: false,
                allowClose: false,
                type: 'error',
                title: tit,
                content: msg,
                buttons: [{
                    text: '确定',
                    onclick: function (item, dialog, index) {
                        //查找当前iframe名称
                        var itemiframe = "#framecenter .l-tab-content .l-tab-content-item";
                        var curriframe = "";
                        $(itemiframe).each(function () {
                            if ($(this).css("display") != "none") {
                                curriframe = $(this).attr("tabid");
                                return false;
                            }
                        });
                        if (curriframe != "") {
                            tab.removeTabItem(curriframe);
                            dialog.close();
                        }
                    }
                }]
            });
        }
    </script>
</head>
<body style="padding: 0px;">
    <form id="form1" runat="server">
    <div class="pageloading_bg" id="pageloading_bg">
    </div>
    <div id="pageloading">
        数据加载中，请稍等...</div>
    <div id="global_layout" class="layout" style="width: 100%">
        <!--头部-->
        <div position="top" class="header">
            <div class="header_box">
                <div class="header_right">
                    <span><b>
                        <%=admin_info.user_name %>（<%=new DTcms.BLL.manager_role().GetTitle(admin_info.role_id) %>）</b>您好，欢迎光临</span>
                    <br />
                    <a href="javascript:f_addTab('home','管理中心','center.aspx')">管理中心</a> | <a target="_blank"
                        href="../gongshi/index.aspx">公示平台</a> | |
                    <asp:LinkButton ID="lbtnExit" runat="server" OnClick="lbtnExit_Click">安全退出</asp:LinkButton>
                </div>
                <a class="logo">DTcms Logo</a>
            </div>
        </div>
        <!--左边-->
        <div position="left" title="管理菜单" id="global_left_nav">
            <div title="站点信息" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('sitemap','站点信息','../baseInfo/sitemap.aspx')">站点信息</a></li>
                </ul>
            </div>
            <div title="站点数据监控" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('shishi','实时数据','../datacontrol/Currentdata.aspx')">
                        实时数据</a></li>
                    <%--                    <li><a href="javascript:f_addTab('zhandian','AQI实时报表','../datacontrol/currentAQI.aspx')">
                        AQI实时报表</a></li>--%>
                    <li><a href="javascript:f_addTab('kqrb','空气质量日报','../datacontrol/currentAQI.aspx')">
                        空气质量日报</a></li>
                    <%--<li><a href="javascript:f_addTab('shuizhi','水质','../baseInfo/sitemap.aspx')">水质</a></li>--%>
                </ul>
            </div>
            <div title="站点运行管理" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('zhandianyunxing','站点运行信息','../datacontrol/Currentdata.aspx')">
                        站点运行信息</a></li>
                    <li><a href="javascript:f_addTab('siteinfo','站点运行信息','../siteinfo/site_list.aspx')">
                        站点信息维护</a></li>
                </ul>
            </div>
            <div title="报警管理" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('baojing','报警信息','../baojing/baojing_list.aspx')">报警信息</a></li>
                </ul>
            </div>
            <div title="数据下载" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('datadownload','数据下载','../datadownload/baobiao.aspx')">
                        数据下载</a></li>
                </ul>
            </div>
            <div title="数据审核" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('datashenhe','数据审核信息','../device/device_info_query.aspx')">
                        数据审核信息</a></li>
                    <li><a href="javascript:f_addTab('datashenhepass','数据审核通过','../device/device_info_pass.aspx')">
                        数据审核通过</a></li>
                </ul>
            </div>
            <div title="公告管理" iconcss="menu-icon-member">
                <ul class="nlist">
                    <li><a href="javascript:f_addTab('datashenhe','公示公告','../gonggao/gonggao_list.aspx')">
                        公示公告</a></li>
                </ul>
            </div>
            <div title="对外接口" iconcss="menu-icon-setting">
                <ul class="nlist">
                    <li><a class="l-link" href="javascript:f_addTab('data_query','对外接口','project/query/data_query.aspx')">
                        公共访问接口</a></li>
                </ul>
            </div>
        </div>
        <div position="center" id="framecenter" toolsid="tab-tools-nav">
            <div tabid="home" title="管理中心" iconcss="tab-icon-home" style="height: 300px">
                <iframe frameborder="0" name="sysMain" src="../baseInfo/sitemap.aspx"></iframe>
            </div>
        </div>
        <div position="bottom" class="footer">
            <div class="copyright">
                Copyright &copy; 2009 - 2012. dtcms.net. All Rights Reserved.</div>
        </div>
    </div>
    </form>
</body>
</html>
