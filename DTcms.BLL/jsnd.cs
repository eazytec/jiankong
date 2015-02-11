using System;
using System.Collections.Generic;
using System.Text;
using DTcms.DBUtility;
using System.Data;


namespace DTcms.BLL
{
    class jsnd  //计算浓度
    {
        public static void b(string begindate,string enddate,string canshu) {
            float sum=0;
            int n = 0;
            string sql = "select " + canshu + " from AirIndex where dtt between '" + begindate + "'and '" + enddate + "'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            foreach (DataRow dr in dt.Rows)
            {
                float canshuzhi = float.Parse(dt.Rows[0][canshu].ToString());

                sum = sum + canshuzhi;

                n = n + 1;
            }
            float nongdu = sum / n;
        }
    }
}
