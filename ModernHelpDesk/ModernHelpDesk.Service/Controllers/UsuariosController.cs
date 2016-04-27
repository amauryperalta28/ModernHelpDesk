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
    public class UsuariosController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            List<Usuarios> Usuarios = UsuariosHelper.GetAll();
            bool TheresData = Usuarios.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Usuarios);
        }

        [HttpGet]
        public HttpResponseMessage GetUsuarioById(int Id)
        {
            if (!UsuariosHelper.UserExist(Id))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Usuarios usr = UsuariosHelper.GetUsuarioByPrimaryKey(Id);

            return Request.CreateResponse(HttpStatusCode.OK, usr);
        }

        [HttpPost]
        public HttpResponseMessage Save(Usuarios usr)
        {
            bool SuccesfullSaved = UsuariosHelper.Save(usr);

            if (!SuccesfullSaved)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // GET api/usuarios/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT api/usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/usuarios/5
        public void Delete(int id)
        {
        }
    }
}
