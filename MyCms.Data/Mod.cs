using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MyCms.Data
{
    public class Mod
    {
        #region [Declera variables]
        private string _Id;
        private string _Mod_Parent;
        private string _Mod_Name;
        private string _Mod_Code;
        private string _Modtype_ID;
        private string _Mod_Url;
        private string _Mod_Img;
        private string _Mod_Title;
        private string _Mod_Key;
        private string _Mod_Meta;
        private string _Mod_Content;
        private string _Mod_Status;
        private string _Mod_Hot;
        private string _Mod_Pos;
        private string _Mod_Level;
        private string _Lang;
        private string _Mod_style;
        private string _Mod_Tag;
        private string _Mod_Intro;
        private string _Mod_Same;
        #endregion

        #region [Public Variables]
        public string Id { get { return _Id; } set {  value=_Id; } }
        public string Mod_Parent { get { return _Mod_Parent; } set { value = _Mod_Parent; } }
        public string Mod_Name { get { return _Mod_Name; } set { value = _Mod_Name; } } 
        public string Mod_Code { get { return _Mod_Code; } set { value =_Mod_Code; } }
        public string Modtype_ID { get { return _Modtype_ID; } set { value = _Modtype_ID; } }
        public string Mod_Url { get { return _Mod_Url; } set { value = _Mod_Url; } }
        public string Mod_Img { get { return _Mod_Img; } set { value = _Mod_Img; } }
        public string Mod_Title { get { return _Mod_Title; } set { value = _Mod_Title; } }
        public string Mod_Key { get { return _Mod_Key; } set { value = _Mod_Key; } }
        public string Mod_Meta { get { return _Mod_Meta; } set { value = _Mod_Meta; } }
        public string Mod_Content { get { return _Mod_Content; } set { value = _Mod_Content; } }
        public string Mod_Status { get { return _Mod_Status;   } set { value = _Mod_Status;  } }
        public string Mod_Hot { get { return _Mod_Hot; } set { value = _Mod_Hot; } }
        public string Mod_Pos {  get { return _Mod_Pos; } set { value = _Mod_Pos; } }
        public string Mod_Level { get { return _Mod_Level; } set { value = _Mod_Level; } }  
        public string Lang { get { return _Lang; } set { value = _Lang; } }
        public string Mod_style { get { return _Mod_style; } set { value = _Mod_style; } }
        public string Mod_Tag { get { return _Mod_Tag; } set { value = _Mod_Tag; } }
        public string Mod_Intro { get { return _Mod_Intro; } set { value = _Mod_Intro; } }
        public string Mod_Same {  get { return _Mod_Same; } set { value = _Mod_Same; } }
        #endregion
        #region [Mod_IDataReader]
        public Mod ModIDataReader (IDataReader dr)
        {
            Data.Mod obj = new Data.Mod();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Mod_Parent = (dr["Mod_Parent"] is DBNull) ? string.Empty : dr["Mod_Parent"].ToString();
            obj.Mod_Name = (dr["Mod_Name"] is DBNull) ? string.Empty : dr["Mod_Name"].ToString();
            obj.Mod_Code = (dr["Mod_Code"] is DBNull) ? string.Empty : dr["Mod_Code"].ToString();
            obj.Modtype_ID = (dr["Modtype_ID"] is DBNull) ? string.Empty : dr["Modtype_ID"].ToString();
            obj.Mod_Url = (dr["Mod_Url"] is DBNull) ? string.Empty : dr["Mod_Url"].ToString();
            obj.Mod_Title = (dr["Mod_Title"] is DBNull) ? string.Empty : dr["Mod_Title"].ToString();
            obj.Mod_Key = (dr["Mod_Key"] is DBNull) ? string.Empty : dr["Mod_Key"].ToString();
            obj.Mod_Meta = (dr["Mod_Meta"] is DBNull) ? string.Empty : dr["Mod_Meta"].ToString();
            obj.Mod_Content = (dr["Mod_Content"] is DBNull) ? string.Empty : dr["Mod_Content"].ToString();
            obj.Mod_Status = (dr["Mod_Status"] is DBNull) ? string.Empty : dr["Mod_Status"].ToString();
            obj.Mod_Hot = (dr["Mod_Hot"] is DBNull) ? string.Empty : dr["Mod_Hot"].ToString();
            obj.Mod_Level = (dr["Mod_Level"] is DBNull) ? string.Empty : dr["Mod_Level"].ToString();
            obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
            obj.Mod_style = (dr["Mod_style"] is DBNull) ? string.Empty : dr["Mod_style"].ToString();
            obj.Mod_Tag = (dr["Mod_Tag"] is DBNull) ? string.Empty : dr["Mod_Tag"].ToString();
            obj.Mod_Intro = (dr["Mod_Intro"] is DBNull) ? string.Empty : dr["Mod_Intro"].ToString();
            obj.Mod_Same = (dr["Mod_Same"] is DBNull) ? string.Empty : dr["Mod_Same"].ToString();
            return obj;
        }
        #endregion

    }
}