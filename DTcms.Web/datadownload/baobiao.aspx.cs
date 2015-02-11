using System;
using System.Collections;
using System.Configuration;
using System.Data;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using DTcms.Common;
using System.Text;


namespace DTcms.web.histroy_graphs
{
    public partial class baobiao : System.Web.UI.Page
    {


        protected string keywords = string.Empty;
        protected string begindate = string.Empty;
        protected string enddate = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
    
            this.begindate = DTRequest.GetQueryString("begindate");
            this.enddate = DTRequest.GetQueryString("enddate");

            if (!Page.IsPostBack)
            {
                RptBind("id>0" + CombSqlTxt(this.begindate, this.enddate), "dtt desc");
            }
        }

        //时间查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("baobiao.aspx", "begindate={0}&enddate={1}", 
            txtBegindate.Text, txtEnddate.Text));
        }




        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {


            //this.txtBegindate.Text = this.begindate;
            //this.txtEnddate.Text = this.enddate;
            BLL.exportExcel bll = new BLL.exportExcel();
            this.rptList.DataSource = bll.GetList(_strWhere, _orderby);
            this.rptList.DataBind();


        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt( string _begindate, string _enddate)
        {
            StringBuilder strTemp = new StringBuilder();
            _begindate = _begindate.Replace("'", "");
            _enddate = _enddate.Replace("'", "");

            if (!string.IsNullOrEmpty(_begindate))
            {
                strTemp.Append(" and (dtt between '" + _begindate + "'and '" + _enddate + "')");
            }
            return strTemp.ToString();
        }
        #endregion


    }

}
