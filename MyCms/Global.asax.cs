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
        void RegisterRoutes(RouteCollection routes)
        {
            //admin
            RouteTable.Routes.MapPageRoute("Login", "login", "~/Modules/Pages/Login.aspx");
            RouteTable.Routes.MapPageRoute("Logout", "logout", "~/Modules/Pages/logout.aspx");
            RouteTable.Routes.MapPageRoute("User", "user", "~/Admins/Users.aspx");
        }
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes(RouteTable.Routes);
            // Code that runs on application startup
            //RouteConfig.RegisterRoutes(RouteTable.Routes);
            //BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}