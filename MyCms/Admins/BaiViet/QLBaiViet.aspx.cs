using MyCms.Bus;
using MyCms.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCms.Admins.BaiViet
{
   
    public partial class QLBaiViet : System.Web.UI.Page
    {
        string maDMCha = "0";
        public string hienthi;
        DataTable dt = new DataTable();
        QLDanhMucDAO ql_dm = new QLDanhMucDAO();
        QLBaiVietDAO ql_bv = new QLBaiVietDAO();
        QLBaiVietBUS ql_bus = new QLBaiVietBUS();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["maDMCha"] != null)
                maDMCha = Request.QueryString["maDMCha"];

            if (!IsPostBack)
            {
                // Lấy danh mục cha
                DanhMucCha();

                // Lấy bài viết
                LayBaiViet();
            }
        }
        //Lấy danh mục vào ddlDmCha
        private void DanhMucCha()
        {
            DataTable dt = new DataTable();
            dt = ql_dm.ThongtinDMCha("0");
            ddlDmCha.Items.Clear();
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

        //Lấy bài viết vào danh sách
        private void LayBaiViet()
        {
            dt = new DataTable();
            dt = ql_bv.ThongtinBV(); // Lấy ra danh sách bài viết

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ltrBaiViet.Text += @"
           <tr id='maDong" + dt.Rows[i]["MaBaiViet"] + @"'>
               <td class='cotMa'>" + dt.Rows[i]["MaBaiViet"] + @"</td>
               <td class='cotTen'>" + dt.Rows[i]["TenBaiViet"] +@"</td>
               <td class='cotTieuDe'>" + dt.Rows[i]["TieuDe"] + @"</td>
               <td class='cotNoiDung' style='text-overflow: ellipsis'>" + dt.Rows[i]["NoiDung"] +@"</td>
               <td class='cotAnh'>" + dt.Rows[i]["Anh"] + @"</td>
               <td class='cotThuTu'>" + dt.Rows[i]["ThuTu"] + @"</td>
               <td class='cotHienThi'>" + dt.Rows[i]["HienThi"] + @"</td>
               <td class='cotDanhMuc'>" + dt.Rows[i]["TenDM"] + @"</td>
               <td class='cotChucNang'> 
                    <a href='/Admins/BaiViet/BaiVietSua.aspx?thaotac=chinhsua&MaBaiViet=" + dt.Rows[i]["MaBaiViet"] + @"' class='sua'title='Sửa'></a>
                    <a href='javascript:XoaBaiViet(" + dt.Rows[i]["MaBaiViet"] + @")' class='xoa' title='Xóa'></a>
               </td>
           </tr>
            ";
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            if (flAnhDaiDien.FileContent.Length > 0)
            {
                if (flAnhDaiDien.FileContent.Length > 0)
                {
                    if (flAnhDaiDien.FileName.EndsWith(".jpeg") || flAnhDaiDien.FileName.EndsWith(".jpg") || flAnhDaiDien.FileName.EndsWith(".png") || flAnhDaiDien.FileName.EndsWith(".gif"))
                    {
                        flAnhDaiDien.SaveAs(Server.MapPath("/Admins/pic/BaiViet/") + flAnhDaiDien.FileName);
                    }
                }
                if (cbHienThi.Checked == true)
                {
                    hienthi = "true";
                }
                else
                {
                    hienthi = "false";
                }

                Data.QLBaiViet qlbv = new Data.QLBaiViet( txtTenBaiViet.Text, txtNoiDung.Text, txtTieuDe.Text, flAnhDaiDien.FileName, txtThuTu.Text, hienthi, ddlDmCha.SelectedValue.ToString());
                ql_bus.BaiViet_Insert(qlbv);
                Response.Redirect("/Admins/BaiViet/QLBaiViet.aspx");
            }
            else
            {
                if (cbHienThi.Checked == true)
                {
                    hienthi = "true";
                }
                else
                {
                    hienthi = "false";
                }
                Data.QLBaiViet qlbv = new Data.QLBaiViet(txtTenBaiViet.Text, txtNoiDung.Text, txtTieuDe.Text, null, txtThuTu.Text, hienthi, ddlDmCha.SelectedValue.ToString());
                ql_bus.BaiViet_Insert(qlbv);
                Response.Redirect("/Admins/BaiViet/QLBaiViet.aspx");
            }

            
        }
    }
}