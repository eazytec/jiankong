using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DTcms.BLL
{
    public partial class exportExcel
    {
        private readonly DAL.exportExcel dal = new DAL.exportExcel();
        public exportExcel()
        { }
        #region Method

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList( string strWhere, string filedOrder)
        {
            return dal.GetList(strWhere, filedOrder);
        }
        #endregion Method

        /// <summary>
        /// 得到站点名称
        /// </summary>
        public string GetStationName(string id)
        {
            return dal.GetStationName(id);
        }


        public DataSet GetExcelList(string sql)
        {

            return dal.GetExcelList(sql);
        
        }
    }
}
