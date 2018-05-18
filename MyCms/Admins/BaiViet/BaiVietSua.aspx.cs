using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Data;
using MyCms.Bus;
using System.Data;

namespace MyCms.Admins.BaiViet
{

    public partial class BaiVietSua : System.Web.UI.Page
    {
        private string thaotac = "";
        string hienthi;
        private string MaBaiViet = "";
        private string maDMCha = "";
        QLDanhMucDAO ql_dm = new QLDanhMucDAO();
        QLBaiVietDAO ql_bv = new QLBaiVietDAO();
        QLBaiVietBUS ql_bus = new QLBaiVietBUS();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];
            if (Request.QueryString["MaBaiViet"] != null)
                MaBaiViet = Request.QueryString["MaBaiViet"];
            if (Request.QueryString["maDMCha"] != null)
                maDMCha = Request.QueryString["maDMCha"];
            if (!IsPostBack)
            {
                switch (thaotac)
                {
                    case "chinhsua":
                        Hienthithongtin(MaBaiViet);
                        break;
                }
                DanhMucCha();
            }
        }
        private void Hienthithongtin(string maBaiViet)
        {
            if (thaotac == "chinhsua")
            {
                DataTable dt = new DataTable();
                dt = ql_bv.ThongtinBVMaBV(MaBaiViet);

                if (dt.Rows.Count > 0)
                {
                    txtTenBaiViet.Text = dt.Rows[0]["TenBaiViet"].ToString();
                    txtNoiDung.Text = dt.Rows[0]["NoiDung"].ToString();
                    txtTieuDe.Text = dt.Rows[0]["TieuDe"].ToString();
                    txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                    ltrAnhDaiDien.Text = "<img style='width:300px' class='anhDaiDien'src='/Admins/pic/BaiViet/" + dt.Rows[0]["Anh"] + @"' />";
                    hdTenAnhDaiDienCu.Value = dt.Rows[0]["Anh"].ToString();
                    if(dt.Rows[0]["HienThi"].ToString() == "true")
                    {
                        cbHienThi.Checked=true;
                    }
                    ddlDmCha.SelectedValue = dt.Rows[0]["MaDM"].ToString();

                }
            }

        }
        //Lấy danh mục vào ddlDmCha
        private void DanhMucCha()
        {
            DataTable dt = new DataTable();
            dt = ql_dm.ThongtinDMCha("0");
            ddlDmCha.Items.Clear();

            ddlDmCha.Items.Add(new ListItem("Danh mục gốc", "0"));
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlDmCha.Items.Add(new ListItem(dt.Rows[i]["TenDM"].ToString(), dt.Rows[i]["MaDM"].ToString()));
                DanhMucCon(dt.Rows[i]["MaDM"].ToString(), "---");
            }
        }

        //Lấy danh mục con
        private void DanhMucCon(string MaDMCha, string KhoangCach)
        {
            DataTable dt = new DataTable();
            dt = ql_dm.ThongtinDMCha(MaDMCha);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ddlDmCha.Items.Add(new ListItem(KhoangCach + dt.Rows[i]["TenDM"].ToString(), dt.Rows[i]["MaDM"].ToString()));
                DanhMucCon(dt.Rows[i]["MaDM"].ToString(), KhoangCach + "---");
            }
        }
        protected void btnSua_Click(object sender, EventArgs e)
        {
            if (cbHienThi.Checked == true)
            {
                hienthi = "true";
            }
            else
            {
                hienthi = "false";
            }
            Data.QLBaiViet qlbv = new Data.QLBaiViet(txtTenBaiViet.Text, txtNoiDung.Text, txtTieuDe.Text, flAnhDaiDien.FileName, txtThuTu.Text, hienthi, ddlDmCha.SelectedValue.ToString());
            ql_bus.BaiViet_Update(qlbv, MaBaiViet);
            Response.Redirect("/Admins/BaiViet/QLBaiViet.aspx");
        }
    }
}