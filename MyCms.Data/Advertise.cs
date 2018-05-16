using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace MyCms.Data
{
    public class Advertise
    {
        #region [Declera variables]
        private string _Id;
        private string _Name;
        private string _Summary;
        private string _Image;
        private string _ImageSmall;
        private string _Width;
        private string _Height;
        private string _Link;
        private string _Target;
        private string _ContentDetail;
        private string _Position;
        private string _PageId;
        private string _Click;
        private string _Ord;
        private string _Active;
        private string _Lang;
        #endregion
        #region [Public Variables]
        public string Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Summary { get { return _Summary; } set { _Summary = value; } } 
        public string Image { get { return _Image; } set { _Image = value; } }
        public string ImageSmall { get { return _ImageSmall; } set { _ImageSmall = value; } }
        public string Width { get { return _Width; } set { _Width = value; } }
        public string Height { get { return _Height; } set { _Height = value; } }
        public string Link { get { return _Link; } set { _Link = value; } }
        public string Target {  get { return _Target; } set { _Target = value; } }
        public string ContentDetail { get { return _ContentDetail; } set { _ContentDetail = value; } }
        public string Position { get { return _Position; } set { _Position = value; } }
        public string PageId { get { return _PageId; } set { _PageId = value ; } } 
        public string Click { get { return _Click; } set { _Click = value; } }  
        public string Ord { get { return _Ord; } set { _Ord = value; } }   
        public string Active { get { return _Active; } set { _Active = value; } }  
        public string Lang { get { return _Lang; }  set { _Lang = value; } }
        #endregion
        #region [Advertise_IDataReder]
        public Advertise Advertise_IDataReader (IDataReader dr)
        {
            Data.Advertise obj = new Data.Advertise();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Summary = (dr["Summary"] is DBNull) ? string.Empty : dr["Summary"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.ImageSmall = (dr["ImageSmall"] is DBNull) ? string.Empty : dr["ImageSmall"].ToString();
            obj.Width = (dr["Width"] is DBNull) ? string.Empty : dr["Width"].ToString();
            obj.Height = (dr["Height"] is DBNull) ? string.Empty : dr["Height"].ToString();
            obj.Link = (dr["Link"] is DBNull) ? string.Empty : dr["Link"].ToString();
            obj.Target = (dr["Target"] is DBNull) ? string.Empty : dr["Target"].ToString();
            obj.ContentDetail = (dr["ContentDetail"] is DBNull) ? string.Empty : dr["ContentDetail"].ToString();
            obj.Position = (dr["Position"] is DBNull) ? string.Empty : dr["Position"].ToString();
            obj.PageId = (dr["PageId"] is DBNull) ? string.Empty : dr["PageId"].ToString();
            obj.Click = (dr["Click"] is DBNull) ? string.Empty : dr["Click"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Lang = (dr["Lang"] is DBNull) ? string.Empty : dr["Lang"].ToString();
            return obj;
        }
        #endregion


    }
}