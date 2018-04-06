using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyCms.Common
{
    public class PageHelper : System.Web.UI.UserControl
    {
        public static string ShowActiveToolTip(string ActiveCode)
        {
            return ActiveCode == "1" || ActiveCode == "True" ? "Ẩn" : "Hiển thị";
        }
        public static string ShowActiveImage(string ActiveCode)
        {
            string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "show.png" : "hide.png";
            return GlobalClass.GetUrlAdminImage() + strReturn;
        }

        public static string ShowCheckImage(string ActiveCode)
        {
            string strReturn = ActiveCode == "1" || ActiveCode == "True" ? "hot.png" : "normal.png";
            return GlobalClass.GetUrlAdminImage() + strReturn;
        }




    }
}