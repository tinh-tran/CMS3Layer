using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Data;

namespace MyCms.Admins.BaiViet.Ajax
{
    public partial class AjDanhMuc : System.Web.UI.Page
    {
        QLDanhMucDAO ql_dm = new QLDanhMucDAO();
        private string thaotac = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["ThaoTac"] != null)
            {
                thaotac = Request.Params["ThaoTac"];
            }

            switch (thaotac)
            {
                case "XoaDanhMuc":
                    XoaDanhMuc();
                    break;

            }

       }
        private void XoaDanhMuc()
        {
            string MaDM = "";
            if (Request.Params["MaDM"] != null)
            {
                MaDM = Request.Params["MaDM"];
                ql_dm.DanhMuc_Delete(MaDM);
                // Trả về thông báo 1 thực hiện thành công 2 thực hiện không thành công
                Response.Write("1");
            }
        }
    }
}