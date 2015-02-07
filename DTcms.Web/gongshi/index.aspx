<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="DTcms.Web.gongshi.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>宜兴市环境监测项目公示平台</title>
    <link href="css/gongshi.css" rel="stylesheet" type="text/css" />
    <link href="css/cssMain.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.2-vsdoc.js" type="text/javascript"></script>

    <script src="js/Monitor.js" type="text/javascript"></script>
</head>
<body onload="WebInit();">
    <form id="form1" runat="server">
    <div id="mydiv">
    <div id="myhead">
    <div style=" height:20px;"></div>
    <div id="mybunner"></div>
    </div>
    <div id="mybody">
    <div style=" height:10px;"></div>
    <div id="myleft">
    <!--图形界面开始-->
    
     <table border="0" cellpadding="0" cellspacing="0" style="width:100%;height:100%;">
      
      <tr style="height:24px;" valign="middle" class="Noprint">
        <td align="left" id="td1" style="width:100%;">
          <table border="0" cellpadding="0" cellspacing="0" style="width:100%;background-color:#f0f8ff; ">
            <tr style="height:24px;" valign="middle" class="Noprint">
        <td align="left" id="td2" style="height:24px; width:300px;">
          <table border="0" cellpadding="0" cellspacing="0" style="width:100%;">
            <tr style="height:24px;" valign="middle" class="Noprint">
              <td style=" color: black">
                <span style="font-size:13px;font-weight:bold;">&nbsp;当前位置：</span>
                <span id="Span1" runat="server" style="font-size:12px; font-weight:bold; ">
                实时监控</span><span style="">&nbsp;→&nbsp;综合数据</span>
              </td>
            </tr>    
          </table>
        </td>
              
              <td align="right" style="color:blue;">&nbsp;<img src="img/rightArrow.gif" alt='指定区域' title='指定区域'/></td>
              <td align="left" style="width: 60px; font-weight: bold;">
                <span style="color:maroon;">展示方式</span>
              </td>
             
              <td align="left" style="width: 160px; font-weight: bold;">
                <select id="cmbArea" style="width:150px;" onchange="AreaList_OnChange(this.value);">
                </select>           
              </td>
            </tr>    
          </table>
        </td>
      </tr>
      
      <!--中间主体部分-->
      <tr style="height:auto;width:100%;" valign="top" >
        <td align="left" style="width:100%; height:auto;">
        <div id="dvColligateData" style="overflow:auto;width:100%;height:100%;" class="Nav">
          <br /><br /><br /><br />
          <span style="color:red ;font-size:14px; font-weight:bold;">　　正在获取综合数据，请稍候......</span></div>
        </td>
      </tr>
      
    </table>
    
    <!--图形界面结束-->
    </div>
    <div id="myright">
    <div id="mygg">
    <span style=" background-image:url(img/666.jpg); width:183px; height:31px;display:inline-block; font-family:@幼圆; font-size:12pt; vertical-align:middle;"><span style="display:inline-block; color:White; width:100%; height:5px;"></span><span style=" font-family:@幼圆; font-size:8pt;">公告</span></span>
 <table>
 <tr>
 <td style=" width:9px;"></td>
 <td>
 
  <asp:Repeater ID="rptList" runat="server">
    <ItemTemplate>
   <table  style="width:180px; font-family:@幼圆;  font-size:8pt; border:">
   <tr>
   <td style=" font-size:12pt;  font-weight:bold;" align="center"><%#Eval("title")%></td>
   </tr>
   <tr>
   <td align="center"><%#Eval("content")%> </td>
   </tr>
   <tr>
   <td align="center">发布日期：<%#Eval("date")%> </td>
   </tr> 
   </table>
   </ItemTemplate>
   </asp:Repeater>
 
 
 </td>
 
 </tr>
 
 </table>
    </div>
    <div id="mysj">
    
    <span style=" background-image:url(img/666.jpg); width:183px; height:31px;display:inline-block; font-family:@幼圆; font-size:12pt; vertical-align:middle;"><span style="display:inline-block; color:White; width:100%; height:5px;"></span><span style=" font-family:@幼圆; font-size:8pt;">实时空气质量指数（AQI）</span></span>
    <div style="  text-align:center;">
    
    <table>
    <tr>
    <td style="width:9px;"></td>    
    <td>
    
     <asp:Repeater ID="myrep" runat="server">
   <HeaderTemplate>
   <table>
   <tr>
   <th>站点名称</th>
   <th> AQI值</th>
   <th>污染级别</th>
   </tr>
   </HeaderTemplate>
    <ItemTemplate>
    <tr>
    <td><%#DataBinder.Eval(Container.DataItem,"stationName" )%></td>
    <td><%#DataBinder.Eval(Container.DataItem,"AQI" )%></td>
    <td style=" background-color:Teal; color:White;">轻度污染</td>   
    </tr>
    </ItemTemplate>
    <FooterTemplate>
    </table>
    </FooterTemplate>
    </asp:Repeater>
    
    </td>
    </tr>
    </table>
   
   
    </div>
    
   
    
    </div>
    <div id="myload">
    
    <span style=" background-image:url(img/666.jpg); width:183px; height:31px;display:inline-block; vertical-align:middle;"><span style="display:inline-block; color:White; width:100%; height:5px;"></span><span style=" font-family:@幼圆; font-size:8pt;">数据下载</span></span>
   <table  style="width:182px; font-family:@幼圆;  font-size:8pt;">
   <tr><td></td><td></td><td></td></tr>
   <tr><td></td><td></td><td></td></tr>
   <tr><td></td><td></td><td></td></tr>
   <tr><td></td><td></td><td></td></tr>
   <tr><td></td><td></td><td></td></tr>
   <tr><td></td><td></td><td></td></tr>
   <tr><td>发布日期：</td><td></td><td></td></tr>
   </table>
    
    </div>
    
    
    </div>
    </div>
    </div>
    </form>
</body>
</html>
