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
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Data.User> list = UserBUS.User_GetById(Request.Cookies["IdUser"].Value);
            if (list.Count > 0)
            {
                ltrUsername.Text = list[0].Name;
            }

        }
    }
}