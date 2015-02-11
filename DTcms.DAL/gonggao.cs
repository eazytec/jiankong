using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data.SqlClient;



namespace DTcms.DAL
{
    public partial class gonggao
    {

        public gonggao() { }
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM gonggao");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }



        /// <summary>
        /// 返回状态信息
        /// </summary>
        public string GetStatus(int id)
        {
            String StatusName="";
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select status name from gonggao");
            strSql.Append(" where id=" + id);
            int  status = Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
            if (status==0)
            {
            StatusName="未发布";           
            }else{
                StatusName = "已发布";      
            }
            return StatusName;
        }

        /// <summary>
        /// 获得公告最新一条数据
        /// </summary>
        public DataSet GetGonggaoList(string filedOrder)
        {        
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            strSql.Append("top 1 *");
            strSql.Append(" FROM gonggao");
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Model.gonggao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into gonggao(");
            strSql.Append("title,content,name,date)");
            strSql.Append(" values (");
            strSql.Append("@title,@content,@name,@date)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NVarChar,100),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@date", SqlDbType.DateTime)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.content;
            parameters[2].Value = model.name;
            parameters[3].Value = model.date;


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
        public bool Update(Model.gonggao model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update gonggao set ");
            strSql.Append("title=@title,");
            strSql.Append("content=@content,");
            strSql.Append("name=@name,");
            strSql.Append("date=@date");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@title", SqlDbType.NVarChar,100),
					new SqlParameter("@content", SqlDbType.NVarChar,255),
					new SqlParameter("@name", SqlDbType.NVarChar,50),
					new SqlParameter("@date", SqlDbType.DateTime),		
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.title;
            parameters[1].Value = model.content;
            parameters[2].Value = model.name;
            parameters[3].Value = model.date;
            parameters[4].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from gonggao ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

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
        public Model.gonggao GetModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,title,content,name,date from gonggao ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            Model.gonggao model = new Model.gonggao();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["title"] != null && ds.Tables[0].Rows[0]["title"].ToString() != "")
                {
                    model.title = ds.Tables[0].Rows[0]["title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["content"] != null && ds.Tables[0].Rows[0]["content"].ToString() != "")
                {
                    model.content = ds.Tables[0].Rows[0]["content"].ToString();
                }
                if (ds.Tables[0].Rows[0]["name"] != null && ds.Tables[0].Rows[0]["name"].ToString() != "")
                {
                    model.name = ds.Tables[0].Rows[0]["name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["date"] != null && ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
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
