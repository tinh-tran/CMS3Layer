using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MyCms.Data;

namespace MyCms.Bus
{
    public class ModBUS
    {
        private static Data.ModDAO db = new Data.ModDAO();
        #region [Mod_GetById]
        public static List<Data.Mod> Mod_GetById(string Id)
        {
            return db.Mod_GetById(Id);
        }
        #endregion
        #region[Mod_GetByTop]
        public static List<Data.Mod> Mod_GetByTop(string Top, string Where, string Order)
        {
            return db.Mod_GetByTop(Top, Where, Order);
        }
        #endregion
        #region[Mod_GetByType]
        public static List<Data.Mod> Mod_GetByType(string Top, string Where, string Order)
        {
            return db.Mod_GetByType(Top, Where, Order);
        }
        #endregion
        #region[Mod_GetByList]
        public static List<Data.Mod> Mod_GetByList(string ModId)
        {
            return db.Mod_GetByList(ModId);
        }
        #endregion
        #region[Mod_GetByAll]
        public static List<Data.Mod> Mod_GetByAll(string Lang)
        {
            return db.Mod_GetByAll(Lang);
        }
        #endregion
        #region[Mod_Insert]
        public static bool Mod_Insert(Mod data)
        {
            return db.Mod_Insert(data);
        }
        #endregion
        #region[Mod_Update]
        public static bool Mod_Update(Mod data)
        {
            return db.Mod_Update(data);
        }
        #endregion
        #region[Mod_Delete]
        public static bool Mod_Delete(string Id)
        {
            return db.Mod_Delete(Id);
        }
        #endregion
    }
}