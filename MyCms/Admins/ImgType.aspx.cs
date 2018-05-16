using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MyCms.Data;
using MyCms.Bus;
using MyCms.Common;

namespace MyCms.Admins
{
    public partial class ImgType : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                BindGrid();
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            pnView.Visible = false;
            Insert = true;
        }
        protected void grdImgType_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdImgType.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdImgType_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdImgType.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdImgType_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Insert = false;
                    Id = strCA;
                    List<Data.ImgType> listE = ImgTypeBUS.ImgType_GetById(Id);
                    txtName.Text = listE[0].Name;
                    txtCode.Text = listE[0].Code;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [ImageType] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    ImgTypeBUS.ImgType_Delete(strCA);
                    BindGrid();
                    break;
            }
        }

        private void BindGrid()
        {
            grdImgType.DataSource = ImgTypeBUS.ImgType_GetByAll();
            grdImgType.DataBind();
            if (grdImgType.PageCount <= 1)
            {
                grdImgType.PagerStyle.Visible = false;
            }
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdImgType.Items.Count; i++)
            {
                item = grdImgType.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ImgTypeBUS.ImgType_Delete(strId);
                    }
                }
            }
            grdImgType.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.ImgType obj = new Data.ImgType();
                obj.Id = Id;
                obj.Name = txtName.Text;
                obj.Code = txtCode.Text;
                obj.Active = chkActive.Checked ? "1" : "0";
                if (Insert == true)
                {
                    ImgTypeBUS.ImgType_Insert(obj);
                }
                else
                {
                    ImgTypeBUS.ImgType_Update(obj);
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
    }
}