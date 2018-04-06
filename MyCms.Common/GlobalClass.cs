using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCms.Common
{
    public class GlobalClass
    {
        static public string ApplicationPath
        {

            get
            {
                string applicationPath = HttpContext.Current.Request.ApplicationPath;
                if (applicationPath == "/")
                {
                    return string.Empty;
                }
                else
                {
                    return applicationPath;
                }
            }

        }
        static public String GetUrlAdminImage()
        {
            try
            {
                return ApplicationPath + "/App_Themes/Admin/images/";
            }
            catch { return ""; }
        }
    }
}