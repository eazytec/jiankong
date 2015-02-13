using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DTcms.BLL
{
  public partial  class siteinfo
    {
       private readonly DAL.siteinfo dal = new DAL.siteinfo();
        public siteinfo()
        { }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.siteinfo model)
        {
            return dal.Add(model);
        }
       
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.siteinfo GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.siteinfo model)
        {
            return dal.Update(model);
        }


        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

    }
}
