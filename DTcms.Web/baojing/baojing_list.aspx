<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baojing_list.aspx.cs" Inherits="DTcms.web.baojing.baojing_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>数据报警</title>
<link type="text/css" rel="stylesheet" href="../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../../images/style.css" />
<link href="../admin/images/style.css" rel="stylesheet" type="text/css" />
<link type="text/css" rel="stylesheet" href="../css/pagination.css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../../js/function.js"></script>
<script src="/Calendar/JS/calendar2.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $("#table1 tr").each(function () {          
            var so2=$("td:eq(1)", $(this)); 
            var no=$("td:eq(2)", $(this)); 
            var no2=$("td:eq(3)", $(this)); 
            var nox=$("td:eq(4)", $(this)); 
            var co=$("td:eq(5)", $(this)); 
            var o3=$("td:eq(6)", $(this));
            var pm10=$("td:eq(7)",$(this));
            
            //二氧化硫   
            if(parseFloat(so2.text())>2) {         
                so2.css("color", "red");
            } else if (parseFloat(so2.text()) >1){
                so2.css("color", "orange");
            } else {
                so2.css("color", "black");
            }
            
            //一氧化氮 
            if(parseFloat(no.text())>2) {         
                no.css("color", "red");
            } else if (parseFloat(no.text()) >1){
                no.css("color", "orange");
            } else {
                no.css("color", "black");
            }
            
            //二氧化氮 
            if(parseFloat(no2.text())>2) {         
                no2.css("color", "red");
            } else if (parseFloat(no2.text()) >1){
                no2.css("color", "orange");
            } else {
                no2.css("color", "black");
            }
            
            //氮氧化物 
            if(parseFloat(nox.text())>2) {         
                nox.css("color", "red");
            } else if (parseFloat(nox.text()) >1){
                nox.css("color", "orange");
            } else {
                nox.css("color", "black");
            }
            
            //一氧化碳 
            if(parseFloat(co.text())>2) {         
                co.css("color", "red");
            } else if (parseFloat(co.text()) >1){
                co.css("color", "orange");
            } else {
                co.css("color", "black");
            }
            
            //臭氧 
            if(parseFloat(o3.text())>2) {         
                o3.css("color", "red");
            } else if (parseFloat(o3.text()) >1){
                o3.css("color", "orange");
            } else {
                o3.css("color", "black");
            }
            
            //可吸入颗粒物 
            if(parseFloat(pm10.text())>2) {         
                pm10.css("color", "red");
            } else if (parseFloat(pm10.text()) >1){
                pm10.css("color", "orange");
            } else {
                pm10.css("color", "black");
            }
        });
    })
</script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <div class="navigation">首页 &gt;数据报警 </div>
     <div class="navigation">提示：黄色为预报警,红色为超标报警</div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable" id="table1">
      <tr>
        <th width="12%">站点名称</th>
        <th width="8%">二氧化硫</th>
        <th width="8%">一氧化氮</th>
        <th width="8%">二氧化氮</th>
        <th width="8%">氮氧化物</th>
        <th width="8%">一氧化碳</th>
        <th width="8%">臭氧</th>
        <th width="8%">可吸入颗粒物</th>
        <th width="12%">日期</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <%--<td width="6%" align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>--%>
        <%-- <td width="12%"align="left" colspan="2"><%#new Eazytec.BLL.baojing().GetName(Convert.ToInt32(Eval("siteId")))%></td>--%>
        <td width="12%"align="center"><%#new DTcms.BLL.baojing().GetName(Convert.ToString(Eval("stationId")))%></td> 
        <td width="8%" align="center"><%#Eval("so2")%></td>
        <td width="8%" align="center"><%#Eval("no")%></td>     
        <td width="8%" align="center"><%#Eval("no2")%></td> 
        <td width="8%" align="center"><%#Eval("nox") %></td>
        <td width="8%" align="center"><%#Eval("co") %></td> 
        <td width="8%" align="center"><%#Eval("o3") %></td> 
        <td width="8%" align="center"><%#Eval("pm10") %></td>        
        <td width="12%" align="center"><%#Eval("dtt")%></td>
      </tr>
    </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
    </asp:Repeater>
    <!--列表展示.结束-->

   
    <div class="line15"></div>
    <div class="page_box">
      <div id="PageContent" runat="server" class="flickr right"></div>
      <div class="left">
         显示<asp:TextBox ID="txtPageNum" runat="server" CssClass="txtInput2 small2" onkeypress="return (/[\d]/.test(String.fromCharCode(event.keyCode)));" 
             ontextchanged="txtPageNum_TextChanged" AutoPostBack="True"></asp:TextBox>条/页
      </div>
    </div>
    <div class="line10"></div>
</form>
</body>
</html>

