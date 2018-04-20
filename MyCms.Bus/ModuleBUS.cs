using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCms.Data;

namespace MyCms.Bus
{
    public class ModuleBUS
    {
        private static ModuleDAO db = new ModuleDAO();

        #region [Module_GetByALl]
        public static List<Data.Module> Module_GetByAll()
        {
            return db.Module_GetByAll();
        }
        #endregion
        #region [Module_GetById]
        public static List<Data.Module> Module_GetById(string Id)
        {
            return db.Module_GetById(Id);
        }
        #endregion
        #region [Module_GetByTop]
        public static List<Data.Module> Module_GetByTop(string Top, string Where, string Order)
        {
            return db.Module_GetByTop(Top, Where, Order);
        }
        #endregion
        #region [Module_Insert]
        public static bool Module_Insert (Data.Module obj)
        {
            return db.Module_Insert(obj);
        }
        #endregion
        #region [Module_Update]
        public static bool Module_Update(Data.Module obj)
        {
            return db.Module_Update(obj);
        }
        #endregion
        #region [Module_Delete]
        public static bool Module_Delete(string Id)
        {
            return db.Module_Delete(Id);
        }
        #endregion

    }
}