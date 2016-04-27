using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModernHelpDesk.Common.Models;
using ModernHelpDesk.Entity;
namespace ModernHelpDesk.Library.Helpers
{
    public static class PrioridadHelper
    {
        public static Prioridad ToModel(this PRIORIDAD Table)
        {
            if (Table == null) return null;

            return new Prioridad()
            {
                Id = Table.Id,
                Descripcion = Table.Descripcion
            };
        }

        public static PRIORIDAD ToTable(this Prioridad Model)
        {
            if (Model == null) return null;

            return new PRIORIDAD()
            {
                Id = Model.Id,
                Descripcion = Model.Descripcion
            };
        }

        public static List<Prioridad> ToModels(IEnumerable<PRIORIDAD> Entities)
        {
            if (Entities == null) return null;

            return Entities.Select(x => x.ToModel()).ToList();
        }

        public static List<Prioridad> GetAll()
        {
            List<Prioridad> result = new List<Prioridad>();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.PRIORIDAD.ToList();
                result = queryResult.Count > 0 ? ToModels(queryResult) : new List<Prioridad>();

            }

            return result;
        }

        public static Prioridad GetPrioridadByPrimaryKey(int id)
        {
            Prioridad result = new Prioridad();

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                var queryResult = context.PRIORIDAD.SingleOrDefault(x => x.Id == id);

                if (queryResult != null)
                {
                    result = queryResult.ToModel();
                }
            }

            return result;
        }

        public static bool Save(Prioridad Model)
        {
            bool result = false;

            using (HelpDeskApfEntities context = new HelpDeskApfEntities())
            {
                context.PRIORIDAD.Add(Model.ToTable());

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
