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
    public partial class device_info_pass : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected int device_ids;
        protected string keywords = string.Empty;

        protected string begindate = string.Empty;
        protected string enddate = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.device_ids = DTRequest.GetQueryInt("device_ids");
            this.keywords = DTRequest.GetQueryString("keywords");
            this.begindate = DTRequest.GetQueryString("begindate");

            this.enddate = DTRequest.GetQueryString("enddate");
            this.pageSize = GetPageSize(15); //每页数量
            if (!Page.IsPostBack)
            {
              
                TreeBind(""); //绑定类别
                RptBind("id>0" + "and shenhe=2" + CombSqlTxt(this.device_ids, this.begindate, this.enddate), "install_date desc,id desc");
            }
        }


        //时间查询
        protected void timeSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("device_info_query.aspx", "device_ids={0}&begindate={1}&enddate={2}", this.device_ids.ToString()
                , txtBegindate.Text, txtEnddate.Text));

        }

        //筛选类别
        protected void ddlSewageId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("device_info_query.aspx", "device_ids={0}&keywords={1}",
                ddlDeviceIds.SelectedValue, this.keywords));
        }

        #region 绑定类别=================================
        private void TreeBind(string strWhere)
        {
            BLL.device_info bll = new BLL.device_info();
            DataTable dt = bll.GetList(0, strWhere, "id desc").Tables[0];
            this.ddlDeviceIds.Items.Clear();
            this.ddlDeviceIds.Items.Add(new ListItem("请选择通讯设备编号", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlDeviceIds.Items.Add(new ListItem(dr["device_id"].ToString(), dr["id"].ToString()));

            }
        }
        #endregion




        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            if (this.device_ids > 0)
            {
                this.ddlDeviceIds.SelectedValue = this.device_ids.ToString();
            }
            this.txtBegindate.Text = this.begindate;
            this.txtEnddate.Text = this.enddate;
            BLL.device_info bll = new BLL.device_info();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();



            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("device_info_query.aspx", "device_ids={0}&begindate={1}&enddate={2}&page={3}",
            this.device_ids.ToString(), this.begindate, this.enddate, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(int _place_id, string _begindate, string _enddate)
        {
            StringBuilder strTemp = new StringBuilder();
            if (device_ids > 0)
            {
                strTemp.Append(" and device_ids=" + device_ids);
            }
            _begindate = _begindate.Replace("'", "");
            _enddate = _enddate.Replace("'", "");
            if (!string.IsNullOrEmpty(_begindate))
            {
                strTemp.Append("and install_date between '" + _begindate + "'and '" + _enddate + "'");
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
            Response.Redirect(Utils.CombUrlTxt("device_info_query.aspx", "device_ids={0}&keywords={1}",
                this.device_ids.ToString(), this.keywords));
        }

        //批量删除
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ChkAdminLevel("users", DTEnums.ActionEnum.Delete.ToString()); //检查权限
            BLL.monitoring_site bll = new BLL.monitoring_site();
            for (int i = 0; i < rptList.Items.Count; i++)
            {
                int id = Convert.ToInt32(((HiddenField)rptList.Items[i].FindControl("hidId")).Value);
                CheckBox cb = (CheckBox)rptList.Items[i].FindControl("chkId");
                if (cb.Checked)
                {
                    bll.Delete(id);
                }
            }
            JscriptMsg("批量删除成功啦！", Utils.CombUrlTxt("device_info_query.aspx", "place_id={0}&begindate={1}&enddate={2}", this.device_ids.ToString()
            , txtBegindate.Text, txtEnddate.Text), "Success");
        }
    }
}