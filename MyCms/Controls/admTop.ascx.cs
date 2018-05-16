using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Bus;

namespace MyCms.Controls
{
    public partial class admTop : System.Web.UI.UserControl
    {private string Lang = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            Lang = Request.Cookies["Lang"].Value;
            if (!IsPostBack)
            {
                if (Lang == "en")
                {
                    ltrLanguage.Text = "Tiếng Anh";
                }
                if (Lang == "vi")
                {
                    ltrLanguage.Text = "Tiếng Việt";
                }
                if (Lang == "cn")
                {
                    ltrLanguage.Text = "Tiếng Trung";
                }
                List<Data.User> list = UserBUS.User_GetById(Request.Cookies["IdUser"].Value);
                if (list.Count > 0)
                {
                    ltrUsername.Text = list[0].Name;
                }

            }
        }
        // khi click tự hiểu lang def để insert vào csdl 
        protected void lbtVi_Click(object sender, EventArgs e)
        {
            Response.Cookies["Lang"].Expires = DateTime.Now.AddDays(-1);
            HttpCookie cookie_Lang = new HttpCookie("Lang", "vi");
            cookie_Lang.Expires = DateTime.Now.AddHours(4);
            Response.Cookies.Add(cookie_Lang);
            Response.Redirect("/quantri");
        }

        protected void lbtEn_Click(object sender, EventArgs e)
        {
            Response.Cookies["Lang"].Expires = DateTime.Now.AddDays(-1);
            HttpCookie cookie_Lang = new HttpCookie("Lang", "en");
            cookie_Lang.Expires = DateTime.Now.AddHours(4);
            Response.Cookies.Add(cookie_Lang);
            Response.Redirect("/quantri");
        }

        protected void lbtCn_Click(object sender, EventArgs e)
        {
            Response.Cookies["Lang"].Expires = DateTime.Now.AddDays(-1);
            HttpCookie cookie_Lang = new HttpCookie("Lang", "cn");
            cookie_Lang.Expires = DateTime.Now.AddHours(4);
            Response.Cookies.Add(cookie_Lang);
            Response.Redirect("/quantri");
        }
    }
}