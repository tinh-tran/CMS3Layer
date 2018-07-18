using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MyCms.Data;
using MyCms.Bus;
using MyCms.Common;

namespace MyCms
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(Request.Cookies["Lang"].Value))
            {
                HttpCookie cookie_Lang = new HttpCookie("Lang", Global.LangDefault);
                cookie_Lang.Expires = DateTime.Now.AddHours(4);
                Response.Cookies.Add(cookie_Lang);
            }
            if (Request.Cookies["IdUser"] == null)
            {
                Response.Redirect("/login");
            }
            if (!IsPostBack)
            {
                menuadminpermission();
            }
        }
        void menuadminpermission()
        {
            string strUrl = "";
            strUrl = Request.Url.AbsolutePath.ToString();
            if (Request.Cookies["Admin"].Value == "1")
            {
                string s = "";
                List<Data.Module> list = ModuleBUS.Module_GetByTop("", "Idcha=0 and Active=1", "Ord asc");
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        //check active menu cha
                        if (list[i].Link.StartsWith(strUrl))
                        {
                            s += "<li class=\"treeview active\"><a href=\"" + list[i].Link + "\"><i class=\"fa " + list[i].Icon + " fa-fw\"></i> <span> " + list[i].Name + "</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        }
                        else
                        {
                            s += "<li class=\"treeview\"><a href=\"" + list[i].Link + "\"><i class=\"fa " + list[i].Icon + " fa-fw\"></i> <span> " + list[i].Name + "</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        }
                        List<Data.Module> list2 = ModuleBUS.Module_GetByTop("", "Idcha=" + list[i].Id + " and Active=1", "Ord asc");
                        if (list2.Count > 0)
                        {
                            //check active ul menu con
                            List<Data.Module> list3 = ModuleBUS.Module_GetByTop("", "Idcha=" + list[i].Id + " and Active=1 and Link like '" + strUrl + "%'", "Ord asc");
                            if (list3.Count > 0)
                            {
                                s += "<ul class=\"treeview-menu menu-open\" style=\"display: block;\">";
                            }
                            else
                            {
                                s += "<ul class=\"treeview-menu\">";
                            }

                            for (int j = 0; j < list2.Count; j++)
                            {
                                //check active menu con
                                if (list2[j].Link.StartsWith(strUrl))
                                {
                                    s += "<li class='active'><a href='" + list2[j].Link + "'><i class=\"fa fa-circle-o\"></i>" + list2[j].Name + "</a></li>";
                                }
                                else
                                {
                                    s += "<li><a href='" + list2[j].Link + "'><i class=\"fa fa-circle-o\"></i>" + list2[j].Name + "</a></li>";
                                }
                            }
                            s += "</ul>";

                            s += "";
                        }

                        s += " </li>";
                    }
                }
                ltrmenuadmin.Text = s;
            }
            else
            {
                checkpermision();
                string s = "";
                List<Data.Module> list = ModuleBUS.Module_GetByTop("", "Idcha=0 and Active=1", "Ord asc");
                if (list.Count > 0)
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        //check active menu cha
                        if (list[i].Link.StartsWith(strUrl) && check(list[i].Id) == true)
                        {
                            s += "<li class=\"treeview active\"><a href=\"" + list[i].Link + "\"><i class=\"fa " + list[i].Icon + " fa-fw\"></i> <span> " + list[i].Name + "</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        }
                        else if (check(list[i].Id) == true)
                        {
                            s += "<li class=\"treeview\"><a href=\"" + list[i].Link + "\"><i class=\"fa " + list[i].Icon + " fa-fw\"></i> <span> " + list[i].Name + "</span> <i class=\"fa fa-angle-left pull-right\"></i></a>";
                        }

                        List<Data.Module> list2 = ModuleBUS.Module_GetByTop("", "Idcha=" + list[i].Id + " and Active=1", "Ord asc");
                        if (list2.Count > 0)
                        {
                            //check active ul menu con
                            List<Data.Module> list3 = ModuleBUS.Module_GetByTop("", "Idcha=" + list[i].Id + " and Active=1 and Link like '" + strUrl + "%'", "Ord asc");
                            if (list3.Count > 0)
                            {
                                s += "<ul class=\"treeview-menu menu-open\" style=\"display: block;\">";
                            }
                            else
                            {
                                s += "<ul class=\"treeview-menu\">";
                            }

                            for (int j = 0; j < list2.Count; j++)
                            {
                                //check active menu con
                                if (list2[j].Link.StartsWith(strUrl) && check(list2[j].Id) == true)
                                {
                                    s += "<li class='active'><a href='" + list2[j].Link + "'><i class=\"fa fa-circle-o\"></i>" + list2[j].Name + "</a></li>";
                                }
                                else if (check(list2[j].Id) == true)
                                {
                                    s += "<li><a href='" + list2[j].Link + "'><i class=\"fa fa-circle-o\"></i>" + list2[j].Name + "</a></li>";
                                }
                            }
                            s += "</ul>";

                            s += "";
                        }

                        s += " </li>";
                    }
                }

                ltrmenuadmin.Text = s;
            }
        }
        void checkpermision()
        {
            string url = Request.Url.AbsolutePath;
            List<Data.Module> list = ModuleBUS.Module_GetByTop("", "Link like '%" + url + "%'", "");
            {
                if (list.Count > 0)
                {
                    //List<Data.Roles> list2 = ModuleBUS.RolesService.Roles_GetByTop("", "IdMenuAd=" + list[0].Id + " and IdUser=" + Request.Cookies["IdUser"].Value + " and IsView=1", "");
                    //if (list2.Count == 0)
                    //{
                    //    if (url == "/quantri")
                    //    {

                    //    }
                    //    else
                    //    {
                    //        Response.Redirect("/Admins/Error.aspx");
                    //    }
                    //}
                    if (url == "/user")
                    {

                    }
                }
            }
        }
        private bool check(string id)
        {
            //List<Data.Roles> list = Business.RolesService.Roles_GetByTop("", "IdMenuAd=" + id + " and IdUser=" + Request.Cookies["IdUser"].Value + "", "");
            //if (list.Count > 0)
            //{
            //    if (list[0].IsView == "True")
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //else
            //{
            //    
            //}
            return true;
        }

    }
}