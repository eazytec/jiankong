using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;

namespace DTcms.DAL
{
    public partial class baojing
    {
        public baojing()
		{}
        /// <summary>
        /// 返回站点名称
        /// </summary>
        public string GetName(string id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select stationName from stationInfo");
            strSql.Append(" where stationId=" + id);
            String stationName = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            return stationName;
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM AirIndex");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
    }
}
