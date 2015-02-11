


function CompactUrlEncode(urlStr)
{
   return urlStr.replace(/&/g,'');
}



function LTrim(str)
{
        var whitespace = new String(" \t\n\r");
        var s = new String(str);
        if (whitespace.indexOf(s.charAt(0)) != -1) 
        {
            var j=0, i = s.length;
            while (j < i && whitespace.indexOf(s.charAt(j)) != -1)
                j++;
            s = s.substring(j, i);
        }
        return s;
}



function RTrim(str)
{       
        var whitespace = new String(" \t\n\r");
        var s = new String(str);
        if (whitespace.indexOf(s.charAt(s.length-1)) != -1) 
        {
            var i = s.length - 1;
            while (i >= 0 && whitespace.indexOf(s.charAt(i)) != -1)
                i--;
            s = s.substring(0, i+1);
        }
        return s;
}



function Trim(str)
{
     return RTrim(LTrim(str));
}



function IsEnglishLetter(objStr,size)   //size('UL','ul':大小写   'U','u':大写    'L','l':小写 
{
    var reg;  
    if(Trim(objStr)=="")
    {
        return false;
    }
    else
    {
        objStr=objStr.toString();
    }   
    if((size==null)||(Trim(size)==""))
    {
        size="UL";
    }
    else
    {
        size=size.toUpperCase();
    }
    switch(size)
    {
        case "UL":
            //大小写
            reg=/^[A-Za-z]+$/;
            break;
        case "U": 
            //大写
            reg=/^[A-Z]+$/;
            break;
        case "L":
            //小写
            reg=/^[a-z]+$/;
            break;
        default:
            alert("检查大小写参数，只可为(空、UL、U、L)");
            return false;
            break;
    } 
    var r=objStr.match(reg);
    if(r==null)
    {
        return false;
    }
    else
    {        
        return true;     
    }
}


function IsFloat(checkedStr)
{
    var no="0123456789.";
    var pointSum1=0;
    var pointSum2=0;    
    var pointSum3=0; 
   
   if(Trim(checkedStr)=="")
    {
       return false;
    }
    
    for(i=0;i<checkedStr.length;i++)
       {          
           if(no.charAt(10)==checkedStr.charAt(i))
               {
                  pointSum1+=1;
               }
        }           
    for(i=0;i<checkedStr.length;i++)
       {
           var checkStr=checkedStr.charAt(i);
           if(no.indexOf(checkStr)==-1 || pointSum1>1)
              {
                 return false;
              }
        }
    for(i=0;i<checkedStr.length;i++)
       {          
           if(no.charAt(10)==checkedStr.charAt(i))
               {
                  pointSum2+=1;
               }
        }           
     for(i=0;i<checkedStr.length;i++)
       {
           var checkStr=checkedStr.charAt(i);
           if(no.indexOf(checkStr)==-1 || pointSum2>1)
              {                 
                 return false;
              }
        }
     for(i=0;i<checkedStr.length;i++)
       {          
           if(no.charAt(10)==checkedStr.charAt(i))
               {
                  pointSum3+=1;
               }
        }           
     for(i=0;i<checkedStr.length;i++)
       {
           var checkStr=checkedStr.charAt(i);
           if(no.indexOf(checkStr)==-1|| pointSum3>1)
              {
                 return false;
              }
        }
        return true;
   }  
   
  
   
   function IsInt(checkedStr)
    {
     // no="0123456789";
      if(checkedStr==null)
         return false;
	  if(Trim(checkedStr)=="")
		 return false;
	  if(checkedStr.charAt(0)=='-' || checkedStr.charAt(0)=='+')
	  {	 
		 if(checkedStr.length>2 && checkedStr.charAt(1)=='0')
				return false;
	     for(i=1;i<checkedStr.length;i++)
		 { 
			if(checkedStr.charAt(i)<'0' || checkedStr.charAt(i)>'9')
				return false;
		 }
	   }
	   else
	   {
			if(checkedStr.length>1 && checkedStr.charAt(0)=='0')
				return false;
	     for(i=0;i<checkedStr.length;i++)
	     {
	       if(checkedStr.charAt(i)<'0' || checkedStr.charAt(i)>'9' )
	         return false;
	     }
	   }
      return true;
    }

   
   
   function IsDigital(digitalStr)
   {
	  if (digitalStr == null) return false;
	  if (digitalStr == "") return false;
	  for (i=0;i<digitalStr.length;i++)
	  {
		  if (digitalStr.charAt(i) < '0' || digitalStr.charAt(i)>'9')
				return false;
	  }
	  return true;
   }
   
   
   
   function IsDateString(dateStr)      //yyyy-mm-dd
   { 
      var iaMonthDays = [31,28,31,30,31,30,31,31,30,31,30,31]
      var iaDate = new Array(3)
      var year, month, day
      if (arguments.length != 1) return false
        iaDate = dateStr.toString().split("-")
      if (iaDate.length != 3) return false
      if (iaDate[1].length > 2 || iaDate[2].length > 2) return false
      
      if (!IsDigital(iaDate[0])) return false
	  if (!IsDigital(iaDate[1])) return false
	  if (!IsDigital(iaDate[2])) return false

      year = parseInt(iaDate[0],10)
      month = parseInt(iaDate[1],10)
      day=parseInt(iaDate[2],10)
      
      if (isNaN(year) || year < 1900 || year > 2100) return false
      if (((year % 4 == 0) && (year % 100 != 0)) || (year % 400 == 0)) iaMonthDays[1]=29;
      if (isNaN(month) || month < 1 || month > 12) return false
      if (isNaN(day) || day < 1 || day > iaMonthDays[month - 1]) return false
      return true;
   } 

   
   
  