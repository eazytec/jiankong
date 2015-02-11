using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTcms.Common;

namespace DTcms.Web.gonggao
{
    public partial class gonggao_list:Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected String title = string.Empty;
        protected string begindate = string.Empty;
        protected string enddate = string.Empty;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            this.title = DTRequest.GetQueryString("title");
            this.begindate = DTRequest.GetQueryString("begindate");
            this.enddate = DTRequest.GetQueryString("enddate");
            
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
                RptBind("id>0" + CombSqlTxt(this.title, this.begindate, this.enddate), "date desc,id desc");
            }
        }


        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);

            BLL.gonggao bll = new BLL.gonggao();

            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("gonggao_list.aspx", "title={0}&begindate={1}&enddate={2}&page={3}",
                this.title,this.begindate, this.enddate, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _group_id, string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            if (_group_id > 0)
            {
                strTemp.Append(" and group_id=" + _group_id);
            }
            _keywords = _keywords.Replace("'", "");
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" and (user_name like '%" + _keywords + "%' or email like '%" + _keywords + "%' or nick_name like '%" + _keywords + "%')");
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

        #region 返回用户状态===========================
        protected string GetUserStatus(int is_lock)
        {
            string result = string.Empty;
            switch (is_lock)
            {
                case 0:
                    result = "正常";
                    break;
                case 1:
                    result = "待验证";
                    break;
                case 2:
                    result = "待审核";
                    break;
                case 3:
                    result = "已禁用";
                    break;
            }
            return result;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("gonggao_list.aspx", "title={0}&begindate={1}&enddate={2}",
               txtTitle.Text,txtBegindate.Text,txtEnddate.Text));       
        }


        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _title,string _begindate, string _enddate)
        {
            StringBuilder strTemp = new StringBuilder();

            _begindate = _begindate.Replace("'", "");
            _enddate = _enddate.Replace("'", "");

            if (!string.IsNullOrEmpty(_begindate))
            {
                strTemp.Append(" and (date between '" + _begindate + "'and '" + _enddate + "')");
            }
            if (!string.IsNullOrEmpty(_title))
            {
                strTemp.Append(" and title like '%" + _title + "%' ");
            }

            return strTemp.ToString();
        }
        #endregion


        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("gonggao_list_page_size", _pagesize.ToString(), 43200);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("gonggao_list.aspx", "title={0}&begindate={1}&enddate={2}",
                this.title, this.begindate,this.enddate));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            //ChkAdminLevel("users", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.gonggao bll = new BLL.gonggao();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                   bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("gonggao_list.aspx", "title={0}&begindate={1}&enddate={2}",
                this.title, this.begindate,this.enddate), "Success");
        }
    }
}