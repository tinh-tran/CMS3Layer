using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;

namespace MyCms.Data
{
    public class User 
    {
        #region[Declare variables]        private string _Id;
        private string _Name;
        private string _Username;
        private string _Password;
        private string _Admin;
        private string _Active;
        private string _Image;
        private string _DateCreate;
        private string _Role;
        private string _ModuleId;
        private string _ModuleName;



        #endregion
        #region[Public Properties]        public string Id { get { return _Id; } set { _Id = value; } }
        public string Name { get { return _Name; } set { _Name = value; } }
        public string Username { get { return _Username; } set { _Username = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public string Admin { get { return _Admin; } set { _Admin = value; } }
        public string Active { get { return _Active; } set { _Active = value; } }
        public string Image { get { return _Image; } set { _Image = value; } }
        public string DateCreate { get { return _DateCreate; } set { _DateCreate = value; } }
        public string Role { get { return _Role; } set { _Role = value; } }
        public string ModuleId { get { return _ModuleId; } set { _ModuleId = value; } }
        public string ModuleName { get { return _ModuleName; } set { _ModuleName = value; } }

        #endregion
        #region[User IDataReader]        public User UserIDataReader(IDataReader dr)
        {
            Data.User obj = new Data.User();
            obj.Id = (dr["Id"] is DBNull) ? string.Empty : dr["Id"].ToString();
            obj.Name = (dr["Name"] is DBNull) ? string.Empty : dr["Name"].ToString();
            obj.Username = (dr["Username"] is DBNull) ? string.Empty : dr["Username"].ToString();
            obj.Password = (dr["Password"] is DBNull) ? string.Empty : dr["Password"].ToString();
            obj.Admin = (dr["Admin"] is DBNull) ? string.Empty : dr["Admin"].ToString();
            obj.Active = (dr["Active"] is DBNull) ? string.Empty : dr["Active"].ToString();
            obj.Image = (dr["Image"] is DBNull) ? string.Empty : dr["Image"].ToString();
            obj.DateCreate = (dr["DateCreate"] is DBNull) ? string.Empty : dr["DateCreate"].ToString();
            obj.Role = (dr["Role"] is DBNull) ? string.Empty : dr["Role"].ToString();
            obj.ModuleId = (dr["ModuleId"] is DBNull) ? string.Empty : dr["ModuleId"].ToString();
            obj.ModuleName = (dr["ModuleName"] is DBNull) ? string.Empty : dr["ModuleName"].ToString();
            return obj;
        }
        #endregion
    }
}