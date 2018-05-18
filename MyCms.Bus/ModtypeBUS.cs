using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCms.Data;

namespace MyCms.Bus
{
    public class ModtypeBUS
    {
        private static Data.ModtypeDAO db = new Data.ModtypeDAO();
        #region[Modtype_GetById]
        public static List<Data.Modtype> Modtype_GetById(string Id)
        {
            return db.Modtype_GetById(Id);
        }
        #endregion
        #region[Modtype_GetByTop]
        public static List<Data.Modtype> Modtype_GetByTop(string Top, string Where, string Order)
        {
            return db.Modtype_GetByTop(Top, Where, Order);
        }
        #endregion
        #region[Modtype_GetByAll]
        public static List<Data.Modtype> Modtype_GetByAll()
        {
            return db.Modtype_GetByAll();
        }
        #endregion
        #region[Modtype_Insert]
        public static bool Modtype_Insert(Modtype data)
        {
            return db.Modtype_Insert(data);
        }
        #endregion
        #region[Modtype_Update]
        public static bool Modtype_Update(Modtype data)
        {
            return db.Modtype_Update(data);
        }
        #endregion
        #region[Modtype_Delete]
        public static bool Modtype_Delete(string Id)
        {
            return db.Modtype_Delete(Id);
        }
        #endregion
    }
}