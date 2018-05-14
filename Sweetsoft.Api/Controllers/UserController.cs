using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCms.Bus;
using MyCms.Data;

namespace Sweetsoft.Api.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet]
        public List<User> User_Get()
        {
            try
            {
                List<User> list = new List<User>();
                list = UserBUS.User_GetByAll();
                foreach (User us in list)
                {
                    us.Id = null;
                }
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [HttpGet]
        public List<User> User_GetById(string Id)
        {
            try
            {
                List<User> list = new List<User>();
                list = UserBUS.User_GetById(Id);
                foreach (User data in list)
                {
                    data.Id = null;
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
