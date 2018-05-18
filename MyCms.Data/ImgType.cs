using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MyCms.Data
{
    public class ImgType
    {

        #region [Declare variables ]
        private string _Id;
        private string _Name;
        private string _Code;
        private string _Active;
        #endregion

        #region [Public properties]
        public string Id { get { return _Id;  }  set { _Id = value;  } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Code { get { return _Code;} set { _Code = value; } }
        public string Active { get { return _Active;  } set { _Active = value; } }
        #endregion
        #region [ImgType IDataReader]
        public ImgType ImagesTypeIDataReader(IDataReader dr)
        {
            Data.ImgType obj = new Data.ImgType();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Code = (dr["Code"] is DBNull) ? string.Empty : dr["Code"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            return obj;
        }
        #endregion



    }
}