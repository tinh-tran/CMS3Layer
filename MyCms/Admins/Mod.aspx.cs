using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Bus;
using MyCms.Data;
using MyCms.Common;

namespace MyCms.Admins
{
    public partial class Mod : System.Web.UI.Page
    {
        static string Lang = "";
        static string editId = "";
        static string subId = "";
        static string deleteId = "";
        static string activeId = "";
        SqlDataProvider sql = new SqlDataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Request.Cookies["Lang"].Value;
            if (!IsPostBack)
            {
                Loaddinhdang();
                LoadModule();
                query();
                BindGrid();
                // fckconfig();
            }

        }
        //private void fckconfig()
        //{
        //    fckIntro.config.toolbar = new object[]
        //    {
        //        new object[] { "Source" },
        //        new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },		
        //        new object[] { "PasteText", "PasteFromWord", "RemoveFormat", "Preview", "Selectall", "Image" },		
        //        new object[] { "Styles", "Format", "Font", "FontSize", "TextColor", "BGColor", "Maximize"},
        //    };
        //    fckContentDetail.config.toolbar = new object[]
        //    {
        //        new object[] { "Source" },
        //        new object[] { "Bold", "Italic", "Underline", "Strike", "-", "Subscript", "Superscript" },		
        //        new object[] { "PasteText", "PasteFromWord", "RemoveFormat", "Preview", "Selectall", "Image" },		
        //        new object[] { "Styles", "Format", "Font", "FontSize", "TextColor", "BGColor", "Maximize"},
        //    };

