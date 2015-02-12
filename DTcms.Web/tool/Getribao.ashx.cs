using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTcms.Common;
using System.Web.Script.Serialization;
using System.Data;
using DTcms.DBUtility;

namespace DTcms.Web.tool
{
    /// <summary>
    /// Getribao 的摘要说明
    /// </summary>
    public class Getribao : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string siteid = context.Request["siteid"];
            string beginDate = context.Request["beginDate"];
            string endDate = context.Request["endDate"];
            string zc = context.Request["zcc"];
            string SiteHtml = siteid + "§";
            try
            {

                DateTime kDate = DateTime.Parse(beginDate);
                DateTime jDate = DateTime.Parse(endDate);
                //日期循环
                //DateTime endDate = DateTime.Parse(txt2.Text.Trim());
                string sql = "select * from stationInfo where stationId='" + siteid + "' ";

                DataTable ds = DbHelperSQL.Query(sql).Tables[0];

                if (ds.Rows.Count <= 0) SiteHtml = "<br /><br /><span style='color:gray;'>没有找到相关信息！</span><br /><br /><br />";

                SiteHtml += "<table cellpadding='1' border='1' cellspacing='1' style='width:100%;height:100%;BORDER-COLLAPSE:collapse' >";

               while (kDate <= jDate)
               {
               DateTime date = DateTime.Parse(kDate.ToShortDateString());
              
               string convertdate = date.ToString();
               
               string str = BLL.jsnd.jisuannongdu(convertdate, siteid);
              
               string[] strData=str.Split(';');

               if (zc == "1")
               {
                   SiteHtml += "<tr><td style=' text-align:center;' colspan='17'>" + ds.Rows[0]["stationName"].ToString() + "</td></tr>";
                   SiteHtml += "<tr><td style=' text-align:center;'>日期</td><td colspan='2' style=' text-align:center;'>SO2（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>SN2（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>PM10（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>CO（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>O3（最大1小时平均）</td><td colspan='2' style=' text-align:center;'>O3（最大8小时平均）</td><td colspan='2' style=' text-align:center;'>PM2.5（24小时平均浓度）</td></tr>";
               }
               else
               {
                   SiteHtml += "<tr><td style=' text-align:center;' colspan='16'>" + ds.Rows[0]["stationName"].ToString() + "</td></tr>";
                   SiteHtml += "<tr><td colspan='2' style=' text-align:center;'>SO2（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>SN2（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>PM10（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>CO（24小时平均浓度）</td><td colspan='2' style=' text-align:center;'>O3（最大1小时平均）</td><td colspan='2' style=' text-align:center;'>O3（最大8小时平均）</td><td colspan='2' style=' text-align:center;'>PM2.5（24小时平均浓度）</td></tr>";
               } 

                
                for(int i=0;i<strData.Length;i++)
                {
                  string[] singleStrData=strData[i].Split(',');
                  string canshu = singleStrData[0];
                  string nongdu = singleStrData[1];
                }

               kDate = kDate.AddDays(1);
               }

                //string sss = "2";

                if (ds.Rows.Count <= 0) SiteHtml = "<br /><br /><span style='color:gray;'>没有找到相关信息！</span><br /><br /><br />";

                SiteHtml += "<table cellpadding='1' border='1' cellspacing='1' style='width:100%;height:100%;BORDER-COLLAPSE:collapse' >";

                //while (kDate <= jDate)
                //{

                //    DateTime shijiankaishi = kDate;
                //    DateTime shijianjieshu =DateTime.Parse(kDate.ToShortDateString() + " 23:59:59");
                //   kDate = kDate.AddDays(1);
                //}  
                SiteHtml += "</table>";
            }
            catch (System.Exception ex)
            {
                Log.AddLog(AppDomain.CurrentDomain.BaseDirectory + @"\Log\AppErr" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt", "[GetSiteHtml]" + ex.Message, true);
            }
            finally
            {

            }
            //Application[SID] = DateTime.Now.ToString() + "§" + SiteHtml;
            //return Application[SID].ToString();

            context.Response.Write(new JavaScriptSerializer().Serialize(SiteHtml));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}