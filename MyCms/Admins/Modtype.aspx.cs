using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Data;
using MyCms.Bus;
using MyCms.Common;

namespace MyCms.Admins
{
    public partial class Modtype : System.Web.UI.Page
    {
        static string Id = "";
        static bool Insert = false;
        static string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                BindGrid();
            }
        }
        private void BindGrid()
        {
            grdModtype.DataSource = ModtypeBUS.Modtype_GetByTop("", "", "Modtype_Filter asc, Modtype_Name asc");
            grdModtype.DataBind();
            if (grdModtype.PageCount <= 1)
            {
                grdModtype.PagerStyle.Visible = false;
            }
        }
        protected void grdModtype_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdModtype.ClientID + "_row" + e.Item.ItemIndex.ToString();
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
        private void loadfilter()
        {
            ddlFilter.Items.Clear();
            ddlFilter.Items.Add(new ListItem(" -- Định dạng cha -- ", "0"));
            List<Data.Modtype> list = ModtypeBUS.Modtype_GetByTop("", "Modtype_Filter=0", "");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ddlFilter.Items.Add(new ListItem(list[i].Modtype_Name, list[i].Id));
                }
            }
        }
        protected void grdModtype_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdModtype.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdModtype_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    loadfilter();
                    Insert = false;
                    Id = strCA;
                    List<Data.Modtype> listE = ModtypeBUS.Modtype_GetById(Id);
                    txtModtype_Name.Text = listE[0].Modtype_Name;
                    txtModtype_Code.Text = listE[0].Modtype_Code;
                    chkStatus.Checked = listE[0].Modtype_Status == "1" || listE[0].Modtype_Status == "True";
                    txtModtype_Targer.Text = listE[0].Modtype_Target;
                    ddlFilter.SelectedValue = listE[0].Modtype_Filter;
                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Delete":
                    ModtypeBUS.Modtype_Delete(strCA);
                    BindGrid();
                    break;
            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            loadfilter();
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            pnView.Visible = false;
            Insert = true;
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdModtype.Items.Count; i++)
            {
                item = grdModtype.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        ModtypeBUS.Modtype_Delete(strId);
                    }
                }
            }
            grdModtype.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.Modtype obj = new Data.Modtype();
                obj.Id = Id;
                obj.Modtype_Name = txtModtype_Name.Text;
                obj.Modtype_Code = txtModtype_Code.Text;
                obj.Modtype_Status = chkStatus.Checked ? "1" : "0";
                obj.Modtype_Target = txtModtype_Targer.Text;
                obj.Modtype_Filter = ddlFilter.SelectedValue;
                if (Insert == true)
                {
                    ModtypeBUS.Modtype_Insert(obj);
                }
                else
                {
                    ModtypeBUS.Modtype_Update(obj);
                }
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;
                Insert = false;
            }
        }
        public string dinhdang(string id)
        {
            if (id == "0")
            {
                id = "Module";
            }
            else
            {
                id = "Nội dung";
            }
            return id;
        }
        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
            Insert = false;
        }
    }
}