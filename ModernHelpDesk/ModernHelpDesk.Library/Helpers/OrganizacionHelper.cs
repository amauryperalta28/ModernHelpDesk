using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;

namespace ModernHelpDesk.Library.Helpers
{
    public static class OrganizacionHelper
    {
        public static Organizacion ToModel(this ORGANIZACION Table)
        {
            if (Table == null) return null;

            return new Organizacion() { 
                Id = Table.Id,
                Descripcion = Table.Descripcion
            };
        }

        public static ORGANIZACION ToTable(this Organizacion Model)
        {
            if (Model == null) return null;

            return new ORGANIZACION()
            {
                Id = Model.Id,
                Descripcion = Model.Descripcion
            };
        }

        public static List<Organizacion> ToModels(IEnumerable<ORGANIZACION> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Organizacion> GetAll()
        {
            List<Organizacion> result = new List<Organizacion>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.ORGANIZACION.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Organizacion>();

            }

            return result;
        }

        public static Organizacion GetOrganizacionByPrimaryKey(int id)
        {
            Organizacion result = new Organizacion();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.ORGANIZACION.SingleOrDefault(x => x.Id == id);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Organizacion Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.ORGANIZACION.Add(Model.ToTable());

                try
                {
                    context.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;

                }

            }

            return result;
        }
    }
}
