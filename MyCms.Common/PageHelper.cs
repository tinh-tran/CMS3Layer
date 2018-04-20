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
        public static string ShowActiveStatus(string ActiveCode)
        {
            return ActiveCode == "1" || ActiveCode == "True" ? "Hiển thị" : "Ẩn";
        }
        public static string ShowTrangThai(string ActiveCode)
        {
            return ActiveCode == "1" || ActiveCode == "True" ? "<span style=\"color:#1799A3\">Hoàn thành</span>" : "<span style=\"color:red\">Đang chờ</span>";
        }



    }
}