using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCms.Data;
using System.Data;

namespace MyCms.Bus
{
    public class QLBaiVietBUS
    {
        QLBaiVietDAO ql_bv = new QLBaiVietDAO();

        // Thêm Bài Viết
        public bool BaiViet_Insert(QLBaiViet pBaiViet)
        {
            return ql_bv.BaiViet_Insert(pBaiViet);
        }

        // Sửa Bài Viết
        public bool BaiViet_Update(QLBaiViet pBaiViet, string MaBaiViet)
        {
            return ql_bv.BaiViet_Update(pBaiViet,MaBaiViet);
        }
    }
}