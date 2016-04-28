using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Library.Helpers;

namespace ModernHelpDesk.Service.Controllers
{
    public class UtilsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllDepartamentos()
        {
            List<Departamentos> list = DepartamentosHelper.GetAll();
            bool TheresData = list.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        public HttpResponseMessage SaveDepartamentos([FromBody] Departamentos Dep)
        {
            bool SuccessfullSaved = DepartamentosHelper.Save(Dep);

            if (!SuccessfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public HttpResponseMessage GetAllDivisiones()
        {
            List<Division> list = DivisionHelper.GetAll();
            bool TheresData = list.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        public HttpResponseMessage SaveDivision([FromBody] Division Dep)
        {
            bool SuccessfullSaved = DivisionHelper.Save(Dep);

            if (!SuccessfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public HttpResponseMessage GetAllEstatus()
        {
            List<Estatus> list = EstatusHelper.GetAll();
            bool TheresData = list.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        public HttpResponseMessage SaveEstatus([FromBody] Estatus Est)
        {
            bool SuccessfullSaved = EstatusHelper.Save(Est);

            if (!SuccessfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public HttpResponseMessage GetAllIssues()
        {
            List<Issues> list = IssuesHelper.GetAll();
            bool TheresData = list.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        public HttpResponseMessage SaveIssue([FromBody] Issues issue)
        {
            bool SuccessfullSaved = IssuesHelper.Save(issue);

            if (!SuccessfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public HttpResponseMessage GetAllOrganizaciones()
        {
            List<Organizacion> list = OrganizacionHelper.GetAll();
            bool TheresData = list.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        public HttpResponseMessage SaveOrganizacion([FromBody] Organizacion org)
        {
            bool SuccessfullSaved = OrganizacionHelper.Save(org);

            if (!SuccessfullSaved)
            {
                throw new HttpResponseException (HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
	{
		 
	}
        }

        [HttpGet]
        public HttpResponseMessage GetAllPrioridades()
        {
            List<Prioridad> list = PrioridadHelper.GetAll();
            bool TheresData = list.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        public HttpResponseMessage SavePrioridad([FromBody] Prioridad prioridad)
        {
            bool SuccesfullSaved = PrioridadHelper.Save(prioridad);

            if (!SuccesfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public HttpResponseMessage GetAllUserGroups()
        { 
            List<User_Groups> list = UserGroupHelper.GetAll();
            bool TheresData = list.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, list);
        }

        [HttpPost]
        public HttpResponseMessage SaveUserGroups([FromBody] User_Groups UserGroup)
        {
            bool SuccessfullSaved = UserGroupHelper.Save(UserGroup);

            if (!SuccessfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // GET api/utils/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/utils
        public void Post([FromBody]string value)
        {
        }

        // PUT api/utils/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/utils/5
        public void Delete(int id)
        {
        }
    }
}
