<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="baobiao.aspx.cs" Inherits="DTcms.web.histroy_graphs.baobiao" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
	<meta charset="utf-8">
	<link rel="shortcut icon" type="image/ico" href="http://www.datatables.net/favicon.ico">
	<meta name="viewport" content="initial-scale=1.0, maximum-scale=2.0">
	<title>统计参数</title>
	<link type="text/css" rel="stylesheet" href="../scripts/ui/skins/Aqua/css/ligerui-all.css" />
    <link type="text/css" rel="stylesheet" href="../admin/images/style.css" />
    <link type="text/css" rel="stylesheet" href="../css/pagination.css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script src="/Calendar/JS/calendar2.js" type="text/javascript"></script>	
	<link rel="stylesheet" type="text/css" href="media/css/jquery.dataTables.css"/>
	<link rel="stylesheet" type="text/css" href="css/dataTables.tableTools.css"/>
	<link rel="stylesheet" type="text/css" href="examples/resources/syntax/shCore.css"/>
	<link rel="stylesheet" type="text/css" href="examples/resources/demo.css"/>
	<script type="text/javascript" language="javascript" src="media/js/jquery.js"></script>
	<script type="text/javascript" language="javascript" src="media/js/jquery.dataTables.js"></script>
	<script type="text/javascript" language="javascript" src="js/dataTables.tableTools.js"></script>
	<script type="text/javascript" language="javascript" src="examples/resources/syntax/shCore.js"></script>
	<script type="text/javascript" language="javascript" src="examples/resources/demo.js"></script>
	<script type="text/javascript" language="javascript" class="init">

$(document).ready(function() {
	$('#example').DataTable( {
		dom: 'T<"clear">lfrtip',
        "tableTools": {
            "sSwfPath": "/datadownload/swf/copy_csv_xls_pdf.swf"
            }
	} );
} );

$(document).ready(function() {
    var  table = $('#example').DataTable( {
        "bRetrieve": true,
        "scrollY": "350px",
        "paging": false
    } );
 
    $('a.toggle-vis').on( 'click', function (e) {
        e.preventDefault();
 
        // Get the column API object
        var column = table.column( $(this).attr('data-column') );
 
        // Toggle the visibility
        column.visible( ! column.visible() );
    } );
} );
	</script>
	</head>
<body >
  <form id="form1" runat="server"> 
      <div class="navigation">首页 &gt; 数据导出 </div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
                 <span>时间：</span> 
                  <span>
                      <asp:TextBox ID="txtBegindate" onfocus="setday(this)" runat="server" CssClass="txtInput"></asp:TextBox>  
                  </span>                   
                <span>至
                <asp:TextBox ID="txtEnddate" onfocus="setday(this)" runat="server" CssClass="txtInput"></asp:TextBox>
                    </span>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click"/>
		    </div>
        </div>

    </div>
        <div>
				统计参数: <a class="toggle-vis" data-column="0">stcode</a> - <a class="toggle-vis" data-column="1">stname</a> - <a class="toggle-vis" data-column="8">so2</a> -<a class="toggle-vis" data-column="9">no</a> - <a class="toggle-vis" data-column="10">no2</a> - <a class="toggle-vis" data-column="22">dtt</a>
                <br />
			</div>
 <!--列表展示.开始-->
      <asp:CheckBox ID="站点名称" runat="server" />站点名称
      <asp:CheckBox ID="二氧化硫" runat="server" />二氧化硫
      <asp:CheckBox ID="一氧化氮" runat="server" />一氧化氮
      <asp:CheckBox ID="二氧化氮" runat="server" />二氧化氮
      <asp:CheckBox ID="时间" runat="server" />时间

<asp:Repeater ID="rptList" runat="server">
<HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" id="example">
     <thead>
      <tr>
        <th width="12%">stcode</th>
        <th width="8%">stname</th>
        <th style="display:none">yyyy</th>
        <th style="display:none">mm</th>
        <th style="display:none">dd</th>
        <th style="display:none">hh</th>
        <th style="display:none">dwcode</th>
        <th style="display:none">dwname</th>
        <th width="8%">so2</th>
        <th width="8%">no</th>
        <th width="8%">no2</th>
        <th style="display:none">nox</th>
        <th style="display:none">pm10</th>
        <th style="display:none">co</th>
        <th style="display:none">o3</th>
        <th style="display:none">pm25</th>
        <th style="display:none">ws(风速)</th>
        <th style="display:none">wd(风向)</th>
        <th style="display:none">temp(气温)</th>
        <th style="display:none">rh(湿度)</th>
        <th style="display:none">press(风向)</th>
        <th style="display:none">visibility（透明度）（m）</th>       
        <th width="12%">dtt</th>
      </tr>
       </thead>
</HeaderTemplate>
 <ItemTemplate>
      <tr>   
       <%--<td width="6%" align="center"><asp:CheckBox ID="chkId"  runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>--%>
        <%--<td width="12%" align="center"><%#new Eazytec.BLL.exportExcel().GetStationName(Convert.ToString(Eval("stationId")))%></td>--%>
        <td width="12%" align="center"><%#Eval("stcode")%></td>
        <td width="8%" align="center"><%#Eval("stname")%></td>
        <td style="display:none"><%#Eval("yyyy") %></td>
        <td style="display:none"><%#Eval("mm") %></td>
        <td style="display:none"><%#Eval("dd") %></td>
        <td style="display:none"><%#Eval("hh") %></td>
        <td style="display:none"><%#Eval("dwcode")%></td>
        <td style="display:none"><%#Eval("dwname")%></td>
        <td width="8%" align="center"><%#Eval("so2")%></td>  
        <td width="8%" align="center"><%#Eval("no")%></td>
        <td width="8%" align="center"><%#Eval("no2")%></td>
        <td style="display:none"><%#Eval("nox")%></th>
        <td style="display:none"><%#Eval("pm10")%></th>
        <td style="display:none"><%#Eval("co")%></th>
        <td style="display:none"><%#Eval("o3")%></th>
        <td style="display:none"><%#Eval("pm25")%></th>
        <td style="display:none"><%#Eval("ws")%></th>
        <td style="display:none"><%#Eval("wd")%></th>
        <td style="display:none"><%#Eval("temp")%></th>
        <td style="display:none"><%#Eval("rh")%></th>
        <td style="display:none"><%#Eval("press")%></th>
        <td style="display:none"><%#Eval("visibility")%></th>
        <td width="12%" align="center"><%#Eval("dtt")%></td>
      </tr> 
       </ItemTemplate>
    <FooterTemplate>
      <%#rptList.Items.Count == 0 ? "<tr><td align=\"center\" colspan=\"11\">暂无记录</td></tr>" : ""%>
      </table>
    </FooterTemplate>
</asp:Repeater>
      
    </form>
</body>
</html>
