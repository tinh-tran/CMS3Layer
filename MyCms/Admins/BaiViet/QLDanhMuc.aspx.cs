using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Data;
using MyCms.Bus;

namespace MyCms.Admins.BaiViet
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string maDMCha = "0";
        public string hienthi;
        DataTable dt = new DataTable();
        QLDanhMucDAO ql_dm = new QLDanhMucDAO();
        QLDanhMucBUS ql_bus = new QLDanhMucBUS();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["maDMCha"] != null)
                maDMCha = Request.QueryString["maDMCha"];

            if (!IsPostBack)
            {
                // Lấy danh mục cha
                DanhMucCha();
                LayDanhMuc();
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

        //Hàm kiểm tra danh mục có danh mục con hay ko
        bool CoDanhMucCon(string MaDMCha)
        {
            dt = new DataTable();
            dt = ql_dm.ThongtinDMCha(MaDMCha);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        //Lấy danh mục vào danh sách
        private void LayDanhMuc()
        {
            dt = new DataTable();
            dt = ql_dm.ThongtinDMCha(maDMCha); // Lấy ra danh sách danh mục cha

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltrDanhMuc.Text += @"
           <tr id='maDong" + dt.Rows[i]["MaDM"] + @"'>
               <td class='cotMa'>" + dt.Rows[i]["MaDM"] + @"</td>
               <td class='cotTen'>" + dt.Rows[i]["TenDM"] + @"</td>
               <td class='cotThuTu'>" + dt.Rows[i]["ThuTu"] + @"</td>
               <td class='cotHienThi'>" + dt.Rows[i]["HienThi"] + @"</td>
               <td class='cotChucNang'>
                    <a href='/Admins/BaiViet/QLDanhMuc.aspx?maDMCha=" + dt.Rows[i]["MaDM"] + @"' class='dmcon' title='Xem danh mục con'></a>
                    <a href='/Admins/BaiViet/DanhMucSua.aspx?thaotac=chinhsua&MaDM=" + dt.Rows[i]["MaDM"] + @"' class='sua'title='Sửa'></a>
                    <a href='javascript:XoaDanhMuc(" + dt.Rows[i]["MaDM"] + @")' class='xoa' title='Xóa'></a>
               </td>
           </tr>
            ";
            }
        }
        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (cbHienThi.Checked == true)
            {
                hienthi = "true";
            }
            else
            {
                hienthi = "false";
            }
            QLDanhMuc ql = new QLDanhMuc(txtTenDanhMuc.Text, txtThuTu.Text, ddlDmCha.SelectedValue.ToString(), hienthi, "");
            ql_bus.DanhMuc_Insert(ql);
            Response.Redirect("/Admins/BaiViet/QLDanhMuc.aspx");
        }
    }
}