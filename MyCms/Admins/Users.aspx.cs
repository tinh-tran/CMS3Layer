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
            ListItemType itemType = e.Item.ItemType;
            if ((itemType == ListItemType.Footer) && (itemType != ListItemType.Separator))// liệt kê từ đầu tới cuối 
            {
                object checkBox = e.Item.FindControl("chkSelectAll");
                if(checkBox != null)
                {
                    //dùng atriibutes để dùng mouse event thực thi lệnh repeat
                    ((CheckBox)checkBox).Attributes.Add("onclick", "Javascript:chkSelectAll_OnClick(this)");
                }
            }
            else
            {
                string tableRowId = grdUser.ClientID + "_row" + e.Item.ItemIndex.ToString();
                e.Item.Attributes.Add("id", tableRowId);
                object checkBox = e.Item.FindControl("chkSelect");
                if(checkBox != null)
                {
                    e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                    e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
                    ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
                }
            }
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
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdUser.Items.Count; i++)
            {
                item = grdUser.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        UserBUS.User_Delete(strId);
                    }
                }
            }
            grdUser.CurrentPageIndex = 0;
            BindGrid();
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
                    UserBUS.User_Delete(strCA);
                    BindGrid();
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