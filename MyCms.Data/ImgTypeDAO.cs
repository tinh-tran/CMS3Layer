using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class ImgTypeDAO : SqlDataProvider
    {
        #region [ImgType_GetById]
        public List<ImgType> ImgType_GetById(string Id)
        {
            List<Data.ImgType> list = new List<Data.ImgType>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_GetById", GetConnection()))
            {
                Data.ImgType obj = new Data.ImgType();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ImagesTypeIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [ImgType_GetByAll]
        public List<ImgType> ImgType_GetByAll()
        {
            List<Data.ImgType> list = new List<Data.ImgType>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_GetByAll", GetConnection()))
            {
                Data.ImgType obj = new Data.ImgType();
                dbCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ImagesTypeIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [ImgType_GetByTop]
        public List<ImgType> ImgType_GetByTop(string Top, string Where, string Order)
        {
            List<Data.ImgType> list = new List<Data.ImgType>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_GetByTop", GetConnection()))
            {
                Data.ImgType obj = new Data.ImgType();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ImagesTypeIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [ImgType_Insert]
        public bool ImgType_Insert(ImgType data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_Insert", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Code", data.Code));
                dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("ImgType");
            return true;
        }
        #endregion
        #region [ImgType_Update]
        public bool ImgType_Update(ImgType data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_Update", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Code", data.Code));
                dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("ImgType");
            return true;
        }
        #endregion
        #region [ImgType_Delete]
        public bool ImgType_Delete(string Id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_Delete", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("ImgType");
            return true;
        }
        #endregion
    }
}