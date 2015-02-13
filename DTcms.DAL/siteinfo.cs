using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DTcms.DBUtility;
using DTcms.Common;
using System.Data.SqlClient;

namespace DTcms.DAL
{
  public partial  class siteinfo
    {
       public siteinfo() { }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Model.siteinfo model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into stationInfo(");
           strSql.Append("stationId,stationName,stationType,createTime)");
           strSql.Append(" values (");
           strSql.Append("@stationId,@stationName,@stationType,@createTime)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@stationId", SqlDbType.NVarChar,100),
					new SqlParameter("@stationName", SqlDbType.NVarChar,100),
					new SqlParameter("@stationType", SqlDbType.NVarChar,50),
					new SqlParameter("@createTime", SqlDbType.DateTime)};
           parameters[0].Value = model.stationId;
           parameters[1].Value = model.stationName;
           parameters[2].Value = model.stationType;
           parameters[3].Value = model.createTime;


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
       public bool Update(Model.siteinfo model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update stationInfo set ");
           strSql.Append("stationId=@stationId,");
           strSql.Append("stationName=@stationName,");
           strSql.Append("stationType=@stationType,");
           strSql.Append("createTime=@createTime");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@stationId", SqlDbType.NVarChar,100),
					new SqlParameter("@stationName", SqlDbType.NVarChar,255),
					new SqlParameter("@stationType", SqlDbType.NVarChar,50),
					new SqlParameter("@createTime", SqlDbType.DateTime),		
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = model.stationId;
           parameters[1].Value = model.stationName;
           parameters[2].Value = model.stationType;
           parameters[3].Value = model.createTime;
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
       /// 得到一个对象实体
       /// </summary>
       public Model.siteinfo GetModel(int id)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 id,stationId,stationName,stationType,createTime from stationInfo ");
           strSql.Append(" where id=@id");
           SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
           parameters[0].Value = id;

           Model.siteinfo model = new Model.siteinfo();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["id"] != null && ds.Tables[0].Rows[0]["id"].ToString() != "")
               {
                   model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
               }
               if (ds.Tables[0].Rows[0]["stationId"] != null && ds.Tables[0].Rows[0]["stationId"].ToString() != "")
               {
                   model.stationId = ds.Tables[0].Rows[0]["stationId"].ToString();
               }
               if (ds.Tables[0].Rows[0]["stationName"] != null && ds.Tables[0].Rows[0]["stationName"].ToString() != "")
               {
                   model.stationName = ds.Tables[0].Rows[0]["stationName"].ToString();
               }
               if (ds.Tables[0].Rows[0]["stationType"] != null && ds.Tables[0].Rows[0]["stationType"].ToString() != "")
               {
                   model.stationType = ds.Tables[0].Rows[0]["stationType"].ToString();
               }
               if (ds.Tables[0].Rows[0]["createTime"] != null && ds.Tables[0].Rows[0]["createTime"].ToString() != "")
               {
                   model.createTime =DateTime.Parse(ds.Tables[0].Rows[0]["createTime"].ToString());
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
           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from stationInfo ");
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

       public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("select * FROM stationInfo");
           if (strWhere.Trim() != "")
           {
               strSql.Append(" where " + strWhere);
           }
           recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
           return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
       }
    }
}
