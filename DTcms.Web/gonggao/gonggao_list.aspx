<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gonggao_list.aspx.cs" Inherits="DTcms.Web.gonggao.gonggao_list" %>
<%@ Import namespace="DTcms.Common"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>公告管理</title>
<link type="text/css" rel="stylesheet" href="../scripts/ui/skins/Aqua/css/ligerui-all.css" />
<link type="text/css" rel="stylesheet" href="../css/pagination.css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
<link href="../admin/images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script src="/Calendar/JS/calendar2.js" type="text/javascript"></script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
    <div class="navigation">首页 &gt; 公告管理 &gt; 公告列表</div>
    <div class="tools_box">
	    <div class="tools_bar">
            <div class="search_box">
            <span>标题</span>
            <span>
            <asp:TextBox ID="txtTitle"  runat="server" CssClass="txtInput"></asp:TextBox>  
            </span>
                 <span>时间：</span> 
                  <span>
                      <asp:TextBox ID="txtBegindate" onfocus="setday(this)" runat="server" CssClass="txtInput"></asp:TextBox>  
                  </span>                   
                <span>至
                <asp:TextBox ID="txtEnddate" onfocus="setday(this)" runat="server" CssClass="txtInput"></asp:TextBox>
                    </span>
                <asp:Button ID="btnSearch" runat="server" Text="搜 索" CssClass="btnSearch" onclick="btnSearch_Click"/>
		    </div>
           <a href="gonggao_edit.aspx?action=<%=DTEnums.ActionEnum.Add %>" class="tools_btn"><span><b class="add">添加公告</b></span></a>
		    <a href="javascript:void(0);" onclick="checkAll(this);" class="tools_btn"><span><b class="all">全选</b></span></a>
            <asp:LinkButton ID="btnDelete" runat="server" CssClass="tools_btn"  
                OnClientClick="return ExePostBack('btnDelete');" onclick="btnDelete_Click"><span><b class="delete">批量删除</b></span></asp:LinkButton>
        </div>

    </div>

    <!--列表展示.开始-->
    <asp:Repeater ID="rptList" runat="server" >
    <HeaderTemplate>
    <table width="100%" border="0" cellspacing="0" cellpadding="0" class="msgtable">
      <tr>
        <th width="6%">选择</th>
        <th width="12%">标题</th>
        <th width="12%" >公告人</th>
        <th width="12%" >公告时间</th>
        <th width="8%">状态</th>
        <th width="6%">操作</th>
      </tr>
    </HeaderTemplate>
    <ItemTemplate>
      <tr>
        <td align="center"><asp:CheckBox ID="chkId" CssClass="checkall" runat="server" /><asp:HiddenField ID="hidId" Value='<%#Eval("id")%>' runat="server" /></td>
        <td align="center"><%#Eval("title")%></td>
        <td align="center"><%#Eval("name")%></td>
        <td align="center"><%#Eval("date")%></td>
        <td align="center"><%#new DTcms.BLL.gonggao().GetStatus(Convert.ToInt32(Eval("status")))%></td>
        <td align="center"><a href="gonggao_edit.aspx?action=<%#DTEnums.ActionEnum.Edit %>&id=<%#Eval("id")%>">修改</a></td>
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
