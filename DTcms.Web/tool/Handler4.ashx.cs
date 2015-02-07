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
    /// Handler4 的摘要说明
    /// </summary>
    public class Handler4 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string siteid = context.Request["siteid"];

            string SiteHtml = siteid + "§";
            try
            {

                string sss = "2";
                string sql = "select * from stationInfo where stationId='" + siteid + "' ";

                DataTable ds = DbHelperSQL.Query(sql).Tables[0]; 

                if (ds.Rows.Count <= 0) SiteHtml = "<br /><br /><span style='color:gray;'>没有找到相关信息！</span><br /><br /><br />";
                string sql2 = "select * from dbo.AirIndex where stationId='" + siteid + "'";

                DataTable dsmeter = DbHelperSQL.Query(sql2).Tables[0]; 

                SiteHtml += "<table border='0' cellpadding='1' cellspacing='1' style='width:100%;height:100%;' >";
                string zifu = dsmeter.Rows[0]["so2"].ToString() + "," + dsmeter.Rows[0]["no"].ToString() + "," + dsmeter.Rows[0]["no2"].ToString() + "," + dsmeter.Rows[0]["co"].ToString() + "," + dsmeter.Rows[0]["o3"].ToString() + "," + dsmeter.Rows[0]["pm25"].ToString() + "," + dsmeter.Rows[0]["ws"].ToString() + "," + dsmeter.Rows[0]["wd"].ToString();
                string[] zifuchuan = zifu.Split(',');
                int count = zifuchuan.Length;
                //添加站点名称
                SiteHtml += "<tr style='height:22px;'>";
                SiteHtml += "<td colspan='2' align='center' class='td1'>";
                SiteHtml = SiteHtml + "<a  class='a1' href='#'>" + ds.Rows[0]["stationName"].ToString() + "</a>(" + siteid + ")</td></tr>";
                //采样时间
                SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'>采样时间</td><td align='left' class='td5'> &nbsp;";
                SiteHtml += Convert.ToString(dsmeter.Rows[0]["dtt"]);
                SiteHtml += "</td></tr>";
                //离线
                DateTime dt = Convert.ToDateTime(dsmeter.Rows[0]["dtt"]);
                int total = (DateTime.Now.Day - dt.Day) * 24 * 60 + (DateTime.Now.Hour - dt.Hour) * 60 + (DateTime.Now.Minute - dt.Minute);
                if (total >= 10 || dt.Year != DateTime.Now.Year || dt.Month != DateTime.Now.Month)
                {
                    SiteHtml = SiteHtml + "<tr><td colspan='2' align='center'class='td8'> <span style=\"color:red ;\">故障报警</span></td></tr>";
                }

                for (int i = 0; i < count; i++)
                {

                    switch (i)
                    {
                        case 0:

                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>二氧化硫</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[0];
                            SiteHtml += "</td></tr>";
                            break;


                        case 1:
                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>一氧化氮</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[1];
                            SiteHtml += "</td></tr>";
                            break;
                        case 2:
                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>二氧化氮</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[2];
                            SiteHtml += "</td></tr>";
                            break;
                        case 3:
                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>一氧化碳</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[3];
                            SiteHtml += "</td></tr>";
                            break;
                        case 4:
                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>臭氧</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[4];
                            SiteHtml += "</td></tr>";
                            break;
                        case 5:
                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>PM2.5</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[5];
                            SiteHtml += "</td></tr>";
                            break;
                        case 6:
                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>风速</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[6];
                            SiteHtml += "</td></tr>";
                            break;
                        case 7:
                            SiteHtml += "<tr><td align='left' style='width:70px;' class='td4'><a href='#'>风向</a></td><td align='left' class='td5'> &nbsp;";
                            SiteHtml += zifuchuan[7];
                            SiteHtml += "</td></tr>";
                            break;

                        default:
                            break;
                    }
                }
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