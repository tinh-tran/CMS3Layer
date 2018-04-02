using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Bus;
using MyCms.Data;

namespace MyCms.Modules.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //khởi tạo cookie
                HttpCookie cookie_IdUser = new HttpCookie("IdUser", "");
                cookie_IdUser.Expires = DateTime.Now;
                HttpCookie cookie_Admin = new HttpCookie("Admin", "");
                cookie_Admin.Expires = DateTime.Now;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string UId = txtUsername.Text;
            string PId = txtPassword.Text;
            List<User> list = new List<User>();
            list = UserBUS.User_Validate(UId, PId);
            if (list.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(UId, false);
                HttpCookie cookie_IdUser = new HttpCookie("IdUser", list[0].Id.ToString());
                cookie_IdUser.Expires = DateTime.Now.AddHours(4);
                Response.Cookies.Add(cookie_IdUser);
                HttpCookie cookie_Admin = new HttpCookie("Admin", list[0].Admin.ToString());
                cookie_Admin.Expires = DateTime.Now.AddHours(4);
                Response.Cookies.Add(cookie_Admin);
                ltrError.Text = "Đăng nhập thành công!";
            }
            else
            {
                txtPassword.Text = "";
                txtPassword.Focus();
                ltrError.Text = "Đăng nhập không thành công!";
            }
        }
    }
}