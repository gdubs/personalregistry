using Dapper;
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
    public class EventController : GeneralApiController
    {
        // GET: api/Event/5
        public HttpResponseMessage Get()
        {

            HttpResponseMessage response = null;
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    var eventDetail = conn.Query<Event>("Select Name from Events Where Date = @Date", new { Date = Convert.ToDateTime("04/08/2017") });

                    response = Request.CreateResponse<string>(HttpStatusCode.OK, "Whuuuuttv " + eventDetail.First().Name);
                }catch(Exception ex)
                {
                    throw ex;
                }
            }

            return response;
        }
    }
}
