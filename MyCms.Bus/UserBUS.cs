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
        #region[User_Validate]
        /// <summary>
        /// Lấy thông tin mật khẩu vào username
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public static List<User> User_Validate(string UserName, string Password)
        {
            List<User> list = new List<User>();
            list = db.User_GetByAll();
            return list.FindAll(delegate (User obj)
            {
                return obj.Username == UserName && obj.Password == Password;
            });
        }
        #endregion
    }
}