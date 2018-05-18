using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace MyCms
{
    public class Global : HttpApplication
    {
        public static string LangDefault = "";
        public string Lang = "";
        void RegisterRoutes(RouteCollection routes)
        {
            //admin
            RouteTable.Routes.MapPageRoute("Login", "login", "~/Modules/Pages/Login.aspx");
            RouteTable.Routes.MapPageRoute("Logout", "logout", "~/Modules/Pages/logout.aspx");
            RouteTable.Routes.MapPageRoute("User", "user", "~/Admins/Users.aspx");
            RouteTable.Routes.MapPageRoute("Admin", "quantri", "~/Admins/Default.aspx");
        }


        void Application_Start(object sender, EventArgs e)
        {
            LangDefault = "vi";
            //LangWeb = "vi";
            RegisterRoutes(RouteTable.Routes);
            try
            {
                Application["HomNay"] = 0;
                Application["HomQua"] = 0;
                Application["TuanNay"] = 0;
                Application["TuanTruoc"] = 0;
                Application["ThangNay"] = 0;
                Application["ThangTruoc"] = 0;
                Application["TatCa"] = 0;
                Application["visitors_online"] = 0;
            }
            catch (Exception)
            {
                throw;
            }
        }
        void Session_Start(object sender, EventArgs e)
        {
            //if (Session["LangWeb"] == null)
            //{
            //    Session["LangWeb"] = LangWeb;
            //}
            LangDefault = "vi";
            // Code that runs when a new session is started
            if (Request.Cookies["Lang"] == null || Request.Cookies["Lang"].Value == "")
            {
                HttpCookie cookie_Lang = new HttpCookie("Lang", LangDefault);
                cookie_Lang.Expires = DateTime.Now.AddHours(4);
                Response.Cookies.Add(cookie_Lang);
            }

        }
    }
}