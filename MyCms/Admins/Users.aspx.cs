using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Bus;
using MyCms.Data;
using MyCms.Common;

namespace MyCms.Admins
{
    public partial class Users : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                if (Request.Cookies["Admin"].Value == "1")
                {
                    BindGrid();
                }
                else
                {
                    ChangeUser();
                }

            }
        }
        void BindGrid()
        {
            grdUser.DataSource = UserBUS.User_GetByAll();
            grdUser.DataBind();
            if (grdUser.PageCount <=1)
            {
                grdUser.PagerStyle.Visible = true;
            }
              
        }

        protected void grdUser_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdUser.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdUser_ItemDataBound(object sender, DataGridItemEventArgs e)
        {

        }
        public string ShowAdmin(string str)
        {
            string s = "";
            if (str == "1")
            {
                s = "Quản trị";
            }
            if (str == "2")
            {
                s = "Nhân viên";
            }

            return s;
        }
        private void ChangeUser()
        {
            pnView.Visible = false;
            pnUpdate.Visible = true;
            txtPass.Visible = false;
            ddlAdmin.Enabled = false;
            txtId.Text = Request.Cookies["IdUser"].Value;
            List<Data.User> listE = UserBUS.User_GetById(txtId.Text);
            txtImage.Text = listE[0].Image;
            txtDate.Text = DateTimeClass.ConvertDateTime(listE[0].DateCreate, "MM/dd/yyyy");
            txtName.Text = listE[0].Name;
            txtUsername.Text = listE[0].Username;
            ddlAdmin.SelectedValue = listE[0].Admin;
            chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            ltrPass.Text = "Mật Khẩu";
            ControlClass.ResetControlValues(this);
            txtDate.Text = DateTimeClass.ConvertDateTime(DateTime.Now, "MM/dd/yyyy");
            pnUpdate.Visible = true;
            chkActive.Checked = true;
            pnView.Visible = false;
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void grdUser_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                   
                case "Active":
                    break;
                case "Delete":
                    break;
                case "Pass":
                    break;
                case "Role":
                    break;

            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MyCms.Data.User obj = new MyCms.Data.User();
                obj.Name = txtName.Text;
                obj.Username = txtUsername.Text;
                obj.DateCreate = txtDate.Text;
                obj.Password = txtPass.Text;
                obj.Image = txtImage.Text;
                obj.Admin = ddlAdmin.SelectedValue;
                obj.Role = "";
                obj.ModuleId = "";
                obj.ModuleName = "";
                obj.Active= chkActive.Checked ? "1": "0";
                if (txtId.Text.Length == 0)
                {
                    if (txtPass.Text.Length <6)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Mật khẩu phải trên 6 ký tự');", true);
                    }
                    else
                    {
                        obj.Password = txtPass.Text;
                        UserBUS.User_Insert(obj);
                        BindGrid();
                        pnView.Visible = true;
                        pnUpdate.Visible = false;
                    }
                }
                else
                {
                    obj.Id = txtId.Text;
                    UserBUS.User_Update(obj);
                    if (Request.Cookies["Admin"].Value == "1")
                    {
                        BindGrid();
                        pnView.Visible = true;
                        pnUpdate.Visible = false;
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update thông tin tài khoản thành công');", true);
                    }


                }

            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {

        }
    }
}