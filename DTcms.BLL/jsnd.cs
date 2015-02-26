using System;
using System.Collections.Generic;
using System.Text;
using DTcms.DBUtility;
using System.Data;


namespace DTcms.BLL
{
    public partial class jsnd  //计算浓度
    {
        public static string jisuannongdu(string date, string siteid)
        {
            string str = "";
            string[] a = new string[7];
            string canshu;
            string avgValue;
            string sql = "select PollutantCode,sum(monValue)/count(*) from Air_1h_2015_Src where TimePoint between '" + date + " 00:00:00' and '" + date + " 23:59:59' group by PollutantCode ";
            string sql1 = "select PollutantCode,sum(monValue)/count(*)from Air_1m_2015_1_Src where TimePoint between '" + date + " 00:00:00' and '" + date + " 00:59:59' group by PollutantCode";
            String sql2 = "select monValue from Air_1d_aqi_2015_Src where TimePoint='" + date + " 00:00:00' and PollutantCode='O3_8h'";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0];
            DataTable dt1 = DbHelperSQL.Query(sql1).Tables[0];
            DataTable dt2 = DbHelperSQL.Query(sql2).Tables[0];

            foreach (DataRow dr1 in dt1.Rows)
            {

                canshu = dr1[0].ToString();

                avgValue = dr1[1].ToString().Substring(0, 5);

                if (canshu == "O3")
                {

                    a[4] = canshu + "," + avgValue;

                }
            }
            avgValue = dt2.Rows[0]["monValue"].ToString().Substring(0, 5);

                a[5] = "O3_8h" + "," + avgValue;
                foreach (DataRow dr in dt.Rows)
                {
                    canshu = dr[0].ToString();
                    avgValue = dr[1].ToString().Substring(0, 5);

                    if (canshu == "SO2")
                    {

                        a[0] = canshu + "," + avgValue;

                    }
                    else if (canshu == "NO2")
                    {

                        a[1] = canshu + "," + avgValue;
                    }
                    else if (canshu == "PM10")
                    {

                        a[2] = canshu + "," + avgValue;

                    }
                    else if (canshu == "CO")
                    {

                        a[3] = canshu + "," + avgValue;
                    }
                    else if (canshu == "PM2.5")
                    {

                        a[6] = canshu + "," + avgValue;
                    }
                }
                str += a[0] + ";" + a[1] + ";" + a[2] + ";" + a[3] + ";" + a[4] + ";" + a[5] + ";" + a[6]+";";
                return str;
            }
        }
    }
