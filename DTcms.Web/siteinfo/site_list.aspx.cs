﻿using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.siteinfo
{
    public partial class site_list : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected String stationName = string.Empty;
        protected string begindate = string.Empty;
        protected string enddate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.stationName = DTRequest.GetQueryString("stationName");
            this.begindate = DTRequest.GetQueryString("begindate");
            this.enddate = DTRequest.GetQueryString("enddate");

            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                RptBind("id>0" + CombSqlTxt(this.stationName, this.begindate, this.enddate), "createTime desc,id desc");
            }
        }


        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);

            BLL.siteinfo bll = new BLL.siteinfo();

            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("site_list.aspx", "stationName={0}&begindate={1}&enddate={2}&page={3}",
                this.stationName, this.begindate, this.enddate, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _stationName, string _begindate, string _enddate)
        {
            StringBuilder strTemp = new StringBuilder();

            _begindate = _begindate.Replace("'", "");
            _enddate = _enddate.Replace("'", "");

            if (!string.IsNullOrEmpty(_begindate))
            {
                strTemp.Append(" and (createTime between '" + _begindate + "'and '" + _enddate + "')");
            }
            if (!string.IsNullOrEmpty(_stationName))
            {
                strTemp.Append(" and stationName like '%" + _stationName + "%' ");
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

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("site_list.aspx", "stationName={0}&begindate={1}&enddate={2}",
               txtstationName.Text, txtBegindate.Text, txtEnddate.Text));
        }


        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("site_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("site_list.aspx", "stationName={0}&begindate={1}&enddate={2}",
                this.stationName, this.begindate, this.enddate));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("users", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.siteinfo bll = new BLL.siteinfo();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("site_list.aspx", "stationName={0}&begindate={1}&enddate={2}",
                this.stationName, this.begindate, this.enddate), "Success");
        }
    }
}