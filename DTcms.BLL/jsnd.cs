using System;
using System.Collections.Generic;
using System.Text;
using DTcms.DBUtility;
using System.Data;


namespace DTcms.BLL
{
   public partial class jsnd  //计算浓度
    {
        public static string jisuannongdu(string date,string siteid) {

            string sql = "select PollutantCode,sum(monValue)/count(*) from Air_1h_2015_Src where stationCode='"+siteid+"' and TimePoint between '" + date + "'+00:00:00 and '" + date + "'+23:59:59  group by PollutantCode ";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            string str="" ;
            foreach (DataRow dr in dt.Rows)
            {
                //String canshu =dr[0].ToString;
               // String avgValue = dr[1].ToString;
                //str+=canshu+","+avgValue+";";
            }
            return str;
        }
    }
}
