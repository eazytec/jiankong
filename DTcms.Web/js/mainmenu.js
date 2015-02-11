var flag = false;
var hideflag = false;

function hidemenu2() {

    if (parent.allmid.oa_frame.cols == "0,11,*,0") {
        parent.allmid.oa_frame.cols = "180,11,*,0";
    }
    else {
        parent.allmid.oa_frame.cols = "0,11,*,0";
    }
    //  div2.style.display="none";
}

function yewu(num) {
    //基础
    if (num == 02) {  //小流域基本信息管理
        var s = shyj_top.HaveQX("110102");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_xlygl/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 101) {  //河道基本情况信息管理
        var s = shyj_top.HaveQX("110103");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_hdjbqk/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 102) {  //水库基本情况信息管理
        var s = shyj_top.HaveQX("110104");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_skjbqk/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 03) {  //县乡村基本情况信息管理
        var s = shyj_top.HaveQX("110105");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_xxcjbqkgl/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 04) {  //雨量站站点信息管理
        //        parent.bodyFrame.location.href='jcxx_yljcz/body.aspx'
        var s = shyj_top.HaveQX("110106");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_yljcz/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 05) {  //水位站站点信息管理
        var s = shyj_top.HaveQX("110107");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_swjcz/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 06) {  //预案管理
        var s = shyj_top.HaveQX("110108");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_ya/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 07) {  //历史灾害信息
        //        var s = shyj_top.HaveQX("110109");
        //        if (s.value == 1)
        //        {
        //          parent.bodyFrame.location.href=''
        //        }
        //        else
        //        {
        //          alert('您没有操作权限！！');
        //        }
    }
    if (num == 08) {  //工情信息管理
        //        var s = shyj_top.HaveQX("110110");
        //        if (s.value == 1)
        //        {
        //          parent.bodyFrame.location.href=''
        //        }
        //        else
        //        {
        //          alert('您没有操作权限！！');
        //        }
    }
    //水雨情监测、查询
    if (num == 11) {  //雨水情报警地图
        var s = shyj_top.HaveQX("110201");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'ysqbj/body_dt.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='ysqbj/body_dt.aspx'
    }
    if (num == 12) {  //实时降雨量地图
        var s = shyj_top.HaveQX("110202");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yqjc_sdylcx/body_dt.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yqjc_sdylcx/body_dt.aspx'
    }
    if (num == 13) {  //时段降雨量查询
        var s = shyj_top.HaveQX("110203");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yqjc_sdylcx/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yqjc_sdylcx/body.aspx'
    }
    if (num == 130) {  //明细降雨量查询
        var s = shyj_top.HaveQX("110204");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jylcx/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='jylcx/body.aspx'
    }
    if (num == 131) {  //时段降雨量对比
        var s = shyj_top.HaveQX("110205");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yqjc_ylfbt/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yqjc_ylfbt/body.aspx'
    }
    if (num == 14) {  //雨量分布图
        var s = shyj_top.HaveQX("110206");
        if (s.value == 1) {
            var s = shyj_top.GetUrl("1");
            parent.bodyFrame.location.href = s.value
        }
        else {
            alert('您没有操作权限！！');
        }
        //        var s = shyj_top.GetUrl("1");
        //        parent.bodyFrame.location.href=s.value
    }
    if (num == 15) {  //河道实时水情地图
        var s = shyj_top.HaveQX("110207");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yqjc_hdsq/body_dt.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yqjc_hdsq/body_dt.aspx'
    }
    if (num == 16) {  //河道时段水情列表
        var s = shyj_top.HaveQX("110208");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yqjc_hdsq/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yqjc_hdsq/body.aspx'
    }
    if (num == 17) {  //水库实时水情地图
        var s = shyj_top.HaveQX("110209");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yqjc_sksq/body_dt.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yqjc_sksq/body_dt.aspx'
    }
    if (num == 18) {  //水库时段水情列表
        var s = shyj_top.HaveQX("110210");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yqjc_sksq/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yqjc_sksq/body.aspx'
    }


    //预警发布
    if (num == 21) {  //防汛部门及人员管理
        var s = shyj_top.HaveQX("110301");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yjfb/body_fxbmjry.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yjfb/body_fxbmjry.aspx'
    }
    if (num == 22) {  //预警信息查询
        var s = shyj_top.HaveQX("110302");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yjfb/body_yjlb.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yjfb/body_yjlb.aspx'
    }
    if (num == 23) {  //预警信息发布
        var s = shyj_top.HaveQX("110303");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yjfb/body_nbyj.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='yjfb/body_nbyj.aspx'
    }

    if (num == 24) {  //预警短信发布
        var s = shyj_top.HaveQX("110303");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yjfb/SendSMS.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }

    //应急响应
    if (num == 31) {  //应急响应工作流程
        var s = shyj_top.HaveQX("110401");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yjxyfw/body_gzlc.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    if (num == 32) {  //应急响应信息查询
        var s = shyj_top.HaveQX("110402");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'yjxyfw/body_xxcx.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }

    //水情预报
    if (num == 41) {
        var s = shyj_top.GetUrl("2");
        window.open(s.value);
    }

    //气象信息
    if (num == 51) {  //
        var s = shyj_top.GetUrl("3");
        window.open(s.value);
    }

    //国土信息
    if (num == 52) {  //
        var s = shyj_top.GetUrl("4");
        window.open(s.value);
    }

    //上级联网
    if (num == 53) {  //
        var s = shyj_top.GetUrl("5");
        window.open(s.value);
    }

    //系统管理

    if (num == 69) {  //参数设置
        var s = shyj_top.HaveQX("110101");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcsz/body.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }

    if (num == 61) {  //菜单
        var s = shyj_top.HaveQX("119901");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'qxsz/body_cd.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='qxsz/body_cd.aspx'
    }
    
    if (num == 62) {  //手动录入雨量信息
        var s = shyj_top.HaveQX("110211");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_yljcz/rightbody_rgylsjlr.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
        //        parent.bodyFrame.location.href='jcxx_yljcz/rightbody_rgylsjlr.aspx'
    }
    
    if (num == 63) {  //站点雨量数据删除
        var s = shyj_top.HaveQX("119901");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'jcxx_yljcz/body_scsj.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }
    }
    
    if (num == 64) {  //站点电压管理
        parent.bodyFrame.location.href = 'qxsz/body_dy.aspx'
    }
    
    if (num == 65) {  //操作日志
        var s = shyj_top.HaveQX("119902");
        if (s.value == 1) {
            parent.bodyFrame.location.href = 'qxsz/SysLogsList.aspx'
        }
        else {
            alert('您没有操作权限！！');
        }

    }
    
    if (num == 66) {  //密码修改
        parent.bodyFrame.location.href = 'qxsz/ChangePassWord.aspx'
    }
}

function exitsys() {
    window.open('default.aspx', '登录');
    window.opener = null;
    window.parent.close();
}

function sysset() {
    parent.allmid.location = "mainpage.aspx";
}

function wininit() {
    document.getElementById('Td11').style.width = (window.screen.availWidth - 732) / 2;
    document.getElementById('Td22').style.width = (window.screen.availWidth - 732) / 2;
}




function dis(x) {
    if (x == "t1") {
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";

    }
    else if (x == "t2") {
        document.getElementById("t1").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";

    }
    else if (x == "t3") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";

    }
    else if (x == "t4") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";
    }
    else if (x == "t5") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";
    }
    else if (x == "t6") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";

    }
    else if (x == "t7") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";

    }
    else if (x == "t8") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";

    }
    else if (x == "t9") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t10").background = "";
        document.getElementById("t11").background = "";

    }
    else if (x == "t10") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";
        document.getElementById("t11").background = "";

    }
    else if (x == "t11") {
        document.getElementById("t1").background = "";
        document.getElementById("t2").background = "";
        document.getElementById("t3").background = "";
        document.getElementById("t4").background = "";
        document.getElementById("t5").background = "";
        document.getElementById("t6").background = "";
        document.getElementById("t7").background = "";
        document.getElementById("t8").background = "";
        document.getElementById("t9").background = "";
        document.getElementById("t10").background = "";
        document.getElementById(x).background = "images/dh-bg01.gif";

    }
}