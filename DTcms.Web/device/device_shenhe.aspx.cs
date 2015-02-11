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
    public partial class device_shenhe : Web.UI.ManagePage
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
                //TreeBind("");
                TreeBindShenHe("id>1");//绑定类别
                if (action == DTEnums.ActionEnum.Edit.ToString()) //修改
                {
                    ShowInfo(this.id);
                }

            }

        }

        //#region 绑定类别=================================
        //private void TreeBind(string strWhere)
        //{
        //    BLL.device_list bll = new BLL.device_list();
        //    DataTable dt = bll.GetList(0, strWhere, "id asc").Tables[0];

        //    this.ddlDeviceIds.Items.Clear();
        //    this.ddlDeviceIds.Items.Add(new ListItem("请选择监测点...", ""));
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        this.ddlDeviceIds.Items.Add(new ListItem(dr["device_id"].ToString(), dr["id"].ToString()));
        //    }
        //}
        //#endregion

        #region 绑定类别=================================
        private void TreeBindShenHe(string strWhere)
        {
            BLL.device_info bll = new BLL.device_info();
            DataTable dt = bll.GetList1(0, strWhere, "id desc").Tables[0];
            this.ddlShenHe.Items.Clear();
            this.ddlShenHe.Items.Add(new ListItem("请选择", ""));
            foreach (DataRow dr in dt.Rows)
            {
                this.ddlShenHe.Items.Add(new ListItem(dr["shenhe_name"].ToString(), dr["id"].ToString()));

            }
        }
        #endregion

        #region 赋值操作=================================
        private void ShowInfo(int _id)
        {
            BLL.device_info bll = new BLL.device_info();
            Model.device_info model = bll.GetModel(_id);

            txtInstallAddress.Text = model.install_address;
            txtInstallPerson.Text = model.install_person;
            txtInstallDate.Text = model.install_date;
            txtTelephone.Text = model.telephone;
            txtPh.Text=model.ph;
            txtYangQi.Text=model.yangqi;
            //ddlDeviceIds.SelectedValue = model.device_ids.ToString();
        }
        #endregion

        #region 增加操作=================================
        private bool DoAdd()
        {
            bool result = true;
            Model.device_info model = new Model.device_info();
            BLL.device_info bll = new BLL.device_info();
            model.install_person = txtInstallPerson.Text;
            model.install_address = txtInstallAddress.Text;
            model.install_date = txtInstallDate.Text;
            //model.device_ids = int.Parse(ddlDeviceIds.SelectedValue);
            model.telephone = txtTelephone.Text;
            model.ph = txtPh.Text;
            model.yangqi = txtYangQi.Text;
            model.shenhe = 1;
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
            BLL.device_info bll = new BLL.device_info();
            Model.device_info model = bll.GetModel(_id);
            model.install_person = txtInstallPerson.Text;
            model.install_address = txtInstallAddress.Text;
            model.install_date = txtInstallDate.Text;
           // model.device_ids = int.Parse(ddlDeviceIds.SelectedValue);
            model.telephone = txtTelephone.Text;
            model.ph = txtPh.Text;
            model.yangqi = txtYangQi.Text;
            model.shenhe = int.Parse(ddlShenHe.SelectedValue);
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
                JscriptMsg("修改设备信息成功啦！", "device_info_query.aspx", "Success");
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
                JscriptMsg("添加设备信息成功啦！", "device_info_query.aspx", "Success");
            }
        }

    }
}