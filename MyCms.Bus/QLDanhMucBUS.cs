using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCms.Data;
using System.Data;

namespace MyCms.Bus
{
    public class QLDanhMucBUS
    {
        Data.QLDanhMucDAO ql_dm = new Data.QLDanhMucDAO();

        public DataTable ThongtinDM()
        {
            return ql_dm.ThongtinDM();
        }

        // Thêm Danh Mục
        public bool DanhMuc_Insert(QLDanhMuc pDanhMuc)
        {
            return ql_dm.DanhMuc_Insert(pDanhMuc);
        }

        // Sửa Danh Mục
        // Sửa danh mục
        public bool DanhMuc_Update(string madm, string tendm, string thutu, string madmcha, string hienthi)
        {
            return ql_dm.DanhMuc_Update(madm, tendm, thutu, madmcha, hienthi);
        }
    }
}