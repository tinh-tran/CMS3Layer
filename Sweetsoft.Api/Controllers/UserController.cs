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
        [HttpPost]
        public bool User_Insert (string Name, string UserName, string DateCreate, string Password, string Image,string Admin, string Role, string ModuleId, string ModuleName, string Active)
        {
            try
            {
                User obj = new User();
                obj.Name = Name;
                obj.Username = UserName;
                obj.DateCreate = DateCreate;
                obj.Password = Password;
                obj.Image = Image;
                obj.Admin = Admin;
                obj.Role = Role;
                obj.ModuleId = ModuleId;
                obj.ModuleName = ModuleName;
                obj.Active = Active;
                UserBUS.User_Insert(obj);
                return true;
            }
            catch
            {

            }
            return false;
          
        }
        [HttpPut]
        public bool User_Update(string Id, string Name, string UserName, string DateCreate, string Password, string Image, string Admin, string Role, string ModuleId, string ModuleName, string Active)
        {
            User obj = new User();
            obj.Id = Id;
            obj.Name = Name;
            obj.Username = UserName;
            obj.DateCreate = DateCreate;
            obj.Password = Password;
            obj.Image = Image;
            obj.Admin = Admin;
            obj.Role = Role;
            obj.ModuleId = ModuleId;
            obj.ModuleName = ModuleName;
            obj.Active = Active;
            UserBUS.User_Update(obj);
            return true;
        }
        [HttpDelete]
        public bool User_Delete (string Id)
        {
            UserBUS.User_Delete(Id);
            return true;
        }
    }
}
