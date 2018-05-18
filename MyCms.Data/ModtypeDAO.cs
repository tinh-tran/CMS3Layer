using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class ModtypeDAO : SqlDataProvider
    {

        #region [Modtype_GetByAll]
        public List<Modtype> Modtype_GetByAll()
        {
            List<Data.Modtype> list = new List<Modtype>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Modtype_GetByAll", GetConnection()))
            {
                Data.Modtype obj = new Data.Modtype();
                dbCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModtypeIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region[Modtype_GetByTop]
        public List<Modtype> Modtype_GetByTop(string Top, string Where, string Order)
        {
            List<Data.Modtype> list = new List<Data.Modtype>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Modtype_GetByTop", GetConnection()))
            {
                Data.Modtype obj = new Data.Modtype();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModtypeIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region[Modtype_GetById]
        public List<Modtype> Modtype_GetById(string Id)
        {
            List<Data.Modtype> list = new List<Data.Modtype>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Modtype_GetById", GetConnection()))
            {
                Data.Modtype obj = new Data.Modtype();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModtypeIDataReader(dr));
                    }

                    //conn.Close();
                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region[Modtype_Insert]
        public bool Modtype_Insert(Modtype data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Modtype_Insert", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Name", data.Modtype_Name));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Code", data.Modtype_Code));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Status", data.Modtype_Status));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Target", data.Modtype_Target));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Filter", data.Modtype_Filter));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Modtype");
            return true;
        }
        #endregion
        #region[Modtype_Update]
        public bool Modtype_Update(Modtype data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Modtype_Update", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Name", data.Modtype_Name));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Code", data.Modtype_Code));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Status", data.Modtype_Status));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Target", data.Modtype_Target));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_Filter", data.Modtype_Filter));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Modtype");
            return true;
        }
        #endregion
        #region[Modtype_Delete]
        public bool Modtype_Delete(string Id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Modtype_Delete", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Modtype");
            return true;
        }
        #endregion
    }
}