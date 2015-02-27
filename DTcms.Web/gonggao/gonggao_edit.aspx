<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gonggao_edit.aspx.cs" Inherits="DTcms.Web.gonggao.gonggao_edit" %>
<%@ Import namespace="DTcms.Common"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<title>编辑公告信息</title>
<link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
<link href="../admin/images/style.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../scripts/jquery/jquery.form.js"></script>
<script type="text/javascript" src="../scripts/jquery/jquery.validate.min.js"></script> 
<script type="text/javascript" src="../scripts/jquery/messages_cn.js"></script>
<script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
<script type="text/javascript" src="../js/function.js"></script>
<script type="text/javascript" src="../js/WdatePicker.js"></script>

<script type="text/javascript">
    //表单验证
    $(function () {
        $("#form1").validate({
            invalidHandler: function (e, validator) {
                parent.jsprint("有 " + validator.numberOfInvalids() + " 项填写有误，请检查！", "", "Warning");
            },
            errorPlacement: function (lable, element) {
                //可见元素显示错误提示
                if (element.parents(".tab_con").css('display') != 'none') {
                    element.ligerTip({ content: lable.html(), appendIdTo: lable });
                }
            },
            rules: {
                txtUserName: {
                    required: true,
                    minlength: 2,
                    maxlength: 100,
                    remote: {
                        type: "post",
                        url: "../tools/admin_ajax.ashx?action=validate_username",
                        data: {
                            username: function () {
                                return $("#txtUserName").val();
                            },
                            oldusername: function () {
                                return $("#hidUserName").val();
                            }
                        },
                        dataType: "html",
                        dataFilter: function (data, type) {
                            if (data == "true")
                                return true;
                            else
                                return false;
                        }
                    }
                }
            },
            success: function (lable) {
                lable.ligerHideTip();
            },
            messages: {
                txtUserName: {
                    required: "输入(2-100)位字符",
                    minlength: "必须大于2位字符",
                    maxlength: "必须小于100位字符",
                    remote: "抱歉，该用户名不可用"
                }
            }
        });
    });
</script>
</head>
<body class="mainbody">
<form id="form1" runat="server">
<div class="navigation"><a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 公告管理 &gt; 编辑公告信息</div>
<div id="contentTab">
<%--    <ul class="tab_nav">
        <li class="selected"><a onclick="tabs('#contentTab',0);" href="javascript:;">基本信息</a></li>
        <li><a onclick="tabs('#contentTab',1);" href="javascript:;">账户信息</a></li>
    </ul>--%>

    <div class="tab_con" style="display:block;">
        <table class="form_table">
            <col width="150px"><col>
            <tbody>
            <tr>
                <th>标 题：</th>
                <td>               
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="txtInput normal" minlength="2" maxlength="100" />
                </td>
            </tr>
            <tr>
                <th>内 容：</th>
                <td><asp:TextBox ID="txtContent" runat="server" CssClass="small"  TextMode="MultiLine" maxlength="255"></asp:TextBox><label></label></td>
            </tr>
            <tr>
                <th>公告人：</th>
                <td><asp:TextBox ID="txtName" runat="server" CssClass="txtInput normal " maxlength="50"></asp:TextBox><label></label></td>
            </tr>
            </tbody>
        </table>
    </div>

    <div class="foot_btn_box">
    <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" onclick="btnSubmit_Click" />
    &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
    </div>
</div>
</form>
</body>
</html>
