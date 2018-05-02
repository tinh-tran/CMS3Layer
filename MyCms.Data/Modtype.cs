using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace MyCms.Data
{
    public class Modtype
    {
        #region [Declare variables ]
        private string _Id;
        private string _Modtype_Name;
        private string _Modtype_Code;
        private string _Modtype_Status;
        private string _Modtype_Target;
        private string _Modtype_Filter;
        #endregion

        #region [Public Properties]
        public string Id { get { return _Id; } set { _Id = value; } }

        public string Modtype_Name { get { return _Modtype_Name; } set { _Modtype_Name = value; } }

        public string Modtype_Code { get { return _Modtype_Code; } set { _Modtype_Code = value; } }

        public string Modtype_Status { get { return _Modtype_Status; } set { _Modtype_Status = value; } }

        public string Modtype_Target { get { return _Modtype_Target; } set { _Modtype_Target = value; } }

        public string Modtype_Filter { get { return _Modtype_Filter; } set { _Modtype_Filter = value; } }
        #endregion
        #region [ Userr_ IdataReader]
        public Modtype ModtypeIDataReader(IDataReader dr)
        {
            Data.Modtype obj = new Data.Modtype();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Modtype_Name = (dr["Modtype_Name"] is DBNull) ? string.Empty : dr["Modtype_Name"].ToString();
            obj.Modtype_Code = (dr["Modtype_Code"] is DBNull) ? string.Empty : dr["Modtype_Code"].ToString();
            obj.Modtype_Status = (dr["Modtype_Status"] is DBNull) ? string.Empty : dr["Modtype_Status"].ToString();
            obj.Modtype_Target = (dr["Modtype_Target"] is DBNull) ? string.Empty : dr["Modtype_Target"].ToString();
            obj.Modtype_Filter = (dr["Modtype_Filter"] is DBNull) ? string.Empty : dr["Modtype_Filter"].ToString();
            return obj;
        }
        #endregion
    }
}