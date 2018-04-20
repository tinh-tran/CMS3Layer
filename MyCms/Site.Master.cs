using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyCms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["IdUser"] == null)
            {
                Response.Redirect("/login");
            }
            if (!IsPostBack)
            {
                //menuadminpermission();
            }
        }
        //    void menuadminpermission()
        //    {
        //        string strUrl = "";
        //        strUrl = Request.Url.AbsolutePath.ToString();
        //        if (Request.Cookies["Admin"].Value == "1")
        //        {

        //        }
        //}
    }

}