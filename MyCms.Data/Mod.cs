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
        public string Id { get { return _Id; } set { _Id = value; } }
        public string Mod_Parent { get { return _Mod_Parent; } set { _Mod_Parent = value; } }
        public string Mod_Name { get { return _Mod_Name; } set { _Mod_Name = value; } }
        public string Mod_Code { get { return _Mod_Code; } set { _Mod_Code = value; } }
        public string Modtype_ID { get { return _Modtype_ID; } set { _Modtype_ID = value; } }
        public string Mod_Url { get { return _Mod_Url; } set { _Mod_Url = value; } }
        public string Mod_Img { get { return _Mod_Img; } set { _Mod_Img = value; } }
        public string Mod_Title { get { return _Mod_Title; } set { _Mod_Title = value; } }
        public string Mod_Key { get { return _Mod_Key; } set { _Mod_Key = value; } }
        public string Mod_Meta { get { return _Mod_Meta; } set { _Mod_Meta = value; } }
        public string Mod_Content { get { return _Mod_Content; } set { _Mod_Content = value; } }
        public string Mod_Status { get { return _Mod_Status; } set { _Mod_Status = value; } }
        public string Mod_Hot { get { return _Mod_Hot; } set { _Mod_Hot = value; } }
        public string Mod_Pos { get { return _Mod_Pos; } set { _Mod_Pos = value; } }
        public string Mod_Level { get { return _Mod_Level; } set { _Mod_Level = value; } }
        public string Lang { get { return _Lang; } set { _Lang = value; } }
        public string Mod_style { get { return _Mod_style; } set { _Mod_style = value; } }
        public string Mod_Tag { get { return _Mod_Tag; } set { _Mod_Tag = value; } }
        public string Mod_Intro { get { return _Mod_Intro; } set { _Mod_Intro = value; } }
        public string Mod_Same { get { return _Mod_Same; } set { _Mod_Same = value; } }
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
            obj.Mod_Img = (dr["Mod_Img"] is DBNull) ? string.Empty : dr["Mod_Img"].ToString();
            obj.Mod_Title = (dr["Mod_Title"] is DBNull) ? string.Empty : dr["Mod_Title"].ToString();
            obj.Mod_Key = (dr["Mod_Key"] is DBNull) ? string.Empty : dr["Mod_Key"].ToString();
            obj.Mod_Meta = (dr["Mod_Meta"] is DBNull) ? string.Empty : dr["Mod_Meta"].ToString();
            obj.Mod_Content = (dr["Mod_Content"] is DBNull) ? string.Empty : dr["Mod_Content"].ToString();
            obj.Mod_Status = (dr["Mod_Status"] is DBNull) ? string.Empty : dr["Mod_Status"].ToString();
            obj.Mod_Hot = (dr["Mod_Hot"] is DBNull) ? string.Empty : dr["Mod_Hot"].ToString();
            obj.Mod_Pos = (dr["Mod_Pos"] is DBNull) ? string.Empty : dr["Mod_Pos"].ToString();
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