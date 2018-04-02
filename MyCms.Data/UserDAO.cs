using System;using System.Data;using System.Data.SqlClient;using System.Collections.Generic;
namespace MyCms.Data
{
    public class UserDAO : SqlDataProvider
    {

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