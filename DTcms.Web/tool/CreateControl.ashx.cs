using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTcms.DBUtility;
using System.Data;
using System.Web.Script.Serialization;

namespace DTcms.Web.tool
{
    /// <summary>
    /// CreateControl 的摘要说明
    /// </summary>
    public class CreateControl : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            int num = 0;
            string ifram = "<table id='tb' style='width:100%;font-size:12px;' >";
            string sql = "select stationId,stationName from dbo.stationInfo ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            if (dt.Rows.Count > 4)
            {
                for (int i = 0; i < dt.Rows.Count/4; i++)
                {
                    ifram += "<tr>";
                    for (int j =0; j < 4; j++)
                    {
                        ifram += "<td><input type='checkbox'  onchange='tanchuang("+ dt.Rows[num]["stationId"].ToString() + ")'   value='" + dt.Rows[num]["stationId"].ToString() + "' />" + dt.Rows[num]["stationName"].ToString() + "</td>";
                       //string ss = dt.Rows[num]["stationName"].ToString();
                        num += 1;
                    }
                    ifram += "</tr>";
                }
                if (dt.Rows.Count % 4 > 0)
                {
                    ifram += "<tr>";
                    for (int m = 0; m < dt.Rows.Count % 4; m++)
                    {
                        ifram += "<td><input type='checkbox'  onchange='tanchuang(" + dt.Rows[num]["stationId"].ToString() + ")'  value='" + dt.Rows[num]["stationId"].ToString() + "' />" + dt.Rows[num]["stationName"].ToString() + "</td>";
                       //string ss = dt.Rows[num]["stationName"].ToString();
                        num += 1;
                    }
                    ifram += "</tr>";
                }
            }

            context.Response.Write(new JavaScriptSerializer().Serialize(ifram));
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