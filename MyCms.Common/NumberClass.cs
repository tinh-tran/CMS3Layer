using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Globalization;


namespace MyCms.Common
{
    public class NumberClass
    {
        protected static string GetScriptValidatorNumber()
        {
            string str;
            str = "<script> ";
            str += @" function OnlyInputNumber(Characters){";
            str += @" var re; ";
            str += @"var ch=String.fromCharCode(event.keyCode);";
            str += @"if (event.keyCode<32)";
            str += @"{";
            str += @"return;";
            str += @"};";
            str += @"if( (event.keyCode<=57)&&(event.keyCode>=48))";
            str += @"{";
            str += @"if (!event.shiftKey)";
            str += @"{";
            str += @"return;";
            str += @"}";
            str += @"}";
            str += @"if (Characters.length >0 && ch==Characters)";
            str += @"{";
            str += @"return;";
            str += @"}";
            str += @"event.returnValue=false;";
            str += "}</script>";
            return str;
        }
        public static void OnlyInputNumber(TextBox textBox)
        {
            OnlyInputNumber(textBox, "");
        }

        public static void OnlyInputNumber(TextBox textBox, string Characters)
        {
            StringClass.CreateClientScriptAttributes(textBox, "onkeypress", "OnlyInputNumber('" + Characters + "')", GetScriptValidatorNumber());
        }
    }
}