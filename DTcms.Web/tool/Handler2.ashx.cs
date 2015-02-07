using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using DTcms.DBUtility;
using System.Web.Script.Serialization;

namespace DTcms.Web.tool
{
    /// <summary>
    /// Handler2 的摘要说明
    /// </summary>
    public class Handler2 : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {

            context.Response.ContentType = "text/plain";

            string siteid = context.Request["siteid"];

            string FrameHtml = "";

            try
            {

                string sql = "select stationId from stationInfo ";
                DataTable dt =  DbHelperSQL.Query(sql).Tables[0];
                string m_Res = "";
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_Res += dt.Rows[i]["stationId"].ToString();
                    if (i < dt.Rows.Count - 1) m_Res += ",";

                }
                if (m_Res == "") FrameHtml = "";
                string[] m_List = m_Res.Split(',');

                for (int i = 0; i < m_List.Length; i++)
                {
                    FrameHtml += m_List[i];
                    if (i < m_List.Length - 1) FrameHtml += ";";
                }
                FrameHtml += "§";
                FrameHtml += "<table border='0' cellspacing='2' cellpadding='2' style='width:100%;' class='tbl2'>";
                for (int i = 0; i < m_List.Length; i++)
                {
                    if ((i + 1) % 4 == 1) FrameHtml += "<tr valign='top'>";
                    FrameHtml += "<td align='center' style='width:25%' id='Site";
                    FrameHtml += m_List[i];
                    FrameHtml += "' class='tbl1'><br /><br /><span style='color:gray;'>　正在获取数据，请稍候......　</span><br /><br /><br /></td>";
                    if ((i + 1) % 4 == 0) FrameHtml += "</tr>";

                }
                int num = m_List.Length % 4;
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