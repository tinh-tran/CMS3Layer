using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCms.Data;
using MyCms.Bus;

namespace Sweetsoft.Api.Controllers
{
    public class ModController : ApiController
    {
        [HttpGet]
        public List<Mod> Mod_Get(string Top, string Where, string Order)
        {
            try
            {
                List<Mod> list = new List<Mod>();
                list = ModBUS.Mod_GetByTop(Top, Where, Order);
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
