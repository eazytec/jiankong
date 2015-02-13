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

            string sql = "select PollutantCode,sum(monValue)/count(*) from Air_1h_2015_Src where TimePoint between '" + date + " 00:00:00' and '" + date + " 23:59:59' group by PollutantCode ";
            //string sql1="select pollutantCode,sum(monValue)/count(*)from Air_1m_2015_2_Src  TimePoint between '
            //String sql2="select pullutantCode,from Air_1m_2015_  where"
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
           // DataTable dt1=DbHelperSQL.Query(sql1).Tables[0];
           // DataTable dt2=DbHelperSQL.Query(sql2).Tables[0];
            string str = "";
            foreach (DataRow dr in dt.Rows)
            {
                string canshu = dr[0].ToString();
                string avgValue = dr[1].ToString().Substring(0,4);
                str+=canshu+","+avgValue+";";
            }
            return str;
        }
    }
}
