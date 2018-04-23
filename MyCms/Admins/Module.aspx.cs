using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyCms.Bus;
using MyCms.Data;
using MyCms.Common;

namespace MyCms.Admins
{
    public partial class Module : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        SqlDataProvider sql = new SqlDataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");

                NumberClass.OnlyInputNumber(txtOrd);
                BindGrid();
            }
        }
        void BindGrid()
        {
            if (Request.QueryString["Idcha"] != null)
            {
                grdModule.DataSource = ModuleBUS.Module_GetByTop("", "Idcha=" + Request.QueryString["Idcha"].ToString() + "", "Ord");
                grdModule.DataBind();
            }
            else
            {
                grdModule.DataSource = ModuleBUS.Module_GetByTop("", "Idcha=0", "Ord");
                grdModule.DataBind();
            }
            if (grdModule.PageCount <= 1)
            {
                grdModule.PagerStyle.Visible = false;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            pnView.Visible = false;
            Insert = true;
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admins/Module.aspx");
            BindGrid();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdModule.Items.Count; i++)
            {
                item = grdModule.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ModuleBUS.Module_Delete(strId);
                    }
                }
            }
            grdModule.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.Module obj = new Data.Module();
                obj.Id = Id;
                obj.Name = txtName.Text;

                if (Request.QueryString["Idcha"] != null)
                {
                    obj.Idcha = Request.QueryString["Idcha"].ToString();
                }
                else
                {
                    obj.Idcha = "0";
                }

                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Icon = txtIcon.Text;
                obj.Link = txtLink.Text;
                obj.Active = chkActive.Checked ? "1" : "0";
                if (Insert == true)
                {
                    ModuleBUS.Module_Insert(obj);
                }
                else
                {
                    ModuleBUS.Module_Update(obj);
                }
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Insert = false;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            Insert = false;
        }
        public string hienthiIcon(string icon)
        {
            string s = "";
            s += "<i class=\"fa " + icon + " \"></i>  ";
            return s;
        }
        protected void grdModule_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "AddSub":
                    Response.Redirect("/Admins/Module.aspx?Idcha=" + strCA + "");
                    BindGrid();
                    break;
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.Module> listE = ModuleBUS.Module_GetById(Id);
                    txtName.Text = listE[0].Name;
                    txtOrd.Text = listE[0].Ord;
                    txtIcon.Text = listE[0].Icon;
                    Label1.Text = "<i class=\"fa " + listE[0].Icon + "\"></i>";
                    txtLink.Text = listE[0].Link;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    sql.ExecuteNonQuery("Update [Module] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    ModuleBUS.Module_Delete(strCA);
                    BindGrid();
                    break;
                case "UpdateOrd":
                    Int32 tableRowId = e.Item.ItemIndex;
                    TextBox ltrprice = (TextBox)grdModule.Items[tableRowId].FindControl("txtthutu");
                    sql.ExecuteNonQuery("Update Module set Ord=" + ltrprice.Text + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
            }
        }

        protected void grdModule_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdModule.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdModule_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            if ((itemType != ListItemType.Footer) && (itemType != ListItemType.Separator))
            {
                if (itemType == ListItemType.Header)
                {
                    object checkBox = e.Item.FindControl("chkSelectAll");
                    if ((checkBox != null))
                    {
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelectAll_OnClick(this)");
                    }
                }
                else
                {
                    string tableRowId = grdModule.ClientID + "_row" + e.Item.ItemIndex.ToString();
                    e.Item.Attributes.Add("id", tableRowId);
                    object checkBox = e.Item.FindControl("chkSelect");
                    if ((checkBox != null))
                    {
                        e.Item.Attributes.Add("onMouseMove", "Javascript:chkSelect_OnMouseMove(this)");
                        e.Item.Attributes.Add("onMouseOut", "Javascript:chkSelect_OnMouseOut(this," + e.Item.ItemIndex.ToString() + ")");
                        ((CheckBox)checkBox).Attributes.Add("onClick", "Javascript:chkSelect_OnClick(this," + e.Item.ItemIndex.ToString() + ")");
                    }
                }
            }
        }
    }
}