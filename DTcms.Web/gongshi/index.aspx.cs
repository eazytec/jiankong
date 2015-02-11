using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.DBUtility;

namespace DTcms.Web.gongshi
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                getAQI();
                RptBind("date desc");
            }
        }

        private void getAQI()
        {
            string sql = "select a.*,b.stationName as stationName from dbo.StationAQI a left join dbo.stationInfo b on a.stationId=b.stationId";
            DataTable dt = DbHelperSQL.Query(sql).Tables[0]; 
            myrep.DataSource = dt;
            string ss = dt.Rows.Count.ToString();
            myrep.DataBind();
        }



        #region 数据绑定=================================
        private void RptBind(string _orderby)
        {

            BLL.gonggao bll = new BLL.gonggao();
            this.rptList.DataSource = bll.GetGonggaoList(_orderby);
            this.rptList.DataBind();


        }
        #endregion
    }
}