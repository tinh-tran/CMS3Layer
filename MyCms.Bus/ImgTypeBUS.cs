using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCms.Data;

namespace MyCms.Bus
{
    public class ImgTypeBUS
    {
        private static ImgTypeDAO db = new ImgTypeDAO();

        #region [ImgType_GetByAll]
        public static List<Data.ImgType> ImgType_GetByAll()
        {
            return db.ImgType_GetByAll();
        }
        #endregion
        #region [ImgType_GetById]
        public static List<Data.ImgType> ImgType_GetById(string Id)
        {
            return db.ImgType_GetById(Id);
        }
        #endregion
        #region [ImgType_GetByAll]
        public static List<Data.ImgType> ImgType_GetByTop(string Top, string Where, string Oder)
        {
            return db.ImgType_GetByTop(Top, Where, Oder);
        }
        #endregion
        #region [ImgType_Insert]
        public static bool ImgType_Insert (Data.ImgType data)
        {
            return db.ImgType_Insert(data);
        }
        #endregion
        #region [ImgType_Update]
        public static bool ImgType_Update(Data.ImgType data)
        {
            return db.ImgType_Update(data);
        }
        #endregion
        #region [ImgType_Delete]
        public static bool ImgType_Delete(string Id)
        {
            return db.ImgType_Delete(Id);
        }
        #endregion
    }
}