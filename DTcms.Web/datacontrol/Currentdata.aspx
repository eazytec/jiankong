<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Currentdata.aspx.cs" Inherits="DTcms.Web.datacontrol.Currentdata" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>实时数据</title>
    <link href="css/gongshi.css" rel="stylesheet" type="text/css" />
    <link href="css/cssMain.css" rel="stylesheet" type="text/css" />

    <script src="js/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="js/jquery-1.4.2-vsdoc.js" type="text/javascript"></script>

    <script src="js/Monitor.js" type="text/javascript"></script>
</head>
<body onload="WebInit();">
    <form id="form1" runat="server">
    <div>
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
    </div>
    </form>
</body>
</html>
