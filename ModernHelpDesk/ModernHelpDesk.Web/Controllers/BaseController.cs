using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using SimpleRestClient.Http;
using SimpleRestClient.Json;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Web.Models;

namespace ModernHelpDesk.Web.Controllers
{
    public class BaseController : Controller
    {
        protected static string UrlBase
        {
            get
            {
                return ConfigurationManager.AppSettings["urBase"].ToString();
            }
        }
        const int OK = 200;

        protected static List<DropDownListModel> GetDepartamentosDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var departamentos = client.Invoke<List<Departamentos>>(string.Format("/Utils/GetAllDepartamentos"), HttpMethod.GET);

            bool TheresData = ((int)client.Response.StatusCode) == OK;

            if (TheresData)
            {
                dropDown = departamentos.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1, "Seleccione un departamento"));
            }

            return dropDown;

        }

        protected static List<DropDownListModel> GetDivisionDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var division = client.Invoke<List<Division>>(string.Format("/Utils/GetAllDivisiones"), HttpMethod.GET);

            bool TheresData = ((int)client.Response.StatusCode) == OK;

            if (TheresData)
            {
                dropDown = division.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1, "Seleccione una División"));
            }

            return dropDown;
            {

            }

        }

        protected static List<DropDownListModel> GetEstatusDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var Estatus = client.Invoke<List<Estatus>>(string.Format("/Utils/GetAllEstatus"), HttpMethod.GET);
            bool TheresData = (int)client.Response.StatusCode == OK;

            if (TheresData)
            {
                dropDown = Estatus.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1, "Seleccione un Estatus"));
            }

            return dropDown;
        }

        public static List<DropDownListModel> GetGruposDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var Grupos = client.Invoke<List<Grupos>>(string.Format("/Utils/GetAllUserGroups"), HttpMethod.GET);
            bool TheresData = (int)client.Response.StatusCode == OK;

            if (TheresData)
            {
                dropDown = Grupos.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1, "Seleccione un Grupo"));
            }

            return dropDown;
        }

        public static List<DropDownListModel> GetIssuesDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var Issues = client.Invoke<List<Issues>>(string.Format("/Utils/GetAllIssues"), HttpMethod.GET);
            bool TheresData = (int)client.Response.StatusCode == OK;

            if (TheresData)
            {
                dropDown = Issues.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1, "Seleccione una Situación"));
            }

            return dropDown;
        }

        public static List<DropDownListModel> GetOrganizacionDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var organizaciones = client.Invoke<List<Organizacion>>("/Utils/GetAllOrganizaciones", HttpMethod.GET);
            bool TheresData = (int)client.Response.StatusCode == OK;

            if (TheresData)
            {
                dropDown = organizaciones.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1, "Selecione una Organización"));
            }

            return dropDown;
        }

        public static List<DropDownListModel> GetPrioridadDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var prioridades = client.Invoke<List<Prioridad>>("/Utils/GetAllPrioridades", HttpMethod.GET);
            bool TheresData = (int)client.Response.StatusCode == OK;

            if (TheresData)
            {
                dropDown = prioridades.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1, "Seleccione una prioridad"));
            }

            return dropDown;
        }

        public static List<DropDownListModel> GetUsuariosDropDown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);
            var usuarios = client.Invoke<List<Usuarios>>("/Usuarios/GetAllUsers",HttpMethod.GET);
            bool TheresData = (int)client.Response.StatusCode == OK;

            if (TheresData)
            {
                dropDown = usuarios.Select(x => new DropDownListModel(x.id, x.PrimerNombre + " " + x.PrimerApellido)).ToList();
                dropDown.Insert(0, new DropDownListModel(-1,"Seleccione un Usuario"));
            }

            return dropDown;
        }


    }
}
