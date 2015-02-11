using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data.SqlClient;

namespace DTcms.DAL
{
        public partial class monitoring_site
        {
            public monitoring_site()
            { }
            #region  Method
            /// <summary>
            /// 获得前几行数据
            /// </summary>
            public DataSet GetList(int Top, string strWhere, string filedOrder)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select");
                if (Top > 0)
                {
                    strSql.Append(" top " + Top.ToString());
                }
                strSql.Append(" id,place_name ");
                strSql.Append(" FROM dt_monitoring_site_info ");
                //if (strWhere.Trim() != "")
                //{
                //    strSql.Append(" where " + strWhere);
                //}
                strSql.Append(" order by " + filedOrder);
                return DbHelperSQL.Query(strSql.ToString());
            }
            /// <summary>
            /// 获得查询分页数据
            /// </summary>
            public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select * FROM dt_monitoring_site");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
                return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
            }
            #endregion  Method

            /// <summary>
            /// 删除一条数据
            /// </summary>
            public bool Delete(int id)
            {
                List<CommandInfo> sqllist = new List<CommandInfo>();         
                //删除监测点信息
                StringBuilder strSql1 = new StringBuilder();
                strSql1.Append("delete from dt_monitoring_site ");
                strSql1.Append(" where id=@id");
                SqlParameter[] parameters1 = {
					new SqlParameter("@id",SqlDbType.Int,4)};
                parameters1[0].Value = id;
                CommandInfo cmd = new CommandInfo(strSql1.ToString(), parameters1);
                sqllist.Add(cmd);
                int rowsAffected = DbHelperSQL.ExecuteSqlTran(sqllist);
                if (rowsAffected > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
}
