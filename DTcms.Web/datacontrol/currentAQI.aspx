<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="currentAQI.aspx.cs" Inherits="DTcms.Web.datacontrol.currentAQI" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>AQI实时数据</title>
    <script src="js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.2-vsdoc.js" type="text/javascript"></script>
    <script src="js/Monitor.js" type="text/javascript"></script>
<link type="text/css" rel="stylesheet" href="../../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../admin/images/style.css" />
<link type="text/css" rel="stylesheet" href="../../css/pagination.css" />
<script type="text/javascript" src="../../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../admin/js/function.js"></script>
   
</head>
<body class="mainbody" onload="loaded()">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 站点数据监控 &gt; AQI实时报表</div>
    <div id="navtips" class="navtips">按点位显示空气检测数据实时AQI！<a href="javascript:CloseTip('navtips');" class="close">关闭</a></div>
    <div style=" font-size:18px;">起始时间：
<input type="text" name="from" id="from" onclick="WdatePicker()" />    
    终止时间：<input type="text" name="to"  id="to" onclick="WdatePicker()" />
    <input type="button" value="查询日报" onclick="chaxunshuju()" /> <input type="button" value="下载到excel" onclick="" />
    </div>
    
    <div id="mytb">
    <input type="checkbox"  />
   
    </div>

    <div class="line10"></div>
    <!--列表展示.开始-->
   <div id="myzhanshi"></div>
    <!--列表展示.结束-->

    <div class="line10"></div>
</form>
</body>
</html>

