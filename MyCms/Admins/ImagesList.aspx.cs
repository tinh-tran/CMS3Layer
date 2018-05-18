using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Bus;
using MyCms.Data;
using MyCms.Common;
using System.Net;
using System.IO;

namespace MyCms.Admins
{
    public partial class ImagesList : System.Web.UI.Page
    {
        static string Id = "";
       // static string anh = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lbtDeleteT.Attributes.Add("onClick", "javascript:return confirm('Bạn có muốn xóa?');");
                // NumberClass.OnlyInputNumber(txtOrd);
                //trImages.Visible = false;
                BindGrid();
               // loadimage();
            }
        }
        //public string checkImg(string urlImg)
        //{
        //    if (File.Exists(Server.MapPath(urlImg)) == false)
        //    {
        //        urlImg = "/App_Themes/Admin/images/nophoto.jpg";
        //    }
        //    return urlImg;
        //}
        //private void loadimage( )
        //{
        //    List<Data.ImgType> list = Bus.ImgTypeBUS.ImgType_GetByAll();
        //    if (list.Count > 0)
        //    {
        //        ddlPosition.Items.Clear();
        //        //ddlFilterPosition.Items.Clear();
        //        ddlPosition.Items.Add(new ListItem(" -- Chọn định dạng-- ", ""));
        //       // ddlFilterPosition.Items.Add(new ListItem(" -- Chọn định dạng-- ", ""));
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            ddlPosition.Items.Add(new ListItem(list[i].Name, list[i].Code));
        //            //ddlFilterPosition.Items.Add(new ListItem(list[i].Name, list[i].Code));
        //        }
        //    }

        //}
        //public string ShowPosition(string str)
        //{
        //    string s = "";
        //    List<Data.ImgType> list = ImgTypeBUS.ImgType_GetByTop("", "Code=" + str + "", "");
        //    if (list.Count > 0)
        //    {
        //        s += list[0].Name;
        //    }
        //    return s;
        //}
        private void BindGrid()
        {
            grdListImg.DataSource = ImagesDetailBUS.ImageDetail_GetByAll();
            grdListImg.DataBind();
            if (grdListImg.PageCount <= 1)
            {
                grdListImg.PagerStyle.Visible = true;
            }
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = true;
            chkActive.Checked = true;
            pnView.Visible = false;
        }

        protected void RefreshButton_Click(object sender, EventArgs e)
        {

        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if ( Page.IsValid)
            {
                MyCms.Data.ImagesDetail obj = new MyCms.Data.ImagesDetail();
                if (txtName.Text.StartsWith("http://"))
                {
                        string fileExt = Path.GetExtension(txtImage.Text);
                        WebClient webClient = new WebClient();
                        if (fileExt.ToLower() == ".gif" || fileExt.ToLower() == ".png" || fileExt.ToLower() == ".jpg" || fileExt.ToLower() == ".jpeg")
                        {
                            string urlsave = "/Uploads/testimg/" + Common.StringClass.RandomString(10) + fileExt;
                            webClient.DownloadFile(txtImage.Text, Request.PhysicalApplicationPath + urlsave);
                            obj.Image = urlsave;
                        }
                        else
                        {
                            obj.Image = txtImage.Text;
                        }
                }
                obj.Name = txtName.Text;
                obj.Image = txtImage.Text;
                obj.Summary = txtsummary.Text;
                obj.ImageId = Common.StringClass.RandomNum(5);
                obj.Active = chkActive.Checked ? "1" : "0";
                if (txtId.Text.Length == 0)
                {
                    obj.Id = Id;
                    Bus.ImagesDetailBUS.ImagesDetail_Insert(obj);
                }
                else {
                    obj.Id = txtId.Text;
                    obj.ImageId = txtLink.Text;
                    Bus.ImagesDetailBUS.ImagesDetail_Update(obj);
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

        protected void grdListImg_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            string strCA = e.CommandArgument.ToString();
            switch (e.CommandName)
            {
                case "Edit":
                    Id = strCA;
                    List<Data.ImagesDetail> listE = ImagesDetailBUS.ImageDetail_GetById(Id);
                    txtId.Text = strCA;
                    txtName.Text = listE[0].Name;
                    txtsummary.Text = listE[0].Summary;
                    if (listE[0].Image.Length > 0)
                    {
                        txtImage.Text = listE[0].Image;
                        imgImage.Visible = true;
                        imgImage.ImageUrl = listE[0].Image;
                    }
                    //if (listE[0].Image.Length > 0)
                    //{
                    //    txtImagesmall.Text = listE[0].Image;
                    //    Image1.Visible = true;
                    //    Image1.ImageUrl = listE[0].Image;

                    //}
                    //else
                    //{
                    //    trImages.Visible = false;
                    //}

                    //txtWidth.Text = listE[0].Width;
                    //txtHeight.Text = listE[0].Height;
                    txtLink.Text = listE[0].ImageId;
                    txtsummary.Text = listE[0].Summary;
                    chkActive.Checked = listE[0].Active == "1" || listE[0].Active == "True";

                    pnView.Visible = false;
                    pnUpdate.Visible = true;
                    break;
                case "Active":
                    string strA = "";
                    string str = e.Item.Cells[2].Text;
                    strA = str == "1" ? "0" : "1";
                    SqlDataProvider sql = new SqlDataProvider();
                    sql.ExecuteNonQuery("Update [ImagesDetail] set Active=" + strA + "  Where Id='" + strCA + "'");
                    BindGrid();
                    break;
                case "Delete":
                    Bus.ImagesDetailBUS.ImagesDetail_Delete(strCA);
                    BindGrid();
                    break;
                case "Image":
                    Response.Redirect("/Admins/ImagesDetail.aspx?ImagesId=" + strCA + "");
                    break;
            }
        }

        protected void grdListImg_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdListImg.CurrentPageIndex = e.NewPageIndex;
            BindGrid();

        }

        protected void grdListImg_ItemDataBound(object sender, DataGridItemEventArgs e)
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
                    string tableRowId = grdListImg.ClientID + "_row" + e.Item.ItemIndex.ToString();
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