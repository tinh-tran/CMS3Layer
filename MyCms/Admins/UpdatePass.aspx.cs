using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Bus;

namespace MyCms.Admins
{
    public partial class UpdatePass : System.Web.UI.Page
    {
        string IdUser = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Request Cookie User 
            IdUser = Request.Cookies["IdUser"].Value;
            // Chỉ admin mới có quyền reset mật khẩu 
            if (Request.Cookies["Admin"].Value == "1")
            {
                lbtReset.Visible = true;
            }
            
        }

        protected void lbtReset_Click(object sender, EventArgs e)
        {
            Data.SqlDataProvider sql = new Data.SqlDataProvider();
            sql.ExecuteNonQuery("Update [Users] set Password='12345679'  Where Id='" + Request.QueryString["Id"] + "'");
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Reset mật khẩu mới thành 12345679');", true);

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                //trường hợp adin reset pass
                // trả về Request Id và request cookie admin 
                if( Request.QueryString ["Id"] !=null && Request.Cookies["Admin"].Value == "1" )
                {
                    string Id = Request.QueryString["Id"].ToString();
                    string Passnew = txtPassNew.Text;
                    List<Data.User> list = UserBUS.User_GetById(Id);
                    if(list.Count >0)
                    {
                        if (txtPassOld.Text == list[0].Password)
                        {
                            Data.SqlDataProvider sql = new Data.SqlDataProvider();
                            sql.ExecuteNonQuery("Update [Users] set Password='" + txtPassNew.Text + "'  Where Id='" + Id + "'");
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update thành công mật khẩu mới');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update không thành công');", true);
                        }

                    }
                    list.Clear();
                    list = null;
                }
                else
                {
                    List<Data.User> list = UserBUS.User_GetById(IdUser);
                    if (list.Count > 0)
                    {
                        if (txtPassOld.Text == list[0].Password)
                        {
                            Data.SqlDataProvider sql = new Data.SqlDataProvider();
                            sql.ExecuteNonQuery("Update [Users] set Password='" + txtPassNew.Text + "'  Where Id='" + IdUser + "'");
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update thành công mật khẩu mới');", true);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Update không thành công');", true);
                        }

                    }
                    list.Clear();
                    list = null;
                }
            }
        }
    }
}