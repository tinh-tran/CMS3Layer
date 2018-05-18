using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class AdvertiseDAO : SqlDataProvider
    {
        #region [Advertise_GetByAll]
        public List<Data.Advertise> Advertise_GetByAll(string Lang)
        {

            List<Data.Advertise> List = new List<Advertise>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetByAll", GetConnection()))
            {
                Data.Advertise obj = new Advertise();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Lang", Lang));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        List.Add(obj.Advertise_IDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return List;
        }
        #endregion
        #region [Advertise_GetByTop]
        public List<Data.Advertise> Advertise_GetByTop(string Top, string Where, string Order)
        {

            List<Data.Advertise> List = new List<Advertise>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetByTop", GetConnection()))
            {
                Data.Advertise obj = new Advertise();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        List.Add(obj.Advertise_IDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return List;
        }
        #endregion
        #region [Advertise_GetById]
        public List<Data.Advertise> Advertise_GetById(string Id)
        {

            List<Data.Advertise> List = new List<Advertise>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetById", GetConnection()))
            {
                Data.Advertise obj = new Advertise();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        List.Add(obj.Advertise_IDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return List;
        }
        #endregion
        #region [Advertise_GetByMod]
        public List<Data.Advertise> Advertise_GetByMod(string Top, string Where, string Order)
        {

            List<Data.Advertise> List = new List<Advertise>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetByMod", GetConnection()))
            {
                Data.Advertise obj = new Advertise();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        List.Add(obj.Advertise_IDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return List;
        }
        #endregion
        #region [Advertise_GetByType]
        public List<Data.Advertise> Advertise_GetByType(string Top, string Where, string Order)
        {

            List<Data.Advertise> List = new List<Advertise>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_GetByType", GetConnection()))
            {
                Data.Advertise obj = new Advertise();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        List.Add(obj.Advertise_IDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return List;
        }
        #endregion
        #region [Advertise_Insert]
        public bool Advertise_Insert(Advertise data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_Insert", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                dbCmd.Parameters.Add(new SqlParameter("@ImageSmall", data.ImageSmall));
                dbCmd.Parameters.Add(new SqlParameter("@Summary", data.Summary));
                dbCmd.Parameters.Add(new SqlParameter("@Width", data.Width));
                dbCmd.Parameters.Add(new SqlParameter("@Height", data.Height));
                dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
                dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
                dbCmd.Parameters.Add(new SqlParameter("@ContentDetail", data.ContentDetail));
                dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
                dbCmd.Parameters.Add(new SqlParameter("@PageId", data.PageId));
                dbCmd.Parameters.Add(new SqlParameter("@Click", data.Click));
                dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
                dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
                dbCmd.ExecuteNonQuery();
            }  
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Advertise");
            return true;
        }
        #endregion
        #region [Advertise_Update]
        public bool Advertise_Update(Advertise data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_Update", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                dbCmd.Parameters.Add(new SqlParameter("@Name", data.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Image", data.Image));
                dbCmd.Parameters.Add(new SqlParameter("@ImageSmall", data.ImageSmall));
                dbCmd.Parameters.Add(new SqlParameter("@Summary", data.Summary));
                dbCmd.Parameters.Add(new SqlParameter("@Width", data.Width));
                dbCmd.Parameters.Add(new SqlParameter("@Height", data.Height));
                dbCmd.Parameters.Add(new SqlParameter("@Link", data.Link));
                dbCmd.Parameters.Add(new SqlParameter("@Target", data.Target));
                dbCmd.Parameters.Add(new SqlParameter("@ContentDetail", data.ContentDetail));
                dbCmd.Parameters.Add(new SqlParameter("@Position", data.Position));
                dbCmd.Parameters.Add(new SqlParameter("@PageId", data.PageId));
                dbCmd.Parameters.Add(new SqlParameter("@Click", data.Click));
                dbCmd.Parameters.Add(new SqlParameter("@Ord", data.Ord));
                dbCmd.Parameters.Add(new SqlParameter("@Active", data.Active));
                dbCmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
                dbCmd.ExecuteNonQuery();
            }
            
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Advertise");
            return true;
        }
        #endregion
        #region [Advertise_Delete]
        public bool Advertise_Delete(string Id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Advertise_Delete", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                dbCmd.ExecuteNonQuery();
            }

            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Advertise");
            return true;
        }
        #endregion
    }
}