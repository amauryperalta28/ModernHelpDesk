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
        // GET api/tickets
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public List<Tickets> GetAll()
        {
            List<Tickets> Tickets = TicketsHelper.GetAll();
            bool TheresData = Tickets.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Tickets;
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
