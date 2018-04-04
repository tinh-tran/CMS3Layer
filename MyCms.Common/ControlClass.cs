using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CKEditor.NET;

namespace MyCms.Common
{
    public class ControlClass
    {
        //reset giá trị các control
        public static void ResetControlValues(Control parent)
        {
            //duyệt qua tất cả Control trên trang
            foreach (Control c in parent.Controls)
            {
                string abc = c.ID;
                //tại sao?
                if (c.Controls.Count > 0)
                {
                    //kiểm tra loại Control
                    if (c.GetType().ToString() == "CKEditor.NET")
                    {
                        ((CKEditorControl)c).Text = "";
                        break;
                    }
                    else
                    {
                        // sử dụng đệ quy
                        ResetControlValues(c);
                    }
                }
                else // < 0
                {
                    // kiểm tra loại control
                    switch (c.GetType().ToString())
                    {
                        // = ddl xóa item
                        //case "System.Web.UI.WebControls.DropDownList":
                        //    ((DropDownList)c).Items.Clear();
                        //    break;   
                        case "System.Web.UI.WebControls.TextBox":
                            ((TextBox)c).Text = "";
                            break;
                        //tại sao?
                        case "System.Web.UI.WebControls.CheckBox":
                            ((CheckBox)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.RadioButton":
                            ((RadioButton)c).Checked = false;
                            break;
                        case "System.Web.UI.WebControls.Image":
                            ((Image)c).ImageUrl = null;
                            ((Image)c).Width = 0;
                            break;
                        case "CKEditor.NET":
                            ((CKEditorControl)c).Text = "";
                            break;
                    }
                }
            }
        }
    }
}