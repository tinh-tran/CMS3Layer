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
            return db.ImagType_GetByAll();
        }
        #endregion
        #region [ImgType_GetById]
        public static List<Data.ImgType> ImgType_GetById(string Id)
        {
            return db.ImagType_GetById(Id);
        }
        #endregion
        #region [ImgType_GetByAll]
        public static List<Data.ImgType> ImgType_GetByTop(string Top, string Where, string Oder)
        {
            return db.ImgType_GetByTop(Top, Where, Oder);
        }
        #endregion
    }
}