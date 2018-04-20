using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class ImagesDetailDAO : SqlDataProvider
    {

        #region [ImageDetail_GetById]
        public List<Data.ImagesDetail> ImageDetail_GetById(string id)
        {
            List<Data.ImagesDetail> listImageDetail = new List<Data.ImagesDetail>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImagesDetail_GetById", GetConnection()))
            {
                Data.ImagesDetail obj = new Data.ImagesDetail();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", id));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listImageDetail.Add(obj.ImageInfoIDataReader(dr));
                    }      
                }
                dr.Close();
                obj = null;

            }
            return listImageDetail;
        }
        #endregion

        #region [ImageDetail_GetByALl]
        public List<Data.ImagesDetail> ImageDetail_GetByAll()
        {
            List<Data.ImagesDetail> list = new List<ImagesDetail>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImagesDetail_GetByAll", GetConnection()))
            {
                Data.ImagesDetail obj = new Data.ImagesDetail();
                dbCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dbCmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ImageInfoIDataReader(dr));
                    }       
                }
                dr.Close();
                obj = null;
            }
            return list;
        }


        #endregion
        #region[ImagesDetail_GetByTop]        public List<ImagesDetail> ImagesDetail_GetByTop(string Top, string Where, string Order)
        {
            List<Data.ImagesDetail> list = new List<Data.ImagesDetail>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImagesDetail_GetByTop", GetConnection()))
            {
                Data.ImagesDetail obj = new Data.ImagesDetail();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ImageInfoIDataReader(dr));
                    }

                    //conn.Close();
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [ImagesDetail_Insert]
        public bool ImagesDetail_Insert (Data.ImagesDetail obj)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_ImagesDetail_Insert", GetConnection()))
            { 
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Name", obj.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Image", obj.Image));
                dbCmd.Parameters.Add(new SqlParameter("@ImagesId", obj.ImageId));
                dbCmd.Parameters.Add(new SqlParameter("@Active", obj.Active));
                dbCmd.Parameters.Add(new SqlParameter("@Summary", obj.Summary));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }
        #endregion
        #region [ImagesDetail_Update]
        public bool ImagesDetail_Update(Data.ImagesDetail obj)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_ImagesDetail_Update", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", obj.Id));
                dbCmd.Parameters.Add(new SqlParameter("@Name", obj.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Image", obj.Image));
                dbCmd.Parameters.Add(new SqlParameter("@ImagesId", obj.ImageId));
                dbCmd.Parameters.Add(new SqlParameter("@Active", obj.Active));
                dbCmd.Parameters.Add(new SqlParameter("@Summary", obj.Summary));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }
        #endregion
        #region [ImagesDetail_Delete]
        public bool ImagesDetail_Delete(string Id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_ImagesDetail_Delete", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }
        #endregion

    }
}