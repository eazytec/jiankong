using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data.SqlClient;

namespace DTcms.DAL
{
    public partial class device_list
    {
        public device_list()
        { }
        #region  Method

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.device model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_device(");
            strSql.Append("device_id,device_name)");
            strSql.Append(" values (");
            strSql.Append("@device_id,@device_name)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {				
					new SqlParameter("@device_id", SqlDbType.NVarChar,50),
					new SqlParameter("@device_name", SqlDbType.NVarChar,100),
		                             };
            parameters[0].Value = model.device_id;
            parameters[1].Value = model.device_name;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,device_id ");
            strSql.Append(" FROM dt_device ");
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
            strSql.Append("select * FROM dt_device");
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
            strSql1.Append("delete from dt_device ");
            strSql1.Append(" where id=@id");
            SqlParameter[] parameters1 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
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

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.device GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,device_id,device_name from dt_device ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.device model = new Model.device();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["device_id"] != null && ds.Tables[0].Rows[0]["device_id"].ToString() != "")
                {
                    model.device_id = ds.Tables[0].Rows[0]["device_id"].ToString();
                }
                if (ds.Tables[0].Rows[0]["device_name"] != null && ds.Tables[0].Rows[0]["device_name"].ToString() != "")
                {
                    model.device_name = ds.Tables[0].Rows[0]["device_name"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.device model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_device set ");
            strSql.Append("device_id=@device_id,");
            strSql.Append("device_name=@device_name");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@device_id", SqlDbType.NVarChar,50),
					new SqlParameter("@device_name", SqlDbType.NVarChar,100),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.device_id;
            parameters[1].Value = model.device_name;
            parameters[2].Value = model.id;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 返回设备编号
        /// </summary>
        public string GetId(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 device_id from dt_device");
            strSql.Append(" where id=" + id);
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            return name;
        }

        /// <summary>
        /// 返回审核状态
        /// </summary>
        public string GetName(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 shenhe_name from dt_device_shenhe");
            strSql.Append(" where id=" + id);
            string name = Convert.ToString(DbHelperSQL.GetSingle(strSql.ToString()));
            if (string.IsNullOrEmpty(name))
            {
                return "";
            }
            return name;
        }
    }
}
