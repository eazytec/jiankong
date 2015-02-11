using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Linq;
using DTcms.DBUtility;

namespace DTcms.web.tool
{
    /// <summary>
    /// $codebehindclassname$ 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class GetZhanDianInfo : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string siteid=context.Request["siteid"];
            string sql = "select * from AirIndex where stationId='" + siteid + "'";

            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            string zifuchuan = dt.Rows[0]["so2"].ToString() + "," + dt.Rows[0]["no"].ToString() + "," + dt.Rows[0]["no2"].ToString() + "," + dt.Rows[0]["dtt"].ToString()+ "," + dt.Rows[0]["stationId"].ToString();
            context.Response.Write(zifuchuan);
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
