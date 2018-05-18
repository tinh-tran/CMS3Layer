using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCms.Admins
{
    public partial class Default : System.Web.UI.Page
    {
       
        public string lienhe = "";
        public string tintuc = "";
        public string thanhvien = "";
        public string tintucduyet = "";
        string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["Lang"] != null)
            {
                Lang = Request.Cookies["Lang"].Value;
            }

            if (!IsPostBack)
            {
                //thongtinchung();
                tinchuaduyet();

            }
        }
        void tinchuaduyet()
        {
          
        }
        protected void grdNews_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            grdNews.CurrentPageIndex = e.NewPageIndex;
            tinchuaduyet();
        }
        protected void grdNews_ItemCommand(object source, DataGridCommandEventArgs e)
        {
           
        }
    }
}