using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HotelWebApplication.Controllers.api
{
    public class RoomController : ApiController
    {
        string connectionString = "Data Source=.;Initial Catalog=HotelDB;Integrated Security=True;Pooling=False;MultipleActiveResultSets=True;Application Name=EntityFramework";

        // GET: api/Room
        public IHttpActionResult Get()
        {
            List<>
        }

        // GET: api/Room/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Room
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
    }
}
