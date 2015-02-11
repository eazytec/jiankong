﻿var lg={
downMsg:'<br/><br/><h1>帮助</h1>        您可以通过“下载轨迹数据”功能，下载指定设备某一日期内的移动痕迹。<br/><br/>步骤：<br/>1.选择需要下载的指定设备。<br/> 2.输入需要下载的具体日期。<br/> 3.单击“下载KML轨迹文件”按钮。<br/><br/><span style="color:red;">注意：如果单击“下载”按钮， 出现“没有找到有效的轨迹数据!”提示信息，表示当前没有你需要<br/>下载的数据。 </span><br/><br/>        下载的轨迹文件的格式是Google KML格式，如:“文件名.kml”。安装 Google Earth后。双击KML<br/>文件，会通过Google Earth工具打开。<BR/>        "KML轨迹文件"会将设备的移动痕迹以红线动态的描绘在Google地图上。<br/>        <br/><br/>附注:下载 Google Earth 请点击 <a href="http://dl.google.com/earth/client/ge4/release_4_3/googleearth-win-plus-4.3.7284.3916.exe"><font color="blue">这里</font></a> <br/>',
startPk:"开始回放",stop:"停止",bTime:["对不起！本系统暂不提供时间段跨度超过","天以上的统计数据查询！请将查询时间段跨度改为不超过"],playOverTip:["轨迹回放完毕!!时间从 ","到"],totalTime:"总时间",duration:"运行",kPerH:"公里/小时",
//globe
lang:"cn",googleKey:"http://ditu.google.cn/",
lng:"经度",lat:"纬度",latlng:"经纬度",
snew:"新货",skt:"开通",sbk:"退货",swx:"维修",stj:"停机",//销售状态
sdw:"定位状态",sdw0:"未定位",sdw1:"已定位",p:"位置:",//定位状态
srun0:"未上线",srun1:"离线",srun2:"静止",srun3:"行驶",srun4:"快速行驶",srun5:"超速行驶",srun6:"全部",//运行状态
date:"日期",time:"时间",y:"年",d:"天",h:"小时",m:"分",s:"秒",due:"到期时间",serviceYear:"服务年限",saleTime:"销售时间",factoryTime:"出厂日期",activeTime:"开通日期",dwtime:"定位时间",heartTime:"心跳时间",sendtime:"发送时间",utime:"信号时间",
update0:"关闭更新",update1:"打开更新",view:"全景",target:"目标",
mi:"米",km:"公里",

on:"开启",off:"熄火",
msgtit0:"提示",msgtit1:"成功",msgtit2:"失败",//弹出窗口提示信息标题

//loading 信息
updateSuc:"数据更新成功....",subvali:"正在验证.....请等待...",loadfali:"数据加载失败...请重试",fload:"正在加载数据....请稍候",leadin:"正在提交数据.....请等待...",inputName:"请输入您要统计设备的设备名称!",

//tips
ctimetip:"查询的时间跨度不能大于 ",msgcon0:"请选择",msgcon1:"IMEI号输入有误,请输入6位以上数字!!",msgcon2:"请输入要搜索的设备名",
nodata:"没有查询到数据",distime:"开始时间不能大于结束时间",terror:"时间输入有误",//提示信息内容
imeivali:"IMEI号必须是15个字符长度的数字组成",imeitip:'IMEI号必须为15个字符长度的数字,导入多个IMEI号用","号分隔',saleImeiTip:"IMEI号必须是由5-20个字符长度的数字组成",
passvali:"俩次输入的密码不一致,请重新输入",selUTip:"选择客户",fsuc:"以下设备导入成功",pexist:"以下设备已经存在",lfaluler:"IMEI号导入失败....",
companyNameTip:"客户名称必须不能为空白字符",addUsuc:"客户添加<font color=red>成功</font>",logNameVali:"登陆名的第一个字符不能为数字",delSelfTip:"你无权删除你自己的账号",delUTip:"您确定要删除该用户吗？",selectTarget:"请选择设备",selectCustom:"请选择客户",
resetpwdtip:"你确定要重置密码吗？",resetpwdfail:"重置密码失败,请重试.....",userExist:"该登陆名已经存在!请选择其他用户名!",addFali:"数据添加失败",resetpwdsuc:"您现在的密码是",
SimNumTip:"SIM卡号必须为长度小于20位的数字",carNumExistTip:"您输入的车牌号码在系统中已存在，请重新输入",stattip:"请选择里程统计的日期",carNumFormatTip:"车牌号格式错误",dealedtip:"请不要重复处理",
sucpwdtip:"密码已更新",falipwdtip:"密码更新失败!!",sendzltip:"发指令前请再次确认登陆密码",dealedsuc:"报警处理成功",maptip:"Google map暂不支持当前浏览器！",zoomMax:"已经到达最大缩放级别了",

proaccount:"设备登陆号",
product:"产品",client:"客户",type:"类型",sclient:"选中客户",pro:"设备",name:"名称",status:"状态",speed:"速度",account:"设备短号",pimei:"IMEI号",
list:"列表",allp:"所有设备",hidn:"隐藏设备名",shown:"显示设备名",number:"号码",

//button
promanage:"设备管理",add:"新增",manage:"管理",search:"查询",resetPwd:"重置密码",updatepwd:"修改密码",leadin:"导入",delall:"删除所有",del:"删除",areaPlayBack:"区域回放",active:"销售开通",
statLC:"里程统计",statCS:"超速统计",downgj:"下载轨迹",runct:"运行统计",pback:"回 放",track:"跟 踪",searchw:"查询报警记录",zl:"指令",cutyd:"远程断油电",repyd:"远程恢复油电",checkp:"查询定位",checkr:"查询指令记录",simei:"按IMEI号搜",sname:"按设备名搜",addCustom:"新增客户",
ok:"确定",sub:"提交",cancel:"取消",rset:"重置",rload:"重载",searchpro:"设备查询",searchIMEI:"搜 索",sale:"销售",enlarge:"放大地图",clos:"关闭",more:"更多...",

//array
hangxiang: [ "正北向", "北向", "东北向偏北", "东北向", "东北向偏东", "正东向", "东向","东南向偏东", "东南向", "东南向偏南", "正南向", "南向", "西南向偏南", "西南向", "西南向偏西","正西向", "西向", "西北向偏西", "西北向", "西北向偏北" ],
wtype: ["正常","震动报警","断电报警","强行关机报警","SOS求救","超速报警","超速报警","超速报警","超速报警","超速报警"],
backMess :{SEND_SUCCESS:"指令下发成功",SEND_FAIL:"指令下发失败",PWD_ERROR:"密码错误",NOT_CUSTOMER:"客户不存在",USER_LEAVE:"设备离线,不能发指令"},
cmdType :{DWXX:'定位指令',DYD:'断油电指令',HFYD:'恢复油电指令'},
statusType :['网页发出指令','网关收到指令','网关判断不满足发送指令条件','设备不在线','网关发送指令','终端响应指令'],
warnData :[['所有报警', 'ALL'],['震动报警', '1'], ['断电报警', '2'],['低电报警', '3'], ['SOS求救', '4'], ['超速报警', '5']],
warnDealWith :['未处理','已处理'],gradeDate :[['经销商', '4'], ['最终客户', '8']],

//words
stip:"设备IMEI号/设备名",logName:"登陆名",warn:"报警",cmd:"指令",response:"响应",mess:"信息",idle:"停留",sign:"信号",
start:" 开 始：",end:" 结 束：",sarea:"经过区域设备",atit:"区域设置",map:"地图",
owner:"所属客户",platf:"平台费",oney:"一年期",threey:"三年期",otherp:"外挂平台",remark:"备注信息",pwd:"密码",opwd:"旧密码",npwd:"新密码",rpwd:"确认密码",cfirm:"确认",
course:"航向",operate:"操作",warntit:"报警信息报表",leadout:" 导出 ",stattime:"  统计日期  ",tmovement:"总里程(单位:Km)",toverspeed:"总超速次数", mileagetit:"里程统计报表",dealed:"处理",movement:"里程",
viewpos:"查看位置",timelywarntit:"报警信息",icon:"选择图标",format:"格式",phone:"联系电话",contact:"联系人",address:"地址",oSpeed:"超速",updateMsg:"更新信息",
adduwait:"添加客户信息",addutit:"新增客户",cardNum:"卡号",carNum:"车牌号",pCompany:"所属客户",updateUTit:"更新客户信息",grate:"级别",companyName:"客户名称",SuperCustom:"上级客户",tagInfo:"设备信息",tagName:"设备名",cmdDetail:"指令详细信息",inputTip:"请输入设备名/IMEI号"
}