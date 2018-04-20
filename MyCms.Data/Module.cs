using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace MyCms.Data
{
    public class Module
    {
        #region [Declare variables]
        private string _Id;
        private string _Name;
        private string _Idcha;
        private string _Ord;
        private string _Icon;
        private string _Link;
        private string _Active;
        #endregion

        #region [Public properties]
        public string Id { get { return _Id; } set { _Id = value; } }

        public string Name { get { return _Name; } set { _Name= value ; } }

        public string IdCha { get { return _Idcha; } set { _Idcha = value; } }

        public string Ord { get { return _Ord; } set { _Ord=value; } }
        public string Icon { get { return _Icon; } set { _Icon= value ; } }
        public string Link { get { return _Link; } set { _Link= value;  } }  
        public string Active { get { return _Active; } set { _Active =  value ; } }
        #endregion

        #region [ModuleIDataReader]
        public Module ModuleIDataReader(IDataReader dr)
        {
            Data.Module obj = new Data.Module();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.IdCha = (dr["IdCha"] is DBNull) ? string.Empty : dr["IdCha"].ToString();
            obj.Ord = (dr["Ord"] is DBNull) ? string.Empty : dr["Ord"].ToString();
            obj.Icon = (dr["Icon"] is DBNull) ? string.Empty : dr["Icon"].ToString();
            obj.Link = (dr["Link"] is DBNull) ? string.Empty : dr["Link"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            return obj;
        }
        #endregion


    }
}