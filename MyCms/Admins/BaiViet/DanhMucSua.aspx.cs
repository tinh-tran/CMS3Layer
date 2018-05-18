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
    public partial class DanhMucSua : System.Web.UI.Page
    {
        private string thaotac = "";
        string hienthi;
        private string MaDM = "";
        private string maDMCha = "";
        QLDanhMucDAO ql_dm = new QLDanhMucDAO();
        QLDanhMucBUS ql_bus = new QLDanhMucBUS();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMaDM.Enabled = false;
            if (Request.QueryString["thaotac"] != null)
                thaotac = Request.QueryString["thaotac"];
            if (Request.QueryString["MaDM"] != null)
                MaDM = Request.QueryString["MaDM"];
            if (Request.QueryString["maDMCha"] != null)
                maDMCha = Request.QueryString["maDMCha"];
            if (!IsPostBack)
            {
                switch (thaotac)
                {
                    case "chinhsua":
                        Hienthithongtin(MaDM);
                        break;
                }
                DanhMucCha();
            }
        }
            private void Hienthithongtin(string maDM)
        {
            if (thaotac == "chinhsua")
            {
                DataTable dt = new DataTable();
                dt = ql_dm.ThongtinDMMaDM(MaDM);

                if (dt.Rows.Count > 0)
                {
                    txtMaDM.Text = dt.Rows[0]["MaDM"].ToString();
                    txtTenDanhMuc.Text = dt.Rows[0]["TenDM"].ToString();
                    txtThuTu.Text = dt.Rows[0]["ThuTu"].ToString();
                    ddlDmCha.SelectedValue = dt.Rows[0]["MaDMCha"].ToString();

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

            ql_bus.DanhMuc_Update(txtMaDM.Text, txtTenDanhMuc.Text, txtThuTu.Text, ddlDmCha.SelectedValue.ToString(), hienthi);
            txtTenDanhMuc.Text = "";
            txtThuTu.Text = "";
            Response.Redirect("/Admins/BaiViet/QLDanhMuc.aspx");
        }
       }
    }