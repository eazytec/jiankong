using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DTcms.BLL
{
    public partial class gonggao
    {
        private readonly DAL.gonggao dal = new DAL.gonggao();
        public gonggao()
        { }

        /// <summary>
        /// 得到状态
        /// </summary>
        public string GetStatus(int id)
        {
            return dal.GetStatus(id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(DTcms.Model.gonggao model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.gonggao model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.gonggao GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        public DataSet GetGonggaoList(string filedOrder)
        {
            return dal.GetGonggaoList( filedOrder);
        }
    }
}
