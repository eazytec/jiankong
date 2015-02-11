using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data.SqlClient;

namespace DTcms.DAL
{
    public partial class exportExcel
    {
      
        public exportExcel() { }

        /// <summary>
        /// 获得查询数据
        /// </summary>
        public DataSet GetList(string strWhere,string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM AirIndex");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }    
            return DbHelperSQL.Query( strSql.ToString());
        }

        /// <summary>
        /// 返回站点名称
        /// </summary>
        public string GetStationName(string id)
        {
            
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select stationName from stationInfo");
            strSql.Append(" where stationId=" + id);
            String stationName = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            return stationName;
        }


        ///<summary>
        ///导出EXCEL
        ///</summary>
        public DataSet GetExcelList(string sql) {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(sql);
            return DbHelperSQL.Query(strSql.ToString());   
        }

    }
}