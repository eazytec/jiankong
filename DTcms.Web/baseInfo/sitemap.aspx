<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="sitemap.aspx.cs" Inherits="DTcms.Web.baseInfo.sitemap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>设置地图显示范围</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
    <style type="text/css">
        body, html
        {
            width: 100%;
            height: 100%;
            margin: 0;
            font-family: "微软雅黑";
        }
        #allmap
        {
            width: 100%;
            height: 100%;
        }
    </style>
    <%--<script src="js/JScript1.js" type="text/javascript"></script>--%>
    <script src="../js/jquery-1.4.2.js" type="text/javascript"></script>
    <script src="../js/jquery-1.4.2-vsdoc.js" type="text/javascript"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/api?v=2.0&ak=LRIf3Wm64rKhpOXiqHFt3luG"></script>
    <script type="text/javascript" src="http://api.map.baidu.com/library/AreaRestriction/1.2/src/AreaRestriction_min.js"></script>
    <script type="text/javascript" src="http://developer.baidu.com/map/jsdemo/demo/convertor.js"></script>
</head>
<body>
    <div id="allmap">
    </div>
</body>
</html>
<script type="text/javascript">
    $(function () {
    });
    setTimeout('theLocation()', 10000); //指定1秒刷新一次 
    //百度地图API功能	
    var map = new BMap.Map("allmap");

    map.centerAndZoom("宜兴", 13);                    // 初始化地图,设置中心点坐标和地图级别。
    map.setMinZoom(12);
    map.setMaxZoom(18);
    map.enableScrollWheelZoom();                            //启用滚轮放大缩小
    map.addControl(new BMap.NavigationControl());       //添加缩放工具
    map.addControl(new BMap.MapTypeControl());
    theLocation();
    function theLocation() {

        var zhandian = "001$丁蜀镇观测站,002$宜兴观测站,003$芳庄观测站,004$川埠观测站,005$衡山水库,006$楼新桥水库,007$兰山嘴水库,end";
        var Net = zhandian.split(',');

        for (var nIdx = 0; nIdx < Net.length; nIdx++) {

            if (Net[nIdx] != 'end') {
                var zhanhao = Net[nIdx].split('$');

                $.post("../tool/GetZhanDianInfo.ashx", { "siteid": zhanhao[0], "sitename": zhanhao[1] }, function (data) {

                    var s1 = data.split(',');
                    s1[0] = parseFloat(s1[0]);
                    s1[1] = parseFloat(s1[1]);
                    s1[2] = parseFloat(s1[2]);

                    if (s1[4] == '001') {

                        var dzzgcz = "<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">丁蜀镇观测站<br>";

                        if (s1[0] > 2) {
                            dzzgcz += "<span style=\"color:red\">so2:" + s1[0] + "</span></br>";
                        } else {
                            dzzgcz += "<span style=\"color:green\">so2:" + s1[0] + "</span></br>";
                        }

                        if (s1[1] > 2) {
                            dzzgcz += "<span style=\"color:red\">no:" + s1[1] + "</span></br>";
                        } else {
                            dzzgcz += "<span style=\"color:green\">no:" + s1[1] + "</span></br>";
                        }

                        if (s1[2] > 2) {
                            dzzgcz += "<span style=\"color:red\">no2:" + s1[2] + "</span></br>";
                        } else {
                            dzzgcz += "<span style=\"color:green\">no2:" + s1[2] + "</span></br>";
                        }



                        var dzzgczpoint = new BMap.Point(119.794399, 31.274751); //丁蜀镇观测站


                        var markerdzzgcz = new BMap.Marker(dzzgczpoint, {
                            icon: new BMap.Icon("../images/marker_blue_sprite.png", new BMap.Size(20, 25), {
                                anchor: new BMap.Size(10, 25)
                            })
                        });  // 创建标注
                        map.addOverlay(markerdzzgcz);              // 将标注添加到地图中
                        var labeldzzgcz = new BMap.Label("<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">丁蜀镇观测站</a>", { offset: new BMap.Size(20, 0) });
                        labeldzzgcz.setContent(dzzgcz);
                        markerdzzgcz.setLabel(labeldzzgcz);
                        markerdzzgcz.addEventListener("dblclick", function (e) {
                            map.centerAndZoom(e.point, map.getZoom() + 2);
                        });
                    }


                    if (s1[4] == '002') {

                        var yxgcz = "<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">宜兴观测站<br>";

                        if (s1[0] > 2) {
                            yxgcz += "<span style=\"color:red\">so2:" + s1[0] + "</span></br>";
                        } else {
                            yxgcz += "<span style=\"color:green\">so2:" + s1[0] + "</span></br>";
                        }

                        if (s1[1] > 2) {
                            yxgcz += "<span style=\"color:red\">no:" + s1[1] + "</span></br>";
                        } else {
                            yxgcz += "<span style=\"color:green\">no:" + s1[1] + "</span></br>";
                        }

                        if (s1[2] > 2) {
                            yxgcz += "<span style=\"color:red\">no2:" + s1[2] + "</span></br>";
                        } else {
                            yxgcz += "<span style=\"color:green\">no2:" + s1[2] + "</span></br>";
                        }



                        var yxgczpoint = new BMap.Point(119.802626, 31.368905); //宜兴观测站


                        var markeryxgcz = new BMap.Marker(yxgczpoint, {
                            icon: new BMap.Icon("../images/marker_blue_sprite.png", new BMap.Size(20, 25), {
                                anchor: new BMap.Size(10, 25)
                            })
                        });  // 创建标注
                        map.addOverlay(markeryxgcz);              // 将标注添加到地图中
                        var labelyxgcz = new BMap.Label("<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">宜兴观测站</a>", { offset: new BMap.Size(20, 0) });
                        labelyxgcz.setContent(yxgcz);
                        markeryxgcz.setLabel(labelyxgcz);
                        markeryxgcz.addEventListener("dblclick", function (e) {
                            map.centerAndZoom(e.point, map.getZoom() + 2);
                        });
                    }

                    if (s1[4] == '003') {

                        var fzgcz = "<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">芳庄观测站<br>";

                        if (s1[0] > 2) {
                            fzgcz += "<span style=\"color:red\">so2:" + s1[0] + "</span></br>";
                        } else {
                            fzgcz += "<span style=\"color:green\">so2:" + s1[0] + "</span></br>";
                        }

                        if (s1[1] > 2) {
                            fzgcz += "<span style=\"color:red\">no:" + s1[1] + "</span></br>";
                        } else {
                            fzgcz += "<span style=\"color:green\">no:" + s1[1] + "</span></br>";
                        }

                        if (s1[2] > 2) {
                            fzgcz += "<span style=\"color:red\">no2:" + s1[2] + "</span></br>";
                        } else {
                            fzgcz += "<span style=\"color:green\">no2:" + s1[2] + "</span></br>";
                        }


                        var fzgczpoint = new BMap.Point(119.599831, 31.42535); //芳庄观测站


                        var markerfzgcz = new BMap.Marker(fzgczpoint, {
                            icon: new BMap.Icon("../images/marker_blue_sprite.png", new BMap.Size(20, 25), {
                                anchor: new BMap.Size(10, 25)
                            })
                        });  // 创建标注
                        map.addOverlay(markerfzgcz);              // 将标注添加到地图中
                        var labelfzgcz = new BMap.Label("<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">芳庄观测站</a>", { offset: new BMap.Size(20, 0) });
                        labelfzgcz.setContent(fzgcz);
                        markerfzgcz.setLabel(labelfzgcz);
                        markerfzgcz.addEventListener("dblclick", function (e) {
                            map.centerAndZoom(e.point, map.getZoom() + 2);
                        });
                    }

                    if (s1[4] == '004') {

                        var czgcz = "<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">川埠观测站<br>";

                        if (s1[0] > 2) {
                            czgcz += "<span style=\"color:red\">so2:" + s1[0] + "</span></br>";
                        } else {
                            czgcz += "<span style=\"color:green\">so2:" + s1[0] + "</span></br>";
                        }

                        if (s1[1] > 2) {
                            czgcz += "<span style=\"color:red\">no:" + s1[1] + "</span></br>";
                        } else {
                            czgcz += "<span style=\"color:green\">no:" + s1[1] + "</span></br>";
                        }

                        if (s1[2] > 2) {
                            czgcz += "<span style=\"color:red\">no2:" + s1[2] + "</span></br>";
                        } else {
                            czgcz += "<span style=\"color:green\">no2:" + s1[2] + "</span></br>";
                        }


                        var czgczpoint = new BMap.Point(119.844618, 31.295642); //川埠观测站


                        var markerczgcz = new BMap.Marker(czgczpoint, {
                            icon: new BMap.Icon("../images/marker_blue_sprite.png", new BMap.Size(20, 25), {
                                anchor: new BMap.Size(10, 25)
                            })
                        });  // 创建标注
                        map.addOverlay(markerczgcz);              // 将标注添加到地图中
                        var labelczgcz = new BMap.Label("<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">川埠观测站</a>", { offset: new BMap.Size(20, 0) });
                        labelczgcz.setContent(czgcz);
                        markerczgcz.setLabel(labelczgcz);
                        markerczgcz.addEventListener("dblclick", function (e) {
                            map.centerAndZoom(e.point, map.getZoom() + 2);
                        });

                    }

                    if (s1[4] == '005') {

                        var hssk = "<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">衡山水库<br>";

                        if (s1[0] > 2) {
                            hssk += "<span style=\"color:red\">so2:" + s1[0] + "</span></br>";
                        } else {
                            hssk += "<span style=\"color:green\">so2:" + s1[0] + "</span></br>";
                        }

                        if (s1[1] > 2) {
                            hssk += "<span style=\"color:red\">no:" + s1[1] + "</span></br>";
                        } else {
                            hssk += "<span style=\"color:green\">no:" + s1[1] + "</span></br>";
                        }

                        if (s1[2] > 2) {
                            hssk += "<span style=\"color:red\">no2:" + s1[2] + "</span></br>";
                        } else {
                            hssk += "<span style=\"color:green\">no2:" + s1[2] + "</span></br>";
                        }



                        var hsskpoint = new BMap.Point(119.915884, 31.319066); //衡山水库


                        var markerhssk = new BMap.Marker(hsskpoint, {
                            icon: new BMap.Icon("../images/marker_blue_sprite.png", new BMap.Size(20, 25), {
                                anchor: new BMap.Size(10, 25)
                            })
                        });  // 创建标注
                        map.addOverlay(markerhssk);              // 将标注添加到地图中
                        var labelhssk = new BMap.Label("<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">衡山水库</a>", { offset: new BMap.Size(20, 0) });
                        labelhssk.setContent(hssk);
                        markerhssk.setLabel(labelhssk);
                        markerhssk.addEventListener("dblclick", function (e) {
                            map.centerAndZoom(e.point, map.getZoom() + 2);
                        });
                    }

                    if (s1[4] == '006') {

                        var lxqsk = "<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">楼新桥水库<br>";

                        if (s1[0] > 2) {
                            lxqsk += "<span style=\"color:red\">so2:" + s1[0] + "</span></br>";
                        } else {
                            lxqsk += "<span style=\"color:green\">so2:" + s1[0] + "</span></br>";
                        }

                        if (s1[1] > 2) {
                            lxqsk += "<span style=\"color:red\">no:" + s1[1] + "</span></br>";
                        } else {
                            lxqsk += "<span style=\"color:green\">no:" + s1[1] + "</span></br>";
                        }

                        if (s1[2] > 2) {
                            lxqsk += "<span style=\"color:red\">no2:" + s1[2] + "</span></br>";
                        } else {
                            lxqsk += "<span style=\"color:green\">no2:" + s1[2] + "</span></br>";
                        }



                        var lxqskpoint = new BMap.Point(119.585816, 31.207889); //楼新桥水库


                        var markerlxqsk = new BMap.Marker(lxqskpoint, {
                            icon: new BMap.Icon("../images/marker_blue_sprite.png", new BMap.Size(20, 25), {
                                anchor: new BMap.Size(10, 25)
                            })
                        });  // 创建标注
                        map.addOverlay(markerlxqsk);              // 将标注添加到地图中
                        var labellxqsk = new BMap.Label("<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">楼新桥水库</a>", { offset: new BMap.Size(20, 0) });
                        labellxqsk.setContent(lxqsk);
                        markerlxqsk.setLabel(labellxqsk);
                        markerlxqsk.addEventListener("dblclick", function (e) {
                            map.centerAndZoom(e.point, map.getZoom() + 2);
                        });
                    }

                    if (s1[4] == '007') {

                        var sszsk = "<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">兰山嘴水库<br>";

                        if (s1[0] > 2) {
                            sszsk += "<span style=\"color:red\">so2:" + s1[0] + "</span></br>";
                        } else {
                            sszsk += "<span style=\"color:green\">so2:" + s1[0] + "</span></br>";
                        }

                        if (s1[1] > 2) {
                            sszsk += "<span style=\"color:red\">no:" + s1[1] + "</span></br>";
                        } else {
                            sszsk += "<span style=\"color:green\">no:" + s1[1] + "</span></br>";
                        }

                        if (s1[2] > 2) {
                            sszsk += "<span style=\"color:red\">no2:" + s1[2] + "</span></br>";
                        } else {
                            sszsk += "<span style=\"color:green\">no2:" + s1[2] + "</span></br>";
                        }



                        var sszskpoint = new BMap.Point(119.849463, 31.258104); //兰山嘴水库


                        var markersszsk = new BMap.Marker(sszskpoint, {
                            icon: new BMap.Icon("../images/marker_blue_sprite.png", new BMap.Size(20, 25), {
                                anchor: new BMap.Size(10, 25)
                            })
                        });  // 创建标注
                        map.addOverlay(markersszsk);              // 将标注添加到地图中
                        var labelsszsk = new BMap.Label("<a href=\"../baojing/baojing_list.aspx\" style=\"text-decoration:none\">兰山嘴水库</a>", { offset: new BMap.Size(20, 0) });
                        labelsszsk.setContent(sszsk);
                        markersszsk.setLabel(labelsszsk);
                        markersszsk.addEventListener("dblclick", function (e) {
                            map.centerAndZoom(e.point, map.getZoom() + 2);
                        });
                    }
                }
)
            };
        }
    }

</script>

