// JScript 文件

var gdCtrl = new Object();
var goSelectTag = new Array();
var gcGray ="#f040c0";// "#83E9B8";
var gcToggle = "#E983E3";
var gcBG ="#f7f7f7";// "#C193BE";//

var gdCurDate = new Date();
var giYear = gdCurDate.getFullYear();
var giMonth = gdCurDate.getMonth()+1;
var giDay = gdCurDate.getDate();
var giHour = gdCurDate.getHours();
var giMinute = gdCurDate.getMinutes();
var giSecond = gdCurDate.getSeconds();

function fPopCalendar(popCtrl, dateCtrl)
{
event.cancelBubble=true;
gdCtrl = dateCtrl;
fSetYearMon(giYear, giMonth);
var point = fGetXY(popCtrl);
with (VicPopCal.style)
{
left = point.x+5+5;
top = point.y+popCtrl.offsetHeight+45+1;//+1+5;
width = VicPopCal.offsetWidth;
height = VicPopCal.offsetHeight;
fToggleTags(point);
visibility = 'visible';
}
VicPopCal.focus();
}

function fSetDate(iYear, iMonth, iDay,iHour,iMinute,iSecond)
{
var sYear = "";
var sMonth = "";
var sDay = "";
var sHour = "";
var sMinute = "";
var sSecond = "";

sYear = iYear;
if(iMonth < 10)
sMonth = "0" + iMonth;
else
sMonth = iMonth;
if(iDay < 10)
sDay = "0" + iDay;
else
sDay = iDay;
if(iHour < 10)
sHour = "0" + iHour;
else
sHour = iHour;
if(iMinute < 10)
sMinute = "0" + iMinute;
else
sMinute = iMinute;
if(iSecond < 10)
sSecond = "0" + iSecond;
else
sSecond = iSecond; 
//这里处理数值
var fs=0;//0:yyyy-mm-dd; 1:yyyy-mm; 2:yyyy
if (gdCtrl.FormatType) {fs=parseInt(gdCtrl.FormatType);}
  switch (fs)
  {
    case 0:{dReturnValue=sYear+"-"+sMonth+"-"+sDay;break;}
    case 1:{dReturnValue=sYear+"-"+sMonth;break;}
    case 2:{dReturnValue=sYear;break;}
  }

//返回结果
gdCtrl.value = dReturnValue; 
//Here, you could modify the locale as you need !!!!
fHideCalendar();
}

function fHideCalendar()
{
VicPopCal.style.visibility = "hidden";
for (i in goSelectTag)
goSelectTag[i].style.visibility = "visible";
goSelectTag.length = 0;
}

function fSetSelected(aCell)
{
var iOffset = 0;
var iYear = parseInt(tbSelYear.value);
var iMonth = parseInt(tbSelMonth.value);

aCell.bgColor = gcBG;
with (aCell.children["cellText"])
{
var iDay = parseInt(innerText);
if (color==gcGray)
iOffset = (Victor<10)?-1:1;
iMonth += iOffset;
if (iMonth<1)
{
iYear--;
iMonth = 12;
}
else if (iMonth>12)
{
iYear++;
iMonth = 1;
}
}
fSetDate(iYear, iMonth, iDay, giHour,giMinute,giSecond);
}

function Point(iX, iY)
{
this.x = iX;
this.y = iY;
}

function fBuildCal(iYear, iMonth)
{
var aMonth=new Array();
for(i=1;i<7;i++)
{
aMonth[i]=new Array(i);
}

var dCalDate=new Date(iYear, iMonth-1, 1);
var iDayOfFirst=dCalDate.getDay();
var iDaysInMonth=new Date(iYear, iMonth, 0).getDate();
var iOffsetLast=new Date(iYear, iMonth-1, 0).getDate()-iDayOfFirst+1;
var iDate = 1;
var iNext = 1;

for (d = 0; d < 7; d++)
{
aMonth[1][d] = (d<iDayOfFirst)?-(iOffsetLast+d):iDate++;
}
for (w = 2; w < 7; w++)
{
for (d = 0; d < 7; d++)
{
aMonth[w][d] = (iDate<=iDaysInMonth)?iDate++:-(iNext++);
}
}
return aMonth;
}

function fDrawCal(iYear, iMonth, iCellHeight, iDateTextSize)
{
var WeekDay = new Array("日","一","二","三","四","五","六");
var styleTD = " bgcolor='"+gcBG+"' bordercolor='"+gcBG+"' valign='middle' align='center' height='"+iCellHeight+"' style='font:bold "+iDateTextSize+" 宋体;border:0px;";

with (document)
{
write("<tr>");
for(i=0; i<7; i++)
{
write("<td "+styleTD+"color:#0000ff' >" + WeekDay[i] + "</td>");
}
for(i=0; i<7; i++)
{
write("<td "+styleTD+"color:#0000ff' >" + WeekDay[i] + "</td>");
}
write("</tr>");

for (w = 1; w < 4; w++)
{
write("<tr>");
for (d = 0; d < 14; d++)
{
write("<td id=calCell "+styleTD+"cursor:hand;' onMouseOver='this.bgColor=gcToggle' onMouseOut='this.bgColor=gcBG' onclick='fSetSelected(this)'>");
write("<font id=cellText Victor='Liming Weng'> </font>");
write("</td>")
}
write("</tr>");
}
}
}

