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
        public HttpResponseMessage GetAllUsers()
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
        public HttpResponseMessage GetUserById(int Id)
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

        [HttpGet]
        public HttpResponseMessage GetAllUsersSeguidos()
        {
            List<User_Followed_User> Usuarios = UsuariosSeguidosHelper.GetAll();
            bool TheresData = Usuarios.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, Usuarios);
        }

        [HttpGet]
        public HttpResponseMessage GetUserFollowedById(int UserId)
        {
            if (!UsuariosSeguidosHelper.IsFollowingUsers(UserId))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            User_Followed_User usr = UsuariosSeguidosHelper.GetUserFollowedByPrimaryKey(UserId);

            return Request.CreateResponse(HttpStatusCode.OK, usr);
        }

        [HttpPost]
        public HttpResponseMessage Save(User_Followed_User usr)
        {
            bool SuccesfullSaved = UsuariosSeguidosHelper.Save(usr);

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
