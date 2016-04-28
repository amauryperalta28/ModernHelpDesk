using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModernHelpDesk.Library.Helpers;
using ModernHelpDesk.Common.Models;

namespace ModernHelpDesk.Service.Controllers
{
    public class TicketsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<Tickets> Tickets = TicketsHelper.GetAll();
            bool TheresData = Tickets.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return  Request.CreateResponse(HttpStatusCode.OK,Tickets);
        }

        [HttpGet]
        public HttpResponseMessage GetTicketsById(int id)
        {
            if (!TicketsHelper.Exists(id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Tickets ticket = TicketsHelper.GetTicketByPrimaryKey(id);

            return Request.CreateResponse(HttpStatusCode.OK, ticket); ;
        }

        [HttpPost]
        public HttpResponseMessage Save([FromBody] Tickets ticket)
        {
            bool SuccesfullSaved = TicketsHelper.Save(ticket);

            if (!SuccesfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // GET api/tickets/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/tickets
        public void Post([FromBody]string value)
        {
        }

        // PUT api/tickets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tickets/5
        public void Delete(int id)
        {
        }
    }
}
