using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace MyCms.Data
{
    public class ModDAO : SqlDataProvider
    {
        #region [Mod_GetByAll]
        public List<Mod> Mod_GetByAll( string Lang)
        {
            List<Data.Mod> list = new List<Mod>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Mod_GetByAll", GetConnection()))
            {
                Data.Mod obj = new Data.Mod();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Lang", Lang));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModIDataReader(dr));
                    }

                }
                dr.Close();
                obj = null;
            }
            return list;        
        }
        #endregion
        #region [Mod_GetByTop]
        public List<Mod> Mod_GetByTop (string Top, string Where, string Oder)
        {
            List<Data.Mod> list = new List<Mod>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Mod_GetByTop", GetConnection()))
            {
                Data.Mod obj = new Data.Mod();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Top", Top));
                dbCmd.Parameters.Add(new SqlParameter("@Where", Where));
                dbCmd.Parameters.Add(new SqlParameter("@Oder", Oder));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        list.Add(obj.ModIDataReader(dr));
                    }
                    dr.Close();
                    obj = null;
                }
                return list;
            }
        }
        #endregion
        #region[Mod_Insert]
        public bool Mod_Insert(Mod data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Mod_Insert", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Parent", data.Mod_Parent));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Name", data.Mod_Name));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Code", data.Mod_Code));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_ID", data.Modtype_ID));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Url", data.Mod_Url));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Img", data.Mod_Img));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Title", data.Mod_Title));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Key", data.Mod_Key));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Meta", data.Mod_Meta));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Content", data.Mod_Content));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Status", data.Mod_Status));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Hot", data.Mod_Hot));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Pos", data.Mod_Pos));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Level", data.Mod_Level));
                dbCmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_style", data.Mod_style));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Tag", data.Mod_Tag));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Intro", data.Mod_Intro));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Same", data.Mod_Same));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Mod");
            return true;
        }
        #endregion
        #region[Mod_Update]
        public bool Mod_Update(Mod data)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Mod_Update", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", data.Id));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Parent", data.Mod_Parent));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Name", data.Mod_Name));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Code", data.Mod_Code));
                dbCmd.Parameters.Add(new SqlParameter("@Modtype_ID", data.Modtype_ID));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Url", data.Mod_Url));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Img", data.Mod_Img));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Title", data.Mod_Title));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Key", data.Mod_Key));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Meta", data.Mod_Meta));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Content", data.Mod_Content));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Status", data.Mod_Status));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Hot", data.Mod_Hot));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Pos", data.Mod_Pos));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Level", data.Mod_Level));
                dbCmd.Parameters.Add(new SqlParameter("@Lang", data.Lang));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_style", data.Mod_style));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Tag", data.Mod_Tag));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Intro", data.Mod_Intro));
                dbCmd.Parameters.Add(new SqlParameter("@Mod_Same", data.Mod_Same));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Mod");
            return true;
        }
        #endregion
        #region[Mod_Delete]
        public bool Mod_Delete(string Id)
        {
            using (SqlCommand dbCmd = new SqlCommand("sp_Mod_Delete", GetConnection()))
            {
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@Id", Id));
                dbCmd.ExecuteNonQuery();
            }
            //Clear cache
            System.Web.HttpContext.Current.Cache.Remove("Mod");
            return true;
        }
        #endregion
        #region [Mod_GetByList]
        public List<Mod> Mod_GetByList(string ModId)
        {
            List<Data.Mod> list = new List<Data.Mod>();
            using (SqlCommand dbCmd = new SqlCommand("sp_Mod_Getlist", GetConnection()))
            {
                Data.Mod obj = new Data.Mod();
                dbCmd.CommandType = CommandType.StoredProcedure;
                dbCmd.Parameters.Add(new SqlParameter("@ModId", ModId));
                SqlDataReader dr = dbCmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        list.Add(obj.ModIDataReader(dr));
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