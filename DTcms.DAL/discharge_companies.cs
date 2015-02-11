using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DTcms.DBUtility;
using System.Data;
using DTcms.Common;

namespace DTcms.DAL
{
    /// <summary>
    /// 排污企业信息
    /// </summary>
    public partial class discharge_companies
    {
        public discharge_companies()
        { }
        #region  Method

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from dt_sewage_companies");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.discharge_companies model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into dt_sewage_companies(");
            strSql.Append("name,address,contact_person,telephone,sewage_id)");
            strSql.Append(" values (");
            strSql.Append("@name,@address,@contact_person,@telephone,@sewage_id)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {				
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@contact_person", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,20),
					new SqlParameter("@sewage_id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.address;
            parameters[2].Value = model.contact_person;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.sewage_id;

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
        public bool Update(Model.discharge_companies model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update dt_sewage_companies set ");
            strSql.Append("name=@name,");
            strSql.Append("address=@address,");
            strSql.Append("contact_person=@contact_person,");
            strSql.Append("telephone=@telephone,");
            strSql.Append("sewage_id=@sewage_id");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@address", SqlDbType.NVarChar,100),
					new SqlParameter("@contact_person", SqlDbType.NVarChar,30),
					new SqlParameter("@telephone", SqlDbType.NVarChar,20),
					new SqlParameter("@sewage_id", SqlDbType.Int,4),
                    new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.name;
            parameters[1].Value = model.address;
            parameters[2].Value = model.contact_person;
            parameters[3].Value = model.telephone;
            parameters[4].Value = model.sewage_id;
            parameters[5].Value = model.id;
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
        /// 得到一个对象实体
        /// </summary>
        public Model.discharge_companies GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,name,address,contact_person,telephone,sewage_id from dt_sewage_companies ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;
            
            Model.discharge_companies model = new Model.discharge_companies();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["address"] != null && ds.Tables[0].Rows[0]["address"].ToString() != "")
                {
                    model.address = ds.Tables[0].Rows[0]["address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["contact_person"] != null && ds.Tables[0].Rows[0]["contact_person"].ToString() != "")
                {
                    model.contact_person = ds.Tables[0].Rows[0]["contact_person"].ToString();
                }
                if (ds.Tables[0].Rows[0]["telephone"] != null && ds.Tables[0].Rows[0]["telephone"].ToString() != "")
                {
                    model.telephone = ds.Tables[0].Rows[0]["telephone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["sewage_id"] != null && ds.Tables[0].Rows[0]["sewage_id"].ToString() != "")
                {
                    model.sewage_id = int.Parse(ds.Tables[0].Rows[0]["sewage_id"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            //先取得用户Model
            Model.discharge_companies model = GetModel(id);
            if (model == null)
            {
                return false;
            }
            List<CommandInfo> sqllist = new List<CommandInfo>();

            //删除排污企业
            StringBuilder strSql5 = new StringBuilder();
            strSql5.Append("delete from dt_sewage_companies ");
            strSql5.Append(" where id=@id");
            SqlParameter[] parameters5 = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters5[0].Value = id;
            CommandInfo cmd = new CommandInfo(strSql5.ToString(), parameters5);
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
            strSql.Append("id,name,address,contract_person,telephone,sewage_id ");
            strSql.Append(" FROM dt_sewage_companies");
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
            strSql.Append("select * FROM dt_sewage_companies");
            //if (strWhere.Trim() != "")
            //{
               // strSql.Append(" where " + strWhere);
            //}
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion Method
    }
}
