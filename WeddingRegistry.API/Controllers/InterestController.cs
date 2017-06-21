using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeddingRegistry.Domain.Entities;

namespace WeddingRegistry.API.Controllers
{
    public class InterestController : GeneralApiController
    {
        
        // POST: api/Interest
        [HttpPost]
        public HttpResponseMessage Post(Interest model)
        {
            HttpResponseMessage response = null;

            if (model.Email == null || model.Email == "")
                return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Please provide us with an Email.");
            
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    var interest = conn.Query<Interest>("select * from Interests Where Email = @Email", new { Email = model.Email }).FirstOrDefault();

                    if (interest != null)
                    {
                        response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                        response.Content = new StringContent("We already have your Email on file.");
                        return response;
                    }
                    
                    var success = conn.Insert<Interest>(model);

                    return Request.CreateResponse<bool>(HttpStatusCode.OK, (success > 0) ? true : false);
                }
                catch (Exception ex)
                {
                    response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                    response.Content = new StringContent("Error submitting your Email");
                    return response;
                }
            }

            //return response;
        }

    }
}
