using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCms.Data;

namespace MyCms.Bus
{
    public class ImagesDetailBUS
    {
        private static ImagesDetailDAO db = new ImagesDetailDAO();
        #region [ImageDetail_GetById]
        public static List<Data.ImagesDetail> ImageDetail_GetById(string Id)
        {
            return db.ImageDetail_GetById(Id);
        }
        #endregion
        #region [ImageDetail_GetByAll]
        public static List<Data.ImagesDetail> ImageDetail_GetByAll()
        {
            return db.ImageDetail_GetByAll();
        }
        #endregion
        #region [ImagesDetail_GetByTop]
        public static List<Data.ImagesDetail> ImagesDetail_GetByTop(string Top, string Where, string Order)
        {
            return db.ImagesDetail_GetByTop(Top, Where, Order);
        }
        #endregion

        #region [ImagesDetail_Insert]
        public static bool ImagesDetail_Insert (Data.ImagesDetail obj)
        {
            return db.ImagesDetail_Insert(obj);
        }
        #endregion
        #region [ImagesDetail_Update]
        public static bool ImagesDetail_Update(Data.ImagesDetail obj)
        {
            return db.ImagesDetail_Update(obj);
        }
        #endregion
        #region [ImagesDetail_Delete]
        public static bool ImagesDetail_Delete(string Id)
        {
            return db.ImagesDetail_Delete(Id);
        }
        #endregion
    }
}