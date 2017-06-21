using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeddingRegistry.Domain.Entities;

namespace WeddingRegistry.API.Controllers
{
    public class GeneralApiController : ApiController
    {
        //protected WeddingContext context;
        protected bool debugSource = false;
        protected string source = "";
        protected string connectionString = "";
        //protected string connectionStringNpgSql = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Wedding;Integrated Security=True";

        public GeneralApiController()
        {
            /*if(context == null)
                context = new WeddingContext();*/
            source = (debugSource) ? @"(localdb)\MSSQLLocalDB" : @".\SQLExpress";
            connectionString = @"Data Source=" + source + ";Initial Catalog=Wedding;Integrated Security=True";
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                /*if (context != null)
                    context.Dispose();*/

                //GC.SuppressFinalize(this);
            }
            base.Dispose(disposing);
        }
        
    }
}