        //}
        private void Loaddinhdang()
        {
            List<Data.Modtype> list = ModtypeBUS.Modtype_GetByTop("", "Modtype_Filter=0", "");
            if (list.Count > 0)
            {
                ddltype.Items.Add(new ListItem(" -- Chọn định dạng -- ", ""));
                ddltype.Items.Add(new ListItem("Tùy chỉnh liên kết", "0"));
                for (int i = 0; i < list.Count; i++)
                {
                    ddltype.Items.Add(new ListItem(list[i].Modtype_Name, list[i].Id));
                }
            }
        }
        private void LoadModule()
        {
            ddlParent.Items.Clear();
            ddlParent.Items.Add(new ListItem(" -- Chọn cấp -- ", "0"));
            List<Data.Mod> list = ModBUS.Mod_GetByTop("", "Lang='" + Lang + "' and Mod_Parent=0 and Mod_Level=1", "Mod_Pos asc,Id desc");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    ddlParent.Items.Add(new ListItem(list[i].Mod_Name, list[i].Id));
                    List<Data.Mod> list2 = ModBUS.Mod_GetByTop("", "Lang='" + Lang + "' and Mod_Parent=" + list[i].Id + " and Mod_Level=2", "Mod_Pos asc,Id desc");
                    if (list2.Count > 0)
                    {
                        for (int j = 0; j < list2.Count; j++)
                        {
                            ddlParent.Items.Add(new ListItem("----" + list2[j].Mod_Name, list2[j].Id));
                            List<Data.Mod> list3 = ModBUS.Mod_GetByTop("", "Lang='" + Lang + "' and Mod_Parent=" + list2[j].Id + " and Mod_Level=3", "Mod_Pos asc,Id desc");
                            if (list3.Count > 0)
                            {
                                for (int k = 0; k < list3.Count; k++)
                                {
                                    ddlParent.Items.Add(new ListItem("--------" + list3[k].Mod_Name, list3[k].Id));
                                }
                            }
                        }
                    }
                }
            }
        }
        private void query()
        {
            if (Request.QueryString["add"] != null || Request.QueryString["subId"] != null)
            {
                ControlClass.ResetControlValues(this);
                txtMod_style.Text = "";
                ddlParent.SelectedValue = "0";
                ddltype.SelectedValue = "";
                pnUpdate.Visible = true;
                chkStatus.Checked = true;

            }
            if (Request.QueryString["subId"] != null)
            {
                txtSubId.Text = Request.QueryString["subId"].ToString();
                ddlParent.SelectedValue = txtSubId.Text;
                ddlParent.Enabled = false;
                txtLevel.Text = tanglevel(txtSubId.Text);
                txtLevel.Enabled = false;
            }
            if (Request.QueryString["editId"] != null)
            {
                txtId.Text = Request.QueryString["editId"].ToString();
                List<Data.Mod> listE = ModBUS.Mod_GetById(txtId.Text);
                txtMod_Name.Text = listE[0].Mod_Name;
                txtMod_Code.Text = listE[0].Mod_Code;
                chkHot.Checked = listE[0].Mod_Hot == "1" || listE[0].Mod_Hot == "True";
                chkStatus.Checked = listE[0].Mod_Status == "1" || listE[0].Mod_Status == "True";
                chk_Same.Checked = listE[0].Mod_Same == "1" || listE[0].Mod_Same == "True";

                if (chk_Same.Checked == true)
                {
                    txtMod_Tag.Visible = true;
                    txtMod_Tag.Text = listE[0].Mod_Tag;
                }

                txtMod_Img.Text = listE[0].Mod_Img;
                txtMod_Key.Text = listE[0].Mod_Key;
                txtMod_Meta.Text = listE[0].Mod_Meta;
                txtMod_Pos.Text = listE[0].Mod_Pos;
                txtMod_style.Text = listE[0].Mod_style;
                txtMod_Title.Text = listE[0].Mod_Title;
                txtMod_Url.Text = listE[0].Mod_Url;
                txtLevel.Text = listE[0].Mod_Level;
                fckContentDetail.Text = listE[0].Mod_Content;
                fckIntro.Text = listE[0].Mod_Intro;
                ddlParent.SelectedValue = listE[0].Mod_Parent;
                ddltype.SelectedValue = listE[0].Modtype_ID;
                txtLevel.Text = listE[0].Mod_Level;
                pnUpdate.Visible = true;
            }
            if (Request.QueryString["deleteId"] != null)
            {
                deleteId = Request.QueryString["deleteId"].ToString();
                sql.ExecuteNonQuery("Delete from [Mod]  Where Id='" + deleteId + "'");
                List<Data.Mod> list = ModBUS.Mod_GetByTop("", "Mod_Parent=" + deleteId + "", "");
                if (list.Count > 0)
                {
                    ModBUS.Mod_Delete(deleteId);
                    sql.ExecuteNonQuery("Delete from [Mod]  Where Mod_Parent='" + deleteId + "'");
                }
                Response.Redirect("/Admins/Mod.aspx");
            }

            if (Request.QueryString["activeId"] != null)
            {
                activeId = Request.QueryString["activeId"].ToString();
                List<Data.Mod> list = ModBUS.Mod_GetById(activeId);
                if (list.Count > 0)
                {
                    if (list[0].Mod_Status == "True")
                    {
                        sql.ExecuteNonQuery("Update [Mod] set Mod_Status='False'  Where Id=" + activeId + "");
                    }
                    else
                    {
                        sql.ExecuteNonQuery("Update [Mod] set Mod_Status='True'  Where Id=" + activeId + "");
                    }
                }
                Response.Redirect("/Admins/Mod.aspx");
            }
        }
        private string activemod(string active)
        {
            // check module không active thì gạch ngang
            string s = "";
            if (active == "False")
            {
                s += "line-through";
            }
            return s;
        }

        private string tanglevel(string Id)
        {
            //check xem có phải cấp con không            
            List<Data.Mod> list = ModBUS.Mod_GetById(Id);
            if (list.Count > 0)
            {
                Id = (Int32.Parse(list[0].Mod_Level) + 1).ToString();
            }
            return Id;
        }
        protected void Update_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Data.Mod obj = new Data.Mod();
                obj.Mod_Parent = ddlParent.SelectedValue;
                obj.Mod_Name = txtMod_Name.Text;
                obj.Mod_Code = txtMod_Code.Text;
                obj.Modtype_ID = ddltype.SelectedValue;
                obj.Mod_Img = txtMod_Img.Text;
                obj.Mod_Title = txtMod_Title.Text;
                obj.Mod_Key = txtMod_Key.Text;
                obj.Mod_Meta = txtMod_Meta.Text;
                obj.Mod_Content = fckContentDetail.Text;
                obj.Mod_Intro = fckIntro.Text;
                obj.Mod_Status = chkStatus.Checked ? "1" : "0";
                obj.Mod_Same = chk_Same.Checked ? "1" : "0";
                obj.Mod_Hot = chkHot.Checked ? "1" : "0";
                obj.Mod_Pos = txtMod_Pos.Text;
                obj.Lang = Lang;
                obj.Mod_style = txtMod_style.Text;
                //chọn tùy chỉnh liên kết
                if (ddltype.SelectedValue == "0")
                {
                    obj.Mod_Url = txtMod_Url.Text;
                    obj.Mod_Tag = "";
                }
                else
                {
                    obj.Mod_Url = "/" + StringClass.NameToTag(txtMod_Name.Text) + ".html";
                }
                if (ddlParent.SelectedValue == "0")
                {
                    obj.Mod_Level = "1";
                }
                else
                {
                    obj.Mod_Level = "" + tanglevel(ddlParent.SelectedValue) + "";
                }
                //trung tag
                if (chk_Same.Checked == true)
                {
                    obj.Mod_Tag = txtMod_Tag.Text;
                    obj.Mod_Url = "/" + txtMod_Tag.Text + ".html";
                }
                else
                {
                    obj.Mod_Tag = StringClass.NameToTag(txtMod_Name.Text);
                }

                if (Request.QueryString["editId"] != null && txtId.Text.Length > 0)
                {
                    obj.Id = txtId.Text;
                    ModBUS.Mod_Update(obj);
                }
                if (Request.QueryString["subId"] != null && txtSubId.Text.Length > 0)
                {
                    obj.Mod_Parent = txtSubId.Text;
                    ModBUS.Mod_Insert(obj);
                }
                if (Request.QueryString["add"] != null && txtId.Text.Length == 0)
                {
                    ModBUS.Mod_Insert(obj);
                }
                Response.Redirect("/Admins/Mod.aspx");
                pnUpdate.Visible = false;
            }
        }

        protected void Back_Click(object sender, EventArgs e)
        {
            pnUpdate.Visible = false;
        }
        private void BindGrid()
        {
            ltrmod.Text = GetMod(0);
        }
        private string GetMod(int id)
        {
            List<Data.Mod> list = ModBUS.Mod_GetByTop("", "Mod.Mod_Parent=" + id + " and Lang='" + Lang + "'", "Mod_Pos asc");
            string a = "";
            if (list.Count > 0)
            {
                a += "<ul>";
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Mod_Parent == "0")
                    {
                        a += "<li class='branch " + activemod(list[i].Mod_Status) + "' >" + list[i].Mod_Name + " (" + list[i].Mod_Pos + ") ";
                        a += "<span class='functionitem'> ";
                        a += "<a href='?deleteId=" + list[i].Id + "' onclick=\"javascript:return confirm('Bạn có muốn xóa?');\"><i class='fa fa-trash'></i></a>";
                        a += "<a href='?editId=" + list[i].Id + "'><i class='fa fa-edit'></i></a>";
                        a += "<a href='?subId=" + list[i].Id + "'><i class='fa fa-plus'></i></a>";
                        a += "<a href='?activeId=" + list[i].Id + "'><i class='fa fa-eye'></i></a>";
                        a += "</span>";
                        a += GetMod(Int32.Parse(list[i].Id));
                        a += "</li>";
                    }
                    else
                    {
                        // 
                        a += "<li style=\"display:none\"  class='branch " + activemod(list[i].Mod_Status) + "'>" + list[i].Mod_Name + " (" + list[i].Mod_Pos + ") ";
                        a += "<span class='functionitem'> ";
                        a += "<a href='?deleteId=" + list[i].Id + "' onclick=\"javascript:return confirm('Bạn có muốn xóa?');\"><i class='fa fa-trash'></i></a>";
                        a += "<a href='?editId=" + list[i].Id + "'><i class='fa fa-edit'></i></a>";
                        a += "<a href='?subId=" + list[i].Id + "'><i class='fa fa-plus'></i></a>";
                        a += "<a href='?activeId=" + list[i].Id + "'><i class='fa fa-eye'></i></a>";
                        a += "</span>";
                        a += GetMod(Int32.Parse(list[i].Id));
                        a += "</li>";
                    }
                }
                a += "</ul>";

            }
            return a;
        }
        protected void RefreshButton_Click(object sender, EventArgs e)
        {
            BindGrid();
        }
        protected void chk_Same_CheckedChanged(object sender, EventArgs e)
        {
            txtMod_Tag.Visible = true;
        }
    }
}