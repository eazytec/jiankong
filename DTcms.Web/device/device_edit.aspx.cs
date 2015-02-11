using System;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DTcms.Common;
using DTcms.BLL;


namespace DTcms.Web.device
{
    public partial class device_edit : Web.UI.ManagePage
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
                if (!new BLL.discharge_companies().Exists(this.id))
                {
                    JscriptMsg("信息不存在或已被删除！", "back", "Error");
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
            BLL.device_list bll = new BLL.device_list();
            Model.device model = bll.GetModel(_id);

            txtDeviceId.Text = model.device_id;
            txtDeviceName.Text = model.device_name;
 
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.device model = new Model.device();
            BLL.device_list bll = new BLL.device_list();
            model.device_id = txtDeviceId.Text;
            model.device_name = txtDeviceName.Text;
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
            BLL.device_list bll = new BLL.device_list();
            Model.device model = bll.GetModel(_id);
            model.device_id = txtDeviceId.Text;
            model.device_name = txtDeviceName.Text; 
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
                ChkAdminLevel("users", DTEnums.ActionEnum.Edit.ToString()); //检查权限
                if (!DoEdit(this.id))
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("修改用户成功啦！", "device_list.aspx", "Success");
            }
            else //添加
            {
                ChkAdminLevel("users", DTEnums.ActionEnum.Add.ToString()); //检查权限
                //if (new BLL.users().Exists(txtUserName.Text.Trim()))
                //{
                //    JscriptMsg("用户名已存在啦！", "", "Error");
                //    return;
                //}
                if (!DoAdd())
                {
                    JscriptMsg("保存过程中发生错误啦！", "", "Error");
                    return;
                }
                JscriptMsg("信息保存成功！", "device_list.aspx", "Success");
            }
        }

    }
}