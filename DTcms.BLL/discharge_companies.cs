using System;
using System.Collections.Generic;
using System.Text;
using DTcms.DAL;
using DTcms.Model;
using System.Data;

namespace DTcms.BLL
{
    /// <summary>
    /// 排污企业信息
    /// </summary>
    public partial class discharge_companies
    {
        private readonly DAL.discharge_companies dal = new DAL.discharge_companies();

        public discharge_companies() 
        { }
        #region  Method
        /// <summary>
        /// 增加一条数
        /// </summary>
        public int Add(DTcms.Model.discharge_companies model)
        {
            return dal.Add(model);
        }
       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.discharge_companies GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.discharge_companies model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        #endregion  Method

    }
}
