using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DTcms.BLL
{
    public partial class device_list
    {
        private readonly DAL.device_list dal = new DAL.device_list();
        public device_list()
        { }
        #region Method
        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        #endregion Method

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 增加一条数
        /// </summary>
        public int Add(DTcms.Model.device model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DTcms.Model.device GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DTcms.Model.device model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 返回设备编号
        /// </summary>
        public string GetId(int id)
        {
            return dal.GetId(id);
        }
        /// <summary>
        /// 返回审核状态
        /// </summary>
        public string GetName(int id) {
            return dal.GetName(id);      
        }
    }
}
