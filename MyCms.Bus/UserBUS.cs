using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyCms.Data;

namespace MyCms.Bus
{
    public class UserBUS
    {
        private static UserDAO db = new UserDAO();
        #region [User_GetByID]
        public static List<Data.User> User_GetById (string Id)
        {
            return db.User_GetById(Id);
        }
        #endregion
        #region[User_Validate]
        /// <summary>
        /// Lấy thông tin mật khẩu vào username
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static List<Data.User> User_Validate(string UserName, string Password)
        {
            List<User> list = new List<User>();
            list = db.User_GetByAll();
            return list.FindAll(delegate (User obj)
            {
                return obj.Username == UserName && obj.Password == Password;
            });
        }
        #endregion
        #region [User_GetByID]
        public static List<Data.User> User_GetByAll(string Id)
        {
            return db.User_GetById(Id);
        }
        #endregion
        #region [User_GetByAll]
        public static List<Data.User> User_GetByAll()
        {
            return db.User_GetByAll();
        }
        #endregion
        #region [User_Insert]
        public static bool User_Insert(Data.User data)
        {
            return db.User_Insert(data) ;
        }
        #endregion
        #region [User_Updatepass]
        public static bool User_UpdatePass(string id ,string password)
        {
            return db.User_UpdatePass(id, password);
        }
        #endregion
        #region [User_Update]
        public static bool User_Update(Data.User data)
        {
            return db.User_Update(data);
        }
        #endregion
        #region [User_Delete]
        public static bool User_Delete(string Id)
        {
            return db.User_Delete(Id);
        }
        #endregion
    }
}