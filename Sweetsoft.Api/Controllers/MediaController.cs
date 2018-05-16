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
    public class MediaController : ApiController
    {
        [HttpGet]
        public List<Advertise> Advertise_Get(string Top,string Where,string Order)
        {
            try
            {
                List<Advertise> list = new List<Advertise>();
                list = AdvertiseBUS.Advertise_GetByTop(Top, Where, Order);
                return list;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
