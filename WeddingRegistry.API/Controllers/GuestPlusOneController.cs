using Dapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeddingRegistry.Domain.Entities;

namespace WeddingRegistry.API.Controllers
{
    public class GuestPlusOneController : GeneralApiController
    {
        public IEnumerable<Guest> GetAll()
        {
            return null;
        }

        public Guest Get()
        {
            return null;
        }

        [HttpPost]
        // POST: api/Default
        public HttpResponseMessage Post([FromBody]Guest value)
        {
            HttpResponseMessage response = null;

            if (value.ParentId == null)
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Parent needs to be assigned to this new plus one!");

            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    value.RSVPDate = DateTime.Now;

                    var inserted = conn.Insert(value);

                    response = Request.CreateResponse<long>(HttpStatusCode.OK, inserted);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception("Error updating Guest."));
                }
            }

            return response;
        }

        // PUT: api/Default/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Default/5
        public void Delete(int id)
        {
        }
    }
}