function fUpdateCal(iYear, iMonth)
{
myMonth = fBuildCal(iYear, iMonth);
var i = 0;
for (w = 0; w < 5; w++)
{
  for (d = 0; d < 7; d++)
  {
    with (cellText[(7*w)+d])
    {
      Victor = i++;
      if (myMonth[w+1][d]<0) {
      color = gcGray;
      innerText = -myMonth[w+1][d];
      }else{
      color = ((d==0)||(d==6))?"red":"black";
      innerText = myMonth[w+1][d];
      }
    }
  }
}
}

function fSetYearMon(iYear, iMon)
{
tbSelMonth.options[iMon-1].selected = true;
for (i = 0; i < tbSelYear.length; i++)
{
if (tbSelYear.options[i].value == iYear)
tbSelYear.options[i].selected = true;
}
fUpdateCal(iYear, iMon);
}

function fPrevMonth()
{
var iMon = tbSelMonth.value;
var iYear = tbSelYear.value;

if (--iMon<1)
{
iMon = 12;
iYear--;
}

fSetYearMon(iYear, iMon);
}

function fNextMonth()
{
var iMon = tbSelMonth.value;
var iYear = tbSelYear.value;

if (++iMon>12)
{
iMon = 1;
iYear++;
}

fSetYearMon(iYear, iMon);
}

function fToggleTags()
{
with (document.all.tags("Select"))
{
for (i=0; i<length; i++)
{
if ((item(i).Victor!="Won")&&fTagInBound(item(i)))
{
item(i).style.visibility = "hidden";
goSelectTag[goSelectTag.length] = item(i);
}
}
}
}

function fTagInBound(aTag)
{
with (VicPopCal.style)
{
var l = parseInt(left);
var t = parseInt(top);
var r = l+parseInt(width);
var b = t+parseInt(height);
var ptLT = fGetXY(aTag);
return !((ptLT.x>r)||(ptLT.x+aTag.offsetWidth<l)||(ptLT.y>b)||(ptLT.y+aTag.offsetHeight<t));
}
}

function fGetXY(aTag)
{
var oTmp = aTag;
var pt = new Point(0,0);
do
{
pt.x += oTmp.offsetLeft+0;
pt.y += oTmp.offsetTop-7;
oTmp = oTmp.offsetParent;
} while(oTmp.tagName!="BODY");
return pt;
}

var gMonths = new Array(" 1月"," 2月"," 3月"," 4月"," 5月"," 6月"," 7月"," 8月"," 9月"," 10月","11月","12月");

with (document)
{
//write("<div><iframe>");
write("<Div id='VicPopCal' onclick='event.cancelBubble=true' style='POSITION:absolute;visibility:hidden;border:0px ridge;width:0;z-index:9999;'>");

write("<table border='0' cellspadding='0' cellspacing='0' bgcolor='#f0f0ff' style='border:solid 1px #6699cc;'>");// bgcolor='#6699cc'>");
write("<TR>");
write("<td valign='middle' align='center' onselect='return false'>");
write("<span style='cursor:hand;border:solid 0px;height:16px;font-size:12px;font-weight:bold;' onClick='fPrevMonth()'>＜</span>");
//write("<td valign='middle' align='center'><input type='button' name='PrevMonth' value='<' style='height:20;width:20;FONT:bold' onClick='fPrevMonth()'>");
write(" <Select name='tbSelYear' style='boder:solid 1px;height:10px;font-size:12px;' onChange='fUpdateCal(tbSelYear.value, tbSelMonth.value)' Victor='Won'>");
for(i=1990;i<2051;i++)
{
write("<OPTION value='"+i+"'>"+i+"年</OPTION>");
}
write("</Select>");
write("<select name='tbSelMonth' style='boder:solid 1px;height:10px;font-size:12px;'  onChange='fUpdateCal(tbSelYear.value, tbSelMonth.value)' Victor='Won'>");
for (i=0; i<12; i++)
{
write("<option value='"+(i+1)+"'>"+gMonths[i]+"</option>");
}
write("</Select>");
write("&nbsp;<B style='cursor:hand;font:bold 12 宋体;color:black;' onclick='fSetDate(giYear,giMonth,giDay,giHour,giMinute,giSecond)' onMouseOver='this.style.color=gcToggle' onMouseOut='this.style.color=0'>今天</B>");
write("<span style='cursor:hand;border:solid 0px;height:12px;font-size:12px;font-weight:bold;' onClick='fNextMonth()'>&nbsp;＞</span>");
//write(" <input type='button' name='PrevMonth' value='>' style='height:20;width:20;FONT:bold' onclick='fNextMonth()'>");
write("</td>");
write("</TR><TR>");
write("<td align='center'>");
write("<DIV style='background-color:teal'><table width='100%' border='0' cellspacing='1' cellpadding='0'>");
fDrawCal(giYear, giMonth, 10, 12);
write("</table></DIV>");
write("</td>");
write("</TR><!--<TR><TD align='center'>");
write("<B style='cursor:hand;font:bold 12 宋体' onclick='fSetDate(giYear,giMonth,giDay,giHour,giMinute,giSecond)' onMouseOver='this.style.color=gcToggle' onMouseOut='this.style.color=0'>今天："+giYear+"年"+giMonth+"月"+giDay+"日</B>");
write("</TD></TR>-->");
write("</TABLE></Div>");
//write("</iframe></div>");
write("<SCRIPT event=onclick() for=document>fHideCalendar()</SCRIPT>");
}


//调用
//  Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
//    If Not Page.IsPostBack Then
//      '加载Me.btn1.Attributes.Add("onmouseover", "return fPopCalendar(ddl1,ddl1);")
//    End If
//  End Sub
//  注：ddl1-->TextBox的客户端ID或Input的ID