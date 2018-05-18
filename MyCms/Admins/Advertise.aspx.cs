using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Common;
using System.IO;
using MyCms.Bus;
using MyCms.Data;
using System.Net;

namespace MyCms.Admins
{
    public partial class Advertise : System.Web.UI.Page
    {
        static string Id = "";
        static string Lang = "";
        static string anh = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                NumberClass.OnlyInputNumber(txtOrd);
                //trImages.Visible = false;
                BindGrid();
                loadtype();
                loadmodule();
            }
        }
        public string checkImg(string urlImg)
        {
            if (File.Exists(Server.MapPath(urlImg)) == false)
            {
                urlImg = "/App_Themes/Admin/images/nophoto.jpg";
            }
            return urlImg;
        }
        private void BindGrid()
        {
            if (ddlFilterPosition.SelectedValue == "" || ddlFilterPosition.SelectedValue == null)
            {
                grdAdvertise.DataSource = AdvertiseBUS.Advertise_GetByAll(Lang);
            }
            else
            {
                grdAdvertise.DataSource = AdvertiseBUS.Advertise_GetByTop("", "Lang='" + Lang + "' and Position=" + ddlFilterPosition.SelectedValue, "Id desc");
            }
            grdAdvertise.DataBind();
            if (grdAdvertise.PageCount <= 1)
            {
                grdAdvertise.PagerStyle.Visible = false;
            }
        }

        private void loadtype()
        {
            List<Data.ImgType> list = ImgTypeBUS.ImgType_GetByAll();
            if (list.Count > 0)
            {
                ddlPosition.Items.Clear();
                ddlFilterPosition.Items.Clear();
                ddlPosition.Items.Add(new ListItem(" -- Chọn định dạng-- ", ""));
                ddlFilterPosition.Items.Add(new ListItem(" -- Chọn định dạng-- ", ""));
                for (int i = 0; i < list.Count; i++)
                {
                    ddlPosition.Items.Add(new ListItem(list[i].Name, list[i].Code));
                    ddlFilterPosition.Items.Add(new ListItem(list[i].Name, list[i].Code));
                }
            }
        }

        private void loadmodule()
        {
            List<Data.Mod> list = ModBUS.Mod_GetByTop("", "Mod_Level=1", "Mod_Pos asc");
            if (list.Count > 0)
            {
                ddlModule.Items.Clear();
                ddlModule.Items.Add(new ListItem(" -- Chọn vị trí -- ", "0"));
                for (int i = 0; i < list.Count; i++)
                {
                    ddlModule.Items.Add(new ListItem(list[i].Mod_Name, list[i].Id));
                    List<Data.Mod> list2 = ModBUS.Mod_GetByTop("", "Mod_Level=2 and Mod_Parent=" + list[i].Id + "", "Mod_Pos asc");
                    if (list2.Count > 0)
                    {
                        for (int j = 0; j < list2.Count; j++)
                        {
                            ddlModule.Items.Add(new ListItem("----" + list2[j].Mod_Name, list2[j].Id));
                        }
                    }
                }
            }
        }
        protected void grdAdvertise_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdAdvertise.ClientID + "_row" + e.Item.ItemIndex.ToString();
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

        protected void grdAdvertise_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdAdvertise.CurrentPageIndex = e.NewPageIndex;
            BindGrid();
        }

        protected void grdAdvertise_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Id = strCA;
                    List<Data.Advertise> listE = AdvertiseBUS.Advertise_GetById(Id);
                    txtId.Text = strCA;
                    txtName.Text = listE[0].Name;
                    txtsummary.Text = listE[0].Summary;
                    if (listE[0].Image.Length > 0)
                    {
                        txtImage.Text = listE[0].Image;
                        imgImage.Visible = true;
                        imgImage.ImageUrl = listE[0].Image;
                    }
                    if (listE[0].ImageSmall.Length > 0)
                    {
                        txtImagesmall.Text = listE[0].Image;
                        Image1.Visible = true;
                        Image1.ImageUrl = listE[0].ImageSmall;

                    }
                    //else
                    //{
                    //    trImages.Visible = false;
                    //}

                    //txtWidth.Text = listE[0].Width;
                    //txtHeight.Text = listE[0].Height;
                    txtLink.Text = listE[0].Link;
                    ddlTarget.SelectedValue = listE[0].Target;
                    ddlPosition.SelectedValue = listE[0].Position;
                    ddlModule.SelectedValue = listE[0].PageId;
                    txtOrd.Text = listE[0].Ord;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";

                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [Advertise] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    AdvertiseBUS.Advertise_Delete(strCA);
                    BindGrid();
                    break;

                case "Image":
                    Response.Redirect("/Admins/ImagesDetail.aspx?ImagesId=" + strCA + "");

                    break;
            }
        }
        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            ControlClass.ResetControlValues(this);
            ddlPosition.SelectedValue = anh;
            chkActive.Checked = true;
            pnView.Visible = false;
            ddlPosition.Text = "";
            //pathImage = "";
            imgImage.ImageUrl = "";
            //imgImagesamll.ImageUrl = "";
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            DataGridItem item = default(DataGridItem);
            for (int i = 0; i < grdAdvertise.Items.Count; i++)
            {
                item = grdAdvertise.Items[i];
                if (item.ItemType == ListItemType.AlternatingItem | item.ItemType == ListItemType.Item)
                {
                    if (((CheckBox)item.FindControl("ChkSelect")).Checked)
                    {
                        string strId = item.Cells[1].Text;
                        AdvertiseBUS.Advertise_Delete(strId);
                    }
                }
            }
            grdAdvertise.CurrentPageIndex = 0;
            BindGrid();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.Advertise obj = new Data.Advertise();
                obj.Name = txtName.Text;

                if (txtImage.Text.StartsWith("http://"))
                {
                    string fileExt = Path.GetExtension(txtImage.Text);
                    WebClient webClient = new WebClient();
                    if (fileExt.ToLower() == ".gif" || fileExt.ToLower() == ".png" || fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".jpeg")
                    {
                        string urlsave = "/Uploads/Advertise/" + Common.StringClass.RandomString(10) + fileExt;
                        webClient.DownloadFile(txtImage.Text, Request.PhysicalApplicationPath + urlsave);
                        obj.Image = urlsave;
                    }
                }
                else
                {
                    obj.Image = txtImage.Text;
                }
                obj.ImageSmall = txtImagesmall.Text;
                obj.Summary = txtsummary.Text;
                obj.Width = "0";
                obj.Height = "0";
                obj.Link = txtLink.Text;
                obj.Target = ddlTarget.SelectedValue;
                obj.ContentDetail = "";
                obj.Position = ddlPosition.SelectedValue;
                obj.PageId = ddlModule.SelectedValue;
                obj.Click = "";
                obj.Ord = txtOrd.Text != "" ? txtOrd.Text : "1";
                obj.Active = chkActive.Checked ? "1" : "0";
                obj.Lang = Lang;
                if (txtId.Text.Length == 0)
                {
                    obj.Id = Id;
                    AdvertiseBUS.Advertise_Insert(obj);
                }
                else
                {
                    obj.Id = txtId.Text;
                    AdvertiseBUS.Advertise_Update(obj);
                }
                BindGrid();
                pnView.Visible = true;
                pnUpdate.Visible = false;

            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnView.Visible = true;
            pnUpdate.Visible = false;
        }

        protected void ddlFilterPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }
        public string ShowPosition(string str)
        {
            string s = "";
            List<Data.ImgType> list = ImgTypeBUS.ImgType_GetByTop("", "Code=" + str + "", "");
            if (list.Count > 0)
            {
                s += list[0].Name;
            }
            return s;
        }
    }
}