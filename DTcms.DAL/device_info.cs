using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data.SqlClient;

namespace DTcms.DAL
{
    public partial class device_info
    {
        public device_info()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_device_info");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.device_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_device_info(");
            strSql.Append("install_address,telephone,install_date,install_person,device_ids,shenhe,ph,yangqi)");
            strSql.Append(" values (");
            strSql.Append("@install_address,@telephone,@install_date,@install_person,@device_ids,@shenhe,@ph,@yangqi)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {				
					new SqlParameter("@install_address", SqlDbType.NVarChar,50),
					new SqlParameter("@telephone", SqlDbType.NVarChar,100),
					new SqlParameter("@install_date", SqlDbType.NVarChar,30),
					new SqlParameter("@install_person", SqlDbType.NVarChar,20),
                    new SqlParameter("@ph", SqlDbType.NVarChar,20),
                    new SqlParameter("@yangqi", SqlDbType.NVarChar,20),
					new SqlParameter("@device_ids", SqlDbType.Int,4),
                    new SqlParameter("@shenhe", SqlDbType.Int,4)};
            parameters[0].Value = model.install_address;
            parameters[1].Value = model.telephone;
            parameters[2].Value = model.install_date;
            parameters[3].Value = model.install_person;
            parameters[4].Value = model.ph;
            parameters[5].Value = model.yangqi;
            parameters[6].Value = model.device_ids;
            parameters[7].Value = model.shenhe;

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
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.device_info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_device_info set ");
            strSql.Append("install_person=@install_person,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("install_date=@install_date,");
            strSql.Append("install_address=@install_address,");
            strSql.Append("ph=@ph,");
            strSql.Append("yangqi=@yangqi,");
            strSql.Append("device_ids=@device_ids,");
            strSql.Append("shenhe=@shenhe");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@install_person", SqlDbType.NVarChar,50),
					new SqlParameter("@telephone", SqlDbType.NVarChar,100),
					new SqlParameter("@install_date", SqlDbType.NVarChar,30),
					new SqlParameter("@install_address", SqlDbType.NVarChar,20),
                    new SqlParameter("@ph", SqlDbType.NVarChar,20),
                    new SqlParameter("@yangqi", SqlDbType.NVarChar,20),
					new SqlParameter("@device_ids", SqlDbType.Int,4),
                    new SqlParameter("@shenhe", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.install_person;
            parameters[1].Value = model.telephone;
            parameters[2].Value = model.install_date;
            parameters[3].Value = model.install_address;
            parameters[4].Value = model.ph;
            parameters[5].Value = model.yangqi;
            parameters[6].Value = model.device_ids;
            parameters[7].Value = model.shenhe;
            parameters[8].Value = model.id;
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
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList1(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,shenhe_name ");
            strSql.Append(" FROM dt_device_shenhe ");
           if (strWhere.Trim() != "")
            {
               strSql.Append(" where " + strWhere);
           }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM dt_device_info");
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
        public Model.device_info GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,install_address,install_person,install_date,device_ids,telephone,ph,yangqi from dt_device_info ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.device_info model = new Model.device_info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["install_address"] != null && ds.Tables[0].Rows[0]["install_address"].ToString() != "")
                {
                    model.install_address = ds.Tables[0].Rows[0]["install_address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["telephone"] != null && ds.Tables[0].Rows[0]["telephone"].ToString() != "")
                {
                    model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["install_date"] != null && ds.Tables[0].Rows[0]["install_date"].ToString() != "")
                {
                    model.install_date = ds.Tables[0].Rows[0]["install_date"].ToString();
                }
                if (ds.Tables[0].Rows[0]["install_person"] != null && ds.Tables[0].Rows[0]["install_person"].ToString() != "")
                {
                    model.install_person = ds.Tables[0].Rows[0]["install_person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["device_ids"] != null && ds.Tables[0].Rows[0]["device_ids"].ToString() != "")
                {
                    model.device_ids = int.Parse(ds.Tables[0].Rows[0]["device_ids"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ph"] != null && ds.Tables[0].Rows[0]["ph"].ToString() != "")
                {
                    model.ph = ds.Tables[0].Rows[0]["ph"].ToString();
                }
                if (ds.Tables[0].Rows[0]["yangqi"] != null && ds.Tables[0].Rows[0]["yangqi"].ToString() != "")
                {
                    model.yangqi = ds.Tables[0].Rows[0]["yangqi"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
