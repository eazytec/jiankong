using System;
using System.Collections.Generic;

using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace DTcms.DBUtility
{
    public class SqlHelper
    {
        public SqlHelper()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        public static string ConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

            }
        }
        //增删改查的操作
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteNonQuery();

                }
            }
        }

        //增删改查的操作
        public static int ExecuteNonQueryStore(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }


        //查询的操作
        public static DataTable ExecuteDataSet(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    DataSet ds = new DataSet();

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }


                }
            }
        }
        //查询的操作cunchu
        public static DataTable ExecuteDataSetScore(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(ds);
                        return ds.Tables[0];
                    }


                }
            }
        }
        //单个查询
        public static int ExecuScale(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    //cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return Convert.ToInt32(cmd.ExecuteScalar());

                }
            }

        }

        //单个查询
        public static object ExecuScale2(string sql, params SqlParameter[] parameters)
        {
            using (SqlConnection conn = new SqlConnection(ConnStr))
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    // cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = sql;
                    foreach (var parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);

                    }
                    return cmd.ExecuteScalar();
                }
            }

        }

        //查询所有返回集合
        //public static List<object> ExecuteDataSetlist(string sql, params SqlParameter[] parameters)
        //{
        //    using (SqlConnection conn = new SqlConnection(ConnStr))
        //    {
        //        conn.Open();
        //        using (SqlCommand cmd = conn.CreateCommand())
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.CommandText = sql;
        //            foreach (var parameter in parameters)
        //            {
        //                cmd.Parameters.Add(parameter);
        //            }
        //            DataSet ds = new DataSet();
        //            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
        //            {
        //                adapter.Fill(ds);
        //                //return ds.Tables[0];
        //                if (ds.Tables[0].Rows.Count > 0)
        //                {
        //                    List<object> list=new List<object>();
        //                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //                    {
        //                        list.Add(ds.Tables[0].Rows[i][]);
        //                    }
        //                }
        //            }


        //        }
        //    }
        //}

    }
}
