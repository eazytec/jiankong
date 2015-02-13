<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="site_edit.aspx.cs" Inherits="DTcms.Web.siteinfo.site_edit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>编辑站点信息</title>
    <link href="../scripts/ui/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery-1.3.2.min.js"></script>
    <link href="../admin/images/style.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../scripts/jquery/jquery.form.js"></script>
    <script type="text/javascript" src="../scripts/jquery/jquery.validate.min.js"></script>
    <script type="text/javascript" src="../scripts/jquery/messages_cn.js"></script>
    <script type="text/javascript" src="../scripts/ui/js/ligerBuild.min.js"></script>
    <script type="text/javascript" src="../js/function.js"></script>
    <script src="../js/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    <script type="text/javascript">
        //表单验证
        $(function () {
            $("#form1").validate({KJ
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
    <div class="navigation">
        <a href="javascript:history.go(-1);" class="back">后退</a>首页 &gt; 站点管理 &gt; 编辑站点信息</div>
    <div id="contentTab">
        <div class="tab_con" style="display: block;">
            <table class="form_table">
                <col width="150px">
                <col>
                <tbody>
                    <tr>
                        <th>
                            站点编号：
                        </th>
                        <td>
                            <asp:TextBox ID="txtStationId" runat="server" CssClass="txtInput normal" minlength="2"
                                MaxLength="100" />
                        </td>
                    </tr>
                    <tr>
                        <th>
                            站点名称：
                        </th>
                        <td>
                            <asp:TextBox ID="txtStationName" runat="server" CssClass="txtInput normal" MaxLength="255"></asp:TextBox><label></label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            站点类型：
                        </th>
                        <td>
                            <asp:TextBox ID="txtStationType" runat="server" CssClass="txtInput normal " MaxLength="50"></asp:TextBox><label></label>
                        </td>
                    </tr>
                    <tr>
                        <th>
                            创建时间:
                        </th>
                        <td>
                            <asp:TextBox ID="txtCreateTime" runat="server" CssClass="txtInput normal " MaxLength="50" onclick="WdatePicker()"></asp:TextBox><label></label>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="foot_btn_box">
            <asp:Button ID="btnSubmit" runat="server" Text="提交保存" CssClass="btnSubmit" OnClick="btnSubmit_Click" />
            &nbsp;<input name="重置" type="reset" class="btnSubmit" value="重 置" />
        </div>
    </div>
    </form>
</body>
</html>
