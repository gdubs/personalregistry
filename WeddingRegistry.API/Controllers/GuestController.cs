using System;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WeddingRegistry.Domain.Entities;
using System.Data;

namespace WeddingRegistry.API.Controllers
{
    [EnableCors("*", "*", "GET,PUT,POST")]
    public class GuestController : GeneralApiController
    {
        public GuestController()
        {
        }

        public IEnumerable<Guest> GetAll()
        {
            var guests = new List<Guest>();
            using (IDbConnection conn = new SqlConnection(connectionString)){
                try
                {
                    guests = conn.Query<Guest>("select * from Guests").ToList();
                }
                catch(Exception ex)
                {
                    //reader.Close();
                }
            }

            return guests;
        }

        public string GetGuest(int id) {
            return "Bisyh";
        }

        [HttpPost]
        public HttpResponseMessage RSVP(Guest guest)
        {
            HttpResponseMessage response = null;
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    var model = conn.Query<Guest>("select * from Guests Where Id = @Id", new { Id = guest.Id }).FirstOrDefault();

                    if (model == null)
                    {
                        response = new HttpResponseMessage(HttpStatusCode.BadRequest);
                        response.Content = new StringContent("Guest not found!");
                        return response;
                    }

                    if (model.AdditionalGuest < guest.ConfirmedGuests)
                        return Request.CreateResponse<string>(HttpStatusCode.BadRequest, "Sorry, but you're limited to " + model.AdditionalGuest + " additional guests");

                    model.RSVPDate = DateTime.Now;
                    model.Note = (guest.Note != null) ? guest.Note : model.Note;
                    model.ConfirmedGuests = guest.ConfirmedGuests;
                    model.Attending = guest.Attending;

                    var success = conn.Update<Guest>(model);

                    response = Request.CreateResponse<bool>(HttpStatusCode.OK, success);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, new Exception("Error updating Guest."));
                }
            }

            return response;
        }


        public HttpResponseMessage GetByCode(string code)
        {
            HttpResponseMessage response = null;
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    var guest = conn.Query<Guest>("Select Id, FirstName, LastName, Code, AdditionalGuest, ConfirmedGuests, RSVPDate, AddressId, Attending from Guests Where Code = @Code", new { Code = code });

                    response = Request.CreateResponse<Guest>(HttpStatusCode.OK, guest.FirstOrDefault());
                }
                catch (Exception ex)
                {
                }
            }
            
            return response;
        }

        public HttpResponseMessage GetByName(string firstName, string lastName)
        {
            HttpResponseMessage response = null;
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    var encodeFirstName = firstName.ToLower() + "%";
                    var encodeLastName = lastName.ToLower() + "%";

                    var guest = conn.Query<Guest>("Select Id, FirstName, LastName, Code, AdditionalGuest, ConfirmedGuests, RSVPDate, AddressId, Attending from Guests Where lower(FirstName) like @FirstName and lower(LastName) like @LastName", 
                        new { FirstName = encodeFirstName, LastName = encodeLastName });

                    response = Request.CreateResponse<List<Guest>>(HttpStatusCode.OK, guest.ToList());
                }
                catch (Exception ex)
                {
                }
            }

            return response;
        }
    }
}
