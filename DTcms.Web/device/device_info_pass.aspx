<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="device_info_pass.aspx.cs" Inherits="DTcms.Web.device.device_info_pass" %>
<%@ Import namespace="DTcms.Common" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>设备信息</title>
<link href="../admin/images/style.css" rel="stylesheet" type="text/css" />
<link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
<script src="../admin/js/function.js" type="text/javascript"></script>
<script src="/Calendar/JS/calendar2.js" type="text/javascript"></script>
</head>
<body class="mainbody">
    <form id="form1" runat="server">
    <div class="navigation">首页 &gt; 设备信息</div>
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
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="timeSearch_Click"/>
		    </div>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
        </div>
        <!--
        <div class="select_box">
            请选择: <asp:DropDownList ID="ddlDeviceIds" runat="server" CssClass="select2" AutoPostBack="True" onselectedindexchanged="ddlSewageId_SelectedIndexChanged"></asp:DropDownList>&nbsp;	                      
        </div>
        -->
    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server">
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">选择</th>
        <th width="12%" align="left">余氯</th>
        <th width="12%" align="left">浊度</th>
        <th width="8%">液位</th>
        <th width="8%">COD</th>
        <th width="8%">PH值</th>
        <th width="8%">氧气</th>
        <th width="8%">状态</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td width="6%" align="center"><asp:CheckBox ID="CheckBox1" CssClass="checkall" runat="server" /><asp:HiddenField ID="HiddenField1" Value='<%#Eval("id")%>' runat="server" /></td>
        <td width="12%" align="left"><%#Eval("install_address")%></td>
        <td width="12%" align="left"><%#Eval("telephone")%></td>       
        <td width="8%" align="center"><%#Eval("install_date")%></td>       
        <td width="8%" align="center"><%#Eval("install_person")%></td>
        <td width="8%" align="center"><%#Eval("ph")%></td>
        <td width="8%" align="center"><%#Eval("yangqi")%></td>
        <td width="8%" align="center"><%#new DTcms.BLL.device_list().GetName(2)%></td>
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

