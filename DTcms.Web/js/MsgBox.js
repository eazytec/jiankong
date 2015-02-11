// JScript 文件

function Msg(MsgText,MsgTitle,MsgW,MsgH)
{ 
  var ppF=parent;
  var msgw,msgh,bordercolor; 
  msgw=500;//提示窗口的宽度 
  msgh=220;//提示窗口的高度 
  if (MsgW!=null) {msgw = parseInt(MsgW);}
  if (MsgH!=null) {msgh = parseInt(MsgH);}
  titleheight=25 //提示窗口标题高度 
  bordercolor="#336699";//提示窗口的边框颜色 
  titlecolor="#99CCFF";//提示窗口的标题颜色 

  var sWidth,sHeight;
  sWidth = document.body.scrollWidth;   //screen.width;//document.body.offsetWidth;
  sHeight = document.body.scrollHeight;// document.body.offsetHeight; //screen.height-190; 
  //覆盖的底部
  var bgObj=document.createElement("div"); 
  bgObj.setAttribute('id','bgDiv'); 
  bgObj.style.position="absolute"; 
  bgObj.style.top="0"; 
  bgObj.style.background="#777"; 
  bgObj.style.filter="progid:DXImageTransform.Microsoft.Alpha(style=3,opacity=25,finishOpacity=75)"; 
  bgObj.style.opacity="0.6"; 
  bgObj.style.left="0"; 
  bgObj.style.width=sWidth + "px"; 
  bgObj.style.height=sHeight + "px"; 
  bgObj.style.zIndex = "10000"; 
  document.body.appendChild(bgObj); 

  //实际的对话框
  var msgObj=document.createElement("div") 
  msgObj.setAttribute("id","msgDiv"); 
  msgObj.setAttribute("align","center"); 
  msgObj.style.background="white"; 
  msgObj.style.border="1px solid " + bordercolor; 
  msgObj.style.position = "absolute"; 
  msgObj.style.left = "50%"; 
  msgObj.style.top = "50%"; 
  msgObj.style.font="12px/1.6em Verdana, Geneva, Arial, Helvetica, sans-serif"; 
  msgObj.style.marginLeft = -225+(500-msgw)*0.5+"px" ;
  msgObj.style.marginTop = document.body.scrollTop-200+"px"; //-75+document.documentElement.scrollTop+(220-msgh)*0.5+"px"; 
  msgObj.style.width = msgw + "px"; 
  msgObj.style.height =msgh + "px"; 
  msgObj.style.textAlign = "center"; 
  msgObj.style.lineHeight ="25px"; 
  msgObj.style.zIndex = "10001"; 
  document.body.appendChild(msgObj); 

  //对话框标题项目
  var titleHtml='<table border="0" cellpadding="0" cellspacing="0" style="font-size:12px;width:100%; height:=100%;">'
  +'<tr valign="middle"><td id="msgContext" align="left" style="font-weight:bold;color:#fff;">'+MsgTitle+'</td>'
  +'<td id="msgClose" align="center" style="color:white;width:46px;cursor:pointer;" title="点这里关闭窗口" onclick="MsgClose();">[关闭]</td></tr></table>'
  var title=document.createElement("h4"); 
  title.setAttribute("id","msgTitle"); 
  title.setAttribute("align","left"); 
  title.style.margin="0"; 
  title.style.padding="2px"; 
  title.style.background=bordercolor; 
  title.style.filter="progid:DXImageTransform.Microsoft.Alpha(startX=20, startY=20, finishX=100, finishY=100,style=1,opacity=75,finishOpacity=100);"; 
  title.style.opacity="0.75"; 
  title.style.border="1px solid " + bordercolor; 
  title.style.height="16px"; 
  title.style.font="12px Verdana, Geneva, Arial, Helvetica, sans-serif"; 
  title.style.color="white";
  title.innerHTML=titleHtml;
//  title.setAttribute("title","点这里关闭窗口"); 
  document.getElementById("msgDiv").appendChild(title); 

  //对话框提示信息部分
  var txt=document.createElement("div"); 
//  txt.style.margin="1em 0" 
  txt.setAttribute("id","msgTxt"); 
  txt.setAttribute("align","center"); 
  txt.setAttribute("valign","top");  
  txt.style.width = "100%"; 
  txt.innerHTML=MsgText; 
  document.getElementById("msgDiv").appendChild(txt); 
} 

function MsgClose()
{
  var bgObj=document.getElementById('bgDiv');
  var title=document.getElementById('msgTitle');
  var msgObj=document.getElementById('msgDiv');
  document.body.removeChild(bgObj);
  document.getElementById("msgDiv").removeChild(title); 
  document.body.removeChild(msgObj); 
}