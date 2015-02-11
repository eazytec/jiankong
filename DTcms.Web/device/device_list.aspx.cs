using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.device
{
    public partial class device_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int place_id;
        protected string keywords = string.Empty;

        protected string begindate = string.Empty;
        protected string enddate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {

            this.keywords = DTRequest.GetQueryString("keywords");
            this.begindate = DTRequest.GetQueryString("begindate");
            this.enddate = DTRequest.GetQueryString("enddate");
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.View.ToString()); //检查权限
        
                RptBind("id>0" + CombSqlTxt(this.begindate, this.enddate), "date desc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            BLL.device_list bll = new BLL.device_list();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("device_list.aspx", "place_id={0}&begindate={1}&enddate={2}&page={3}",
            this.place_id.ToString(), this.begindate, this.enddate, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _begindate, string _enddate)
        {
            StringBuilder strTemp = new StringBuilder();

            _begindate = _begindate.Replace("'", "");
            _enddate = _enddate.Replace("'", "");
            if (!string.IsNullOrEmpty(_begindate))
            {
                strTemp.Append(" and (date between '" + _begindate + "'and '" + _enddate + "')");
            }
            return strTemp.ToString();
        }
        #endregion

        #region 返回用户每页数量=========================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("user_list_page_size"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        #endregion
        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("user_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("device_list.aspx", "place_id={0}&keywords={1}",
                this.place_id.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("users", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.device_list bll = new BLL.device_list();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("device_list.aspx", "place_id={0}&begindate={1}&enddate={2}", this.place_id.ToString()), "Success");
        }
    }
}