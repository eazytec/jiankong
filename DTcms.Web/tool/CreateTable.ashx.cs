using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DTcms.DBUtility;
using System.Data;

namespace DTcms.Web.tool
{
    /// <summary>
    /// CreateTable 的摘要说明
    /// </summary>
    public class CreateTable : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string siteid = context.Request["siteid"];
            string[] siteids = siteid.Split(',');

            string FrameHtml = "";

            try
            {
                if (siteid == "") FrameHtml = "";
                for (int i = 0; i < siteids.Length; i++)
                {
                    FrameHtml += siteids[i];
                    if (i < siteids.Length - 1) FrameHtml += ";";
                }
                FrameHtml += "§";
               
                FrameHtml += "<table border='0' cellspacing='2' cellpadding='0' style='' class='tbl2'>";
                for (int i = 0; i < siteids.Length; i++)
                {
                    if ((i + 1) % 4 == 1) FrameHtml += "<tr valign='top'>";
                    FrameHtml += "<td align='center' style='' id='Site";
                    FrameHtml += siteids[i];
                    FrameHtml += "' class='tbl1'><br /><br /><span style='color:gray;'>　正在获取数据，请稍候......　</span><br /><br /><br /></td>";
                    if ((i + 1) % 4 == 0) FrameHtml += "</tr>";

                }
                int num = siteids.Length % 4;
                num = 4 - num;
                if (num != 4)
                {
                    int i = 0;
                    while (i < num)
                    {
                        FrameHtml += "<td class='tbl1'>&nbsp</td>";
                        i++;
                    }
                    FrameHtml += "</tr>";
                }
                FrameHtml += "</table>";
            }
            catch
            {
            }
            finally
            {

            }




            context.Response.Write(new JavaScriptSerializer().Serialize(FrameHtml));
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