using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using DTcms.Common;

namespace DTcms.Web.gonggao
{
    public partial class gonggao_edit : Web.UI.ManagePage
    {
        protected string action = DTEnums.ActionEnum.Add.ToString(); //操作类型
        private int id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            string _action = DTRequest.GetQueryString("action");
            if (!string.IsNullOrEmpty(_action) && _action == DTEnums.ActionEnum.Edit.ToString())
            {
                this.action = DTEnums.ActionEnum.Edit.ToString();//修改类型
                this.id = DTRequest.GetQueryInt("id");
                if (this.id == 0)
                {
                    JscriptMsg("传输参数不正确！", "back", "Error");
                    return;
                }
            }
            if (!Page.IsPostBack)
            {
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }
        }

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.gonggao bll = new BLL.gonggao();
            Model.gonggao model = bll.GetModel(_id);
            txtTitle.Text = model.title;
            txtContent.Text = model.content;
            txtName.Text = model.name;
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.gonggao model = new Model.gonggao();
            BLL.gonggao bll = new BLL.gonggao();
            model.title = txtTitle.Text;
            model.content = txtContent.Text;
            model.name = txtName.Text;         

            if (bll.Add(model) < 1)
            {
                result = false;
            }
            return result;
        }
        #endregion

        #region 修改操作=================================
        private bool DoEdit(int _id)
        {
            bool result = true;
            BLL.gonggao bll = new BLL.gonggao();
            Model.gonggao model = bll.GetModel(_id);

            model.title = txtTitle.Text;
            model.content = txtContent.Text;
            model.name = txtName.Text;

            if (!bll.Update(model))
            {
                result = false;
            }
            return result;
        }
        #endregion

        //保存
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
            {
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改公告信息成功啦！", "gonggao_list.aspx", "Success");
            }
            else //添加
            {
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("添加公告信息成功啦！", "gonggao_list.aspx", "Success");
            }
        }

    }
}
