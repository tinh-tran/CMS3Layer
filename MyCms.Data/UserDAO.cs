using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;
namespace MyCms.Data
{
    public class UserDAO : SqlDataProvider
    {
        #region[User_GetById]        public List<Data.User> User_GetById(string id)
        {
            List<Data.User> list = new List<Data.User>();
            using (SqlCommand dbCmd = new SqlCommand("sp_User_GetById", GetConnection()))
            {
                Data.User obj = new Data.User();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.UserIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [User_UpdatePass]
        public bool User_UpdatePass(string password, string id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_User_UpdatePass", GetConnection())) 
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", id));
                dbCmd.Parameters.Add(new SqlParameter("Password", password));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;

        }
        #endregion


        #region [User_Insert]
        public bool User_Insert(User data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_User_Insert", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Username", data.Username));
                dbCmd.Parameters.Add(new SqlParameter("@Password", data.Password));
                dbCmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
                dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                dbCmd.Parameters.Add(new SqlParameter("@DateCreate", data.DateCreate));
                dbCmd.Parameters.Add(new SqlParameter("@Role", data.Role));
                dbCmd.Parameters.Add(new SqlParameter("@ModuleId", data.ModuleId));
                dbCmd.Parameters.Add(new SqlParameter("@ModuleName", data.ModuleName));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }
        #endregion
        #region [User_Update]
        public bool User_Update(User data)
        {
            using (SqlCommand dbcmd = new SqlCommand("sp_User_Update", GetConnection()))
            {
                dbcmd.CommandType = CommandType.StoredProcedure;
                dbcmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                dbcmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                dbcmd.Parameters.Add(new SqlParameter("@Username", data.Username));
                dbcmd.Parameters.Add(new SqlParameter("@Password", data.Password));
                dbcmd.Parameters.Add(new SqlParameter("@Admin", data.Admin));
                dbcmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbcmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                dbcmd.Parameters.Add(new SqlParameter("@DateCreate", data.DateCreate));
                dbcmd.Parameters.Add(new SqlParameter("@Role", data.Role));
                dbcmd.Parameters.Add(new SqlParameter("@ModuleId", data.ModuleId));
                dbcmd.Parameters.Add(new SqlParameter("@ModuleName", data.ModuleName));
                dbcmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }




        #endregion

        #region [User_Delete]
        public bool User_Delete (String Id )
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_User_Delete", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }
        #endregion
        #region[User_GetByAll]        /// <summary>
                                       /// Lấy thông tin user
                                       /// </summary>
                                       /// <returns></returns>        public List<User> User_GetByAll()
        {
            List<Data.User> list = new List<Data.User>();
            using (SqlCommand dbCmd = new SqlCommand("sp_User_GetByAll", GetConnection()))
            {
                Data.User obj = new Data.User();
                dbCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.UserIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
    }
}