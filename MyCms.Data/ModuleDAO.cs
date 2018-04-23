using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class ModuleDAO : SqlDataProvider
    {
        #region [Module_GetByAll]
        public List<Module> Module_GetByAll()
        {
            List<Data.Module> list = new List<Data.Module>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Module_GetByAll", GetConnection()))
            {
                Data.Module obj = new Data.Module();
                dbCmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModuleIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [Module_GetById]
        public List<Module> Module_GetById(string Id)
        {
            List<Data.Module> list = new List<Data.Module>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Module_GetById", GetConnection()))
            {
                Data.Module obj = new Data.Module();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModuleIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [Module_GetByTop]
        public List<Module> Module_GetByTop(string Top, string Where, string Order)
        {
            List<Data.Module> list = new List<Data.Module>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Module_GetByTop", GetConnection()))
            {
                Data.Module obj = new Data.Module();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Order", Order));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModuleIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;
        }
        #endregion
        #region [Module_Insert]
        public bool Module_Insert(Data.Module obj)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Module_Insert", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Name", obj.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Idcha", obj.Idcha));
                dbCmd.Parameters.Add(new SqlParameter("@Ord", obj.Ord));
                dbCmd.Parameters.Add(new SqlParameter("@Icon", obj.Icon));
                dbCmd.Parameters.Add(new SqlParameter("@Link", obj.Link));
                dbCmd.Parameters.Add(new SqlParameter("@Active", obj.Active));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }
        #endregion
        #region [Module_Update]
        public bool Module_Update(Data.Module obj)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Module_Update", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", obj.Id));
                dbCmd.Parameters.Add(new SqlParameter("@Name", obj.Name));
                dbCmd.Parameters.Add(new SqlParameter("@Idcha", obj.Idcha));
                dbCmd.Parameters.Add(new SqlParameter("@Ord", obj.Ord));
                dbCmd.Parameters.Add(new SqlParameter("@Icon", obj.Icon));
                dbCmd.Parameters.Add(new SqlParameter("@Link", obj.Link));
                dbCmd.Parameters.Add(new SqlParameter("@Active", obj.Active));
                dbCmd.ExecuteNonQuery();
            }
            System.Web.HttpContext.Current.Cache.Remove("Users"); // clear server cache 
            return true;
        }
        #endregion
        #region [Module_Delete]
        public bool Module_Delete (string Id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Module_Delete", GetConnection()))
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