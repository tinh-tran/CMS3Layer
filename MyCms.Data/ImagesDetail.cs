using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;

namespace MyCms.Data
{
    public class ImagesDetail
    {
        #region [Declare variables ]
        private string _Id;
        private string _Name;
        private string _Image;
        private string _ImageId;
        private string _Active;
        private string _Summary;
        #endregion

        #region [Public Properties]
        public string Id { get { return _Id; } set { _Id= value; } }

        public string Name { get { return _Name; } set { _Name = value; } }
        
        public string Image { get { return _Image; } set { _Image = value; } }

        public string ImageId { get { return _ImageId; } set { _ImageId = value; } }

        public string Active { get { return _Active; } set { _Active = value; }  }

        public string Summary { get { return _Summary; } set { _Summary = value; } }
        #endregion
        #region [ Userr_ IdataReader]
        public ImagesDetail ImageInfoIDataReader(IDataReader dr)
        {
            Data.ImagesDetail obj = new Data.ImagesDetail();
            obj.Id= (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.ImageId = (dr["ImagesId"] is DBNull) ? string.Empty : dr["ImagesId"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Summary = (dr["Summary"] is DBNull) ? string.Empty : dr["Summary"].ToString();
            return obj;
        }
        #endregion
    }
}