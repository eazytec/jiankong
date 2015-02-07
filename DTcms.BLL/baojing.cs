using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DTcms.BLL
{
    public partial class baojing
    {
        private readonly DAL.baojing dal = new DAL.baojing();
        public baojing()
        { }

        /// <summary>
        /// 得到站点名称
        /// </summary>
        public string GetName(string id)
        {
            return dal.GetName(id);
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

