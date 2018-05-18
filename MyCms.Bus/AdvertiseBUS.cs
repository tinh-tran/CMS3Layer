using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using MyCms.Data;

namespace MyCms.Bus
{
    public class AdvertiseBUS
    {
        private static AdvertiseDAO db = new AdvertiseDAO();

        #region [Advertise_GetByAll]
        public static List<Data.Advertise> Advertise_GetByAll(string Lang)
        {
            return db.Advertise_GetByAll(Lang);
        }
        #endregion
        #region [Advertise_GetByTop]
        public static List<Data.Advertise> Advertise_GetByTop(string Top, string Where, string Order)
        {
            return db.Advertise_GetByTop(Top,Where,Order);
        }
        #endregion
        #region [Advertise_GetByMod]
        public static List<Data.Advertise> Advertise_GetByMod(string Top, string Where, string Order)
        {
            return db.Advertise_GetByMod(Top, Where, Order);
        }
        #endregion
        #region [Advertise_GetByType]
        public static List<Data.Advertise> Advertise_GetByType(string Top, string Where, string Order)
        {
            return db.Advertise_GetByType(Top, Where, Order);
        }
        #endregion
        #region [Advertise_GetById]
        public static List<Data.Advertise> Advertise_GetById(string Id)
        {
            return db.Advertise_GetById(Id);
        }
        #endregion
        #region [Advertise_Insert]
        public static bool Advertise_Insert(Advertise data)
        {
            return db.Advertise_Insert(data);
        }
        #endregion
        #region [Advertise_Update]
        public static bool Advertise_Update(Advertise data)
        {
            return db.Advertise_Update(data);
        }
        #endregion
        #region [Advertise_Delete]
        public static bool Advertise_Delete(string Id)
        {
            return db.Advertise_Delete(Id);
        }
        #endregion

    }
}