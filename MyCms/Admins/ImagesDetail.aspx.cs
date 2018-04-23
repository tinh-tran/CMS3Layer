using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Bus;
using MyCms.Data;

namespace MyCms.Admins
{
    public partial class ImagesDetail : System.Web.UI.Page
    {
        static string ImagesId = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");

                if (!String.IsNullOrEmpty(Request.QueryString["ImagesId"].ToString()))
                {
                    ImagesId = Request.QueryString["ImagesId"].ToString();
                    BindGrid();
                }
                else
                Response.Redirect("/user");
            }
        }
        private void BindGrid()
        {
            grdProductImage.DataSource = ImagesDetailBUS.ImagesDetail_GetByTop("", "Active = 1 and ImagesId= " +ImagesId, "Id");
            grdProductImage.DataBind();
            if (grdProductImage.PageCount <= 1)
            {
                grdProductImage.PagerStyle.Visible = false;
            }
        }
        protected void grdProductImage_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdProductImage.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdProductImage_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdProductImage.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdProductImage_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    txtId.Text = strCA;
                    txtName.Text = "";
                    List<Data.ImagesDetail> ListE = ImagesDetailBUS.ImageDetail_GetById(strCA);
                    txtImage.Text = ListE[0].Image.Length > 0 ? ListE[0].Image : "";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    break;
                case "Delete":
                    break;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {

        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void Update_Click(object sender, EventArgs e)
        {

        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
        }
    }
}