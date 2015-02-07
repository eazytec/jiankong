//定时刷新时间
var stycle=20;
var TimerID=''
function WebInit()
{

    //初始获取查看的基站列表数据并生成框架页
    GetNetFrame('0');
    //获取区域列表数据
  GetAreaList();
    
}

//2.综合数据——获取要查看的基站列表数据并生成框架页
function GetNetFrame(AreaID) {

    $.post("../tool/Handler2.ashx", { "siteid": "061451288780" }, function (data) {
        var dv = document.getElementById('dvColligateData');
      

        if (!data.error) {
            var rs = data.split('§');
            if (rs.length > 1) {
                //得到的是整个页面框架

                dv.innerHTML = rs[1];
                //得到的是这个页面中要显示站点的编号,以 ;  相隔
                form1.NetNo = rs[0];

                GetSiteData();
                //定时器刷新数据
                TimerID = window.setInterval("GetSiteData();", 60000);
            }
            else {
                dv.innerHTML = '';
                form1.NetNo = '';
            }
        }




    }, "json");
   
}



//3.综合数据——根据基站编码获得指定基站的实时监控数据项目（定时器，循环所有基站）
function GetSiteData() {
if (form1.NetNo == '') return;
  var Net=form1.NetNo.split(';');

  for (var nIdx = 0; nIdx < Net.length; nIdx++) {
  $.post("../tool/Handler4.ashx", { "siteid":Net[nIdx]}, pageFinish, "json");
   
  }


 
    

}

 var pageFinish = function(data) {
 
  if (!data.error)
  {
    if (data.length>0)
    {
      var rs=data.split('§');
      if (rs.length==2)
      {
        var dvNet=document.getElementById('Site'+rs[0]);
        if (dvNet) {dvNet.innerHTML='正在获取数据，请稍候...';dvNet.innerHTML=rs[1];}
      }
    }
  }
 
 
 }
function dedaozongjin(res)
{

//alert(res.value);


}

function CallBackSiteData(res)
{
//alert(res.value);
  if (!res.error)
  {
    if (res.value.length>0)
    {
      var rs=res.value.split('§');
      if (rs.length==2)
      {
        var dvNet=document.getElementById('Site'+rs[0]);
        if (dvNet) {dvNet.innerHTML='正在获取数据，请稍候...';dvNet.innerHTML=rs[1];}
      }
    }
  }
}

//4.综合数据——获取区域列表数据
function GetAreaList()
{
  
    var cmb=document.getElementById('cmbArea');
    for (var k=cmb.length-1;k>=0;k--) {cmb.options[k]=null;}
    //cmb.options[cmb.length]=new Option('──选择区域──','');
   // cmb.options[cmb.length]=new Option('所有区域','-1');
 
   
     
          cmb.options[0] = new Option('├ ' + '实时数据','0');
           cmb.options[1] = new Option('├ ' + '指定展示样式','1');
        
          
   
  
}


//5.综合数据——listbox onchange
function AreaList_OnChange(obj)
{
  if(obj=='0')
   {
   GetNetFrame('0');
   }else{
    var dv=document.getElementById('dvColligateData');
     dv.innerHTML="";
   } 
}

//6.打开曲线对话框
function OpenMeterDialog(SiteID,Title,num,Type)
{
//alert(SiteID+"   "+Title+"   "+num+"  "+Type);
  var winWidth='1024px';//screen.availWidth ; 
  var winHeight='768px';//screen.availHeight-20;
  strFeatures="dialogWidth="+winWidth+";dialogHeight="+winHeight+";center=yes;middle=yes;toolbar=no;help=no;status=no;scroll=no"; 
  var url,strReturn; 
  url="MeterDataDialog.aspx?"+"id="+SiteID+"&chl="+num+"&type="+Type+"&strTitle="+Title;   
  //水厂曲线叠加对话框
  url2="MeterScDialog.aspx?"+"id="+SiteID+"&chl="+num; 
  if(SiteID=='D001')if(num==13||num==10){window.showModalDialog(url2,'',strFeatures);return;}
  if(SiteID=='D104')if(num==12){window.showModalDialog(url2,'',strFeatures);return;}
  if(SiteID=='D003'){window.showModalDialog(url2,'',strFeatures);return;}
  if (SiteID == 'X007') if (num == 11 || num == 12||num==8||num==13) { window.showModalDialog(url2, '', strFeatures); return; }
                        
  if(SiteID=='X005'&&num==12){window.showModalDialog(url2,'',strFeatures);return;}
  //if((SiteID=='D001'&&(num==9||num==10))||SiteID=='D003'||(SiteID='X007'&&(num==11||num==12))||(SiteID=='X005'&&num==12))
  //else 
  strReturn=window.showModalDialog(url,'',strFeatures); 

}

