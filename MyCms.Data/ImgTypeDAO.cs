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
        public List<Data.ImgType> ImagType_GetById (string Id )
        {
            List<Data.ImgType> list = new List<ImgType>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_GetById", GetConnection()))
            {
                Data.ImgType obj = new Data.ImgType();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter ("@Id", Id));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.HasRows)
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
        public List<Data.ImgType> ImagType_GetByAll()
        {
            List<Data.ImgType> list = new List<ImgType>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImgType_GetByAll", GetConnection()))
            {
                Data.ImgType obj = new Data.ImgType();
                dbCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.HasRows)
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
        public List<Data.ImgType> ImgType_GetByTop(string Top , string Where, string Order)
        {
            List<Data.ImgType> list = new List<ImgType>();
            using (SqlCommand dbCmd = new SqlCommand("sp_ImageType_GetByTop", GetConnection()))
            {
                Data.ImgType obj = new Data.ImgType();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Oder", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.HasRows)
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
    }
}